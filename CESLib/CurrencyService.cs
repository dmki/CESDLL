using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CESLib.CESRef;

namespace CESLib
{
    public class CurrencyService
    {
        private string _apiKey;
        private const string serviceURL = "http://mondor.org/ces/rates.svc";//You can change this to SSL if needed
        public bool KeyValid { get; private set; }
        public KeyState KeyStatus { get; private set; }
        /// <summary>
        /// Class to access functions of Mondor Currency Rates Service at https://mondor.org
        /// </summary>
        /// <param name="apiKey">Your API key to access Mondor currency rates service</param>
        public CurrencyService(string apiKey)
        {
            KeyValid = true;
            KeyStatus = KeyState.Valid;
            if (apiKey.Length != 32)
            {
                KeyStatus = KeyState.Invalid;
                KeyValid = false;
                return;
            }
            //Remember this API key for future requests
            _apiKey = apiKey;

        }
        /// <summary>
        /// Convert particular currency. To get the rate, set amount to 1
        /// </summary>
        /// <param name="sourceCur">Currency you have</param>
        /// <param name="targetCur">Currency you want</param>
        /// <param name="amount">How much of source currency you want to convert to target</param>
        /// <returns></returns>
        public double Convert(string sourceCur, string targetCur, double amount)
        {
            if (KeyStatus == KeyState.Invalid) return 0;
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.Convert(sourceCur, targetCur, amount, _apiKey);
            }
        }

        public double ConvertByDate(string sourceCur, string targetCur, double amount, DateTime dateConversion)
        {
            if (KeyStatus == KeyState.Invalid) return 0;
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.ConvertByDate(sourceCur, targetCur, dateConversion, amount, _apiKey);
            }
        }

        public int CheckBalance()
        {
            if (KeyStatus == KeyState.Invalid) return 0;
            using (var cfFactory = GetChannel())
            {
                return cfFactory.CreateChannel().CheckBalance(_apiKey);
            }
        }

        public Currency[] GetCurrencies()
        {
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.GetCurrencyList();
            }
        }
        /// <summary>
        /// Return an array of currency codes (e.g. USD, EUR)
        /// </summary>
        /// <returns></returns>
        public string[] GetCurrencyCodes()
        {
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.GetCurrencyCodes();
                //svc.GetRatesMatrix();
                //svc.GetRetrospective();
                //svc.CheckExpirationDate();
            }
        }
        /// <summary>
        /// Return the list of currencies as Comma-Separated-Value file.
        /// You can save this data array to file to get .csv file
        /// </summary>
        /// <returns></returns>
        public byte[] GetCurrencyListCSV()
        {
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.GetCurrencyListCSV();
            }
        }
        /// <summary>
        /// Return the minimal date from which you can request historic conversions
        /// </summary>
        /// <returns></returns>
        public DateTime GetMinimalDate()
        {
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.GetMinimalDate();
            }
        }
        /// <summary>
        /// Get cross-rates for target currencies
        /// Try to keep the list to a minimum
        /// </summary>
        /// <param name="currencies">Comma-separated list of target currency codes</param>
        /// <returns></returns>
        public string GetRatesMatrix(string currencies)
        {
            if (KeyStatus == KeyState.Invalid) return "";
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                return svc.GetRatesMatrix(_apiKey, currencies);
            }
        }
        /// <summary>
        /// Return rates between 2 currencies for specific number of days, since today
        /// </summary>
        /// <param name="currencyFrom"></param>
        /// <param name="currenciesTo"></param>
        /// <param name="days"></param>
        /// <returns>XML document as one string</returns>
        public string GetRetrospective(string currencyFrom, string currenciesTo, int days)
        {
            if (KeyStatus == KeyState.Invalid) return null;
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                var data = svc.GetRetrospective(_apiKey, currencyFrom, currenciesTo, days);
                if (data.Length == 0) return null;
                byte[] step = new byte[256];
                //This is compressed string, we need to decompress it to get XML
                MemoryStream outStream = new MemoryStream();
                using (var output = new MemoryStream(data))
                {
                    using (var gzip = new GZipStream(output, CompressionMode.Decompress))
                    {
                        int rCount;
                        do
                        {
                            rCount = gzip.Read(step, 0, step.Length);
                            outStream.Write(step,0, rCount);
                        } while (rCount > 0);
                        //outBytes = new byte[data.Length];
                        //gzip.Read(outBytes, 0, data.Length);
                    }
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    return encoding.GetString(outStream.ToArray());
                }
            }
        }

        public void UpdateKeyStatus()
        {
            if (_apiKey.Length != 32)
            {
                KeyStatus = KeyState.Invalid;
                KeyValid = false;
                return;
            }

            KeyStatus = KeyState.Valid;
            using (var cfFactory = GetChannel())
            {
                var svc = cfFactory.CreateChannel();
                var expSoon = DateTime.Now.AddDays(14);
                var expDate = svc.CheckExpirationDate(_apiKey);
                if (expDate > DateTime.MinValue && expDate < expSoon)
                {
                    KeyStatus = KeyState.ExpiringSoon;
                    if (expDate < DateTime.Now)
                    {
                        KeyStatus = KeyState.Expired;
                        KeyValid = false;
                        return;
                    }
                }

                var balanceLeft = svc.CheckBalance(_apiKey);
                if (balanceLeft == 5 && expDate.Year == 1)
                {
                    KeyValid = true;
                    KeyStatus = KeyState.Valid;
                    return;
                }

                if (balanceLeft < 1)
                {
                    KeyStatus = KeyState.Depleted;
                    KeyValid = false;
                    return;
                }

                if (balanceLeft < 100)
                {
                    KeyStatus = KeyState.NearlyDepleted;
                }
            }
            KeyValid = true;
        }


        private ChannelFactory<iRates> GetChannel()
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(serviceURL);
            var myChannelFactory = new ChannelFactory<iRates>(binding, endpoint);
            return myChannelFactory;
            //return myChannelFactory.CreateChannel();
        }
    }

    public enum KeyState
    {
        Invalid = 0,
        Valid = 1,
        ExpiringSoon,
        NearlyDepleted,
        Expired,
        Depleted
    }
}

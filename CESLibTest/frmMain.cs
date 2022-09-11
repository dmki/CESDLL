using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CESLib;

namespace CESLibTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdGetCurList_Click(object sender, EventArgs e)
        {
            if (!IsKeyValid()) return;

            var ces = new CESLib.CurrencyService(txtAPIKey.Text);
            if (!ces.KeyValid)
            {
                MessageBox.Show("Service response: key is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            txtResult.Text = string.Join(Environment.NewLine, ces.GetCurrencyCodes());
        }

        private void cmdTestRetro_Click(object sender, EventArgs e)
        {
            if (!IsKeyValid()) return;
            var ces = new CESLib.CurrencyService(txtAPIKey.Text);
            txtResult.Text = ces.GetRetrospective("USD", "GBP", 14);

        }

        private bool IsKeyValid()
        {
            if (txtAPIKey.Text.Trim().Length != 32)
            {
                MessageBox.Show("Invalid API key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void cmdTestMatrix_Click(object sender, EventArgs e)
        {
            if (!IsKeyValid()) return;
            var ces = new CESLib.CurrencyService(txtAPIKey.Text);
            txtResult.Text = ces.GetRatesMatrix("USD,GBP,AUD,CHF");
        }

        private void cmdTestConvertDate_Click(object sender, EventArgs e)
        {
            if (!IsKeyValid()) return;
            DateTime dtConvert = DateTime.Now.AddDays(-3);
            txtResult.Text = $"Converting USD to GBP, date: {dtConvert.ToString("D")}{Environment.NewLine}";
            var ces = new CESLib.CurrencyService(txtAPIKey.Text);
            txtResult.Text += ces.ConvertByDate("USD", "GBP", 1, dtConvert);
        }

        private void cmdConvert_Click(object sender, EventArgs e)
        {
            if (!IsKeyValid()) return;
            var ces = new CESLib.CurrencyService(txtAPIKey.Text);
            txtResult.Text = "1 USD is GBP " + ces.Convert("USD", "GBP", 1);
        }

        private void lblNewKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open web page
            System.Diagnostics.Process.Start("https://mondor.org/default.aspx#Pricing");
        }
    }
}


namespace CESLibTest
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.lblNewKey = new System.Windows.Forms.LinkLabel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGetCurList = new System.Windows.Forms.Button();
            this.cmdTestRetro = new System.Windows.Forms.Button();
            this.cmdTestMatrix = new System.Windows.Forms.Button();
            this.cmdTestConvertDate = new System.Windows.Forms.Button();
            this.cmdConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Key:";
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Location = new System.Drawing.Point(85, 6);
            this.txtAPIKey.MaxLength = 32;
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(382, 25);
            this.txtAPIKey.TabIndex = 1;
            this.txtAPIKey.Text = "4fc1b76b14dd4ebab8c563ced8887544";
            // 
            // lblNewKey
            // 
            this.lblNewKey.AutoSize = true;
            this.lblNewKey.Location = new System.Drawing.Point(505, 14);
            this.lblNewKey.Name = "lblNewKey";
            this.lblNewKey.Size = new System.Drawing.Size(127, 17);
            this.lblNewKey.TabIndex = 2;
            this.lblNewKey.TabStop = true;
            this.lblNewKey.Text = "Request new API key";
            this.lblNewKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewKey_LinkClicked);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 172);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(658, 158);
            this.txtResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "RESULT:";
            // 
            // cmdGetCurList
            // 
            this.cmdGetCurList.Location = new System.Drawing.Point(12, 58);
            this.cmdGetCurList.Name = "cmdGetCurList";
            this.cmdGetCurList.Size = new System.Drawing.Size(156, 37);
            this.cmdGetCurList.TabIndex = 5;
            this.cmdGetCurList.Text = "Get list of currencies";
            this.cmdGetCurList.UseVisualStyleBackColor = true;
            this.cmdGetCurList.Click += new System.EventHandler(this.cmdGetCurList_Click);
            // 
            // cmdTestRetro
            // 
            this.cmdTestRetro.Location = new System.Drawing.Point(12, 101);
            this.cmdTestRetro.Name = "cmdTestRetro";
            this.cmdTestRetro.Size = new System.Drawing.Size(156, 37);
            this.cmdTestRetro.TabIndex = 6;
            this.cmdTestRetro.Text = "Get Retrospective";
            this.cmdTestRetro.UseVisualStyleBackColor = true;
            this.cmdTestRetro.Click += new System.EventHandler(this.cmdTestRetro_Click);
            // 
            // cmdTestMatrix
            // 
            this.cmdTestMatrix.Location = new System.Drawing.Point(174, 58);
            this.cmdTestMatrix.Name = "cmdTestMatrix";
            this.cmdTestMatrix.Size = new System.Drawing.Size(156, 37);
            this.cmdTestMatrix.TabIndex = 7;
            this.cmdTestMatrix.Text = "Get Matrix";
            this.cmdTestMatrix.UseVisualStyleBackColor = true;
            this.cmdTestMatrix.Click += new System.EventHandler(this.cmdTestMatrix_Click);
            // 
            // cmdTestConvertDate
            // 
            this.cmdTestConvertDate.Location = new System.Drawing.Point(174, 101);
            this.cmdTestConvertDate.Name = "cmdTestConvertDate";
            this.cmdTestConvertDate.Size = new System.Drawing.Size(156, 37);
            this.cmdTestConvertDate.TabIndex = 8;
            this.cmdTestConvertDate.Text = "Convert by date";
            this.cmdTestConvertDate.UseVisualStyleBackColor = true;
            this.cmdTestConvertDate.Click += new System.EventHandler(this.cmdTestConvertDate_Click);
            // 
            // cmdConvert
            // 
            this.cmdConvert.Location = new System.Drawing.Point(336, 101);
            this.cmdConvert.Name = "cmdConvert";
            this.cmdConvert.Size = new System.Drawing.Size(156, 37);
            this.cmdConvert.TabIndex = 9;
            this.cmdConvert.Text = "Simple conversion";
            this.cmdConvert.UseVisualStyleBackColor = true;
            this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 339);
            this.Controls.Add(this.cmdConvert);
            this.Controls.Add(this.cmdTestConvertDate);
            this.Controls.Add(this.cmdTestMatrix);
            this.Controls.Add(this.cmdTestRetro);
            this.Controls.Add(this.cmdGetCurList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblNewKey);
            this.Controls.Add(this.txtAPIKey);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "Test CES Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.LinkLabel lblNewKey;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdGetCurList;
        private System.Windows.Forms.Button cmdTestRetro;
        private System.Windows.Forms.Button cmdTestMatrix;
        private System.Windows.Forms.Button cmdTestConvertDate;
        private System.Windows.Forms.Button cmdConvert;
    }
}


namespace DLVD_Project.Driving_License
{
    partial class frmIssueDrivingLicense
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
            this.uC_DrivingLicenseAppInfo1 = new DLVD_Project.ApplicationUC.UC_DrivingLicenseAppInfo();
            this.uC_ApplicatoinBasicInfo1 = new DLVD_Project.ApplicationUC.UC_ApplicatoinBasicInfo();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uC_DrivingLicenseAppInfo1
            // 
            this.uC_DrivingLicenseAppInfo1.Location = new System.Drawing.Point(115, 12);
            this.uC_DrivingLicenseAppInfo1.Name = "uC_DrivingLicenseAppInfo1";
            this.uC_DrivingLicenseAppInfo1.Size = new System.Drawing.Size(833, 153);
            this.uC_DrivingLicenseAppInfo1.TabIndex = 0;
            // 
            // uC_ApplicatoinBasicInfo1
            // 
            this.uC_ApplicatoinBasicInfo1.Location = new System.Drawing.Point(115, 152);
            this.uC_ApplicatoinBasicInfo1.Name = "uC_ApplicatoinBasicInfo1";
            this.uC_ApplicatoinBasicInfo1.Size = new System.Drawing.Size(802, 312);
            this.uC_ApplicatoinBasicInfo1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 35;
            this.label5.Text = "Notes :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 470);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(591, 88);
            this.textBox1.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(801, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 44);
            this.button1.TabIndex = 37;
            this.button1.Text = "Issue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.uC_ApplicatoinBasicInfo1);
            this.Controls.Add(this.uC_DrivingLicenseAppInfo1);
            this.Name = "frmIssueDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIssueDrivingLicense";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationUC.UC_DrivingLicenseAppInfo uC_DrivingLicenseAppInfo1;
        private ApplicationUC.UC_ApplicatoinBasicInfo uC_ApplicatoinBasicInfo1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}
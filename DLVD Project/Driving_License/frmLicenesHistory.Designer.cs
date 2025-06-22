namespace DLVD_Project.Driving_License
{
    partial class frmLicenesHistory
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
            this.uC_ShowPersonDetails1 = new DLVD_Project.PersonUC.UC_ShowPersonDetails();
            this.uC_LicenseHist1 = new DLVD_Project.ApplicationUC.UC_LicenseHist();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(395, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 49);
            this.label1.TabIndex = 30;
            this.label1.Text = "License History";
            // 
            // uC_ShowPersonDetails1
            // 
            this.uC_ShowPersonDetails1.Location = new System.Drawing.Point(22, 128);
            this.uC_ShowPersonDetails1.Name = "uC_ShowPersonDetails1";
            this.uC_ShowPersonDetails1.Size = new System.Drawing.Size(1133, 366);
            this.uC_ShowPersonDetails1.TabIndex = 1;
            // 
            // uC_LicenseHist1
            // 
            this.uC_LicenseHist1.Location = new System.Drawing.Point(87, 482);
            this.uC_LicenseHist1.Name = "uC_LicenseHist1";
            this.uC_LicenseHist1.Size = new System.Drawing.Size(993, 269);
            this.uC_LicenseHist1.TabIndex = 0;
            // 
            // frmLicenesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 763);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_ShowPersonDetails1);
            this.Controls.Add(this.uC_LicenseHist1);
            this.Name = "frmLicenesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLicenesHistory";
            this.Load += new System.EventHandler(this.frmLicenesHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationUC.UC_LicenseHist uC_LicenseHist1;
        private PersonUC.UC_ShowPersonDetails uC_ShowPersonDetails1;
        private System.Windows.Forms.Label label1;
    }
}
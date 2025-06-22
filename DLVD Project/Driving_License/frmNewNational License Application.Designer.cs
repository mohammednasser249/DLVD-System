namespace DLVD_Project.Driving_License
{
    partial class frmNewNational_License_Application
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
            this.uC_InternatinalLicneseApplicationInfo1 = new DLVD_Project.ApplicationUC.UC_InternatinalLicneseApplicationInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(194, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "International License Application";
            // 
            // uC_InternatinalLicneseApplicationInfo1
            // 
            this.uC_InternatinalLicneseApplicationInfo1.Location = new System.Drawing.Point(34, 64);
            this.uC_InternatinalLicneseApplicationInfo1.Name = "uC_InternatinalLicneseApplicationInfo1";
            this.uC_InternatinalLicneseApplicationInfo1.Size = new System.Drawing.Size(928, 689);
            this.uC_InternatinalLicneseApplicationInfo1.TabIndex = 5;
            // 
            // frmNewNational_License_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(948, 762);
            this.Controls.Add(this.uC_InternatinalLicneseApplicationInfo1);
            this.Controls.Add(this.label1);
            this.Name = "frmNewNational_License_Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewNational_License_Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ApplicationUC.UC_InternatinalLicneseApplicationInfo uC_InternatinalLicneseApplicationInfo1;
    }
}
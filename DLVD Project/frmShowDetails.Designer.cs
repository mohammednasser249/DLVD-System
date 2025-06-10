namespace DLVD_Project
{
    partial class frmShowDetails
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
            this.uC_ShowPersonDetails1 = new DLVD_Project.PersonUC.UC_ShowPersonDetails();
            this.SuspendLayout();
            // 
            // uC_ShowPersonDetails1
            // 
            this.uC_ShowPersonDetails1.Location = new System.Drawing.Point(49, 12);
            this.uC_ShowPersonDetails1.Name = "uC_ShowPersonDetails1";
            this.uC_ShowPersonDetails1.Size = new System.Drawing.Size(1111, 524);
            this.uC_ShowPersonDetails1.TabIndex = 0;
            this.uC_ShowPersonDetails1.Load += new System.EventHandler(this.uC_ShowPersonDetails1_Load);
            // 
            // frmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 548);
            this.Controls.Add(this.uC_ShowPersonDetails1);
            this.Name = "frmShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowDetails";
            this.Load += new System.EventHandler(this.frmShowDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonUC.UC_ShowPersonDetails uC_ShowPersonDetails1;
    }
}
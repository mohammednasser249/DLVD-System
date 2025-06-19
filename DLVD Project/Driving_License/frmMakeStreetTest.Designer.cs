namespace DLVD_Project.Driving_License
{
    partial class frmMakeStreetTest
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
            this.uC_StreetTest1 = new DLVD_Project.ApplicationUC.UC_StreetTest();
            this.SuspendLayout();
            // 
            // uC_StreetTest1
            // 
            this.uC_StreetTest1.BackColor = System.Drawing.Color.White;
            this.uC_StreetTest1.Location = new System.Drawing.Point(13, -1);
            this.uC_StreetTest1.Name = "uC_StreetTest1";
            this.uC_StreetTest1.Size = new System.Drawing.Size(516, 682);
            this.uC_StreetTest1.TabIndex = 0;
            // 
            // frmMakeStreetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 693);
            this.Controls.Add(this.uC_StreetTest1);
            this.Name = "frmMakeStreetTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMakeStreetTest";
            this.Load += new System.EventHandler(this.frmMakeStreetTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ApplicationUC.UC_StreetTest uC_StreetTest1;
    }
}
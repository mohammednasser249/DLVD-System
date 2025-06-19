namespace DLVD_Project.Driving_License
{
    partial class frmMakeAVisionTests
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
            this.components = new System.ComponentModel.Container();
            this.uC_VisoinTest1 = new DLVD_Project.ApplicationUC.UC_VisoinTest();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.SuspendLayout();
            // 
            // uC_VisoinTest1
            // 
            this.uC_VisoinTest1.BackColor = System.Drawing.Color.White;
            this.uC_VisoinTest1.Location = new System.Drawing.Point(-2, 10);
            this.uC_VisoinTest1.Name = "uC_VisoinTest1";
            this.uC_VisoinTest1.Size = new System.Drawing.Size(538, 671);
            this.uC_VisoinTest1.TabIndex = 0;
            // 
            // frmMakeAVisionTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 693);
            this.Controls.Add(this.uC_VisoinTest1);
            this.Name = "frmMakeAVisionTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMakeAVisionTests";
            this.Load += new System.EventHandler(this.frmMakeAVisionTests_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ApplicationUC.UC_VisoinTest uC_VisoinTest1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}
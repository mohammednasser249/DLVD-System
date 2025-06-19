namespace DLVD_Project.Driving_License
{
    partial class frmTakeTest
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
            this.uC_TakeTest1 = new DLVD_Project.ApplicationUC.UC_TakeTest();
            this.SuspendLayout();
            // 
            // uC_TakeTest1
            // 
            this.uC_TakeTest1.BackColor = System.Drawing.Color.White;
            this.uC_TakeTest1.Location = new System.Drawing.Point(-2, 2);
            this.uC_TakeTest1.Name = "uC_TakeTest1";
            this.uC_TakeTest1.Size = new System.Drawing.Size(524, 716);
            this.uC_TakeTest1.TabIndex = 0;
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 714);
            this.Controls.Add(this.uC_TakeTest1);
            this.Name = "frmTakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTakeTest";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ApplicationUC.UC_TakeTest uC_TakeTest1;
    }
}
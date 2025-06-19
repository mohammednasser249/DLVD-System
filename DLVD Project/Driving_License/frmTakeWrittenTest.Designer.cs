namespace DLVD_Project.Driving_License
{
    partial class frmTakeWrittenTest
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
            this.uC_TakeWrittenTest1 = new DLVD_Project.ApplicationUC.UC_TakeWrittenTest();
            this.SuspendLayout();
            // 
            // uC_TakeWrittenTest1
            // 
            this.uC_TakeWrittenTest1.BackColor = System.Drawing.Color.White;
            this.uC_TakeWrittenTest1.Location = new System.Drawing.Point(-3, 0);
            this.uC_TakeWrittenTest1.Name = "uC_TakeWrittenTest1";
            this.uC_TakeWrittenTest1.Size = new System.Drawing.Size(524, 716);
            this.uC_TakeWrittenTest1.TabIndex = 0;
            // 
            // frmTakeWrittenTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 714);
            this.Controls.Add(this.uC_TakeWrittenTest1);
            this.Name = "frmTakeWrittenTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTakeWrittenTest";
            this.Load += new System.EventHandler(this.frmTakeWrittenTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ApplicationUC.UC_TakeWrittenTest uC_TakeWrittenTest1;
    }
}
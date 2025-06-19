namespace DLVD_Project.Driving_License
{
    partial class frmTakeStreetTest
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
            this.uC_TakeStreetTest1 = new DLVD_Project.ApplicationUC.UC_TakeStreetTest();
            this.SuspendLayout();
            // 
            // uC_TakeStreetTest1
            // 
            this.uC_TakeStreetTest1.BackColor = System.Drawing.Color.White;
            this.uC_TakeStreetTest1.Location = new System.Drawing.Point(0, -3);
            this.uC_TakeStreetTest1.Name = "uC_TakeStreetTest1";
            this.uC_TakeStreetTest1.Size = new System.Drawing.Size(524, 716);
            this.uC_TakeStreetTest1.TabIndex = 0;
            // 
            // frmTakeStreetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 714);
            this.Controls.Add(this.uC_TakeStreetTest1);
            this.Name = "frmTakeStreetTest";
            this.Text = "frmTakeStreetTest";
            this.Load += new System.EventHandler(this.frmTakeStreetTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ApplicationUC.UC_TakeStreetTest uC_TakeStreetTest1;
    }
}
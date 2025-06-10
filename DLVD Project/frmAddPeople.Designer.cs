namespace DLVD_Project
{
    partial class frmAddPeople
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
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.uC_AddPeople1 = new DLVD_Project.PersonUC.UC_AddPeople();
            this.SuspendLayout();
            // 
            // uC_AddPeople1
            // 
            this.uC_AddPeople1.Location = new System.Drawing.Point(16, 20);
            this.uC_AddPeople1.Name = "uC_AddPeople1";
            this.uC_AddPeople1.Size = new System.Drawing.Size(1115, 515);
            this.uC_AddPeople1.TabIndex = 0;
            // 
            // frmAddPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 546);
            this.Controls.Add(this.uC_AddPeople1);
            this.Name = "frmAddPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddPeople";
            this.Load += new System.EventHandler(this.frmAddPeople_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonUC.UC_AddPeople uC_AddPeople1; // add this at the bottom

        #endregion
    }
}
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
        private void InitializeComponent()
        {
            int someID = -1;
            this.uC_AddPeople1 = new DLVD_Project.PersonUC.UC_AddPeople(someID);
            this.SuspendLayout();
            // 
            // uC_AddPeople1
            // 
            this.uC_AddPeople1.Location = new System.Drawing.Point(22, 12);
            this.uC_AddPeople1.Name = "uC_AddPeople1";
            this.uC_AddPeople1.Size = new System.Drawing.Size(1097, 532);
            this.uC_AddPeople1.TabIndex = 0;
           // this.uC_AddPeople1.Load += new System.EventHandler(this.uC_AddPeople1_Load_1);
            // 
            // frmAddPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 556);
            this.Controls.Add(this.uC_AddPeople1);
            this.Name = "frmAddPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddPeople";
            this.Load += new System.EventHandler(this.frmAddPeople_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonUC.UC_AddPeople uC_AddPeople1;
    }
}
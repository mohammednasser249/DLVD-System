namespace DLVD_Project.UserForms
{
    partial class frmCurrentUserInfoForm
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
            this.ucLoginCurrentUserInfo1 = new DLVD_Project.UserUC.UCLoginCurrentUserInfo();
            this.uC_ShowPersonDetails1 = new DLVD_Project.PersonUC.UC_ShowPersonDetails();
            this.SuspendLayout();
            // 
            // ucLoginCurrentUserInfo1
            // 
            this.ucLoginCurrentUserInfo1.Location = new System.Drawing.Point(183, 406);
            this.ucLoginCurrentUserInfo1.Name = "ucLoginCurrentUserInfo1";
            this.ucLoginCurrentUserInfo1.Size = new System.Drawing.Size(800, 99);
            this.ucLoginCurrentUserInfo1.TabIndex = 1;
            // 
            // uC_ShowPersonDetails1
            // 
            this.uC_ShowPersonDetails1.Location = new System.Drawing.Point(12, 30);
            this.uC_ShowPersonDetails1.Name = "uC_ShowPersonDetails1";
            this.uC_ShowPersonDetails1.Size = new System.Drawing.Size(1133, 366);
            this.uC_ShowPersonDetails1.TabIndex = 0;
            // 
            // frmCurrentUserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 543);
            this.Controls.Add(this.ucLoginCurrentUserInfo1);
            this.Controls.Add(this.uC_ShowPersonDetails1);
            this.Name = "frmCurrentUserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCurrentUserInfoForm";
            this.Load += new System.EventHandler(this.frmCurrentUserInfoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonUC.UC_ShowPersonDetails uC_ShowPersonDetails1;
        private UserUC.UCLoginCurrentUserInfo ucLoginCurrentUserInfo1;
    }
}
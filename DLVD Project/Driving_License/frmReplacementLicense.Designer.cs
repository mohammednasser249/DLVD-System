namespace DLVD_Project.Driving_License
{
    partial class frmReplacementLicense
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
            this.uC_Replacement1 = new DLVD_Project.ApplicationUC.UC_Replacement();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uC_Replacement1
            // 
            this.uC_Replacement1.Location = new System.Drawing.Point(4, 76);
            this.uC_Replacement1.Name = "uC_Replacement1";
            this.uC_Replacement1.Size = new System.Drawing.Size(954, 626);
            this.uC_Replacement1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(103, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(771, 49);
            this.label1.TabIndex = 10;
            this.label1.Text = "Replacement For Damaged License";
            // 
            // frmReplacementLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 695);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_Replacement1);
            this.Name = "frmReplacementLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReplacementLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationUC.UC_Replacement uC_Replacement1;
        private System.Windows.Forms.Label label1;
    }
}
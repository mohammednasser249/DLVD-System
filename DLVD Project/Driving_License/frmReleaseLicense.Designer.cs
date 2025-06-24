namespace DLVD_Project.Driving_License
{
    partial class frmReleaseLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.uC_ReleaseLiecense1 = new DLVD_Project.ApplicationUC.UC_ReleaseLiecense();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(257, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Release Detained License";
            // 
            // uC_ReleaseLiecense1
            // 
            this.uC_ReleaseLiecense1.Location = new System.Drawing.Point(12, 105);
            this.uC_ReleaseLiecense1.Name = "uC_ReleaseLiecense1";
            this.uC_ReleaseLiecense1.Size = new System.Drawing.Size(962, 645);
            this.uC_ReleaseLiecense1.TabIndex = 0;
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 734);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_ReleaseLiecense1);
            this.Name = "frmReleaseLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReleaseLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationUC.UC_ReleaseLiecense uC_ReleaseLiecense1;
        private System.Windows.Forms.Label label1;
    }
}
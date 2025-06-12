namespace DLVD_Project
{
    partial class frmShowDetails
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
            this.uC_ShowPersonDetails1 = new DLVD_Project.PersonUC.UC_ShowPersonDetails();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(446, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Person Details";
            // 
            // uC_ShowPersonDetails1
            // 
            this.uC_ShowPersonDetails1.Location = new System.Drawing.Point(26, 92);
            this.uC_ShowPersonDetails1.Name = "uC_ShowPersonDetails1";
            this.uC_ShowPersonDetails1.Size = new System.Drawing.Size(1145, 479);
            this.uC_ShowPersonDetails1.TabIndex = 0;
            this.uC_ShowPersonDetails1.Load += new System.EventHandler(this.uC_ShowPersonDetails1_Load);
            // 
            // frmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_ShowPersonDetails1);
            this.Name = "frmShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowDetails";
            this.Load += new System.EventHandler(this.frmShowDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonUC.UC_ShowPersonDetails uC_ShowPersonDetails1;
        private System.Windows.Forms.Label label1;
    }
}
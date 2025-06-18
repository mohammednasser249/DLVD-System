namespace DLVD_Project.ApplicationUC
{
    partial class UC_DrivingLicenseAppInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbApplicatoinId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbClass = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPassedTests = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPassedTests);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbClass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbApplicatoinId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving License Application Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "D L.Application ID :";
            // 
            // lbApplicatoinId
            // 
            this.lbApplicatoinId.AutoSize = true;
            this.lbApplicatoinId.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicatoinId.Location = new System.Drawing.Point(199, 46);
            this.lbApplicatoinId.Name = "lbApplicatoinId";
            this.lbApplicatoinId.Size = new System.Drawing.Size(42, 18);
            this.lbApplicatoinId.TabIndex = 22;
            this.lbApplicatoinId.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 19);
            this.label1.TabIndex = 23;
            this.label1.Text = "Applied For License :";
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClass.Location = new System.Drawing.Point(489, 46);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(42, 18);
            this.lbClass.TabIndex = 24;
            this.lbClass.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(338, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Passed Tests :";
            // 
            // lbPassedTests
            // 
            this.lbPassedTests.AutoSize = true;
            this.lbPassedTests.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassedTests.Location = new System.Drawing.Point(489, 95);
            this.lbPassedTests.Name = "lbPassedTests";
            this.lbPassedTests.Size = new System.Drawing.Size(42, 18);
            this.lbPassedTests.TabIndex = 26;
            this.lbPassedTests.Text = "[???]";
            // 
            // UC_DrivingLicenseAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_DrivingLicenseAppInfo";
            this.Size = new System.Drawing.Size(777, 153);
            this.Load += new System.EventHandler(this.UC_DrivingLicenseAppInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPassedTests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbApplicatoinId;
    }
}

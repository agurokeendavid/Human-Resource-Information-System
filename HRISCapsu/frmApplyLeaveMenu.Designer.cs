namespace HRISCapsu
{
    partial class frmApplyLeaveMenu
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
            this.btnAcademic = new System.Windows.Forms.Button();
            this.btnNonAcademic = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAcademic
            // 
            this.btnAcademic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcademic.Location = new System.Drawing.Point(53, 107);
            this.btnAcademic.Name = "btnAcademic";
            this.btnAcademic.Size = new System.Drawing.Size(177, 84);
            this.btnAcademic.TabIndex = 0;
            this.btnAcademic.Text = "Academic";
            this.btnAcademic.UseVisualStyleBackColor = true;
            this.btnAcademic.Click += new System.EventHandler(this.btnAcademic_Click);
            // 
            // btnNonAcademic
            // 
            this.btnNonAcademic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonAcademic.Location = new System.Drawing.Point(317, 107);
            this.btnNonAcademic.Name = "btnNonAcademic";
            this.btnNonAcademic.Size = new System.Drawing.Size(177, 84);
            this.btnNonAcademic.TabIndex = 2;
            this.btnNonAcademic.Text = "Non - Academic";
            this.btnNonAcademic.UseVisualStyleBackColor = true;
            this.btnNonAcademic.Click += new System.EventHandler(this.btnNonAcademic_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.btnClose);
            this.Panel1.Controls.Add(this.lblTitle);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(547, 66);
            this.Panel1.TabIndex = 13;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(210, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Employee Type";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::HRISCapsu.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(488, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(46, 36);
            this.btnClose.TabIndex = 14;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = global::HRISCapsu.Properties.Resources._200px_Capiz_State_University;
            this.PictureBox1.Location = new System.Drawing.Point(114, 4);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(84, 57);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 47;
            this.PictureBox1.TabStop = false;
            // 
            // frmApplyLeaveMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 241);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnNonAcademic);
            this.Controls.Add(this.btnAcademic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmApplyLeaveMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmApplyLeaveMenu";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAcademic;
        private System.Windows.Forms.Button btnNonAcademic;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Button btnClose;
    }
}
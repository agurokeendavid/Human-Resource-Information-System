namespace HRISCapsu
{
    partial class frmAcademicApplyLeave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcademicApplyLeave));
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dtpLeaveTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpLeaveFrom = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.panelEmployeeInformation = new System.Windows.Forms.Panel();
            this.lblLeaveCredits = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.panelEmployeeInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(20, 233);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(248, 97);
            this.txtReason.TabIndex = 5;
            // 
            // dtpLeaveTo
            // 
            this.dtpLeaveTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpLeaveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveTo.Location = new System.Drawing.Point(20, 183);
            this.dtpLeaveTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpLeaveTo.Name = "dtpLeaveTo";
            this.dtpLeaveTo.Size = new System.Drawing.Size(248, 26);
            this.dtpLeaveTo.TabIndex = 4;
            this.dtpLeaveTo.Value = new System.DateTime(2020, 1, 3, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Leave To:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(126, 48);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(70, 24);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Reason:";
            // 
            // dtpLeaveFrom
            // 
            this.dtpLeaveFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpLeaveFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveFrom.Location = new System.Drawing.Point(20, 133);
            this.dtpLeaveFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpLeaveFrom.Name = "dtpLeaveFrom";
            this.dtpLeaveFrom.Size = new System.Drawing.Size(248, 26);
            this.dtpLeaveFrom.TabIndex = 3;
            this.dtpLeaveFrom.Value = new System.DateTime(2020, 1, 3, 0, 0, 0, 0);
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.BackColor = System.Drawing.Color.White;
            this.txtEmployeeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeNo.Location = new System.Drawing.Point(20, 48);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(102, 26);
            this.txtEmployeeNo.TabIndex = 0;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(16, 24);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(107, 20);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Employee No.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(16, 110);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(97, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Leave From:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Teal;
            this.Label9.Location = new System.Drawing.Point(97, 13);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(163, 26);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "APPLY LEAVE";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(280, 54);
            this.Panel1.TabIndex = 10;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = global::HRISCapsu.Properties.Resources._200px_Capiz_State_University;
            this.PictureBox1.Location = new System.Drawing.Point(28, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(63, 46);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 47;
            this.PictureBox1.TabStop = false;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(16, 83);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(123, 20);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "Service Credits :";
            // 
            // panelEmployeeInformation
            // 
            this.panelEmployeeInformation.BackColor = System.Drawing.Color.Transparent;
            this.panelEmployeeInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEmployeeInformation.Controls.Add(this.lblLeaveCredits);
            this.panelEmployeeInformation.Controls.Add(this.txtReason);
            this.panelEmployeeInformation.Controls.Add(this.dtpLeaveTo);
            this.panelEmployeeInformation.Controls.Add(this.label3);
            this.panelEmployeeInformation.Controls.Add(this.btnSelect);
            this.panelEmployeeInformation.Controls.Add(this.label2);
            this.panelEmployeeInformation.Controls.Add(this.btnCancel);
            this.panelEmployeeInformation.Controls.Add(this.btnSave);
            this.panelEmployeeInformation.Controls.Add(this.dtpLeaveFrom);
            this.panelEmployeeInformation.Controls.Add(this.txtEmployeeNo);
            this.panelEmployeeInformation.Controls.Add(this.Label16);
            this.panelEmployeeInformation.Controls.Add(this.Label1);
            this.panelEmployeeInformation.Controls.Add(this.Label20);
            this.panelEmployeeInformation.Location = new System.Drawing.Point(0, 58);
            this.panelEmployeeInformation.Name = "panelEmployeeInformation";
            this.panelEmployeeInformation.Size = new System.Drawing.Size(281, 388);
            this.panelEmployeeInformation.TabIndex = 9;
            // 
            // lblLeaveCredits
            // 
            this.lblLeaveCredits.AutoSize = true;
            this.lblLeaveCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveCredits.Location = new System.Drawing.Point(145, 83);
            this.lblLeaveCredits.Name = "lblLeaveCredits";
            this.lblLeaveCredits.Size = new System.Drawing.Size(18, 20);
            this.lblLeaveCredits.TabIndex = 36;
            this.lblLeaveCredits.Text = "0";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(194, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 43);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(116, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAcademicApplyLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 444);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.panelEmployeeInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAcademicApplyLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.panelEmployeeInformation.ResumeLayout(false);
            this.panelEmployeeInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.DateTimePicker dtpLeaveTo;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpLeaveFrom;
        internal System.Windows.Forms.TextBox txtEmployeeNo;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Panel panelEmployeeInformation;
        internal System.Windows.Forms.Label lblLeaveCredits;
    }
}
namespace HRISCapsu
{
    partial class frmEmployeesOnLeave
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeesOnLeave));
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.dtgRecords = new System.Windows.Forms.DataGridView();
            this.Label9 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnModemPort = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecords)).BeginInit();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(2, 17);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(147, 18);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Employee Name:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.txtEmployeeName);
            this.GroupBox1.Controls.Add(this.dtgRecords);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(10, 81);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(512, 344);
            this.GroupBox1.TabIndex = 37;
            this.GroupBox1.TabStop = false;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.Color.White;
            this.txtEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(6, 41);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(204, 26);
            this.txtEmployeeName.TabIndex = 26;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.txtEmployeeName_TextChanged);
            // 
            // dtgRecords
            // 
            this.dtgRecords.AllowUserToAddRows = false;
            this.dtgRecords.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FloralWhite;
            this.dtgRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dtgRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRecords.BackgroundColor = System.Drawing.Color.White;
            this.dtgRecords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtgRecords.EnableHeadersVisualStyles = false;
            this.dtgRecords.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dtgRecords.Location = new System.Drawing.Point(6, 72);
            this.dtgRecords.MultiSelect = false;
            this.dtgRecords.Name = "dtgRecords";
            this.dtgRecords.ReadOnly = true;
            this.dtgRecords.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dtgRecords.RowHeadersVisible = false;
            this.dtgRecords.RowHeadersWidth = 25;
            this.dtgRecords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.dtgRecords.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dtgRecords.RowTemplate.Height = 18;
            this.dtgRecords.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRecords.Size = new System.Drawing.Size(500, 266);
            this.dtgRecords.TabIndex = 25;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Britannic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Teal;
            this.Label9.Location = new System.Drawing.Point(146, 7);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(296, 36);
            this.Label9.TabIndex = 1;
            this.Label9.Text = "Employees on Leave";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.Controls.Add(this.btnModemPort);
            this.Panel2.Controls.Add(this.btnSend);
            this.Panel2.Controls.Add(this.btnClose);
            this.Panel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel2.Location = new System.Drawing.Point(10, 431);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(513, 60);
            this.Panel2.TabIndex = 38;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(430, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(532, 54);
            this.Panel1.TabIndex = 36;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::HRISCapsu.Properties.Resources._200px_Capiz_State_University;
            this.PictureBox1.Location = new System.Drawing.Point(70, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(62, 45);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 33;
            this.PictureBox1.TabStop = false;
            // 
            // btnModemPort
            // 
            this.btnModemPort.BackColor = System.Drawing.Color.Transparent;
            this.btnModemPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModemPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModemPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModemPort.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModemPort.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnModemPort.Image = global::HRISCapsu.Properties.Resources.router;
            this.btnModemPort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModemPort.Location = new System.Drawing.Point(164, 7);
            this.btnModemPort.Name = "btnModemPort";
            this.btnModemPort.Size = new System.Drawing.Size(124, 39);
            this.btnModemPort.TabIndex = 11;
            this.btnModemPort.Text = "MODEM PORT";
            this.btnModemPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModemPort.UseVisualStyleBackColor = false;
            this.btnModemPort.Visible = false;
            this.btnModemPort.Click += new System.EventHandler(this.btnModemPort_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnSend.Image = global::HRISCapsu.Properties.Resources.send;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(295, 7);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(129, 39);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send Reminder";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmEmployeesOnLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 493);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmEmployeesOnLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeesOnLeave";
            this.Load += new System.EventHandler(this.frmEmployeesOnLeave_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecords)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtEmployeeName;
        internal System.Windows.Forms.DataGridView dtgRecords;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button btnModemPort;
        internal System.Windows.Forms.Button btnSend;
    }
}
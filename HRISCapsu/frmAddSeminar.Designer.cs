namespace HRISCapsu
{
    partial class frmAddSeminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSeminar));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label9 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.panelFileInformation = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLocationBased = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDateofActivity = new System.Windows.Forms.DateTimePicker();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtSeminarName = new System.Windows.Forms.TextBox();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.panelFileInformation.SuspendLayout();
            this.SuspendLayout();
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
            this.Panel1.Size = new System.Drawing.Size(405, 54);
            this.Panel1.TabIndex = 6;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Teal;
            this.Label9.Location = new System.Drawing.Point(124, 6);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(238, 37);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "ADD SEMINAR";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = global::HRISCapsu.Properties.Resources._200px_Capiz_State_University;
            this.PictureBox1.Location = new System.Drawing.Point(56, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(63, 46);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 47;
            this.PictureBox1.TabStop = false;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(17, 24);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(72, 20);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Seminar:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 185);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(119, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Date of Activity:";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(17, 75);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(74, 20);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "Location:";
            // 
            // panelFileInformation
            // 
            this.panelFileInformation.BackColor = System.Drawing.Color.Transparent;
            this.panelFileInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFileInformation.Controls.Add(this.label3);
            this.panelFileInformation.Controls.Add(this.cmbLocationBased);
            this.panelFileInformation.Controls.Add(this.btnCancel);
            this.panelFileInformation.Controls.Add(this.btnSave);
            this.panelFileInformation.Controls.Add(this.dtpDateofActivity);
            this.panelFileInformation.Controls.Add(this.txtLocation);
            this.panelFileInformation.Controls.Add(this.txtSeminarName);
            this.panelFileInformation.Controls.Add(this.Label16);
            this.panelFileInformation.Controls.Add(this.Label1);
            this.panelFileInformation.Controls.Add(this.Label20);
            this.panelFileInformation.Location = new System.Drawing.Point(0, 58);
            this.panelFileInformation.Name = "panelFileInformation";
            this.panelFileInformation.Size = new System.Drawing.Size(406, 306);
            this.panelFileInformation.TabIndex = 0;
            this.panelFileInformation.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFileInformation_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Location Based:";
            // 
            // cmbLocationBased
            // 
            this.cmbLocationBased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocationBased.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocationBased.FormattingEnabled = true;
            this.cmbLocationBased.Items.AddRange(new object[] {
            "Local",
            "Regional",
            "National",
            "International"});
            this.cmbLocationBased.Location = new System.Drawing.Point(21, 155);
            this.cmbLocationBased.Name = "cmbLocationBased";
            this.cmbLocationBased.Size = new System.Drawing.Size(367, 28);
            this.cmbLocationBased.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(315, 239);
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
            this.btnSave.Location = new System.Drawing.Point(237, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDateofActivity
            // 
            this.dtpDateofActivity.CustomFormat = "MMMM dd, yyyy";
            this.dtpDateofActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateofActivity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateofActivity.Location = new System.Drawing.Point(21, 208);
            this.dtpDateofActivity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDateofActivity.Name = "dtpDateofActivity";
            this.dtpDateofActivity.Size = new System.Drawing.Size(367, 26);
            this.dtpDateofActivity.TabIndex = 4;
            this.dtpDateofActivity.Value = new System.DateTime(2020, 1, 3, 0, 0, 0, 0);
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.White;
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(21, 98);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(367, 26);
            this.txtLocation.TabIndex = 2;
            // 
            // txtSeminarName
            // 
            this.txtSeminarName.BackColor = System.Drawing.Color.White;
            this.txtSeminarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeminarName.Location = new System.Drawing.Point(21, 47);
            this.txtSeminarName.Name = "txtSeminarName";
            this.txtSeminarName.Size = new System.Drawing.Size(367, 26);
            this.txtSeminarName.TabIndex = 1;
            // 
            // frmAddSeminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 364);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.panelFileInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAddSeminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddSeminar";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.panelFileInformation.ResumeLayout(false);
            this.panelFileInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Panel panelFileInformation;
        internal System.Windows.Forms.TextBox txtLocation;
        internal System.Windows.Forms.TextBox txtSeminarName;
        private System.Windows.Forms.DateTimePicker dtpDateofActivity;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbLocationBased;
    }
}
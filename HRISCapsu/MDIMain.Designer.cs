namespace HRISCapsu
{
    partial class MDIMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEmployeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.academicToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.allAcademicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonAcademicToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.allNonAcademicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.academicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonAcademicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.qualificationGenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masteralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctoralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seminarsAttendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endOfContractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endOfLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oldEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentDateAndTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.academicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nonAcademicToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.recordsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 55);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(141, 45);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(345, 46);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(345, 46);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEmployeesToolStripMenuItem1,
            this.employeesToolStripMenuItem,
            this.leaveToolStripMenuItem,
            this.positionsToolStripMenuItem});
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(185, 45);
            this.recordsToolStripMenuItem.Text = "HR Records";
            // 
            // allEmployeesToolStripMenuItem1
            // 
            this.allEmployeesToolStripMenuItem1.Name = "allEmployeesToolStripMenuItem1";
            this.allEmployeesToolStripMenuItem1.Size = new System.Drawing.Size(295, 46);
            this.allEmployeesToolStripMenuItem1.Text = "All Employees";
            this.allEmployeesToolStripMenuItem1.Click += new System.EventHandler(this.allEmployeesToolStripMenuItem1_Click);
            // 
            // leaveToolStripMenuItem
            // 
            this.leaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyLeaveToolStripMenuItem});
            this.leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            this.leaveToolStripMenuItem.Size = new System.Drawing.Size(295, 46);
            this.leaveToolStripMenuItem.Text = "Leave";
            // 
            // applyLeaveToolStripMenuItem
            // 
            this.applyLeaveToolStripMenuItem.Name = "applyLeaveToolStripMenuItem";
            this.applyLeaveToolStripMenuItem.Size = new System.Drawing.Size(270, 46);
            this.applyLeaveToolStripMenuItem.Text = "Apply Leave";
            this.applyLeaveToolStripMenuItem.Click += new System.EventHandler(this.applyLeaveToolStripMenuItem_Click);
            // 
            // positionsToolStripMenuItem
            // 
            this.positionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPositionToolStripMenuItem});
            this.positionsToolStripMenuItem.Name = "positionsToolStripMenuItem";
            this.positionsToolStripMenuItem.Size = new System.Drawing.Size(295, 46);
            this.positionsToolStripMenuItem.Text = "Positions";
            // 
            // addPositionToolStripMenuItem
            // 
            this.addPositionToolStripMenuItem.Name = "addPositionToolStripMenuItem";
            this.addPositionToolStripMenuItem.Size = new System.Drawing.Size(279, 46);
            this.addPositionToolStripMenuItem.Text = "Add Position";
            this.addPositionToolStripMenuItem.Click += new System.EventHandler(this.addPositionToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEmployeesToolStripMenuItem,
            this.academicToolStripMenuItem2,
            this.nonAcademicToolStripMenuItem3,
            this.graphToolStripMenuItem,
            this.seminarsAttendedToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(134, 45);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // allEmployeesToolStripMenuItem
            // 
            this.allEmployeesToolStripMenuItem.Name = "allEmployeesToolStripMenuItem";
            this.allEmployeesToolStripMenuItem.Size = new System.Drawing.Size(557, 46);
            this.allEmployeesToolStripMenuItem.Text = "All Employees";
            this.allEmployeesToolStripMenuItem.Click += new System.EventHandler(this.allEmployeesToolStripMenuItem_Click);
            // 
            // academicToolStripMenuItem2
            // 
            this.academicToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allAcademicToolStripMenuItem,
            this.regularToolStripMenuItem,
            this.contractualToolStripMenuItem});
            this.academicToolStripMenuItem2.Name = "academicToolStripMenuItem2";
            this.academicToolStripMenuItem2.Size = new System.Drawing.Size(557, 46);
            this.academicToolStripMenuItem2.Text = "Academic";
            // 
            // allAcademicToolStripMenuItem
            // 
            this.allAcademicToolStripMenuItem.Name = "allAcademicToolStripMenuItem";
            this.allAcademicToolStripMenuItem.Size = new System.Drawing.Size(280, 46);
            this.allAcademicToolStripMenuItem.Text = "All Academic";
            this.allAcademicToolStripMenuItem.Click += new System.EventHandler(this.allAcademicToolStripMenuItem_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(280, 46);
            this.regularToolStripMenuItem.Text = "Regular";
            this.regularToolStripMenuItem.Click += new System.EventHandler(this.regularToolStripMenuItem_Click);
            // 
            // contractualToolStripMenuItem
            // 
            this.contractualToolStripMenuItem.Name = "contractualToolStripMenuItem";
            this.contractualToolStripMenuItem.Size = new System.Drawing.Size(280, 46);
            this.contractualToolStripMenuItem.Text = "Contractual";
            this.contractualToolStripMenuItem.Click += new System.EventHandler(this.contractualToolStripMenuItem_Click);
            // 
            // nonAcademicToolStripMenuItem3
            // 
            this.nonAcademicToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allNonAcademicToolStripMenuItem,
            this.regularToolStripMenuItem1,
            this.contractualToolStripMenuItem1});
            this.nonAcademicToolStripMenuItem3.Name = "nonAcademicToolStripMenuItem3";
            this.nonAcademicToolStripMenuItem3.Size = new System.Drawing.Size(557, 46);
            this.nonAcademicToolStripMenuItem3.Text = "Non - Academic";
            // 
            // allNonAcademicToolStripMenuItem
            // 
            this.allNonAcademicToolStripMenuItem.Name = "allNonAcademicToolStripMenuItem";
            this.allNonAcademicToolStripMenuItem.Size = new System.Drawing.Size(365, 46);
            this.allNonAcademicToolStripMenuItem.Text = "All Non - Academic";
            this.allNonAcademicToolStripMenuItem.Click += new System.EventHandler(this.allNonAcademicToolStripMenuItem_Click);
            // 
            // regularToolStripMenuItem1
            // 
            this.regularToolStripMenuItem1.Name = "regularToolStripMenuItem1";
            this.regularToolStripMenuItem1.Size = new System.Drawing.Size(365, 46);
            this.regularToolStripMenuItem1.Text = "Regular";
            this.regularToolStripMenuItem1.Click += new System.EventHandler(this.regularToolStripMenuItem1_Click);
            // 
            // contractualToolStripMenuItem1
            // 
            this.contractualToolStripMenuItem1.Name = "contractualToolStripMenuItem1";
            this.contractualToolStripMenuItem1.Size = new System.Drawing.Size(365, 46);
            this.contractualToolStripMenuItem1.Text = "Contractual";
            this.contractualToolStripMenuItem1.Click += new System.EventHandler(this.contractualToolStripMenuItem1_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.academicToolStripMenuItem,
            this.nonAcademicToolStripMenuItem1});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(557, 46);
            this.graphToolStripMenuItem.Text = "Graph Presentation";
            // 
            // academicToolStripMenuItem
            // 
            this.academicToolStripMenuItem.Name = "academicToolStripMenuItem";
            this.academicToolStripMenuItem.Size = new System.Drawing.Size(324, 46);
            this.academicToolStripMenuItem.Text = "Academic";
            this.academicToolStripMenuItem.Click += new System.EventHandler(this.academicToolStripMenuItem_Click);
            // 
            // nonAcademicToolStripMenuItem1
            // 
            this.nonAcademicToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qualificationGenderToolStripMenuItem});
            this.nonAcademicToolStripMenuItem1.Name = "nonAcademicToolStripMenuItem1";
            this.nonAcademicToolStripMenuItem1.Size = new System.Drawing.Size(324, 46);
            this.nonAcademicToolStripMenuItem1.Text = "Non - Academic";
            // 
            // qualificationGenderToolStripMenuItem
            // 
            this.qualificationGenderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masteralToolStripMenuItem,
            this.doctoralToolStripMenuItem});
            this.qualificationGenderToolStripMenuItem.Name = "qualificationGenderToolStripMenuItem";
            this.qualificationGenderToolStripMenuItem.Size = new System.Drawing.Size(400, 46);
            this.qualificationGenderToolStripMenuItem.Text = "Qualification (Gender)";
            // 
            // masteralToolStripMenuItem
            // 
            this.masteralToolStripMenuItem.Name = "masteralToolStripMenuItem";
            this.masteralToolStripMenuItem.Size = new System.Drawing.Size(223, 46);
            this.masteralToolStripMenuItem.Text = "Masteral";
            this.masteralToolStripMenuItem.Click += new System.EventHandler(this.masteralToolStripMenuItem_Click);
            // 
            // doctoralToolStripMenuItem
            // 
            this.doctoralToolStripMenuItem.Name = "doctoralToolStripMenuItem";
            this.doctoralToolStripMenuItem.Size = new System.Drawing.Size(223, 46);
            this.doctoralToolStripMenuItem.Text = "Doctoral";
            this.doctoralToolStripMenuItem.Click += new System.EventHandler(this.doctoralToolStripMenuItem_Click);
            // 
            // seminarsAttendedToolStripMenuItem
            // 
            this.seminarsAttendedToolStripMenuItem.Name = "seminarsAttendedToolStripMenuItem";
            this.seminarsAttendedToolStripMenuItem.Size = new System.Drawing.Size(557, 46);
            this.seminarsAttendedToolStripMenuItem.Text = "Learning Development (Seminars)";
            this.seminarsAttendedToolStripMenuItem.Click += new System.EventHandler(this.seminarsAttendedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 45);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endOfContractToolStripMenuItem,
            this.endOfLeaveToolStripMenuItem,
            this.oldEmployeesToolStripMenuItem});
            this.notificationsToolStripMenuItem.Enabled = false;
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(186, 45);
            this.notificationsToolStripMenuItem.Text = "Notification";
            // 
            // endOfContractToolStripMenuItem
            // 
            this.endOfContractToolStripMenuItem.Name = "endOfContractToolStripMenuItem";
            this.endOfContractToolStripMenuItem.Size = new System.Drawing.Size(316, 46);
            this.endOfContractToolStripMenuItem.Text = "End of Contract";
            // 
            // endOfLeaveToolStripMenuItem
            // 
            this.endOfLeaveToolStripMenuItem.Name = "endOfLeaveToolStripMenuItem";
            this.endOfLeaveToolStripMenuItem.Size = new System.Drawing.Size(316, 46);
            this.endOfLeaveToolStripMenuItem.Text = "End of Leave";
            // 
            // oldEmployeesToolStripMenuItem
            // 
            this.oldEmployeesToolStripMenuItem.Name = "oldEmployeesToolStripMenuItem";
            this.oldEmployeesToolStripMenuItem.Size = new System.Drawing.Size(316, 46);
            this.oldEmployeesToolStripMenuItem.Text = "Old Employees";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentDateAndTime,
            this.tsslConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 47, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1924, 47);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCurrentDateAndTime
            // 
            this.tsslCurrentDateAndTime.BackColor = System.Drawing.Color.Transparent;
            this.tsslCurrentDateAndTime.ForeColor = System.Drawing.Color.White;
            this.tsslCurrentDateAndTime.Name = "tsslCurrentDateAndTime";
            this.tsslCurrentDateAndTime.Size = new System.Drawing.Size(98, 41);
            this.tsslCurrentDateAndTime.Text = "Time :";
            // 
            // tsslConnection
            // 
            this.tsslConnection.BackColor = System.Drawing.Color.Transparent;
            this.tsslConnection.Name = "tsslConnection";
            this.tsslConnection.Size = new System.Drawing.Size(171, 41);
            this.tsslConnection.Text = "Connection";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BackgroundImage = global::HRISCapsu.Properties.Resources.capsu_circle;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 684);
            this.panel1.TabIndex = 9;
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.academicToolStripMenuItem1,
            this.nonAcademicToolStripMenuItem2});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(295, 46);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // academicToolStripMenuItem1
            // 
            this.academicToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularToolStripMenuItem2,
            this.contractualToolStripMenuItem2});
            this.academicToolStripMenuItem1.Name = "academicToolStripMenuItem1";
            this.academicToolStripMenuItem1.Size = new System.Drawing.Size(324, 46);
            this.academicToolStripMenuItem1.Text = "Academic";
            // 
            // nonAcademicToolStripMenuItem2
            // 
            this.nonAcademicToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularToolStripMenuItem3,
            this.contractualToolStripMenuItem3});
            this.nonAcademicToolStripMenuItem2.Name = "nonAcademicToolStripMenuItem2";
            this.nonAcademicToolStripMenuItem2.Size = new System.Drawing.Size(324, 46);
            this.nonAcademicToolStripMenuItem2.Text = "Non - Academic";
            // 
            // regularToolStripMenuItem2
            // 
            this.regularToolStripMenuItem2.Name = "regularToolStripMenuItem2";
            this.regularToolStripMenuItem2.Size = new System.Drawing.Size(262, 46);
            this.regularToolStripMenuItem2.Text = "Regular";
            this.regularToolStripMenuItem2.Click += new System.EventHandler(this.regularToolStripMenuItem2_Click);
            // 
            // contractualToolStripMenuItem2
            // 
            this.contractualToolStripMenuItem2.Name = "contractualToolStripMenuItem2";
            this.contractualToolStripMenuItem2.Size = new System.Drawing.Size(262, 46);
            this.contractualToolStripMenuItem2.Text = "Contractual";
            this.contractualToolStripMenuItem2.Click += new System.EventHandler(this.contractualToolStripMenuItem2_Click);
            // 
            // regularToolStripMenuItem3
            // 
            this.regularToolStripMenuItem3.Name = "regularToolStripMenuItem3";
            this.regularToolStripMenuItem3.Size = new System.Drawing.Size(262, 46);
            this.regularToolStripMenuItem3.Text = "Regular";
            this.regularToolStripMenuItem3.Click += new System.EventHandler(this.regularToolStripMenuItem3_Click);
            // 
            // contractualToolStripMenuItem3
            // 
            this.contractualToolStripMenuItem3.Name = "contractualToolStripMenuItem3";
            this.contractualToolStripMenuItem3.Size = new System.Drawing.Size(262, 46);
            this.contractualToolStripMenuItem3.Text = "Contractual";
            this.contractualToolStripMenuItem3.Click += new System.EventHandler(this.contractualToolStripMenuItem3_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(27F, 54F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1924, 786);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.MaximizeBox = false;
            this.Name = "MDIMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capiz State University - Human Resource Information System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEmployeesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentDateAndTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endOfContractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endOfLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEmployeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oldEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seminarsAttendedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem academicToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem allAcademicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonAcademicToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem allNonAcademicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contractualToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem academicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonAcademicToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem qualificationGenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masteralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctoralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem academicToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nonAcademicToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem contractualToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem contractualToolStripMenuItem3;
    }
}




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
            this.employeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRegularEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContractualEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonAcademicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularEmployeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualEmployeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.academicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonAcademicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.academicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nonAcademicToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfMasteralHolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfDoctoralHolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.seminarsAttendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(1924, 46);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(114, 36);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(276, 36);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(276, 36);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEmployeesToolStripMenuItem1,
            this.employeesToolStripMenuItem1,
            this.nonAcademicToolStripMenuItem,
            this.leaveToolStripMenuItem});
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(148, 36);
            this.recordsToolStripMenuItem.Text = "HR Records";
            // 
            // allEmployeesToolStripMenuItem1
            // 
            this.allEmployeesToolStripMenuItem1.Name = "allEmployeesToolStripMenuItem1";
            this.allEmployeesToolStripMenuItem1.Size = new System.Drawing.Size(263, 36);
            this.allEmployeesToolStripMenuItem1.Text = "All Employees";
            this.allEmployeesToolStripMenuItem1.Click += new System.EventHandler(this.allEmployeesToolStripMenuItem1_Click);
            // 
            // employeesToolStripMenuItem1
            // 
            this.employeesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRegularEmployeesToolStripMenuItem,
            this.viewContractualEmployeesToolStripMenuItem});
            this.employeesToolStripMenuItem1.Name = "employeesToolStripMenuItem1";
            this.employeesToolStripMenuItem1.Size = new System.Drawing.Size(263, 36);
            this.employeesToolStripMenuItem1.Text = "Academic";
            // 
            // viewRegularEmployeesToolStripMenuItem
            // 
            this.viewRegularEmployeesToolStripMenuItem.Name = "viewRegularEmployeesToolStripMenuItem";
            this.viewRegularEmployeesToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.viewRegularEmployeesToolStripMenuItem.Text = "Regular Employees";
            this.viewRegularEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewRegularEmployeesToolStripMenuItem_Click);
            // 
            // viewContractualEmployeesToolStripMenuItem
            // 
            this.viewContractualEmployeesToolStripMenuItem.Name = "viewContractualEmployeesToolStripMenuItem";
            this.viewContractualEmployeesToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.viewContractualEmployeesToolStripMenuItem.Text = "Contractual Employees";
            this.viewContractualEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewContractualEmployeesToolStripMenuItem_Click);
            // 
            // nonAcademicToolStripMenuItem
            // 
            this.nonAcademicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularEmployeesToolStripMenuItem1,
            this.contractualEmployeesToolStripMenuItem1});
            this.nonAcademicToolStripMenuItem.Name = "nonAcademicToolStripMenuItem";
            this.nonAcademicToolStripMenuItem.Size = new System.Drawing.Size(263, 36);
            this.nonAcademicToolStripMenuItem.Text = "Non - Academic";
            // 
            // regularEmployeesToolStripMenuItem1
            // 
            this.regularEmployeesToolStripMenuItem1.Name = "regularEmployeesToolStripMenuItem1";
            this.regularEmployeesToolStripMenuItem1.Size = new System.Drawing.Size(334, 36);
            this.regularEmployeesToolStripMenuItem1.Text = "Regular Employees";
            this.regularEmployeesToolStripMenuItem1.Click += new System.EventHandler(this.regularEmployeesToolStripMenuItem1_Click);
            // 
            // contractualEmployeesToolStripMenuItem1
            // 
            this.contractualEmployeesToolStripMenuItem1.Name = "contractualEmployeesToolStripMenuItem1";
            this.contractualEmployeesToolStripMenuItem1.Size = new System.Drawing.Size(334, 36);
            this.contractualEmployeesToolStripMenuItem1.Text = "Contractual Employees";
            this.contractualEmployeesToolStripMenuItem1.Click += new System.EventHandler(this.contractualEmployeesToolStripMenuItem1_Click);
            // 
            // leaveToolStripMenuItem
            // 
            this.leaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyLeaveToolStripMenuItem});
            this.leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            this.leaveToolStripMenuItem.Size = new System.Drawing.Size(263, 36);
            this.leaveToolStripMenuItem.Text = "Leave";
            // 
            // applyLeaveToolStripMenuItem
            // 
            this.applyLeaveToolStripMenuItem.Name = "applyLeaveToolStripMenuItem";
            this.applyLeaveToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
            this.applyLeaveToolStripMenuItem.Text = "Apply Leave";
            this.applyLeaveToolStripMenuItem.Click += new System.EventHandler(this.applyLeaveToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEmployeesToolStripMenuItem,
            this.regularEmployeesToolStripMenuItem,
            this.contractualEmployeesToolStripMenuItem,
            this.graphToolStripMenuItem,
            this.seminarsAttendedToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(107, 36);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // allEmployeesToolStripMenuItem
            // 
            this.allEmployeesToolStripMenuItem.Name = "allEmployeesToolStripMenuItem";
            this.allEmployeesToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.allEmployeesToolStripMenuItem.Text = "All Employees";
            this.allEmployeesToolStripMenuItem.Click += new System.EventHandler(this.allEmployeesToolStripMenuItem_Click);
            // 
            // regularEmployeesToolStripMenuItem
            // 
            this.regularEmployeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.academicToolStripMenuItem,
            this.nonAcademicToolStripMenuItem1});
            this.regularEmployeesToolStripMenuItem.Name = "regularEmployeesToolStripMenuItem";
            this.regularEmployeesToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.regularEmployeesToolStripMenuItem.Text = "Regular Employees";
            // 
            // academicToolStripMenuItem
            // 
            this.academicToolStripMenuItem.Name = "academicToolStripMenuItem";
            this.academicToolStripMenuItem.Size = new System.Drawing.Size(263, 36);
            this.academicToolStripMenuItem.Text = "Academic";
            this.academicToolStripMenuItem.Click += new System.EventHandler(this.academicToolStripMenuItem_Click);
            // 
            // nonAcademicToolStripMenuItem1
            // 
            this.nonAcademicToolStripMenuItem1.Name = "nonAcademicToolStripMenuItem1";
            this.nonAcademicToolStripMenuItem1.Size = new System.Drawing.Size(263, 36);
            this.nonAcademicToolStripMenuItem1.Text = "Non - Academic";
            this.nonAcademicToolStripMenuItem1.Click += new System.EventHandler(this.nonAcademicToolStripMenuItem1_Click);
            // 
            // contractualEmployeesToolStripMenuItem
            // 
            this.contractualEmployeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.academicToolStripMenuItem1,
            this.nonAcademicToolStripMenuItem2});
            this.contractualEmployeesToolStripMenuItem.Name = "contractualEmployeesToolStripMenuItem";
            this.contractualEmployeesToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.contractualEmployeesToolStripMenuItem.Text = "Contractual Employees";
            // 
            // academicToolStripMenuItem1
            // 
            this.academicToolStripMenuItem1.Name = "academicToolStripMenuItem1";
            this.academicToolStripMenuItem1.Size = new System.Drawing.Size(263, 36);
            this.academicToolStripMenuItem1.Text = "Academic";
            this.academicToolStripMenuItem1.Click += new System.EventHandler(this.academicToolStripMenuItem1_Click);
            // 
            // nonAcademicToolStripMenuItem2
            // 
            this.nonAcademicToolStripMenuItem2.Name = "nonAcademicToolStripMenuItem2";
            this.nonAcademicToolStripMenuItem2.Size = new System.Drawing.Size(263, 36);
            this.nonAcademicToolStripMenuItem2.Text = "Non - Academic";
            this.nonAcademicToolStripMenuItem2.Click += new System.EventHandler(this.nonAcademicToolStripMenuItem2_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfMasteralHolderToolStripMenuItem,
            this.listOfDoctoralHolderToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // listOfMasteralHolderToolStripMenuItem
            // 
            this.listOfMasteralHolderToolStripMenuItem.Name = "listOfMasteralHolderToolStripMenuItem";
            this.listOfMasteralHolderToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.listOfMasteralHolderToolStripMenuItem.Text = "List of Masteral Holder";
            this.listOfMasteralHolderToolStripMenuItem.Click += new System.EventHandler(this.listOfMasteralHolderToolStripMenuItem_Click);
            // 
            // listOfDoctoralHolderToolStripMenuItem
            // 
            this.listOfDoctoralHolderToolStripMenuItem.Name = "listOfDoctoralHolderToolStripMenuItem";
            this.listOfDoctoralHolderToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.listOfDoctoralHolderToolStripMenuItem.Text = "List of Doctoral Holder";
            this.listOfDoctoralHolderToolStripMenuItem.Click += new System.EventHandler(this.listOfDoctoralHolderToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(92, 36);
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
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(152, 36);
            this.notificationsToolStripMenuItem.Text = "Notification";
            // 
            // endOfContractToolStripMenuItem
            // 
            this.endOfContractToolStripMenuItem.Name = "endOfContractToolStripMenuItem";
            this.endOfContractToolStripMenuItem.Size = new System.Drawing.Size(256, 36);
            this.endOfContractToolStripMenuItem.Text = "End of Contract";
            // 
            // endOfLeaveToolStripMenuItem
            // 
            this.endOfLeaveToolStripMenuItem.Name = "endOfLeaveToolStripMenuItem";
            this.endOfLeaveToolStripMenuItem.Size = new System.Drawing.Size(256, 36);
            this.endOfLeaveToolStripMenuItem.Text = "End of Leave";
            // 
            // oldEmployeesToolStripMenuItem
            // 
            this.oldEmployeesToolStripMenuItem.Name = "oldEmployeesToolStripMenuItem";
            this.oldEmployeesToolStripMenuItem.Size = new System.Drawing.Size(256, 36);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 749);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 47, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1924, 37);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCurrentDateAndTime
            // 
            this.tsslCurrentDateAndTime.BackColor = System.Drawing.Color.Transparent;
            this.tsslCurrentDateAndTime.ForeColor = System.Drawing.Color.White;
            this.tsslCurrentDateAndTime.Name = "tsslCurrentDateAndTime";
            this.tsslCurrentDateAndTime.Size = new System.Drawing.Size(80, 32);
            this.tsslCurrentDateAndTime.Text = "Time :";
            // 
            // tsslConnection
            // 
            this.tsslConnection.BackColor = System.Drawing.Color.Transparent;
            this.tsslConnection.Name = "tsslConnection";
            this.tsslConnection.Size = new System.Drawing.Size(138, 32);
            this.tsslConnection.Text = "Connection";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BackgroundImage = global::HRISCapsu.Properties.Resources.capsu_circle;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 703);
            this.panel1.TabIndex = 9;
            // 
            // seminarsAttendedToolStripMenuItem
            // 
            this.seminarsAttendedToolStripMenuItem.Name = "seminarsAttendedToolStripMenuItem";
            this.seminarsAttendedToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.seminarsAttendedToolStripMenuItem.Text = "Seminars Attended";
            this.seminarsAttendedToolStripMenuItem.Click += new System.EventHandler(this.seminarsAttendedToolStripMenuItem_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 44F);
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
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewRegularEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewContractualEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractualEmployeesToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem listOfMasteralHolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfDoctoralHolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEmployeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nonAcademicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularEmployeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contractualEmployeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem academicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonAcademicToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem academicToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nonAcademicToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem oldEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seminarsAttendedToolStripMenuItem;
    }
}




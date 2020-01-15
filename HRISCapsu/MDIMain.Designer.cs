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
            this.employeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRegularEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContractualEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDepartmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seminarsAndTrainingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSeminarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractualEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentDateAndTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();

            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentDateAndTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();

            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.recordsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.menuStrip1.Size = new System.Drawing.Size(2538, 55);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(139, 45);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(337, 46);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(337, 46);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem1,
            this.positionsToolStripMenuItem1,
            this.departmentsToolStripMenuItem1,
            this.seminarsAndTrainingsToolStripMenuItem});
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(136, 45);
            this.recordsToolStripMenuItem.Text = "Records";
            // 
            // employeesToolStripMenuItem1
            // 
            this.employeesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewEmployeesToolStripMenuItem,
            this.viewRegularEmployeesToolStripMenuItem,
            this.viewContractualEmployeesToolStripMenuItem});
            this.employeesToolStripMenuItem1.Name = "employeesToolStripMenuItem1";
            this.employeesToolStripMenuItem1.Size = new System.Drawing.Size(405, 46);
            this.employeesToolStripMenuItem1.Text = "Employees";
            // 
            // viewEmployeesToolStripMenuItem
            // 
            this.viewEmployeesToolStripMenuItem.Name = "viewEmployeesToolStripMenuItem";
            this.viewEmployeesToolStripMenuItem.Size = new System.Drawing.Size(478, 46);
            this.viewEmployeesToolStripMenuItem.Text = "View Employees";
            this.viewEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewEmployeesToolStripMenuItem_Click);
            // 
            // viewRegularEmployeesToolStripMenuItem
            // 
            this.viewRegularEmployeesToolStripMenuItem.Name = "viewRegularEmployeesToolStripMenuItem";
            this.viewRegularEmployeesToolStripMenuItem.Size = new System.Drawing.Size(478, 46);
            this.viewRegularEmployeesToolStripMenuItem.Text = "View Regular Employees";
            this.viewRegularEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewRegularEmployeesToolStripMenuItem_Click);
            // 
            // viewContractualEmployeesToolStripMenuItem
            // 
            this.viewContractualEmployeesToolStripMenuItem.Name = "viewContractualEmployeesToolStripMenuItem";
            this.viewContractualEmployeesToolStripMenuItem.Size = new System.Drawing.Size(478, 46);
            this.viewContractualEmployeesToolStripMenuItem.Text = "View Contractual Employees";
            this.viewContractualEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewContractualEmployeesToolStripMenuItem_Click);
            // 
            // positionsToolStripMenuItem1
            // 
            this.positionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPositionsToolStripMenuItem});
            this.positionsToolStripMenuItem1.Name = "positionsToolStripMenuItem1";
            this.positionsToolStripMenuItem1.Size = new System.Drawing.Size(405, 46);
            this.positionsToolStripMenuItem1.Text = "Positions";
            // 
            // viewPositionsToolStripMenuItem
            // 
            this.viewPositionsToolStripMenuItem.Name = "viewPositionsToolStripMenuItem";
            this.viewPositionsToolStripMenuItem.Size = new System.Drawing.Size(293, 46);
            this.viewPositionsToolStripMenuItem.Text = "View Positions";
            this.viewPositionsToolStripMenuItem.Click += new System.EventHandler(this.viewPositionsToolStripMenuItem_Click);
            // 
            // departmentsToolStripMenuItem1
            // 
            this.departmentsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDepartmentsToolStripMenuItem});
            this.departmentsToolStripMenuItem1.Name = "departmentsToolStripMenuItem1";
            this.departmentsToolStripMenuItem1.Size = new System.Drawing.Size(405, 46);
            this.departmentsToolStripMenuItem1.Text = "Departments";
            // 
            // viewDepartmentsToolStripMenuItem
            // 
            this.viewDepartmentsToolStripMenuItem.Name = "viewDepartmentsToolStripMenuItem";
            this.viewDepartmentsToolStripMenuItem.Size = new System.Drawing.Size(346, 46);
            this.viewDepartmentsToolStripMenuItem.Text = "View Departments";
            this.viewDepartmentsToolStripMenuItem.Click += new System.EventHandler(this.viewDepartmentsToolStripMenuItem_Click);
            // 
            // seminarsAndTrainingsToolStripMenuItem
            // 
            this.seminarsAndTrainingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSeminarsToolStripMenuItem});
            this.seminarsAndTrainingsToolStripMenuItem.Name = "seminarsAndTrainingsToolStripMenuItem";
            this.seminarsAndTrainingsToolStripMenuItem.Size = new System.Drawing.Size(405, 46);
            this.seminarsAndTrainingsToolStripMenuItem.Text = "Seminars and Trainings";
            // 
            // viewSeminarsToolStripMenuItem
            // 
            this.viewSeminarsToolStripMenuItem.Name = "viewSeminarsToolStripMenuItem";
            this.viewSeminarsToolStripMenuItem.Size = new System.Drawing.Size(294, 46);
            this.viewSeminarsToolStripMenuItem.Text = "View Seminars";
            this.viewSeminarsToolStripMenuItem.Click += new System.EventHandler(this.viewSeminarsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEmployeesToolStripMenuItem,
            this.regularEmployeesToolStripMenuItem,
            this.contractualEmployeesToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(132, 45);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // allEmployeesToolStripMenuItem
            // 
            this.allEmployeesToolStripMenuItem.Name = "allEmployeesToolStripMenuItem";
            this.allEmployeesToolStripMenuItem.Size = new System.Drawing.Size(406, 46);
            this.allEmployeesToolStripMenuItem.Text = "All Employees";

            this.allEmployeesToolStripMenuItem.Click += new System.EventHandler(this.allEmployeesToolStripMenuItem_Click);
            // 
            // regularEmployeesToolStripMenuItem
            // 
            this.regularEmployeesToolStripMenuItem.Name = "regularEmployeesToolStripMenuItem";
            this.regularEmployeesToolStripMenuItem.Size = new System.Drawing.Size(406, 46);
            this.regularEmployeesToolStripMenuItem.Text = "Regular Employees";
            this.regularEmployeesToolStripMenuItem.Click += new System.EventHandler(this.regularEmployeesToolStripMenuItem_Click);

            // 
            // contractualEmployeesToolStripMenuItem
            // 
            this.contractualEmployeesToolStripMenuItem.Name = "contractualEmployeesToolStripMenuItem";
            this.contractualEmployeesToolStripMenuItem.Size = new System.Drawing.Size(406, 46);
            this.contractualEmployeesToolStripMenuItem.Text = "Contractual Employees";

            this.contractualEmployeesToolStripMenuItem.Click += new System.EventHandler(this.contractualEmployeesToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 

            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BackgroundImage = global::HRISCapsu.Properties.Resources._200px_Capiz_State_University;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2538, 731);
            this.panel1.TabIndex = 6;
            // 

            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentDateAndTime,
            this.tsslConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 740);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 47, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2538, 46);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCurrentDateAndTime
            // 
            this.tsslCurrentDateAndTime.BackColor = System.Drawing.Color.Transparent;
            this.tsslCurrentDateAndTime.ForeColor = System.Drawing.Color.DarkBlue;
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
            this.panel1.BackgroundImage = global::HRISCapsu.Properties.Resources._200px_Capiz_State_University;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2538, 731);
            this.panel1.TabIndex = 6;
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(27F, 54F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(2538, 786);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
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

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem viewEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRegularEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewContractualEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem seminarsAndTrainingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDepartmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSeminarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractualEmployeesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentDateAndTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnection;
        private System.Windows.Forms.Panel panel1;
    }
}




namespace HRISCapsu
{
    partial class frmViewEmployeesReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.hriscapsuDataSet = new HRISCapsu.hriscapsuDataSet();
            this.view_employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_employeesTableAdapter = new HRISCapsu.hriscapsuDataSetTableAdapters.view_employeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hriscapsuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_employeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.view_employeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // hriscapsuDataSet
            // 
            this.hriscapsuDataSet.DataSetName = "hriscapsuDataSet";
            this.hriscapsuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_employeesBindingSource
            // 
            this.view_employeesBindingSource.DataMember = "view_employees";
            this.view_employeesBindingSource.DataSource = this.hriscapsuDataSet;
            // 
            // view_employeesTableAdapter
            // 
            this.view_employeesTableAdapter.ClearBeforeFill = true;
            // 
            // frmViewEmployeesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "frmViewEmployeesReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Employees";
            this.Load += new System.EventHandler(this.frmViewEmployeesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hriscapsuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_employeesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource view_employeesBindingSource;
        private hriscapsuDataSet hriscapsuDataSet;
        private hriscapsuDataSetTableAdapters.view_employeesTableAdapter view_employeesTableAdapter;
    }
}
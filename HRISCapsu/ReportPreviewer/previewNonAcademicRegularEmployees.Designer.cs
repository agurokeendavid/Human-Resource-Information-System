namespace HRISCapsu.ReportPreviewer
{
    partial class previewNonAcademicRegularEmployees
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.nonAcademicRegularEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hRISDataSource = new HRISCapsu.HRISDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.nonAcademicRegularEmployeesTableAdapter = new HRISCapsu.HRISDataSourceTableAdapters.NonAcademicRegularEmployeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nonAcademicRegularEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nonAcademicRegularEmployeesBindingSource
            // 
            this.nonAcademicRegularEmployeesBindingSource.DataMember = "NonAcademicRegularEmployees";
            this.nonAcademicRegularEmployeesBindingSource.DataSource = this.hRISDataSource;
            // 
            // hRISDataSource
            // 
            this.hRISDataSource.DataSetName = "HRISDataSource";
            this.hRISDataSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "NonAcademicRegularEmployeesDataSet";
            reportDataSource3.Value = this.nonAcademicRegularEmployeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.rptNewRegularNonAcademicEmployees.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // nonAcademicRegularEmployeesTableAdapter
            // 
            this.nonAcademicRegularEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // previewNonAcademicRegularEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "previewNonAcademicRegularEmployees";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non - Academic Employees";
            this.Load += new System.EventHandler(this.previewNonAcademicRegularEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nonAcademicRegularEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HRISDataSource hRISDataSource;
        private System.Windows.Forms.BindingSource nonAcademicRegularEmployeesBindingSource;
        private HRISDataSourceTableAdapters.NonAcademicRegularEmployeesTableAdapter nonAcademicRegularEmployeesTableAdapter;
    }
}
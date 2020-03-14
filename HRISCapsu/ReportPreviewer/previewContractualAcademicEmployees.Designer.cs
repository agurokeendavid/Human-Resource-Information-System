namespace HRISCapsu.ReportPreviewer
{
    partial class previewContractualAcademicEmployees
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.contractualAcademicEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hRISDataSource = new HRISCapsu.HRISDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.contractualAcademicEmployeesTableAdapter = new HRISCapsu.HRISDataSourceTableAdapters.ContractualAcademicEmployeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.contractualAcademicEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // contractualAcademicEmployeesBindingSource
            // 
            this.contractualAcademicEmployeesBindingSource.DataMember = "ContractualAcademicEmployees";
            this.contractualAcademicEmployeesBindingSource.DataSource = this.hRISDataSource;
            // 
            // hRISDataSource
            // 
            this.hRISDataSource.DataSetName = "HRISDataSource";
            this.hRISDataSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "ContractualAcademicEmployeesDataSet";
            reportDataSource4.Value = this.contractualAcademicEmployeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.rptNewContractualAcademicEmployees.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // contractualAcademicEmployeesTableAdapter
            // 
            this.contractualAcademicEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // previewContractualAcademicEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "previewContractualAcademicEmployees";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academic Employees";
            this.Load += new System.EventHandler(this.previewContractualAcademicEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contractualAcademicEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HRISDataSource hRISDataSource;
        private System.Windows.Forms.BindingSource contractualAcademicEmployeesBindingSource;
        private HRISDataSourceTableAdapters.ContractualAcademicEmployeesTableAdapter contractualAcademicEmployeesTableAdapter;
    }
}
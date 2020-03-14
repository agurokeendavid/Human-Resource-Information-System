namespace HRISCapsu.ReportPreviewer
{
    partial class previewAllEmployees
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
            this.allEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hRISDataSource = new HRISCapsu.HRISDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.allEmployeesTableAdapter = new HRISCapsu.HRISDataSourceTableAdapters.AllEmployeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.allEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // allEmployeesBindingSource
            // 
            this.allEmployeesBindingSource.DataMember = "AllEmployees";
            this.allEmployeesBindingSource.DataSource = this.hRISDataSource;
            // 
            // hRISDataSource
            // 
            this.hRISDataSource.DataSetName = "HRISDataSource";
            this.hRISDataSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "AllEmployeesDataSet";
            reportDataSource4.Value = this.allEmployeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.rptNewAllEmployees.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // allEmployeesTableAdapter
            // 
            this.allEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // previewAllEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "previewAllEmployees";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Employees";
            this.Load += new System.EventHandler(this.previewAllEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HRISDataSource hRISDataSource;
        private System.Windows.Forms.BindingSource allEmployeesBindingSource;
        private HRISDataSourceTableAdapters.AllEmployeesTableAdapter allEmployeesTableAdapter;
    }
}
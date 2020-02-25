namespace HRISCapsu
{
    partial class test1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.view_academic_employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HRISDataSource = new HRISCapsu.HRISDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.view_academic_employeesTableAdapter = new HRISCapsu.HRISDataSourceTableAdapters.view_academic_employeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.view_academic_employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRISDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // view_academic_employeesBindingSource
            // 
            this.view_academic_employeesBindingSource.DataMember = "view_academic_employees";
            this.view_academic_employeesBindingSource.DataSource = this.HRISDataSource;
            // 
            // HRISDataSource
            // 
            this.HRISDataSource.DataSetName = "HRISDataSource";
            this.HRISDataSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.view_academic_employeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.rptAcademic.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // view_academic_employeesTableAdapter
            // 
            this.view_academic_employeesTableAdapter.ClearBeforeFill = true;
            // 
            // test1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "test1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acamics Report";
            this.Load += new System.EventHandler(this.test1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view_academic_employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRISDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource view_academic_employeesBindingSource;
        private HRISDataSource HRISDataSource;
        private HRISDataSourceTableAdapters.view_academic_employeesTableAdapter view_academic_employeesTableAdapter;
    }
}
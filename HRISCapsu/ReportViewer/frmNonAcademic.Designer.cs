namespace HRISCapsu.ReportViewer
{
    partial class frmNonAcademic
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
            this.hrisDataSource1 = new HRISCapsu.HRISDataSource();
            this.viewnonacademicemployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_nonacademic_employeesTableAdapter = new HRISCapsu.HRISDataSourceTableAdapters.view_nonacademic_employeesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hrisDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewnonacademicemployeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.viewnonacademicemployeesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.rptNonAcademic.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // hrisDataSource1
            // 
            this.hrisDataSource1.DataSetName = "HRISDataSource";
            this.hrisDataSource1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewnonacademicemployeesBindingSource
            // 
            this.viewnonacademicemployeesBindingSource.DataMember = "view_nonacademic_employees";
            this.viewnonacademicemployeesBindingSource.DataSource = this.hrisDataSource1;
            // 
            // view_nonacademic_employeesTableAdapter
            // 
            this.view_nonacademic_employeesTableAdapter.ClearBeforeFill = true;
            // 
            // frmNonAcademic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmNonAcademic";
            this.Text = "frmNonAcademic";
            this.Load += new System.EventHandler(this.frmNonAcademic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hrisDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewnonacademicemployeesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HRISDataSource hrisDataSource1;
        private System.Windows.Forms.BindingSource viewnonacademicemployeesBindingSource;
        private HRISDataSourceTableAdapters.view_nonacademic_employeesTableAdapter view_nonacademic_employeesTableAdapter;
    }
}
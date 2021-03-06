﻿namespace HRISCapsu.ReportPreviewer
{
    partial class previewSeminarEmployeeList
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
            this.hRISDataSource = new HRISCapsu.HRISDataSource();
            this.employeeSeminarListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeSeminarListTableAdapter = new HRISCapsu.HRISDataSourceTableAdapters.EmployeeSeminarListTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSeminarListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.employeeSeminarListBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HRISCapsu.Reports.rptSeminarList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // hRISDataSource
            // 
            this.hRISDataSource.DataSetName = "HRISDataSource";
            this.hRISDataSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeSeminarListBindingSource
            // 
            this.employeeSeminarListBindingSource.DataMember = "EmployeeSeminarList";
            this.employeeSeminarListBindingSource.DataSource = this.hRISDataSource;
            // 
            // employeeSeminarListTableAdapter
            // 
            this.employeeSeminarListTableAdapter.ClearBeforeFill = true;
            // 
            // previewSeminarEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "previewSeminarEmployeeList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Seminar List";
            this.Load += new System.EventHandler(this.previewSeminarEmployeeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hRISDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSeminarListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HRISDataSource hRISDataSource;
        private System.Windows.Forms.BindingSource employeeSeminarListBindingSource;
        private HRISDataSourceTableAdapters.EmployeeSeminarListTableAdapter employeeSeminarListTableAdapter;
    }
}
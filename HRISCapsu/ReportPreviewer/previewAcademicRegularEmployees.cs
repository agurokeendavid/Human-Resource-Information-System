﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRISCapsu.ReportPreviewer
{
    public partial class previewAcademicRegularEmployees : Form
    {
        public previewAcademicRegularEmployees()
        {
            InitializeComponent();
        }

        private void previewAcademicRegularEmployees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.AcademicRegularEmployees' table. You can move, or remove it, as needed.
            this.academicRegularEmployeesTableAdapter.Fill(this.hRISDataSource.AcademicRegularEmployees);

            this.reportViewer1.RefreshReport();
        }
    }
}

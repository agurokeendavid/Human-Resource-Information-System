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
    public partial class previewContractualAcademicEmployees : Form
    {
        public previewContractualAcademicEmployees()
        {
            InitializeComponent();
        }

        private void previewContractualAcademicEmployees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRISDataSource.ContractualAcademicEmployees' table. You can move, or remove it, as needed.
            this.contractualAcademicEmployeesTableAdapter.Fill(this.hRISDataSource.ContractualAcademicEmployees);

            this.reportViewer1.RefreshReport();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppGipTesting
{
    public partial class FormSolution : Form
    {
        private readonly FormSolutionManagement _parent;
        public string strId, strProblem, strSolution, strCategory, strSubcategory;

        public FormSolution(FormSolutionManagement parent)
        {
            InitializeComponent();
            _parent = parent;

            DbSolution.LoadCategories("SELECT * FROM category;", "name", cmbCategory);
            DbSolution.LoadCategories("SELECT * FROM subcategory;", "name", cmbSubcategory);
        }

        private void FormSolution_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        public void UpdateInfo()
        {
            lblText.Text = "Update Solution";
            btnSave.Text = "Update";
            ActiveForm.Text = "Update Solution";
            txtProblem.Text = strProblem;
            txtSolution.Text = strSolution;
            cmbCategory.SelectedItem = strCategory;
            cmbSubcategory.SelectedItem = strSubcategory;
        }

        public void SaveInfo()
        {
            lblText.Text = "Add Solution";
            btnSave.Text = "Save";
        }

        public void Clear()
        {
            txtProblem.Text = string.Empty;
            txtSolution.Text = string.Empty;
            cmbCategory.SelectedIndex = -1;
            cmbSubcategory.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProblem.Text.Trim().Length < 5)
            {
                MessageBox.Show("Problem title is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSolution.Text.Trim().Length < 5)
            {
                MessageBox.Show("Solution is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Category selection is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbSubcategory.SelectedIndex == -1)
            {
                MessageBox.Show("Subcategory selection is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnSave.Text == "Save")
            {
                Solution sol = new Solution(txtProblem.Text.Trim(), txtSolution.Text.Trim(), cmbCategory.SelectedItem.ToString(), cmbSubcategory.SelectedItem.ToString());
                DbSolution.AddSolution(sol);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                Solution sol = new Solution(txtProblem.Text.Trim(), txtSolution.Text.Trim(), cmbCategory.SelectedItem.ToString(), cmbSubcategory.SelectedItem.ToString());
                DbSolution.UpdateSolution(sol, strId);
            }
            _parent.Display();
        }
    }
}
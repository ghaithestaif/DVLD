using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DetainLicense
{
    public partial class frmDetainLicenseList : Form
    {

        DataTable _DetainLicenseList;
        public frmDetainLicenseList()
        {
            InitializeComponent();
        }
        void _FormatGridView()
        {

            txtNumberOfRecords.Text = dgvDetainLicenseList.Rows.Count.ToString();

            if (dgvDetainLicenseList.Rows.Count > 0)
            {
                dgvDetainLicenseList    .Columns[0].HeaderText = "D.ID";
                dgvDetainLicenseList.Columns[0].Width = 90;

                dgvDetainLicenseList.Columns[1].HeaderText = "L.ID";
                dgvDetainLicenseList.Columns[1].Width = 90;

                dgvDetainLicenseList.Columns[2].HeaderText = "D.Date";
                dgvDetainLicenseList.Columns[2].Width = 160;

                dgvDetainLicenseList.Columns[3].HeaderText = "Is Released";
                dgvDetainLicenseList.Columns[3].Width = 110;

                dgvDetainLicenseList.Columns[4].HeaderText = "Fine Fees";
                dgvDetainLicenseList.Columns[4].Width = 110;

                dgvDetainLicenseList.Columns[5].HeaderText = "Release Date";
                dgvDetainLicenseList.Columns[5].Width = 160;

                dgvDetainLicenseList.Columns[6].HeaderText = "N.No.";
                dgvDetainLicenseList.Columns[6].Width = 90;

                dgvDetainLicenseList.Columns[7].HeaderText = "Full Name";
                dgvDetainLicenseList.Columns[7].Width = 330;

                dgvDetainLicenseList.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainLicenseList.Columns[8].Width = 150;

            }
        }
        private void frmDetainLicenseList_Load(object sender, EventArgs e)
        {
            _DetainLicenseList=clsDetainLicense.GetAll();
            dgvDetainLicenseList.DataSource = _DetainLicenseList;
            _FormatGridView();

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";

               switch (cbFilter.Text)
                {
                    case "Detain ID":
                        ColumnName = "DetainID";
                        break;
                    case "License ID":
                        ColumnName = "LicenseID";
                        break;
                    case "National No":
                        ColumnName = "NationalNo";
                        break;
                    case "FullName":
                         ColumnName = "FullName";
                         break;
                    default:
                        ColumnName = "";
                        break;
                }
            

            if(ColumnName== ""||txtFilter.Text.Trim()=="")
            {
                _DetainLicenseList.DefaultView.RowFilter = string.Empty;
                return;
            }



            if (ColumnName== "DetainID"|| ColumnName == "LicenseID")
            {
                _DetainLicenseList.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtFilter.Text.Trim());
            }
            else
            {
                _DetainLicenseList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", ColumnName, txtFilter.Text);
            }



        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedItem== "Is Released")
            {
                txtFilter.Enabled = false;
                txtFilter.Visible = false;
                cbYesNo.Visible = true;
                cbYesNo.Enabled = true;
            }
            else
            {
                txtFilter.Enabled = true;
                txtFilter.Visible = true;
                cbYesNo.Visible = false;
                cbYesNo.Enabled = false;
            }
            if (cbFilter.SelectedItem == "None")
                _DetainLicenseList.DefaultView.RowFilter = string.Empty;



        }

        private void cbYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
                _DetainLicenseList.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsReleased", cbYesNo.SelectedIndex);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem == "Detain ID" || cbFilter.SelectedItem == "License ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {

            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            this.frmDetainLicenseList_Load(null, null);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();

            this.frmDetainLicenseList_Load(null, null);
        }
    }
}

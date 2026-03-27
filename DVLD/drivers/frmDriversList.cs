using DVLD.License;
using DVLD.People;
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

namespace DVLD.drivers
{
    public partial class frmDriversList : Form
    {
        DataTable _dtDrivers;
        public frmDriversList()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            _dtDrivers = clsDriver.GetAll();
            dgvDrivers.DataSource = _dtDrivers;
            lblRecordsCount.Text=_dtDrivers.Rows.Count.ToString();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }
        }
        private void frmDriversList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            LoadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0) { txtFilterValue.Enabled = false; txtFilterValue.Visible = false; }
            else
            {
                txtFilterValue.Enabled = true; 
                txtFilterValue.Visible = true;
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());


            lblRecordsCount.Text = _dtDrivers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedFilter = cbFilterBy.SelectedItem?.ToString();

            // Allow control keys (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            if (selectedFilter == "Driver ID" || selectedFilter == "Person ID")
            {
                // Allow ONLY numbers
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                // Allow letters and numbers
                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt16(dgvDrivers.CurrentRow.Cells[1].Value);
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt16(dgvDrivers.CurrentRow.Cells[1].Value);

            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(PersonID);
            frm.ShowDialog();

        }
    }
}

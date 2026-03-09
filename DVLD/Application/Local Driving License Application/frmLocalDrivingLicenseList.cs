using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;
using static DVLD_Business.clsApplication;

namespace DVLD.Application
{
    public partial class frmLocalDrivingLicenseList : Form
    {
        public frmLocalDrivingLicenseList()
        {
            InitializeComponent();
        }

        private DataTable _dtLocal; // private table (load once)
        private void _FormatGrid()
        {
            if (LocalDrivingLicenseGridView.Columns.Count == 0) return;

            LocalDrivingLicenseGridView.Columns[0].HeaderText = "L.D.L.AppID";
            LocalDrivingLicenseGridView.Columns[0].Width = 70;

            LocalDrivingLicenseGridView.Columns[1].Width = 180;
            LocalDrivingLicenseGridView.Columns[2].Width = 100;
            LocalDrivingLicenseGridView.Columns[3].Width = 250;
            LocalDrivingLicenseGridView.Columns[4].Width = 200;
        }
        private void frmLocalDrivingLicenseList_Load(object sender, EventArgs e)
        {
            _dtLocal = clsLocalDrivingLicenseApplication.GetAll();
            LocalDrivingLicenseGridView.DataSource = _dtLocal;
            _FormatGrid();
            cbFilter.DataSource = Enum.GetValues(typeof(DVLD_General.Common.LocalDrivingLicenseApplicationFilter));
            cbFilter.SelectedItem = DVLD_General.Common.LocalDrivingLicenseApplicationFilter.None;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (_dtLocal == null) return;

            DVLD_General.Common.LocalDrivingLicenseApplicationFilter filter =
                (DVLD_General.Common.LocalDrivingLicenseApplicationFilter)cbFilter.SelectedItem;

            if (filter == DVLD_General.Common.LocalDrivingLicenseApplicationFilter.None)
            {
                LocalDrivingLicenseGridView.DataSource = _dtLocal;
                _FormatGrid();
                return;
            }

            DataView dv = _dtLocal.DefaultView;

            // Here you set RowFilter based on filter type
            // Example:
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                dv.RowFilter = "";
            }
            else if (int.TryParse(txtFilter.Text, out int id))
            {
                dv.RowFilter = "LocalDrivingLicenseApplicationID = " + id;
            }
            else
            {
                dv.RowFilter = ""; // or show message: only numbers allowed
            }

            if (filter == DVLD_General.Common.LocalDrivingLicenseApplicationFilter.FullName)
            {
                dv.RowFilter = $"FullName LIKE '%{txtFilter.Text}%'";
            }
            else if(filter == DVLD_General.Common.LocalDrivingLicenseApplicationFilter.NationalNo)
            {
                dv.RowFilter = $"NationalNo LIKE '%{txtFilter.Text}%'";

            }
            else if(filter == DVLD_General.Common.LocalDrivingLicenseApplicationFilter.status)
            {
                dv.RowFilter = $"Status LIKE '%{txtFilter.Text}%'";
            }
            // Add more filters as needed

            LocalDrivingLicenseGridView.DataSource = dv;
            _FormatGrid();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Enabled = true;

            if (DVLD_General.Common.LocalDrivingLicenseApplicationFilter.None ==
                (DVLD_General.Common.LocalDrivingLicenseApplicationFilter)cbFilter.SelectedItem)
            {
                txtFilter.Enabled = false;
                LocalDrivingLicenseGridView.DataSource = _dtLocal;
            }
        }

        private void btnAddNewPersonButton_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication form =
                new frmAddEditLocalDrivingLicenseApplication(-1);
            form.OnApplicationSaved+= () =>
            {
                // reload data after add
                _dtLocal = clsLocalDrivingLicenseApplication.GetAll();
                LocalDrivingLicenseGridView.DataSource = _dtLocal;
                _FormatGrid();
            };

            form.ShowDialog();

            // optional: reload data after add
            //_dtLocal = clsLocalDrivingLicenseApplication.GetAll();
            //LocalDrivingLicenseGridView.DataSource = _dtLocal;
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected application ID
            int ID= Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication selectedApp = clsLocalDrivingLicenseApplication.Find(ID);
            if (selectedApp != null) {

                //check if it's already cancelled or completed
                if(selectedApp.ApplicationStatus != enApplicationStatus.New)
                {
                    return;
                }


                if (selectedApp.Cancel())
                {
                    // reload data
                    _dtLocal = clsLocalDrivingLicenseApplication.GetAll();
                    LocalDrivingLicenseGridView.DataSource = _dtLocal;
                    _FormatGrid();
                }
                else
                {
                    MessageBox.Show("Failed to cancel application.");
                }



            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Failed to cancel application.");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);

            frmAddEditLocalDrivingLicenseApplication form =
                new frmAddEditLocalDrivingLicenseApplication(ID);
            form.OnApplicationSaved += () =>
            {
                // reload data after edit
                _dtLocal = clsLocalDrivingLicenseApplication.GetAll();
                LocalDrivingLicenseGridView.DataSource = _dtLocal;
                _FormatGrid();
            };
            
            form.ShowDialog();
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);


            if (clsLocalDrivingLicenseApplication.Delete(ID))
            {
                // reload data
                _dtLocal = clsLocalDrivingLicenseApplication.GetAll();
                LocalDrivingLicenseGridView.DataSource = _dtLocal;
                _FormatGrid();
            }
            else
            {
                MessageBox.Show("Failed to delete application.");
            }

        }
    }
}
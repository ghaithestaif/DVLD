using DVLD.License;
using DVLD.Tests;
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
        clsLocalDrivingLicenseApplication _selectedApp;
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
            frmLocalDrivingLicenseList_Load(null, null);

            // optional: reload data after add
            //_dtLocal = clsLocalDrivingLicenseApplication.GetAll();
            //LocalDrivingLicenseGridView.DataSource = _dtLocal;
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected application ID
            int ID= Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication selectedApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(ID);
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

                frmLocalDrivingLicenseList_Load(null, null);


            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LicenseID = clsLicense.GetLicenseIDByApplicationID(_selectedApp.ApplicationID);
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();


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
            frmLocalDrivingLicenseList_Load(null, null);
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
            frmLocalDrivingLicenseList_Load(null, null);


        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int ID = Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication selectedApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(ID);
            _selectedApp = selectedApp;
            bool visionTest = selectedApp.DoesPersonPassedTest(1);
            bool WrittenTest = selectedApp.DoesPersonPassedTest(2);
            bool StreetTest = selectedApp.DoesPersonPassedTest(3);

            //check if the application is cancelled or completed, if so disable all options except show license

            if ( selectedApp.ApplicationStatus == enApplicationStatus.Cancelled)
            {
                CancelApplicaitonToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                DeleteApplicationToolStripMenuItem.Enabled = false;
                ScheduleTestsMenue.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }



            //for now the following items are going to be disabled4 until we implement the license issuing process
            if(visionTest && WrittenTest && StreetTest)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true; 
            }
            else
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }

            //if this person has 
            if (clsLicense.DoesPersonHaveLicesne(selectedApp.ApplicantPerson.PersonID, selectedApp.LicenseClass.LicenseClassID))
            {
                editToolStripMenuItem.Enabled = false;
                CancelApplicaitonToolStripMenuItem.Enabled = false;
                DeleteApplicationToolStripMenuItem.Enabled = false;
                showDetailsToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else
            {
                showLicenseToolStripMenuItem.Enabled = false;

            }





                // reset the items
                scheduleVisionTestToolStripMenuItem.Enabled = true;
            scheduleWrittenTestToolStripMenuItem.Enabled = true;
            scheduleStreetTestToolStripMenuItem.Enabled = true;

            // here I check the tests and set the visibility of menu items accordingly
            

            ScheduleTestsMenue.Enabled = (visionTest&&WrittenTest&&StreetTest)? false : true;

            if (!visionTest)
            {
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
            }
            else if(!WrittenTest)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if(!StreetTest)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
            }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);
            frmVisionTests frm = new frmVisionTests(LocalDrivingLicenseApplicationID,clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmLocalDrivingLicenseList_Load(null, null);

        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);
            frmVisionTests frm = new frmVisionTests(LocalDrivingLicenseApplicationID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmLocalDrivingLicenseList_Load(null, null);



        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationInfo frm = new frmApplicationInfo(Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            frmLocalDrivingLicenseList_Load(null, null);

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value);
            frmVisionTests frm = new frmVisionTests(LocalDrivingLicenseApplicationID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmLocalDrivingLicenseList_Load(null, null);


        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLicenseFirstTime frm = new frmIssueLicenseFirstTime(Convert.ToInt32(LocalDrivingLicenseGridView.CurrentRow.Cells[0].Value)); 
            frm.ShowDialog();
            frmLocalDrivingLicenseList_Load(null, null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID=_selectedApp.ApplicantPerson.PersonID;
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
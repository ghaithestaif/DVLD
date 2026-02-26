using DVLD_Buisness;
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

namespace DVLD.Application
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        int _ID = 0;
        public int ID
        {
            get
            {
                return _ID;
            }
        }
        enum enApplicationMode { Add, Edit }
        enApplicationMode _applicationMode;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication=new clsLocalDrivingLicenseApplication();
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
        {
            get
            {
                return _LocalDrivingLicenseApplication;
            }
        }

        void _LaodApplicatoinCalsses()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["ClassName"]);
            }
            
            comboBox1.SelectedIndex = 0;
        }
        void _FillApplicationFields()
        {
            _LaodApplicatoinCalsses(); 
        lblCreatedByUser.Text = Global_Classes.General.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = "15";

        }

        public frmAddEditLocalDrivingLicenseApplication(int ID)
        {
                _ID = ID;
                if (ID == -1)
                {
                    _applicationMode = enApplicationMode.Add;
                }
                else
                {
                    _applicationMode = enApplicationMode.Edit;

                }
            InitializeComponent();
        }

        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillApplicationFields();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (personDetailsWithFilters1.PersonID==-1)
            {
                MessageBox.Show("Please select a person to continue");
                e.Cancel= true;
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplication Application=new clsApplication();


           Application.ApplicantPerson = DVLD_Business.People.Find(personDetailsWithFilters1.PersonID);
           Application.ApplicationDate = DateTime.Now;
           Application.CreatedByUser = Global_Classes.General.CurrentUser;
           Application.PaidFees = 15;
           Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
           Application.ApplicationType = clsApplicationType.Find(1);
           Application.LastStatusDate=DateTime.Now;
            if (!Application.Save())
            {
                MessageBox.Show("An error occurred while saving the application. Please try again.");
                return;

            }

            _LocalDrivingLicenseApplication.LicenseClass = clsLicenseClass.Find(comboBox1.SelectedIndex+1);
            _LocalDrivingLicenseApplication.Application = Application;

            if (_applicationMode == enApplicationMode.Add)
            {
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("Application added successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occurred while saving the application. Please try again.");
                    return;

                }
            }
             else if (_applicationMode == enApplicationMode.Edit)
            {
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("Application updated successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occurred while updating the application. Please try again.");
                }
            }



        }
    }
}

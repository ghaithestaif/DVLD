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
using DVLD_Business;

namespace DVLD.Application
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        int _LocalDrivingLicenseApplicationID = 0;
        public event Action OnApplicationSaved;
        public int ID
        {
            get
            {
                return _LocalDrivingLicenseApplicationID;
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
                _LocalDrivingLicenseApplicationID = ID;
                
            InitializeComponent();
        }
        void FillFormFieldsWithObject()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);
            personDetailsWithFilters1.loadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPerson.PersonID);
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblCreatedByUser.Text = _LocalDrivingLicenseApplication.CreatedByUser.UserName;
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            comboBox1.SelectedIndex = _LocalDrivingLicenseApplication.LicenseClass.LicenseClassID-1;
            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
        }
        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillApplicationFields();
            if (_LocalDrivingLicenseApplicationID != -1) {

                 FillFormFieldsWithObject();
            }
            if (_LocalDrivingLicenseApplicationID == -1)
            {
                lFormTitle.Text = "Add New Local Driving License Application";
                _applicationMode = enApplicationMode.Add;

            }
            else
            {
                _applicationMode = enApplicationMode.Edit;
                lFormTitle.Text = "Edit Local Driving License Application";
            }
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

            //validate
            if (clsLocalDrivingLicenseApplication.DoesPersonHaveClassApplication(personDetailsWithFilters1.PersonID,comboBox1.SelectedIndex+1,1))
            {
                MessageBox.Show("this person already has the same application");
                return;
            }





            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.CreatedByUser = Global_Classes.General.CurrentUser;
            _LocalDrivingLicenseApplication.PaidFees = 15;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicationType = clsApplicationType.Find(1);
            _LocalDrivingLicenseApplication.LastStatusDate=DateTime.Now;
            _LocalDrivingLicenseApplication.LicenseClass = clsLicenseClass.Find(comboBox1.SelectedIndex+1);

            if (_applicationMode == enApplicationMode.Add)
            {
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("Application added successfully");
                    OnApplicationSaved?.Invoke();
                    _applicationMode= enApplicationMode.Edit;
                    lFormTitle.Text = "Edit Local Driving License Application";


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
                    OnApplicationSaved?.Invoke();
                }
                else
                {
                    MessageBox.Show("An error occurred while updating the application. Please try again.");
                }
            }



        }

        private void personDetailsWithFilters1_OnPersonSelected(int obj)
        {
             
            _LocalDrivingLicenseApplication.ApplicantPerson = DVLD_Business.People.Find(obj);
        }
    }
}

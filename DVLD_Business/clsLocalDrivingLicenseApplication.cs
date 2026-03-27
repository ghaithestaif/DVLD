using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    // Enum placed in business layer so UI and Data layers can reference the semantic values.

    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { enUpdate, enAddnew }
        private enMode _Mode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        //  public clsApplication Application { get; set; }


        public clsLicenseClass LicenseClass { get; set; } // numeric ID stored in DB

        // Convenience property to work with enum in business/UI layers


        public clsLocalDrivingLicenseApplication()
        {
            _Mode = enMode.enAddnew;
            LocalDrivingLicenseApplicationID = -1;
        }

        private clsLocalDrivingLicenseApplication(
            int localDrivingLicenseApplicationID,
            int applicationID,
            int licenseClassID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            clsApplication App = clsApplication.Find(applicationID);

            base.PaidFees = App.PaidFees;
            base.LastStatusDate = App.LastStatusDate;
            base.ApplicantPerson = App.ApplicantPerson;
            base.ApplicationDate = App.ApplicationDate;
            base.ApplicationID = App.ApplicationID;
            base.ApplicationStatus = App.ApplicationStatus;
            base.ApplicationTypeID = App.ApplicationTypeID;
            base.CreatedByUser = App.CreatedByUser;
            LicenseClass = clsLicenseClass.Find(licenseClassID);
            _Mode = enMode.enUpdate;
        }

        private int _AddNew()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(
                ApplicationID,
                LicenseClass.LicenseClassID
            );
        }

        private bool _Update()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(
                LocalDrivingLicenseApplicationID,
                ApplicationID,
                LicenseClass.LicenseClassID
            );
        }

        public bool Save()
        {
            //save the the objects first to ensure we have valid IDs for the application and license class
            base.Mode = _Mode == enMode.enAddnew ? clsApplication.enMode.Addnew : clsApplication.enMode.Update;
            if (!base.Save())
            {
                return false;
            }

            if (!LicenseClass.Save())
            {
                return false;
            }

            if (_Mode == enMode.enAddnew)
            {
                LocalDrivingLicenseApplicationID = _AddNew();
                _Mode = enMode.enUpdate;
                return LocalDrivingLicenseApplicationID > 0;
            }
            else if (_Mode == enMode.enUpdate)
            {
                return _Update();
            }
            else
            {
                return false;
            }
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = -1;
            int licenseClassID = 0;

            bool found = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.FindByApplicationID(
                 applicationID,
                ref localDrivingLicenseApplicationID,
                ref licenseClassID
            );

            if (!found)
                return null;

            return new clsLocalDrivingLicenseApplication(
                localDrivingLicenseApplicationID,
                applicationID,
                licenseClassID
            );



        }
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseApplicationID(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1;
            int licenseClassID = 0;

            bool found = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.FindLocalDrivingLicenseApplicationByID(
                localDrivingLicenseApplicationID,
                ref applicationID,
                ref licenseClassID
            );

            if (!found)
                return null;

            return new clsLocalDrivingLicenseApplication(
                localDrivingLicenseApplicationID,
                applicationID,
                licenseClassID
            );
        }

        public static DataTable GetAll()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.GetAllApplications();
        }
        public static bool Delete(int ID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID);
        }

        public static bool DoesPersonHaveClassApplication(int PersonID, int ApplicationClassID, int ApplicationType)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPersonHaveAnActiveApplication(PersonID, ApplicationClassID, ApplicationType);
        }


        public static bool DoesPersonHasAnActiveTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPersonHasAnActiveTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool DoesPersonHasAnActiveTest(int TestTypeID)
        {
            return DoesPersonHasAnActiveTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool DoesPersonPassedTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPersonPassedTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool DoesPersonPassedTest(int TestTypeID)
        {
            return DoesPersonPassedTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static byte PassedTestsByLocalDrivingApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.PassedTestsBylocalDrivingApplicationID(LocalDrivingLicenseApplicationID);

        }
        public byte PassedTests()
        {
            return PassedTestsByLocalDrivingApplicationID(this.LocalDrivingLicenseApplicationID);
        }
        public static byte PassedTextApplicationID(int ApplicationID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.PassedTestsApplicationID(ApplicationID);

        }
        public static DataTable GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static byte numberOfTestsTrials(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.numberOfTestsTrials(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public byte NumberOfTestsTrials(int TestTypeID)
        {
            return numberOfTestsTrials(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static bool DoesPersonAttendedTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return numberOfTestsTrials(LocalDrivingLicenseApplicationID, TestTypeID) > 0;


        }
       public bool DoesPersonAttendedTest(int TestTypeID)
            {
                return DoesPersonAttendedTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
       public bool HasPersonPassedAllTests()
        {
            return this.DoesPersonPassedTest(1)&& this.DoesPersonPassedTest(2)&&this.DoesPersonPassedTest(3);
        } 
        public DataTable GetAllTestAppointments(int TestTypeID)
        {
            return GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }


        public int IssueLicenseTheFirstTime(string Notes,int userID)
        {

            //check if the person already has this license 
            //not implemented yet
            if (clsLicense.DoesPersonHaveLicesne(this.ApplicantPerson.PersonID, this.LicenseClass.LicenseClassID))
            {
                return -1;
            }


            // check if the person has passed all the tests
            if (!this.HasPersonPassedAllTests())
            {
                return -1;
            }

            //check if the application is cancelled 
            if (!(this.ApplicationStatus == enApplicationStatus.New))
            {
                return -1;
            }

            //this person is going to be a driver first
            // so we are going to make this person a driver and then issue the license
            //check if the person is already is a driver
            int DriverID = -1;
            if (!clsDriver.IsPersonADriver(this.ApplicantPerson.PersonID))
            {
                clsDriver NewDriver = new clsDriver();
                NewDriver.PersonID = this.ApplicantPerson.PersonID;
                NewDriver.CreatedDate = DateTime.Now;
                NewDriver.CreatedByUserID = this.CreatedByUser.UserID;
                if (!NewDriver.Save())
                {
                    return -1;
                }
                DriverID = NewDriver.DriverID;
            }
            else
            {
                DriverID = clsDriver.FindByPersonID(this.ApplicantPerson.PersonID);
            }

            //now we create the License Record
            clsLicense NewLicense=new clsLicense();

            NewLicense.Notes = Notes;
            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.CreatedByUserID = userID;
            NewLicense.IssueReason = (int)clsLicense.enIssueReason.FirstTime;
            NewLicense.IsActive = true;
            NewLicense.PaidFees =Convert.ToDecimal(this.LicenseClass.ClassFees);
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength);
            NewLicense.LicenseClassID = this.LicenseClass.LicenseClassID;
            NewLicense.DriverID = DriverID;

            if(!NewLicense.Save()) { return -1; }

            this.SetComplete();
            return NewLicense.LicenseID;









        }
    }
}
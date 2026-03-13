using DVLD_Buisness;
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
            clsApplication App =clsApplication.Find(applicationID);
            
            base.PaidFees = App.PaidFees;
            base.LastStatusDate = App.LastStatusDate;
            base.ApplicantPerson = App.ApplicantPerson;
            base.ApplicationDate = App.ApplicationDate;
            base.ApplicationID = App.ApplicationID;
            base.ApplicationStatus=App.ApplicationStatus;
            base.ApplicationType=App.ApplicationType;
            base.CreatedByUser=App.CreatedByUser;
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
            base.Mode= _Mode == enMode.enAddnew ? clsApplication.enMode.enAddnew : clsApplication.enMode.enUpdate;
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

        public static clsLocalDrivingLicenseApplication Find(int localDrivingLicenseApplicationID)
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

        public static bool DoesPersonHaveClassApplication(int PersonID, int ApplicationClassID,int ApplicationType)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPersonHaveAnActiveApplication(PersonID, ApplicationClassID, ApplicationType);
        }


        public static bool DoesPersonHasAnActiveTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPersonHasAnActiveTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool DoesPersonHasAnActiveTest( int TestTypeID)
        {
            return DoesPersonHasAnActiveTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool DoesPersonPassedTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPersonPassedTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool DoesPersonPassedTest( int TestTypeID)
        {
           return DoesPersonPassedTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

    }
}
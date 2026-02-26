using DVLD_Buisness;
using System;
using System.Data;

namespace DVLD_Business
{
    // Enum placed in business layer so UI and Data layers can reference the semantic values.
    
    public class clsLocalDrivingLicenseApplication
    {
        public enum enMode { enUpdate, enAddnew }
        private enMode _Mode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsApplication Application { get; set; }
        

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
            Application =clsApplication.Find(applicationID);
            LicenseClass = clsLicenseClass.Find(licenseClassID);
            _Mode = enMode.enUpdate;
        }

        private int _AddNew()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(
                Application.ApplicationID,
                LicenseClass.LicenseClassID
            );
        }

        private bool _Update()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(
                LocalDrivingLicenseApplicationID,
                Application.ApplicationID,
                LicenseClass.LicenseClassID
            );
        }

        public bool Save()
        {
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
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        public static bool Delete(int ID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID);
        }
    }
}
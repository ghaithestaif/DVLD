using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { enUpdate, enAddnew }
        private enMode _Mode;

        public int ApplicationID { get; set; }
        public DVLD_Business.People ApplicantPerson{ get; set; }
        public DateTime ApplicationDate { get; set; }
        public clsApplicationType ApplicationType { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public   clsUser CreatedByUser{ get; set; }

        public clsApplication()
        {
            _Mode = enMode.enAddnew;
            ApplicationID = -1;
        }

        private clsApplication(
            int applicationID,
            int applicantPersonID,
            DateTime applicationDate,
            int applicationTypeID,
            byte applicationStatus,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID)
        {
            ApplicationID = applicationID;
             ApplicantPerson= People.Find(applicantPersonID);
            ApplicationDate = applicationDate;
            ApplicationType = clsApplicationType.Find(applicationTypeID);
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUser = clsUser.Find(createdByUserID);
            _Mode = enMode.enUpdate;
        }

        // Business operations
        private int _AddNew()
        {
            return DVLD_DataAccess.clsApplicationData.AddNewApplication(
                ApplicantPerson.PersonID,
                ApplicationDate,
                ApplicationType.ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUser.UserID
            );
        }

        private bool _Update()
        {
            return DVLD_DataAccess.clsApplicationData.UpdateApplication(
                ApplicationID,
                ApplicantPerson.PersonID,
                ApplicationDate,
                ApplicationType.ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUser.UserID
            );
        }

        public bool Save()
        {
            if (_Mode == enMode.enAddnew)
            {
                ApplicationID = _AddNew();
                _Mode = enMode.enUpdate;
                return ApplicationID > 0;
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

        public static clsApplication Find(int applicationID)
        {
            int applicantPersonID = -1;
            DateTime applicationDate = DateTime.MinValue;
            int applicationTypeID = 0;
            byte applicationStatus = 0;
            DateTime lastStatusDate = DateTime.MinValue;
            decimal paidFees = 0m;
            int createdByUserID = 0;

            bool found = DVLD_DataAccess.clsApplicationData.FindApplicationByID(
                applicationID,
                ref applicantPersonID,
                ref applicationDate,
                ref applicationTypeID,
                ref applicationStatus,
                ref lastStatusDate,
                ref paidFees,
                ref createdByUserID
            );

            if (!found)
                return null;

            return new clsApplication(
                applicationID,
                applicantPersonID,
                applicationDate,
                applicationTypeID,
                applicationStatus,
                lastStatusDate,
                paidFees,
                createdByUserID
            );
        }

        public static DataTable GetAll()
        {
            return DVLD_DataAccess.clsApplicationData.GetAllApplications();
        }
    }
}

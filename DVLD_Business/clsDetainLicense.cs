using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetainLicense
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        // 🟢 Constructor (Add New)
        public clsDetainLicense()
        {
            this.DetainID = -1;
            Mode = enMode.AddNew;
        }

        // 🔒 Private constructor (for Find)
        private clsDetainLicense(
            int DetainID,
            int LicenseID,
            DateTime DetainDate,
            decimal FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        // 🔍 Find by DetainID
        public static clsDetainLicense Find(int DetainID)
        {
            int LicenseID = 0, CreatedByUserID = 0;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;
            DateTime? ReleaseDate = null;
            int? ReleasedByUserID = null, ReleaseApplicationID = null;

            if (clsDetainLicenseData.FindDetainByID(
                DetainID,
                ref LicenseID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased,
                ref ReleaseDate,
                ref ReleasedByUserID,
                ref ReleaseApplicationID))
            {
                return new clsDetainLicense(
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID);
            }

            return null;
        }


        public static clsDetainLicense FindDetainByLicenseID(int LicenseID)

        {
            int DetainID = 0, CreatedByUserID = 0;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;
            DateTime? ReleaseDate = null;
            int? ReleasedByUserID = null, ReleaseApplicationID = null;

            if (clsDetainLicenseData.FindDetainByLicenseID(
                LicenseID,
                ref DetainID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased,
                ref ReleaseDate,
                ref ReleasedByUserID,
                ref ReleaseApplicationID))
            {
                return new clsDetainLicense(
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID);
            }

            return null;

        }


        // ➕ Add New (PRIVATE)
        private bool _AddNew()
        {
            this.DetainID = clsDetainLicenseData.AddNewDetain(
                LicenseID,
                DetainDate,
                FineFees,
                CreatedByUserID,
                IsReleased,
                ReleaseDate,
                ReleasedByUserID,
                ReleaseApplicationID);

            return (this.DetainID != -1);
        }

        // ✏️ Update (PRIVATE)
        private bool _Update()
        {
            return clsDetainLicenseData.UpdateDetain(
                DetainID,
                LicenseID,
                DetainDate,
                FineFees,
                CreatedByUserID,
                IsReleased,
                ReleaseDate,
                ReleasedByUserID,
                ReleaseApplicationID);
        }

        // 💾 Save
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        // ❌ Delete
        public static bool Delete(int DetainID)
        {
            return clsDetainLicenseData.DeleteDetain(DetainID);
        }

        // 📊 Get All
        public static DataTable GetAll()
        {
            return clsDetainLicenseData.GetAllDetains();
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainLicenseData.IsLicenseDetained(LicenseID);


        }

        public static bool DetainLicense(clsLicense LicenseToDetain,decimal Fees,int UserID)
        {
            //check if the License is Not Detained
            if (IsLicenseDetained(LicenseToDetain.LicenseID))
            {
                return false; // License is already detained, cannot detain again
            }

            //check if the License is active
            if (LicenseToDetain.IsActive != true)
            {
                return false;
            }

            //now Detain the License 

            clsDetainLicense DetainedLicense=new clsDetainLicense();
            DetainedLicense.LicenseID = LicenseToDetain.LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = Fees;
            DetainedLicense.CreatedByUserID = UserID;
            DetainedLicense.IsReleased = false;
            DetainedLicense.ReleaseDate = null;
            DetainedLicense.ReleasedByUserID = null;
            DetainedLicense.ReleaseApplicationID = null;
            if(!DetainedLicense.Save())
            {
             return false; // Failed to save the detained license   
            }
            //Deactivata
            LicenseToDetain.IsActive = false;

            if (!LicenseToDetain.Save())
            {
                // Rollback the detained license if updating the license status fails
                clsDetainLicense.Delete(DetainedLicense.DetainID);
                return false; // Failed to update license status
            }

            return true; // Successfully detained the license
        }

        

        

    }


}

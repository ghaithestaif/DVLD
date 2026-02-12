using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
namespace DVLD_Business
{
    public class clsApplicationType
    {

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationType() { }

        private clsApplicationType(int id, string title, decimal fees)
        {
            ApplicationTypeID = id;
            ApplicationTypeTitle = title;
            ApplicationFees = fees;
        }

        public static clsApplicationType Find(int applicationTypeID)
        {
            string title = "";
            decimal fees = 0;

            if (clsApplicationTypeData.Find(applicationTypeID, ref title, ref fees))
            {
                return new clsApplicationType(applicationTypeID, title, fees);
            }
            else
            {
                return null;
            }
        }


        public  bool Update()
        {

            
            return clsApplicationTypeData.UpdateApplicationType(
                this.ApplicationTypeID,
                this.ApplicationTypeTitle,
                this.ApplicationFees);
        }
        public static DataTable GetAll()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }



    }
}

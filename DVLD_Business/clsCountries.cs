using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsCountries
    {
        public string Name { get; set; }
       public  int ID { get; set; }
        private clsCountries(string Name,int ID) {
            this .Name = Name;
            this.ID = ID;
        
        
        
        }
        public clsCountries() { }
        static public DataTable GetAllCountries()
        {
            return DVLD_DataAccess.clsCountries.GetAllCountries();
        }
        static public clsCountries Find(int ID)
        {
            string Name = "";
            DVLD_DataAccess.clsCountries.FindCountryByID(ID,  ref Name);
            return new clsCountries(Name, ID);
        }
    }
}

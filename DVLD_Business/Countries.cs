using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class Countries
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public Countries() { }
        private Countries(int countryID, string name)
        {
            this.CountryID = countryID;
            this.CountryName = name;
        }
        static public DataTable GetAllCountries()
        {
            return DVLD_DataAccess.Countries.GetAllCountries();
        }
        static public Countries Find(int countryID)
        {
            string Name = "";
            DVLD_DataAccess.Countries.FindCountryByID(countryID, ref Name);
            return new Countries(countryID, Name);
        }
    }
}

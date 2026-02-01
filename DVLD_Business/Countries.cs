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
        static public DataTable GetAllCountries()
        {
            return DVLD_DataAccess.Countries.GetAllCountries();
        }
    }
}

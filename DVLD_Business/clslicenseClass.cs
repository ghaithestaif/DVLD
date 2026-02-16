using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clslicenseClass
    {


        DataTable GetAll()
        {
            return DVLD_DataAccess.clsLicenseClassData.GetAll();
        }
    }
}

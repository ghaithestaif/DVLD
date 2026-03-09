using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_General
{
    public class Common
    {
        public enum LocalDrivingLicenseApplicationFilter
        {
            None,
            ID,
            NationalNo,
            FullName,
            status
        }
        public enum PeopleFilter
        {
            none,
            PersonID,
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            Gendor,
            Phone,
            Email,
            CountryID
        }
        public enum UsersFilter
        {
            None,        // no filter
            UserID,
            PersonID,
            UserName,
            FullName,
            IsActive
            
        }


    }
}

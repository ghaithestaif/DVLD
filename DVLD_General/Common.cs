using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_General
{
    public class Common
    {
        public enum PeopleFilterSort
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
        public enum SortType
        {
            Ascending,
            Descending
        }

    }
}

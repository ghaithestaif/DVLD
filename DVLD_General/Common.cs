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
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            DateOfBirth,
            Gender,
            Phone,
            Email,
            NationalityCountry
        }
        public enum SortType
        {
            Ascending,
            Descending
        }

    }
}

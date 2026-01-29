using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DVLD_General.Common.PeopleFilterSort n=new DVLD_General.Common.PeopleFilterSort();
            n = DVLD_General.Common.PeopleFilterSort.NationalNo;

            DVLD_General.Common.SortType s = new DVLD_General.Common.SortType();
            s = DVLD_General.Common.SortType.Ascending;

            DataTable dt = People.SortPeople(n, s);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["NationalNo"].ToString());
            }

        }
    }
}

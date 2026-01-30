using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.Validating
{
    static internal class clsValidating
    {
        static internal bool IsEmail(string email)
        {// must contain @gmail.
            if (!email.Contains("@gmail."))
                return false;

            //give the location of @gmail.
            int atIndex = email.IndexOf("@gmail.");

            // something before @gmail.
            if (atIndex == 0)
                return false;

            // something after @gmail.
            if (email.Length <= atIndex + 7)
                return false;

            // basic illegal spaces
            if (email.Contains(" "))
                return false;

            return true;


        }



    }
}

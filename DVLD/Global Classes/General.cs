using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DVLD.Global_Classes
{
    public class General
    {

      static   public clsUser CurrentUser=new clsUser();

        static public void RemeberUser(string UserName,string Password)
        {
             string directoryPath = System.IO.Directory.GetCurrentDirectory();
            string FileName="Data.txt";
         string  FileDestination=directoryPath+ "\\" + FileName;


            try
            {
                if (!File.Exists(FileDestination))
                {
                    File.Create(FileDestination).Close();
                }

                System.IO.File.WriteAllText(FileDestination, UserName + Environment.NewLine + Password);
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                Console.WriteLine("Error writing to file: " + ex.Message);
            }















        }

    }
}

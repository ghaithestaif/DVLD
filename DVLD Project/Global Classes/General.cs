using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DVLD_Business;

namespace DVLD.Global_Classes
{
    public class General
    {

         static   public clsUser CurrentUser=new clsUser();
        static public bool GetStoredInfo(ref string Pass, ref string UserName)
        {
            string directoryPath = System.IO.Directory.GetCurrentDirectory();
            string FileName = "Data.txt";
            string FileDestination = directoryPath + "\\" + FileName;

            if (!File.Exists(FileDestination))
            {
                return false;
            }
            string[] lines = System.IO.File.ReadAllLines(FileDestination);

            for (int i = 0; i < lines.Length; i++)
            {
                string item = lines[i].Trim();
                if (i == 0)
                {
                    UserName = item;
                }
                else
                {
                    Pass = item;
                }
            }
            return true;
        }
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

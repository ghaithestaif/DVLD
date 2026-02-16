using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace TestCode
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("=== DVLD Application Test ===");

          //  1.Create a new Application
            clsApplication app = new clsApplication
            {
                ApplicantPerson = People.Find(1), // Assume person with ID 1 exists
                ApplicationDate = DateTime.Now,
                ApplicationType = clsApplicationType.Find(1), // Assume type ID 1 exists
                ApplicationStatus = 1, // Example status
                LastStatusDate = DateTime.Now,
                PaidFees = 100.50m,
                CreatedByUser = clsUser.Find(1) // Assume user ID 1 exists
            };

            // 2. Save the new application
            if (app.Save())
            {
                Console.WriteLine($"New application saved successfully! ID: {app.ApplicationID}");
            }
            else
            {
                Console.WriteLine("Failed to save application.");
            }

            // 3. Update application
            app.PaidFees = 200.75m;
            app.ApplicationStatus = 2;

            if (app.Save())
            {
                Console.WriteLine("Application updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update application.");
            }

            //4.Find application by ID
           clsApplication foundApp = clsApplication.Find(app.ApplicationID);
            if (foundApp != null)
            {
                Console.WriteLine("Found application:");
                Console.WriteLine($"ID: {foundApp.ApplicationID}");
                Console.WriteLine($"Applicant Person ID: {foundApp.ApplicantPerson.PersonID}");
                Console.WriteLine($"Type ID: {foundApp.ApplicationType.ApplicationTypeID}");
                Console.WriteLine($"Status: {foundApp.ApplicationStatus}");
                Console.WriteLine($"Paid Fees: {foundApp.PaidFees}");
            }
            else
            {
                Console.WriteLine("Application not found.");
            }

            // 5. Display all applications
            DataTable allApps = clsApplication.GetAll();
            Console.WriteLine("\nAll Applications:");
            foreach (DataRow row in allApps.Rows)
            {
                Console.WriteLine($"ID: {row["ApplicationID"]}, Status: {row["ApplicationStatus"]}, Paid Fees: {row["PaidFees"]}");
            }

            Console.WriteLine("\nTest finished. Press any key to exit...");
            Console.ReadKey();

        }
    }
}

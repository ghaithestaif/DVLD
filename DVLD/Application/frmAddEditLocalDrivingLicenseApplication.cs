using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        int _ID = 0;
       public int ID { 
            get
            {
                return _ID;
            }
        }
        clsApplication _application = new clsApplication();
        public clsApplication Application { 
            get
            {
                return _application;
            }
        }
        public frmAddEditLocalDrivingLicenseApplication(int ID)
        {
            InitializeComponent();

        }

        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _application.ApplicantPerson = DVLD_Business.People.Find(personDetailsWithFilters1.PersonID); 

        }

        private void personDetailsWithFilters1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _application.ApplicantPerson = DVLD_Business.People.Find(personDetailsWithFilters1.PersonID);
        }
    }
}

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

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        int _PersonID;
        clsPeople _Person=new clsPeople();

        public frmAddUpdatePerson()
        {
            InitializeComponent();

        }
        public frmAddUpdatePerson(int PersonID)
        {

            InitializeComponent();

        }
        public void LoadFormTitle()
       {
            if (crtAddEditPeople1.mode == DVLD_Business.clsPeople.enMode.enAddnew)
            {
                this.Text = "Add New Person";
                txtAddNewEditPerson.Text = "Add New Person";

            }
            else if (crtAddEditPeople1.mode == DVLD_Business.clsPeople.enMode.enUpdate)
            {
                this.Text = "Edit Person";
                txtAddNewEditPerson.Text = "Edit Person";
                txtPersonID.Text = crtAddEditPeople1.PersonID.ToString();
            }

        }

        private void AddNewEditPeople_Load(object sender, EventArgs e)
        {
            LoadFormTitle();
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

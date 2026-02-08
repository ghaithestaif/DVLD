using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class AddEditUser : Form
    {
        public AddEditUser()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if(!DVLD_Business.People.IspersonExist(personDetailsWithFilters1.SelectedPerson.PersonID))
            {
                MessageBox.Show("Please select a person to continue.", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tabControl1.SelectedTab = tabPage2;
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {

        }
    }
}

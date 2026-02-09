using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class PersonDetailsWithFilters : UserControl
    {

        

       public  DVLD_Business.People SelectedPerson { get { return personCard1.SelectedPersonInfo; } }


        public int PersonID { get { return personCard1.PersonID; } }
        public PersonDetailsWithFilters()
        {
            InitializeComponent();
        }
        public   void loadPersonInfo(int personID)
        {
            personCard1.LoadPersonInfo(personID);
        }

        private void PersonDetailsWithFilters_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
                if (cbFilterBy.SelectedIndex == 0)
                {
                    if(txtFilterValue.Text == "")
                    {
                        MessageBox.Show("Please enter a valid National Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                //search by national no
                string NationalNO = txtFilterValue.Text;
                    personCard1.LoadPersonInfo(NationalNO);
                if (!DVLD_Business.People.IspersonExist(personCard1.SelectedPersonInfo.NationalNo))
                {
                    MessageBox.Show("No person found with this National Number", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                else
                {
                if (txtFilterValue.Text == "")
                {
                    MessageBox.Show("Please enter a valid Person ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                    int ID = Convert.ToInt32(txtFilterValue.Text);
                    personCard1.LoadPersonInfo(ID);
                if (!DVLD_Business.People.IspersonExist(personCard1.PersonID))
                {
                    MessageBox.Show("No person found with this Person ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                }
        }
        

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewEditPeople addNewEditPeople = new AddNewEditPeople(-1);
            addNewEditPeople.ShowDialog();
        }

        private void personCard1_Load(object sender, EventArgs e)
        {

        }
    }
}

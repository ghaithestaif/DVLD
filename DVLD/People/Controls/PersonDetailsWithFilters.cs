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
        public PersonDetailsWithFilters()
        {
            InitializeComponent();
        }

        private void PersonDetailsWithFilters_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
           
                if (cbFilterBy.SelectedIndex == 0)
                {
                    //search by national no
                    string NationalNO = txtFilterValue.Text;
                    personCard1.LoadPersonInfo(NationalNO);
                }
                else
                {
                    int ID = Convert.ToInt32(txtFilterValue.Text);
                    personCard1.LoadPersonInfo(ID);
                }
        }
        

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewEditPeople addNewEditPeople = new AddNewEditPeople(-1);
            addNewEditPeople.ShowDialog();
        }
    }
}

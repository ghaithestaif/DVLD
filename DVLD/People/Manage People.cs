using DVLD_Business;
using DVLD_General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD.People
{
    public partial class Manage_People : Form
    {
        public Manage_People()
        {
            InitializeComponent();
        }


        private void Manage_People_Load(object sender, EventArgs e)
        {
            PeopleGridView.DataSource = DVLD_Business.People.GetAll();
            cbFilter.DataSource = Enum.GetValues(typeof(Common.PeopleFilterSort));
            cbFilter.SelectedItem = Common.PeopleFilterSort.none;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.PeopleFilterSort filter = (Common.PeopleFilterSort)cbFilter.SelectedItem;
            if ((filter == Common.PeopleFilterSort.none))
            {
                txtFilter.Enabled = false;
                PeopleGridView.DataSource = DVLD_Business.People.FilterPeople(filter);
                txtFilter.Text = "";
            }
            txtFilter.Enabled = true;


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Common.PeopleFilterSort filter = (Common.PeopleFilterSort)cbFilter.SelectedItem;
            //upper case for name fields


            string txt = txtFilter.Text;


            PeopleGridView.DataSource = DVLD_Business.People.FilterPeople(filter, txt);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.PeopleFilterSort filter = (Common.PeopleFilterSort)cbFilter.SelectedItem;
            if (filter == Common.PeopleFilterSort.Phone || filter == Common.PeopleFilterSort.PersonID
                || filter == Common.PeopleFilterSort.Gendor || filter == Common.PeopleFilterSort.CountryID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
            else if (filter == Common.PeopleFilterSort.FirstName || filter == Common.PeopleFilterSort.SecondName
                || filter == Common.PeopleFilterSort.ThirdName || filter == Common.PeopleFilterSort.LastName
                 )
            {
                if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
               
            }
        }

        private void btnAddNewPersonButton_Click(object sender, EventArgs e)
        {
            AddNewEditPeople addEditPeople = new AddNewEditPeople();  
            addEditPeople.ShowDialog();
        }
    }
}

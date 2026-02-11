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
            cbFilter.DataSource = Enum.GetValues(typeof(Common.PeopleFilter));
            cbFilter.SelectedItem = Common.PeopleFilter.none;
        }


        private void  _RefreshGrid()
        {
            DataTable dt = DVLD_Business.People.GetAll();
            PeopleGridView.DataSource = dt;
            PeopleGridView.Columns["Address"].Visible = false;
            PeopleGridView.Columns["ImagePath"].Visible = false;
            PeopleGridView.Columns["NationalityCountryID"].Visible = false;
            PeopleGridView.Columns["Gendor"].Visible = false;

          

            txtNumberOfRecords.Text = dt.Rows.Count.ToString();

        }
        private void Manage_People_Load(object sender, EventArgs e)
        {
            _RefreshGrid();




        }

    


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.PeopleFilter filter = (Common.PeopleFilter)cbFilter.SelectedItem;
            if ((filter == Common.PeopleFilter.none))
            {
                txtFilter.Enabled = false;
                PeopleGridView.DataSource = DVLD_Business.People.FilterPeople(filter);
                txtFilter.Text = "";
            }
            txtFilter.Enabled = true;


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Common.PeopleFilter filter = (Common.PeopleFilter)cbFilter.SelectedItem;
            //upper case for name fields


            string txt = txtFilter.Text;


            PeopleGridView.DataSource = DVLD_Business.People.FilterPeople(filter, txt);
            txtNumberOfRecords.Text = (PeopleGridView.RowCount-1).ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.PeopleFilter filter = (Common.PeopleFilter)cbFilter.SelectedItem;
            if (filter == Common.PeopleFilter.Phone || filter == Common.PeopleFilter.PersonID
                || filter == Common.PeopleFilter.Gendor || filter == Common.PeopleFilter.CountryID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
            else if (filter == Common.PeopleFilter.FirstName || filter == Common.PeopleFilter.SecondName
                || filter == Common.PeopleFilter.ThirdName || filter == Common.PeopleFilter.LastName
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
            AddNewEditPeople addPerson = new AddNewEditPeople(-1);
            addPerson.DataBack += _RefreshGrid;
            addPerson.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEditPeople editPeople = new AddNewEditPeople((int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value);
            editPeople.mode = DVLD_Business.People.enMode.enUpdate;
            editPeople.DataBack += _RefreshGrid;
            editPeople.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value;
            DVLD_Business.People.Delete(PersonID);
            _RefreshGrid();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEditPeople editPeople = new AddNewEditPeople(-1);
            editPeople.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int ID= (int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value;
            frmPersonDetails frmPersonDetails = new frmPersonDetails(ID);
            

            frmPersonDetails.ShowDialog();
        }

        private void txtNumberOfRecords_Click(object sender, EventArgs e)
        {

        }
    }
}

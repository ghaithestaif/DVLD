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
            cbFilter.DataSource = Enum.GetValues(typeof(Common.PeopleFilterSort));
            cbFilter.SelectedItem = Common.PeopleFilterSort.none;
        }
        private void  _RefreshGrid()
        {
            DataTable dt = DVLD_Business.clsPeople.GetAll();
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
            Common.PeopleFilterSort filter = (Common.PeopleFilterSort)cbFilter.SelectedItem;
            if ((filter == Common.PeopleFilterSort.none))
            {
                txtFilter.Enabled = false;
                PeopleGridView.DataSource = DVLD_Business.clsPeople.FilterPeople(filter);
                txtFilter.Text = "";
            }
            txtFilter.Enabled = true;


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Common.PeopleFilterSort filter = (Common.PeopleFilterSort)cbFilter.SelectedItem;
            //upper case for name fields


            string txt = txtFilter.Text;


            PeopleGridView.DataSource = DVLD_Business.clsPeople.FilterPeople(filter, txt);
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
            frmAddUpdatePerson addPerson = new frmAddUpdatePerson();
            addPerson.crtAddEditPeople1.PersonSaved += _RefreshGrid;
            addPerson.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson editPeople = new frmAddUpdatePerson();
            editPeople.crtAddEditPeople1.mode = DVLD_Business.clsPeople.enMode.enUpdate;
            editPeople.crtAddEditPeople1.PersonID = (int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value;
            editPeople.crtAddEditPeople1.PersonSaved += _RefreshGrid;
            editPeople.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value;
            DVLD_Business.clsPeople.Delete(PersonID);
            _RefreshGrid();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson editPeople = new frmAddUpdatePerson();
            editPeople.ShowDialog();

        }
    }
}

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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.People
{
    public partial class Manage_People : Form
    {
        public enum PeopleFilter
        {
            none,
            PersonID,
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            Gendor,
            Phone,
            Email,
            CountryID
        }

        private DataTable peopleList;

        public Manage_People()
        {
            InitializeComponent();
            
        }

        private void  _RefreshGrid()
        {
            peopleList = clsPeople.GetAll();
            PeopleGridView.DataSource = peopleList;
            PeopleGridView.Columns["Address"].Visible = false;
            PeopleGridView.Columns["ImagePath"].Visible = false;
            PeopleGridView.Columns["NationalityCountryID"].Visible = false;
            PeopleGridView.Columns["Gendor"].Visible = false;

            txtNumberOfRecords.Text = peopleList.Rows.Count.ToString();
        }

        private void Manage_People_Load(object sender, EventArgs e)
        {
            _RefreshGrid();
            cbFilter.DataSource = Enum.GetValues(typeof(PeopleFilter));
            cbFilter.SelectedItem = PeopleFilter.none;
        }

    


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeopleFilter filter = (PeopleFilter)cbFilter.SelectedItem;
            if ((filter == PeopleFilter.none))
            {
                txtFilter.Enabled = false;
                PeopleGridView.DataSource = peopleList;
                txtFilter.Text = "";
            }
            txtFilter.Enabled = true;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (peopleList == null) return;

            PeopleFilter filter = (PeopleFilter)cbFilter.SelectedItem;
            string txt = txtFilter.Text.Trim();

            if (filter == PeopleFilter.none || string.IsNullOrEmpty(txt))
            {
                PeopleGridView.DataSource = peopleList;
                txtNumberOfRecords.Text = peopleList.Rows.Count.ToString();
                return;
            }

            DataView dataView = new DataView(peopleList);
            string columnName = GetColumnName(filter);
            
            if (!string.IsNullOrEmpty(columnName))
            {
                if (filter == PeopleFilter.PersonID  || filter == PeopleFilter.Gendor || filter == PeopleFilter.CountryID)
                {
                    dataView.RowFilter = $"{columnName} = {txt}";
                }
                else
                {
                    dataView.RowFilter = $"{columnName} LIKE '%{txt}%'";
                }
            }

            PeopleGridView.DataSource = dataView;
            txtNumberOfRecords.Text = dataView.Count.ToString();
        }

        private string GetColumnName(PeopleFilter filter)
        {
            switch (filter)
            {
                case PeopleFilter.PersonID: return "PersonID";
                case PeopleFilter.NationalNo: return "NationalNo";
                case PeopleFilter.FirstName: return "FirstName";
                case PeopleFilter.SecondName: return "SecondName";
                case PeopleFilter.ThirdName: return "ThirdName";
                case PeopleFilter.LastName: return "LastName";
                case PeopleFilter.Gendor: return "Gendor";
                case PeopleFilter.Phone: return "Phone";
                case PeopleFilter.Email: return "Email";
                case PeopleFilter.CountryID: return "NationalityCountryID";
                default: return "";
            }
        }
        

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            PeopleFilter filter = (PeopleFilter)cbFilter.SelectedItem;
            if (filter == PeopleFilter.Phone || filter == PeopleFilter.PersonID
                || filter == PeopleFilter.Gendor || filter == PeopleFilter.CountryID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (filter == PeopleFilter.FirstName || filter == PeopleFilter.SecondName
                || filter == PeopleFilter.ThirdName || filter == PeopleFilter.LastName)
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
            addPerson.RefreshData += _RefreshGrid;
            addPerson.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEditPeople editPeople = new AddNewEditPeople((int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value);
            
            editPeople.RefreshData += _RefreshGrid;
            editPeople.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)PeopleGridView.SelectedRows[0].Cells["PersonID"].Value;
            clsPeople.Delete(PersonID);
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

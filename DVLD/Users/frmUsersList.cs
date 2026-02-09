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

namespace DVLD.Users
{
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }
        void _ReloadUsers()
        {
            DataTable dt = clsUser.GetAllUsers();
            _RefreshgridView(dt);
        }
        void _RefreshgridView(DataTable dt)
        {
            UsersGridView.DataSource = dt;
            UsersGridView.Columns[0].Width = 120;
            UsersGridView.Columns[1].Width = 120;
            UsersGridView.Columns[2].Width = 120;
            UsersGridView.Columns[3].Visible = false;
            UsersGridView.Columns[4].Width = 120;
            UsersGridView.Columns[5].Width = 120;
            UsersGridView.Columns[5].Width = 270;
            UsersGridView.Columns[5].DisplayIndex = 2;

            txtNumberOfRecords.Text = (UsersGridView.Rows.Count - 1).ToString();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            _RefreshgridView(clsUser.GetAllUsers());
            cbFilter.DataSource = Enum.GetValues(typeof(Common.UsersFilter));
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterExpression= txtFilter.Text.Trim();
            Common.UsersFilter filter = (Common.UsersFilter)cbFilter.SelectedItem;
            _RefreshgridView(clsUser.GetUsersByFilter(filter, FilterExpression));
             txtNumberOfRecords.Text = (UsersGridView.Rows.Count-1).ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshgridView(clsUser.GetAllUsers());
            if ((Common.UsersFilter)cbFilter.SelectedItem != Common.UsersFilter.None)
            {
                
                if ((Common.UsersFilter)cbFilter.SelectedItem == Common.UsersFilter.IsActive)
                {
                    txtFilter.Enabled = false;
                    txtFilter.Visible = false;

                    cbIsActive.Visible = true;
                    cbIsActive.Enabled = true;
                    cbIsActive.SelectedIndex = 0; // Set default selection to "All"

                }
                else
                {
                    txtFilter.Enabled = true;
                    txtFilter.Visible = true;
                    cbIsActive.Visible = false;
                    cbIsActive.Enabled = false;
                }
                txtFilter.Clear();
            }
            else
            {
             
                cbIsActive.Visible = false;
                cbIsActive.Enabled = false;
                txtFilter.Enabled = false;
                txtFilter.Visible = false;

                txtFilter.Clear();
                UsersGridView.DataSource = clsUser.GetAllUsers();
            }
            //Validation
            
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Common.UsersFilter)cbFilter.SelectedItem == Common.UsersFilter.UserID ||
                (Common.UsersFilter)cbFilter.SelectedItem == Common.UsersFilter.PersonID)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // block the character
                }

                
            }
            else if ((Common.UsersFilter)cbFilter.SelectedItem == Common.UsersFilter.FullName ||
                (Common.UsersFilter)cbFilter.SelectedItem == Common.UsersFilter.UserName)
            {
                if (!char.IsLetter(e.KeyChar) &&
                  !char.IsWhiteSpace(e.KeyChar) &&
                  !char.IsControl(e.KeyChar))

                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddNewUserButton_Click(object sender, EventArgs e)
        {
            AddEditUser AddNewUser=new AddEditUser(-1);
            AddNewUser.UserSaved += _ReloadUsers;
            AddNewUser.ShowDialog();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIsActive.SelectedItem.ToString() == "All")
            {
                _RefreshgridView(clsUser.GetAllUsers());
            }
            else if (cbIsActive.SelectedItem.ToString() == "Yes")
            {
                _RefreshgridView(clsUser.GetUsersByFilter(Common.UsersFilter.IsActive, "true"));
            }
            else if (cbIsActive.SelectedItem.ToString() == "No")
            {
                _RefreshgridView(clsUser.GetUsersByFilter(Common.UsersFilter.IsActive, "false"));
            }
             txtNumberOfRecords.Text = (UsersGridView.Rows.Count - 1).ToString();
        }

        
    }
}

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

namespace DVLD.Users
{
    public partial class frmUsersList : Form
    {
        public enum UsersFilter
        {
            None,
            UserID,
            PersonID,
            UserName,
            FullName,
            IsActive
        }

        private DataTable usersList;

        public frmUsersList()
        {
            InitializeComponent();
        }

        void _ReloadUsers()
        {
            usersList = clsUser.GetAllUsers();
            _RefreshgridView(usersList);
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
            _ReloadUsers();
            cbFilter.DataSource = Enum.GetValues(typeof(UsersFilter));
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (usersList == null) return;

            string FilterExpression = txtFilter.Text.Trim();
            UsersFilter filter = (UsersFilter)cbFilter.SelectedItem;

            if (filter == UsersFilter.None || string.IsNullOrEmpty(FilterExpression))
            {
                UsersGridView.DataSource = usersList;
                txtNumberOfRecords.Text = usersList.Rows.Count.ToString();
                return;
            }

            DataView dataView = new DataView(usersList);
            string columnName = GetColumnName(filter);
            
            if (!string.IsNullOrEmpty(columnName))
            {
                if (filter == UsersFilter.UserID || filter == UsersFilter.PersonID)
                {
                    dataView.RowFilter = $"{columnName} = {FilterExpression}";
                }
                else if (filter == UsersFilter.IsActive)
                {
                    bool isActiveValue = FilterExpression.ToLower() == "true" || FilterExpression.ToLower() == "yes";
                    dataView.RowFilter = $"{columnName} = {isActiveValue}";
                }
                else
                {
                    dataView.RowFilter = $"{columnName} LIKE '%{FilterExpression}%'";
                }
            }

            UsersGridView.DataSource = dataView;
            txtNumberOfRecords.Text = dataView.Count.ToString();
        }

        private string GetColumnName(UsersFilter filter)
        {
            switch (filter)
            {
                case UsersFilter.UserID: return "UserID";
                case UsersFilter.PersonID: return "PersonID";
                case UsersFilter.UserName: return "UserName";
                case UsersFilter.FullName: return "FullName";
                case UsersFilter.IsActive: return "IsActive";
                default: return "";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersList == null) return;

            UsersGridView.DataSource = usersList;
            if ((UsersFilter)cbFilter.SelectedItem != UsersFilter.None)
            {
                if ((UsersFilter)cbFilter.SelectedItem == UsersFilter.IsActive)
                {
                    txtFilter.Enabled = false;
                    txtFilter.Visible = false;

                    cbIsActive.Visible = true;
                    cbIsActive.Enabled = true;
                    cbIsActive.SelectedIndex = 0;
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
            }
            txtNumberOfRecords.Text = usersList.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((UsersFilter)cbFilter.SelectedItem == UsersFilter.UserID ||
                (UsersFilter)cbFilter.SelectedItem == UsersFilter.PersonID)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if ((UsersFilter)cbFilter.SelectedItem == UsersFilter.FullName ||
                (UsersFilter)cbFilter.SelectedItem == UsersFilter.UserName)
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
            AddEditUser AddNewUser = new AddEditUser(-1);
            AddNewUser.UserSaved += _ReloadUsers;
            AddNewUser.ShowDialog();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersList == null) return;

            if(cbIsActive.SelectedItem.ToString() == "All")
            {
                UsersGridView.DataSource = usersList;
            }
            else if (cbIsActive.SelectedItem.ToString() == "Yes")
            {
                DataView dataView = new DataView(usersList);
                dataView.RowFilter = "IsActive = true";
                UsersGridView.DataSource = dataView;
            }
            else if (cbIsActive.SelectedItem.ToString() == "No")
            {
                DataView dataView = new DataView(usersList);
                dataView.RowFilter = "IsActive = false";
                UsersGridView.DataSource = dataView;
            }
            
            int recordCount = UsersGridView.DataSource is DataView ? 
                ((DataView)UsersGridView.DataSource).Count : 
                usersList.Rows.Count;
            txtNumberOfRecords.Text = recordCount.ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)UsersGridView.SelectedRows[0].Cells[0].Value;
            frmUserCard UserCard = new frmUserCard(ID);
            UserCard.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)UsersGridView.SelectedRows[0].Cells[0].Value;
            frmChangePassword form = new frmChangePassword(UserID);
            form.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)UsersGridView.SelectedRows[0].Cells[0].Value;
            AddEditUser UpdateUser = new AddEditUser(UserID);
            UpdateUser.UserSaved += _ReloadUsers;
            UpdateUser.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)UsersGridView.SelectedRows[0].Cells[0].Value;
            clsUser.Delete(UserID);
            _ReloadUsers();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser AddNewUser = new AddEditUser(-1);
            AddNewUser.UserSaved -= _ReloadUsers;
            AddNewUser.ShowDialog();
        }
    }
}

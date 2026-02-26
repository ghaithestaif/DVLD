using DVLD_Buisness;
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

namespace DVLD.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        int _ApplicationTypeID;
        clsApplicationType _ApplicationType;
        public event Action ApplicationTypeChanged;
        public frmEditApplicationType(int ApplicationTypeId)
        {
            _ApplicationTypeID = ApplicationTypeId;
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
            InitializeComponent();
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeInfo();
        }
        public void _LoadApplicationTypeInfo()
        {
            lUserID.Text = _ApplicationType.ID.ToString();
            txtFees.Text=_ApplicationType.Fees.ToString();
            txtTitle.Text=_ApplicationType.Title.ToString();

        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow ONE decimal point
            if (e.KeyChar == '.' && !txtFees.Text.Contains("."))
                return;

            // Otherwise block input
            e.Handled = true;


        }
        private bool ValidateFees()
        {
            if (!decimal.TryParse(txtFees.Text, out decimal fees))
            {
                MessageBox.Show("Please enter a valid number.");
                return false;
            }

            if (fees < 0)
            {
                MessageBox.Show("Fees cannot be negative.");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFees())
            {
                return;
            }
            //filling the object
            _ApplicationType.Fees = Convert.ToDecimal(txtFees.Text);
            _ApplicationType.Title = txtTitle.Text;

            if (!_ApplicationType.Save())
            {
                MessageBox.Show("the Application type was not updated");
            }
            else
            {
                ApplicationTypeChanged?.Invoke();
                MessageBox.Show("the Application type has been updated");

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

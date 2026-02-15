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

namespace DVLD.TestTypes
{
    public partial class frmEditTestType : Form
    {
       public event Action TestTypeSaved;
        private int _ID;
        private clsTestType _testType;
        public frmEditTestType(int ID)
        {
            _ID=ID; 
            InitializeComponent();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _testType = clsTestType.Find(_ID);
            FillForm();
        }
        void FillForm()
        {
            //fill the form from the object
            if (_testType == null) { return; }
            lblTestTypeID.Text=_ID.ToString();
            txtDescription.Text = _testType.TestTypeDescription;
            txtFees.Text = _testType.TestTypeFees.ToString();
            txtTitle.Text= _testType.TestTypeTitle;


        }
        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _testType.TestTypeFees = Convert.ToDecimal(txtFees.Text);
            _testType.TestTypeDescription = txtDescription.Text;
            _testType.TestTypeTitle = txtTitle.Text;
            if (_testType.Save())
            {
                TestTypeSaved?.Invoke();
                MessageBox.Show("Test Type Saved");
            }
            else
            {
                MessageBox.Show("Error Saving Test Type");
            }
        }
    }
}

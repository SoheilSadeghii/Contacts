using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class FrmAddOrEdit : Form
    {
        IContactRepository Repository;
        public int contactId = 0;
        public FrmAddOrEdit()
        {
            Repository = new ContactRepository();
            InitializeComponent();
        }
        bool ValidateInputs()
        {
            if (txtName.Text == "" || txtName.Text == " ")
            {

                MessageBox.Show("Enter your Contact Name! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "" || txtFamily.Text == " ")
            {
                MessageBox.Show("Enter your Contact Family! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "" || txtMobile.Text == " ")
            {
                MessageBox.Show("Enter your Contact Mobile! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("Enter your Contact Age! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Enter your Contact Email! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess;
                if (contactId == 0)
                {
                    isSuccess = Repository.Insert(txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);
                }
                else
                {
                    isSuccess = Repository.Update(contactId, txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);
                }

                if (isSuccess == true)
                {
                    MessageBox.Show("Operation completed successfully! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Operation faced failure", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "Add Contact";
            }
            else
            {
                this.Text = "Edit Contact";
                DataTable dt = Repository.SelectRow(contactId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtAge.Text = dt.Rows[0][3].ToString();
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtEmail.Text = dt.Rows[0][5].ToString();
                txtAddress.Text = dt.Rows[0][6].ToString();
                btnSubmit.Text = "Edit";

            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = txtName.Text.Substring(0, 1).ToUpper() + txtName.Text.Substring(1).ToLower();
                txtName.Select(txtName.Text.Length, 0); // Move the cursor to the end
            }
        }

        private void txtFamily_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                txtFamily.Text = txtFamily.Text.Substring(0, 1).ToUpper() + txtFamily.Text.Substring(1).ToLower();
                txtFamily.Select(txtFamily.Text.Length, 0); // Move the cursor to the end
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                txtMobile.Text = txtMobile.Text.Substring(0, 1).ToUpper() + txtMobile.Text.Substring(1).ToLower();
                txtMobile.Select(txtMobile.Text.Length, 0); // Move the cursor to the end
            }
        }
    }
}

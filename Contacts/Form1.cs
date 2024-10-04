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
    public partial class Form1 : Form
    {
        IContactRepository repository;
        public Form1()
        {
            repository = new ContactRepository();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgContacts.DataSource = repository.SelectAll();
            dgContacts.AutoGenerateColumns = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmAddOrEdit FrmAdd = new FrmAddOrEdit();
            FrmAdd.ShowDialog();

            if (FrmAdd.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = dgContacts.CurrentRow.Cells[1].Value.ToString();
            string family = dgContacts.CurrentRow.Cells[2].Value.ToString();
            string fullname = name + " " + family;

            if (MessageBox.Show($"Are you sure about the removal of {fullname}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int contactId = Convert.ToInt32(dgContacts.CurrentRow.Cells[0].Value.ToString());
                repository.Delete(contactId);
                BindGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                FrmAddOrEdit frmEdit = new FrmAddOrEdit();
                frmEdit.contactId = contactId;
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource = repository.Search(txtSearch.Text);
        }
    }
}

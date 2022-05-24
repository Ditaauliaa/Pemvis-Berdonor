using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donor
{
    public partial class FormDonor : Form
    {
        private readonly FormDonorList _parent;
        public string id, name, email, phone, address;

        public FormDonor(FormDonorList parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Donors";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors name is Empty ( > 3).");
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors email is Empty ( > 1).");
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors phone is Empty ( > 1).");
                return;
            }
            if (txtAddress.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors address is Empty ( > 1).");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Donor std = new Donor(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim());
                DbDonor.AddIdentity(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                Donor std = new Donor(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim());
                DbDonor.UpdateDonors(std, id);
            }

            _parent.Display();
        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Donors";
            btnSave.Text = "Save";
        }

        public void Clear()
        {
            txtName.Text = txtEmail.Text = txtPhone.Text = txtAddress.Text = String.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors name is Empty ( > 3).");
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors email is Empty ( > 1).");
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors phone is Empty ( > 1).");
                return;
            }
            if (txtAddress.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors address is Empty ( > 1).");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Donor std = new Donor(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim());
                DbDonor.AddIdentity(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Donor std = new Donor(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim());
                DbDonor.UpdateDonors(std, id);
            }

            _parent.Display();
        }

        private void FormDonor_Load(object sender, EventArgs e)
        {

        }
    }
}

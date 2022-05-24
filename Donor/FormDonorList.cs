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
    public partial class FormDonorList : Form
    {
        FormDonor form;

        public FormDonorList()
        {
            InitializeComponent();
            form = new FormDonor(this);
        }

        public void Display()
        {
            DbDonor.DisplayAndSearch("Select ID, Name, Email, Phone, Address FROM list_table", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void FormDonorList_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbDonor.DisplayAndSearch("Select ID, Name, Email, Phone, Address FROM list_table WHERE Name LIKE'%"+ txtSearch.Text +"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Edit
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.email = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.phone = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.address = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //Delete
                if(MessageBox.Show("Are you want to delete student record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbDonor.DeleteDonors(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}


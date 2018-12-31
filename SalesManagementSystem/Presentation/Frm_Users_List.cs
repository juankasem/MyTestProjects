using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagementSystem.BusinessLayer;

namespace SalesManagementSystem.Presentation
{
    public partial class Frm_Users_List: Form
    {
        Login login = new Login();
        public Frm_Users_List()
        {
            InitializeComponent();
            dgvUsers.DataSource = login.SearchUser("");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Frm_Add_User frm = new Frm_Add_User();
            frm.btnSave.Text = "Save";
            frm.ShowDialog();
            dgvUsers.DataSource = login.SearchUser("");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Frm_Add_User frm = new Frm_Add_User();
            frm.btnSave.Text = "Update";
            frm.Text = "Edit an existing User";
            frm.txtUsername.Text = dgvUsers.CurrentRow.Cells[0].Value.ToString();
            frm.txtFullName.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            frm.txtPassword.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            frm.comboxUserType.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            frm.ShowDialog();
            dgvUsers.DataSource = login.SearchUser("");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string username = dgvUsers.CurrentRow.Cells[0].Value.ToString();
                    login.DeleteUser(username);
                    MessageBox.Show("Selected user has been deleted successfully! ", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUsers.DataSource = login.SearchUser("");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Operation failed...please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource = login.SearchUser(txtSearch.Text);
        }
    }
}

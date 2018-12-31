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
    public partial class Frm_Add_User : Form
    {
        
        public Frm_Add_User()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtConfirmPassword.Text == string.Empty ||
                txtFullName.Text == string.Empty)
            {
                MessageBox.Show("Please complete all New User details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (btnSave.Text == "Save")
                {
                    Login user = new Login();
                    user.AddUser(txtUsername.Text, txtPassword.Text, comboxUserType.Text, txtFullName.Text);
                    MessageBox.Show("A new user has been created successfully!", "Add New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else if (btnSave.Text == "Update")
                {
                    Login user = new Login();
                    user.UpdateUser(txtUsername.Text, txtPassword.Text, comboxUserType.Text, txtFullName.Text);
                    MessageBox.Show("A user details have been updated successfully!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Operation failed...please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                ClearTextBoxes();              
            }
        }

        private void ClearTextBoxes()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtFullName.Clear();
            txtUsername.Focus();
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

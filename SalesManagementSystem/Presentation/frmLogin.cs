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
    public partial class frmLogin : Form
    {
        Login login= new Login();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            username = txtUsername.Text;
            password = txtPassword.Text;

            DataTable dt = login.UserLogin(username, password);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString()=="Administrator")
                {
                    frm_Main.GetMainForm.productsToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.customersToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.usersToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.createBackupToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.restoreASavedCopyToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.usersToolStripMenuItem.Visible = true;
                    Program.salesman = dt.Rows[0]["FullName"].ToString();
                    frm_Main.GetMainForm.lblMessage.Text = "";
                    this.Close();
                    MessageBox.Show("You're successfully logged in as an administrator Welcome to our application!", "Sign IN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dt.Rows[0][2].ToString() == "User")
                {
                    frm_Main.GetMainForm.productsToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.customersToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.usersToolStripMenuItem.Visible = false;
                    frm_Main.GetMainForm.createBackupToolStripMenuItem.Enabled = true;
                    frm_Main.GetMainForm.restoreASavedCopyToolStripMenuItem.Enabled = true;
                    Program.salesman = dt.Rows[0]["FullName"].ToString();
                    frm_Main.GetMainForm.lblMessage.Text = "";
                    this.Close();
                    MessageBox.Show("You're successfully logged in as a regular user. Welcome to our application!", "Sign IN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }

            else
                MessageBox.Show("Login failed!...please Enter valid Username & Password");
       
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtUsername.Text != string.Empty)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPassword.Text != string.Empty)
            {
                btnLogin.Focus();
            }
        }
    }
}

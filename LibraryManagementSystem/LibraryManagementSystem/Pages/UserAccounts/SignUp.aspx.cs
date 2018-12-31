using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.UserAccounts
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SignUpUser();
        }

        private void SignUpUser()
        {
            if (Page.IsValid)
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                
                //Creates an instance of User class
                User user = new User(username, email, password);

                try
                {
                    if (!user.CheckIfAccountExists(username, email))
                    {
                        //Registers a new user into database
                        user.AddUser(user);
                        lblNewUser.Text = username;
                        divSuccess.Visible = true;
                        ClearTextFields();
                        Response.Redirect("~/UserAccounts/Login.aspx");
                    }

                    else
                    {
                        user = null;
                        divFail.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

            }
        }

        private void ClearTextFields()
        {
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}
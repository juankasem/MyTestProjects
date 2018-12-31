using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.UserAccounts
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticteUserLogin();
        }

        private void AuthenticteUserLogin()
        {
            if (Page.IsValid)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                User user = new User();
                user = user.AuthenticateLogin(username, password);

                if (user != null)
                {
                    //Store login data in Session variables
                    Session["username"] = user.Username;
                    Response.Redirect("~/Pages/Home/Home.aspx");
                }
                else
                {
                    divFail.Visible = true;
                }
            }
        }
    }
}
using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LibraryManagementSystem.Pages.UserAccounts
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        int userID;
        DataSet dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            string guid = Request.QueryString["GUID"];

            if (guid != null)
            {
                ResetPasswordRequest request = new ResetPasswordRequest();

                //Checks whether the link is valid or not
                userID = request.GetUserIDByGUID(guid);

                if (userID == -1)
                {
                    //divFail.Visible = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResetUserPassword();
        }

        private void ResetUserPassword()
        {
            if (Page.IsValid)
            {
                string password = txtPassword.Text;

                if (userID != -1)
                {
                    //Updates Password for the specified user
                    User user = new User();
                    user.ChangePassword(userID, password);

                    //Deletes ForgotPasswordRequest record from database table
                    ResetPasswordRequest request = new ResetPasswordRequest();
                    request.DeleteResetPasswordRequest(userID);

                    // Shows a confirmation message & Redirects the user to the Sign In page
                    divSuccess.Visible = true;
                }
            }
        }
    }
}
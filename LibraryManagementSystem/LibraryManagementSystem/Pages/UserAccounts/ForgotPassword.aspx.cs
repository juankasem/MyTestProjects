using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.UserAccounts
{
    public partial class ForgotPassword1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassword();
        }

        private void ResetPassword()
        {
            string email = txtEmail.Text;
            User user = new User();
            //Retrieves a user's details by providing their email
            user = user.GetUserByEmail(email);
            if (user != null)
            {
                string guid = Guid.NewGuid().ToString();
                int userID = user.ID;
                DateTime requestdateTime = DateTime.Now;
                ResetPasswordRequest request = new ResetPasswordRequest(guid, userID, requestdateTime);
                request.AddResetPasswordRequest(request);

                //Send an Email to the specified user using query string
                string toEmailAddress = user.Email;
                string username = user.Username;
                //Response.Redirect("~/Pages/UserAccounts/ResetPassword.aspx?GUID=" + guid);
                string emailBody = "Hello" + username + ",<br/>Click the link below to reset your password<br/><br/> http://localhost:52449/UserAccounts/ResetPassword.aspx?GUID=" + guid;
                MailMessage mailMessage = new MailMessage("yourEmail@gmail.com", toEmailAddress);
                mailMessage.Body = emailBody;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Reset Password";

                //Create an SMTP object
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = "YourUsername@gmail.com",
                    Password = "YourGmailPassword"
                };
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

            }
            else
            {
                divFail.Visible = true;
            }
        }
    }
    
}
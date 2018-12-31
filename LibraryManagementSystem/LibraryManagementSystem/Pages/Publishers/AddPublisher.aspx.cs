using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Publishers
{
    public partial class AddPublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCountries.Items[0].Attributes["disabled"] = "disabled";
        }


        private void AppendPublisher()
        {
            if (Page.IsValid)
            {
                string publisherName = txtPublisherName.Text;
                string country = ddlCountries.SelectedValue;
                string description = txtDescription.Text;

                //Creates an instance of Genre class
                Publisher publisher = new Publisher(publisherName, country, description);

                if (!publisher.CheckIfPublisherExists(publisherName))
                {
                    //Appends a new Genre into database
                    publisher.AddPublisher(publisher);
                    lblNewPublisher.Text = publisherName;
                    divSuccess.Visible = true;
                    ClearTextFields();
                    txtPublisherName.Focus();
                }
                else
                {
                    publisher = null;
                    divFail.Visible = true;
                }
            }
        }

        private void ClearTextFields()
        {
            txtPublisherName.Text = "";
            ddlCountries.SelectedIndex = 0;
            txtDescription.Text = "";
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            AppendPublisher();
        }
    }
}
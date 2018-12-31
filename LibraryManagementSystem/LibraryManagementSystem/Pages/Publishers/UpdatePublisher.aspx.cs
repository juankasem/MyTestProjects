using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Publishers
{
    public partial class UpdatePublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["publisherID"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["publisherID"]);
                   GetPublisherByID(id);
                }
            }
        }

        private void GetPublisherByID(int id)
        {
            Publisher publisher = new Publisher();
            publisher = publisher.GetPublisherByID(id);

            //Fill Text Boxes with the specified publisher's ID
            txtPublisherName.Text = publisher.Name;
            ddlCountries.SelectedValue = publisher.Country;
            txtDescription.Text = publisher.Description;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdatePublisherDetails();
        }

        private void UpdatePublisherDetails()
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["publisherID"]))
                {
                    int id = int.Parse(Request.QueryString["publisherID"]);
                    string publisherName = txtPublisherName.Text;
                    string country = ddlCountries.SelectedValue;
                    string description = txtDescription.Text;

                    //Creates an instance of Genre class
                    Publisher publisher = new Publisher(publisherName, country, description);

                    //Appends a new Genre into database
                    publisher.UpdatePublisher(id, publisher);
                    lblNewPublisher.Text = publisherName;
                    divSuccess.Visible = true;
                    ClearTextFields();
                }
            }
        }

        private void ClearTextFields()
        {
            txtPublisherName.Text = "";
            ddlCountries.SelectedIndex = 0;
            txtDescription.Text = "";
        }
    }
}
using LibraryManagementSystem.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Authors
{
    public partial class UpdateAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPhotos();
            ddlCountries.Items[0].Attributes["disabled"] = "disabled";

            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["authorID"]))
                {
                    int authorID = Convert.ToInt32(Request.QueryString["authorID"]);
                    BindAuthor(authorID);
                }
            }
        }

        private void BindAuthor(int id)
        {
            Author author = new Author();
            author = author.BindAuthorByID(id);

            //Fill Text Boxes with the specified author's ID
            txtFirstName.Text = author.FirstName;
            txtLastName.Text = author.LastName;
            txtBiography.Text = author.Biography;

            //Set the dropdown list values
            ddlCountries.SelectedValue = author.Origin;
            ddlPhotos.SelectedValue = author.Photo;
        }

        private void ShowPhotos()
        {
            //Get all filepaths
            string[] photos = Directory.GetFiles(Server.MapPath("~/Images/Authors/"));

            //Get all filenames and add them to an arraylist
            ArrayList photoList = new ArrayList();

            foreach (string photo in photos)
            {
                string photoName = photo.Substring(photo.LastIndexOf(@"\") + 1);
                photoList.Add(photoName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlPhotos.DataSource = photoList;
            ddlPhotos.DataBind();
        }

        private void UpdateAuthorInfo()
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["authorID"]))
                {
                    int id = int.Parse(Request.QueryString["authorID"].ToString());
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;
                    string origin = ddlCountries.SelectedItem.Text;
                    string photo = ddlPhotos.SelectedValue;
                    string biography = txtBiography.Text;

                    //Creates an instance of Author class
                    Author author = new Author(firstName, lastName, origin, photo, biography);

                    //Updates the specified author into database
                    author.UpdateAuthor(id, author);
                    lblNewAuthor.Text = firstName + " " + lastName;
                    divSuccess.Visible = true;
                    ClearTextFields();
                }
            }
        }

        private void ClearTextFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlCountries.SelectedIndex = 0;
            ddlPhotos.SelectedIndex = 0;
            txtBiography.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateAuthorInfo();
        }
    }
}
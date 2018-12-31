using LibraryManagementSystem.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Authors
{
    public partial class AddAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCountries.Items[0].Attributes["disabled"] = "disabled";
            string selectedValue = ddlPhotos.SelectedValue;
            ShowPhotos();
            ddlPhotos.SelectedValue = selectedValue;
        }

        private void ShowPhotos()
        {
            //Get all filepaths
            string[] photos= Directory.GetFiles(Server.MapPath("~/Images/Authors/"));
            
            //Get all filenames and add them to an arraylist
            ArrayList photoList = new ArrayList();

            foreach(string photo in photos)
            {
                string photoName = photo.Substring(photo.LastIndexOf(@"\") + 1);
                photoList.Add(photoName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlPhotos.DataSource = photoList;
            ddlPhotos.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddNewAuthor();
        }

        private void AddNewAuthor()
        {
            if (Page.IsValid)
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string origin = ddlCountries.SelectedItem.Text;
                string photo = ddlPhotos.SelectedValue;
                string biography = txtBiography.Text;

                //Creates an instance of Author class
                Author author = new Author(firstName, lastName, origin, photo, biography);

                if (!author.CheckIfAuthorExists(firstName,lastName))
                {
                    //Appends a new author into database
                    author.AddAuthor(author);
                    lblNewAuthor.Text = firstName +" "+ lastName;
                    divSuccess.Visible = true;
                    divFail.Visible = false;
                    ClearTextFields();
                }
                else
                {
                    author = null;
                    divSuccess.Visible = false;
                    divFail.Visible = true;
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

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(filUplPhoto.FileName);
                filUplPhoto.SaveAs(Server.MapPath("~/Images/Authors/") + fileName);
                lblUploadResult.ForeColor = Color.Green;
                lblUploadResult.Text="Photo" +" "+ fileName +" "+ "has been succesfully uploaded!";
                Page_Load(sender, e);
            }
            catch (Exception)
            {
                lblUploadResult.ForeColor = Color.Red;
                lblUploadResult.Text = "Photo Upload failed!";
            }
        }
    }
}
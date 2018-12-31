using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibraryManagementSystem.App_Code;
using System.IO;
using System.Collections;

namespace LibraryManagementSystem.Pages.Books
{
    public partial class RegisterBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGenres();
                BindAuthors();
                BindPublishers();
            }
            ddlGenres.Items[0].Attributes["disabled"] = "disabled";
            ddlAuthors.Items[0].Attributes["disabled"] = "disabled";
            ddlPublishers.Items[0].Attributes["disabled"] = "disabled";
            string selectedValue = ddlCoverImages.SelectedValue;
            ShowCoverImages();
            ddlCoverImages.SelectedValue = selectedValue;
        }

        private void ShowCoverImages()
        {
            //Get all filepaths
            string[] coverImages = Directory.GetFiles(Server.MapPath("~/Images/BookCovers/"));

            //Get all filenames and add them to an arraylist
            ArrayList coverImagesList = new ArrayList();

            foreach (string item in coverImages)
            {
                string coverImageName = item.Substring(item.LastIndexOf(@"\") + 1);
                coverImagesList.Add(coverImageName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlCoverImages.DataSource = coverImagesList;
            ddlCoverImages.DataBind();
        }

        private void BindGenres()
        {
            ddlGenres.DataSource = sdsGenres;
            ddlGenres.DataTextField = "Name";
            ddlGenres.DataValueField = "ID";
            ddlGenres.DataBind();
            ddlGenres.Items.Insert(0, new ListItem("Select a Genre", "0"));
            ddlGenres.SelectedIndex = 0;
        }

        private void BindAuthors()
        {
            //ddlAuthors.DataSource = sdsAuthors;
            //ddlAuthors.DataTextField = "AuthorName";
            //ddlAuthors.DataValueField = "ID";
            //ddlAuthors.DataBind();
            ddlAuthors.Items.Insert(0, new ListItem("Select an Author", "0"));
            ddlAuthors.SelectedIndex = 0;

        }

        private void BindPublishers()
        {
            ddlPublishers.DataSource = sdsPublishers;
            ddlPublishers.DataTextField = "Name";
            ddlPublishers.DataValueField = "ID";
            ddlPublishers.DataBind();
            ddlPublishers.Items.Insert(0, new ListItem("Select a Publisher", "0"));
            ddlPublishers.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AppendBook();
        }

        private void AppendBook()
        {
            int bookID = -1;
            string isbn = txtISBN.Text;
            string title = txtTitle.Text;
            int genreID = int.Parse(ddlGenres.SelectedValue);
            string coverImage = ddlCoverImages.SelectedItem.Text;
            string description = txtDescription.Text;
            int authorID = int.Parse(ddlAuthors.SelectedValue);
            int publisherID = int.Parse(ddlPublishers.SelectedValue);
            DateTime publicationDate = Convert.ToDateTime(txtPublicationDate.Text);
            int edition = int.Parse(txtEdition.Text);
            string language = ddlLanguages.SelectedItem.Text;
            int numOfPages = int.Parse(txtNumOfPages.Text);
            double price = Convert.ToDouble(txtPrice.Text);
            DateTime registrationDate = Convert.ToDateTime(txtRegistrationDate.Text);
            int totalCopies = int.Parse(txtTotalCopies.Text);
            int issuedCopies = 0;
            string status = "Available";
            string sectionID = txtSectionID.Text;
            string rackID = txtRackID.Text;
            string shelfID = txtShelfID.Text;

            //Creates an instace of Book class
            Book book = new Book(isbn, title,genreID,coverImage,description,authorID,publisherID,publicationDate,edition, language,
                                  numOfPages,price,registrationDate);

            //Checks if book already exists or not
            if (!book.CheckIfBookExists(title, edition))
            {
                //if not, Calls a method in the Book class to append a new book
                bookID = book.AddBook(book);

                //Creates an instance of Inventory class & Adds a new inventory into database
                Inventory inventory = new Inventory(bookID, totalCopies, issuedCopies, status, sectionID, rackID, shelfID);

                //Calls a method in the Inventory class to append a new book
                inventory.AddInventory(inventory);
                divSuccess.Visible = true;
                lblNewBook.Text = title;
                ClearTextFields();
            }
            else
            {
                book = null;
                divFail.Visible = true;
            }

        }

        private void ClearTextFields()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            ddlGenres.SelectedIndex = 0;
            ddlCoverImages.SelectedIndex = 0;
            txtDescription.Text = "";
            ddlAuthors.SelectedIndex = 0;
            ddlPublishers.SelectedIndex = 0;
            txtPublicationDate.Text = "";
            txtEdition.Text = "";
            ddlLanguages.SelectedIndex = 0;
            txtNumOfPages.Text = "";
            txtRegistrationDate.Text = "";
            txtPrice.Text = "";
            txtSectionID.Text = "";
            txtRackID.Text = "";
            txtShelfID.Text = "";
            txtTotalCopies.Text = "";
        }
    }
}
using LibraryManagementSystem.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Books
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCoverImages();

            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["bookID"]))
                {
                    int bookID = Convert.ToInt32(Request.QueryString["bookID"]);
                    GetBookByID(bookID);
                }

                BindGenres();
                BindAuthors();
                BindPublishers();
            }
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

        private void GetBookByID(int id)
        {
            Book book = new Book();
            book = book.GetBookByID(id);

            //Fill Text Boxes & DropDown Lists with the specified book's ID
            txtISBN.Text = book.ISBN;
            txtTitle.Text = book.Title;
            ddlGenres.SelectedValue = book.GenreID.ToString();
            ddlCoverImages.SelectedValue = book.CoverImage;
            txtDescription.Text = book.Description;
            ddlAuthors.SelectedValue = book.AuthorID.ToString();
            ddlPublishers.SelectedValue = book.PublisherID.ToString();
            txtPublicationDate.Text = book.PublicationDate.ToString();
            txtEdition.Text = book.Edition.ToString();
            ddlLanguages.SelectedValue = book.Language;
            txtNumOfPages.Text = book.PagesNumber.ToString();
            txtPrice.Text = book.Price.ToString();
            txtRegistrationDate.Text = book.RegistrationDate.ToString();

        }

        private void ShowCoverImages()
        {
            //Get all filepaths
            string[] coverImages = Directory.GetFiles(Server.MapPath("~/Images/BookCovers/"));

            //Get all filenames and add them to an arraylist
            ArrayList coverImageList = new ArrayList();

            foreach (string coverImage in coverImages)
            {
                string coverImageName = coverImage.Substring(coverImage.LastIndexOf(@"\") + 1);
                coverImageList.Add(coverImageName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlCoverImages.DataSource = coverImageList;
            ddlCoverImages.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateBookInfo();
        }

        private void UpdateBookInfo()
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["bookID"]))
                {
                    int bookID = Convert.ToInt32(Request.QueryString["bookID"]);
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

                    //Creates an instace of Book class
                    Book book = new Book(isbn, title, genreID, coverImage, description, authorID, publisherID, publicationDate, edition, language,
                                          numOfPages, price, registrationDate);

                    //Updates the specified book into database
                    book.UpdateBook(bookID, book);
                    divSuccess.Visible = true;
                    ClearTextFields();
                }

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
        }
    }
}
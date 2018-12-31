using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Genres
{
    public partial class UpdateGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["genreID"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["genreID"]);
                    GetGenreByID(id);
                }
            }
        }

        private void GetGenreByID(int id)
        {
            Genre genre = new Genre();
            genre = genre.GetGenreByID(id);

            //Fill Text Boxes with the specified genre's ID
            txtGenreName.Text = genre.Name;
            txtDescription.Text = genre.Description;
        }

        protected void btnSaveGenre_Click(object sender, EventArgs e)
        {
            //Calls a method to update a genre's info
            UpdateGenreDetails();
        }

        private void UpdateGenreDetails()
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["genreID"]))
                {
                    int id = int.Parse(Request.QueryString["genreID"]);
                    string genreName = txtGenreName.Text;
                    string description = txtDescription.Text;

                    //Creates an instance of Genre class
                    Genre genre = new Genre(genreName, description);


                    //Appends a new Genre into database
                    genre.UpdateGenre(id, genre);
                    lblNewGenre.Text = genreName;
                    divSuccess.Visible = true;
                    ClearTextFields();
                }
            }
        }

        private void ClearTextFields()
        {
            txtGenreName.Text = "";
            txtDescription.Text = "";
        }
    }
}
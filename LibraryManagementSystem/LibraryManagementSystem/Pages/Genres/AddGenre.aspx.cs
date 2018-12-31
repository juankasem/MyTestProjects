using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Genres
{
    public partial class AddGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSaveGenre_Click(object sender, EventArgs e)
        {
            AppendGenre();
        }

        private void AppendGenre()
        {
            if (Page.IsValid)
            {
                string genreName = txtGenreName.Text;
                string description = txtDescription.Text;
       
                //Creates an instance of Genre class
                Genre genre = new Genre(genreName, description);

                if (!genre.CheckIfGenreExists(genreName))
                {
                    //Appends a new Genre into database
                    genre.AddGenre(genre);
                    lblNewGenre.Text = genreName;
                    divSuccess.Visible = true;
                    ClearTextFields();
                }
                else
                {
                    genre = null;
                    divFail.Visible = true;
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
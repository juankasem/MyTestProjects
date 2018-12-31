using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Genres
{
    public partial class AllGenres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvGenres_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Get selected Row
            GridViewRow row = gvGenres.Rows[e.NewEditIndex];

            //Get Id of selected row
            int rowID = Convert.ToInt32(row.Cells[0].Text);

            //Redirect user to ManageProducts along with the selected rowId
            Response.Redirect("~/Pages/Genres/UpdateGenre.aspx?genreID=" + rowID);
        }
    }
}
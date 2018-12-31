using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Authors
{
    public partial class AllAuthors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvAuthors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Get selected Row
            GridViewRow row = gvAuthors.Rows[e.NewEditIndex];

            //Get Id of selected row
            int rowID = Convert.ToInt32(row.Cells[0].Text);

            //Redirect user to ManageProducts along with the selected rowId
            Response.Redirect("~/Pages/Authors/UpdateAuthor.aspx?authorID=" + rowID);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Publishers
{
    public partial class AllPublishers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvPublishers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Get selected Row
            GridViewRow row = gvPublishers.Rows[e.NewEditIndex];

            //Get ID of selected row
            int rowID = Convert.ToInt32(row.Cells[0].Text);

            //Redirect user to ManageProducts along with the selected rowId
            Response.Redirect("~/Pages/Publishers/UpdatePublisher.aspx?publisherID=" + rowID);
        }
    }
}
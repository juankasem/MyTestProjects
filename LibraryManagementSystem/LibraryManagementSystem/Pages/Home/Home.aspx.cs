using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LibraryManagementSystem.App_Code;

namespace LibraryManagementSystem.Pages.Home
{
    public partial class Home : System.Web.UI.Page
    {
        Book book = new Book();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ds = book.BindBooks();
            }
            else
            {
                ds = book.BindBooksByGenre(int.Parse(ddlImages.SelectedValue));
            }

            rptrBooksImages.DataSource = ds;
            rptrBooksImages.DataBind();
        }
    }
}
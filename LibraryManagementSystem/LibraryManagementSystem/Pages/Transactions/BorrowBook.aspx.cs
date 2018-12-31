using LibraryManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Pages.Transactions
{
    public partial class BorrowBook : System.Web.UI.Page
    {
        int memberID;
        int[] bookID= new int[3];
        DateTime borrowDate;
        DateTime dueReturnDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Borrow borrow = new Borrow();
                txtBorrowID.Text = borrow.GetNewBorrowOrderID().ToString();

                for(int i=0; i<3; i++)
                {
                    bookID[i] = -1;
                }
            }
        }

        protected void txtLibraryCardNo_TextChanged(object sender, EventArgs e)
        {
            GetMemberFullName();
        }

        private void GetMemberFullName()
        {
            DataSet ds = new DataSet();
            Membership membership = new Membership();
            ds = membership.GetMemberByLibraryCardNo(txtLibraryCardNo.Text);
            try
            {
                if (ds.Tables[0].Rows.Count> 0)
                {
                    // memberID= Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    txtMemberFullName.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    txtMemberFullName.Text = "Member not found!...Invalid Library Card No";
                }
            }
            catch (SqlException ex)
            {
               ex.ToString();
            }
            
        }

        protected void txtISBN1_TextChanged(object sender, EventArgs e)
        {
            GetBookTitle1();
        }

        protected void txtISBN2_TextChanged(object sender, EventArgs e)
        {
            GetBookTitle2();
        }

        protected void txtISBN3_TextChanged(object sender, EventArgs e)
        {
            GetBookTitle3();
        }

      
        private void GetBookTitle1()
        {
            DataSet ds = new DataSet();
            string isbn = txtISBN1.Text;
            Book book = new Book();

            ds = book.GetBookByISBN(isbn);

            if (ds.Tables[0].Rows.Count > 0)
            {
                bookID[0] = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                txtBookTitle1.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                txtBookTitle1.Text = "Book not found!...Invalid ISBN";
            }
        }
        private void GetBookTitle2()
        {
            DataSet ds = new DataSet();
            string isbn = txtISBN2.Text;
            Book book = new Book();

            ds = book.GetBookByISBN(isbn);

            if (ds.Tables[0].Rows.Count > 0)
            {
                bookID[1] = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                txtBookTitle2.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                txtBookTitle2.Text = "Book not found!...Invalid ISBN";
            }
        }

        private void GetBookTitle3()
        {
            DataSet ds = new DataSet();
            string isbn = txtISBN3.Text;
            Book book = new Book();

            ds = book.GetBookByISBN(isbn);

            if (ds.Tables[0].Rows.Count > 0)
            {
                bookID[2] = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                txtBookTitle3.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                txtBookTitle3.Text = "Book not found!...Invalid ISBN";
            }
        }


        protected void txtBorrowDate_TextChanged(object sender, EventArgs e)
        {
            txtDueReturnDate.Enabled = true;

            if (radBtnLstBorrowDuration.SelectedIndex == 0)
            {
                if (txtBorrowDate.Text != string.Empty)
                {
                    dueReturnDate = Convert.ToDateTime(txtBorrowDate.Text).AddDays(7);
                    txtDueReturnDate.Text = dueReturnDate.ToString("MMM dd, yyyy");
                }
            }

            if (radBtnLstBorrowDuration.SelectedIndex == 1)
            {
                if (txtBorrowDate.Text != string.Empty)
                {
                    dueReturnDate = Convert.ToDateTime(txtBorrowDate.Text).AddDays(14);
                    txtDueReturnDate.Text = dueReturnDate.ToString("MMM dd, yyyy");
                }
            }

            if (radBtnLstBorrowDuration.SelectedIndex == 2)
            {
                if (txtBorrowDate.Text != string.Empty)
                {
                    dueReturnDate = Convert.ToDateTime(txtBorrowDate.Text).AddDays(21);
                    txtDueReturnDate.Text = dueReturnDate.ToString("MMM dd, yyyy");
                }
            }

            if (radBtnLstBorrowDuration.SelectedIndex == 3)
            {
                if (txtBorrowDate.Text != string.Empty)
                {
                    dueReturnDate = Convert.ToDateTime(txtBorrowDate.Text).AddDays(30);
                    txtDueReturnDate.Text = dueReturnDate.ToString("MMM dd, yyyy");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddBorrowOrder();
        }

        private void AddBorrowOrder()
        {
            borrowDate = Convert.ToDateTime(txtBorrowDate.Text);

            //Creates an object of Borrow class
            Borrow borrow = new Borrow(memberID, borrowDate, dueReturnDate);

            //Adds a new borrow order to database
            int borrowID = borrow.AddBorrowOrder(borrow);

            for (int i=0; i<3; i++)
            {
                if (bookID[i] != -1)
                {
                    //Adds borrow details into database
                    BorrowDetails borrowDetails = new BorrowDetails(borrowID, bookID[i]);
                }
            }        
        }      
    }
}
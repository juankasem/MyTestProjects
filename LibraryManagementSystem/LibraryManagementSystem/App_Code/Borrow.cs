using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Borrow
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueReturnDate { get; set; }

        public Borrow()
        {

        }

        public Borrow(int memberID, DateTime borrowDate, DateTime dueReturnDate)
        {
            MemberID = memberID;
            BorrowDate = borrowDate;
            DueReturnDate = dueReturnDate;
        }

        /************************************************A method to append a new borrow order into database*************************************************/
        public int AddBorrowOrder(Borrow borrow)
        {
            int borrowID = -1;

            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spAddBorrowOrder",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@memberID", SqlDbType.Int).Value = borrow.MemberID;
            sqlCommand.Parameters.Add("@borrowDate", SqlDbType.Date).Value = borrow.BorrowDate;
            sqlCommand.Parameters.Add("@returnDate", SqlDbType.Date).Value = borrow.DueReturnDate;

            //Initializes output paramater that retrieves ID of the added book
            sqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@borrowID", SqlDbType = SqlDbType.Int,
                Value = -1, Direction = ParameterDirection.Output
            });


            try
            {
                //Calls a method to exeute the query
                DataAccess.ExecuteProcedure(sqlCommand);

                //Retrieves the ID from the last added borrow order
                borrowID = Convert.ToInt32(sqlCommand.Parameters["@borrowID"].Value);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return borrowID;
        }

        /************************************************A method to update an existing borrow order into database*************************************************/
        public void UpdateBorrowOrder(int borrowID, Borrow borrow)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spUpdateBorrowOrder",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int, 5).Value = borrowID;
            sqlCommand.Parameters.Add("@memberID", SqlDbType.Int, 5).Value = borrow.MemberID;
            sqlCommand.Parameters.Add("@borrowDate", SqlDbType.Date).Value = borrow.BorrowDate;
            sqlCommand.Parameters.Add("@returnDate", SqlDbType.Date).Value = borrow.DueReturnDate;

            try
            {
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
            }
        }

        /********************************************A method to delete an borrow order into database*************************************************/
        public void DeleteBorrowOrder(int borrowID)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spDeleteBorrowOrder",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a parameter's value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int, 5).Value = borrowID;

            try
            {
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (SqlException ex)
            {
                ex.ToString();
                return;
            }

            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }

        /********************************************A method to retrieve borrow & return dates from database*************************************************/
        public DataSet RetrieveBorrowReturnDates(int borrowID)
        {
            DataSet ds = new DataSet();

            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spRetrieveBorrowReturnDates",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a parameter value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int).Value = borrowID;

            try
            {
                //Retrieves data from database
                ds = DataAccess.SelectData(sqlCommand);
            }

            catch (SqlException ex)
            {
                ds = null;
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
            }

            return ds;
        }

        /********************************************A method to retrieve borrow order ID from database*************************************************/
        public int GetNewBorrowOrderID()
        {
            int borrowOrderID = -1;
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spGetNewBorrowOrderID",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                //Retrieves scalar data from database
                borrowOrderID = DataAccess.ReturnSingleValue(sqlCommand);
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
            }

            return borrowOrderID + 1;
        }

        /*****************************************A method to check number of copies*************************************************/
        public bool CheckBooksInventory(int bookID)
        {
            bool bookExists = true;
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spCheckBooksInventory",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a parameter's value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;

            try
            {
                int result = DataAccess.ReturnSingleValue(sqlCommand);

                if (result < 2)
                    bookExists = false;
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
            }

            return bookExists;
        }

    }
}

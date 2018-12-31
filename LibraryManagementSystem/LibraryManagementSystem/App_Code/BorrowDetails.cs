using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class BorrowDetails
    {
        public int BorrowID { get; set; }
        public int BookID { get; set; }

        public BorrowDetails()
        {
                
        }

        public BorrowDetails(int borrowID, int bookID)
        {
            BorrowID = borrowID;
            BookID = bookID;
        }

        /**************************************************A method to append a new Borrow Details into database*************************/
        public void AddBorrowDetails(BorrowDetails borrowDetails)
        {

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddBorrowDetails",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int).Value = borrowDetails.BorrowID;
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int).Value = borrowDetails.BookID; 
  

            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Dispose the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }

        /************************************************A method to update an existing Borrow Details into database*************************************************/
        public void UpdateBorrowDetails(BorrowDetails borrowDetails)
        {

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdateBorrowDetails",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int).Value = borrowDetails.BorrowID;
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int).Value = borrowDetails.BookID;


            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);

            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Dispose the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }

        /************************************************A method to delete a Borrow details from database*************************************************/
        public void DeleteBorrowDetails(int borrowID)
        {

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeleteBorrowDetails",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int).Value = borrowID;


            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);

            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Dispose the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }
    }
}
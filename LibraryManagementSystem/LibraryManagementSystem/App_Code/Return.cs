using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Return
    {
        public int ID { get; set; }
        public int BorrowID { get; set; }
        public DateTime ReturnDate { get; set; }

        public Return()
        {

        }

        //Constructor method to initialize ReturnItem objects
        public Return(int borrowID, DateTime returnDate)
        {
            BorrowID = borrowID;
            ReturnDate = returnDate;
        }

        /*******************************************A method to append a new return order into database*************************************************/
        public int AddReturnOrder(Return returnedBook)
        {
            int returnID = -1;
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spAddReturnOrder",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int).Value = returnedBook.BorrowID;
            sqlCommand.Parameters.Add("@returnDate", SqlDbType.Date).Value = returnedBook.ReturnDate;

            sqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@returnID",
                SqlDbType = SqlDbType.Int,
                Value = -1,
                Direction = ParameterDirection.Output
            });

            try
            {
                //Calls a method to exeute the query
                DataAccess.ExecuteProcedure(sqlCommand);

                //Retrieves the last Return ID 
                returnID = Convert.ToInt32(sqlCommand.Parameters["@returnID"].Value.ToString());
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

            return returnID;
        }

        /*******************************************A method to update a existin return order into database*************************************************/
        public void UpdateReturnOrder(int returnID, Return returnedBook)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spUpdateReturnOrder",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@returnID", SqlDbType.Int, 5).Value = returnID;
            sqlCommand.Parameters.Add("@borrowID", SqlDbType.Int, 5).Value = returnedBook.BorrowID;
            sqlCommand.Parameters.Add("@returnDate", SqlDbType.Date).Value = returnedBook.ReturnDate;

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

        /************************************************A method to delete a return order from database *************************************************/
        public void DeleteReturnOrder(int returnID)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spDeleteReturnOrder",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a parameter's value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@returnID", SqlDbType.Int, 5).Value = returnID;

            try
            {
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (Exception)
            {
                return;
            }

            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }
    }
}
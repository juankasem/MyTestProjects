using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Fine
    {
        public int ID { get; set; }
        public int ReturnID { get; set; }
        public string ViolationType { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime PaymentDate { get; set; }

        public Fine()
        {

        }

        //Constructor method to initialize ReturnItem objects
        public Fine(int returnID, string  violationType, double amount, string description, DateTime paymentDate)
        {
            ReturnID = returnID;
            ViolationType = violationType;
            Amount = amount;
            Description = description;
            PaymentDate = paymentDate;  
        }

        /************************************************A method to append a new fine into database*************************************************/
        public void AddFine(Fine fine)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spAddFine",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@returnID", SqlDbType.Int).Value = fine.ReturnID;
            sqlCommand.Parameters.Add("@violationType", SqlDbType.NVarChar).Value = fine.ViolationType;
            sqlCommand.Parameters.Add("@amount", SqlDbType.Float).Value = fine.Amount;
            sqlCommand.Parameters.Add("@paymentDate", SqlDbType.Date).Value = fine.PaymentDate;

            try
            {
                //Calls a method to exeute the query
                DataAccess.ExecuteProcedure(sqlCommand);
            }

            catch (Exception ex)
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

        /************************************************A method to update an existing fine into database*************************************************/
        public void UpdateFine(int fineID, Fine fine)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spUpdateFine",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@fineID", SqlDbType.Int).Value = fineID;
            sqlCommand.Parameters.Add("@returnID", SqlDbType.Int).Value = fine.ReturnID;
            sqlCommand.Parameters.Add("@violationType", SqlDbType.NVarChar, 50).Value = fine.ViolationType;
            sqlCommand.Parameters.Add("@amount", SqlDbType.Float).Value = fine.Amount;
            sqlCommand.Parameters.Add("@paymentDate", SqlDbType.Date).Value = fine.PaymentDate;

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

        /************************************************A method to delete a fine from database*************************************************/
        public void DeleteFine(int fineID)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spDeleteFine",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a parameter's value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@fineID", SqlDbType.Int, 5).Value = fineID;

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LibraryManagementSystem.App_Code
{
    public static class DataAccess
    {
        private static SqlConnection sqlConnection;

        static DataAccess()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["LibrarydbConnection"].ConnectionString;
        }

        /********************************************************A method to Select data from database*****************************************/
        public static DataSet SelectData(SqlCommand sqlCommand)
        {
            DataSet ds = new DataSet();

            //Sets Connection property to the current connection object
            sqlCommand.Connection = sqlConnection;

            try
            {
                //Opens connection to database
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                //Creates an instance of SqlDataAdapter class & Fills the Dataset
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
            }

            catch (SqlException ex)
            {
                ex.ToString();
                return null;
            }

            finally
            {
                //Closes connection to database
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }

            return ds;
        }

        /********************************************************A method to return a single value from database*****************************************/
        public static int ReturnSingleValue(SqlCommand sqlCommand)
        {
            int val = -1;

            //Sets Connection property to the current connection object
            sqlCommand.Connection = sqlConnection;

            try
            {
                //Opens connection to database
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                //Excectes the sqlCommand
                val = (int)sqlCommand.ExecuteScalar();
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                //Closes connection to database
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }

            return val;
        }

        /********************************************************A method to execute stored procedures against database*****************************************/
        public static void ExecuteProcedure(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                //Excecutes the SqlCommand 
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ex.ToString();
                return;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SalesManagementSystem.DataAccessLayer
{
   public static class DataAccess
    {
        private static SqlConnection connection;
        private static SqlCommand command;

        //This constructor initializes the sqlconnection & sqlcommand objects
        static DataAccess()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ProductDBConnection"].ConnectionString;
            command = connection.CreateCommand();
        }

        //Method to initialize parameters 
        public static SqlParameter AddParameter(string parameterName, object value,SqlDbType type, int size)
        {
            //Initialize an Sqlparameter object with required values
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = type;
            parameter.Value = value.ToString();
            parameter.Size = size;
            parameter.Direction = ParameterDirection.Input;

            return parameter;
        }

        //Method to retrieve data from Database
        public static DataTable Selectdata(string procedureName, SqlParameter[] param)
        {
            //Initialize a Datatable object
            DataTable dt = new DataTable();

            try
            {
                //Set the stored procedure name to the sqlcommand
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;

                //Set the Parameters collection to the sql command
                if (param != null)
                    command.Parameters.AddRange(param);

                //Initialize sqlDataAdapter object & fill the DataTable object with rows retrieved from database
                SqlDataAdapter da = new SqlDataAdapter(command);              
                da.Fill(dt);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                connection.Close();
                command.Parameters.Clear();
            }
            
            //Return Data table object
            return dt;
        }

        //Method to conduct transactionbs against the database
        public static void ExecuteProcedure(string procedureName, SqlParameter[] param)
        { 
            try
            {
                //Set the stored procedure name to the sqlcommand
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;

                //Set the array of Parameters to the sql command
                if (param != null)
                    command.Parameters.AddRange(param);

                //Open connection to database
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

               //Execute the Sql command and returns number of affected rows in database
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {   
                //Close connection to database & clear the command
                connection.Close();
                command.Parameters.Clear();
            }
         
        }

    }

}

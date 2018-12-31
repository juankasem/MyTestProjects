using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Publisher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public Publisher()
        {

        }

        public Publisher(string name, string country, string description)
        {
            Name = name;
            Country = country;
            Description = description;
        }

        /*******************************************A method to append a new Publisher into database*************************************************/
        public void AddPublisher(Publisher publisher)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddPublisher",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = publisher.Name;
            sqlCommand.Parameters.Add("@country", SqlDbType.NVarChar).Value = publisher.Country;
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = publisher.Description;


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

        /************************************************A method to update an existing publisher into database *************************************************/
        public void UpdatePublisher(int publisherID, Publisher publisher)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdatePublisher",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@publisherID", SqlDbType.Int).Value = publisherID;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = publisher.Name;
            sqlCommand.Parameters.Add("@country", SqlDbType.NVarChar).Value = publisher.Country;
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = publisher.Description;


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

        /************************************************A method to delete a publisher from database *************************************************/
        public void DeletePublisher(int publisherID)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeletePublisher",
                CommandType = CommandType.StoredProcedure
            };

            //Add a parameter to the SqlCommand & Sets its value
            sqlCommand.Parameters.Add("@publisherID", SqlDbType.Int).Value = publisherID;

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

        /*******************************************************A method to Check whether publisher exists or not ************************************************************/
        public bool CheckIfPublisherExists(string name)
        {
            bool publisherExists = false;
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spCheckIfPublisherExists",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

            try
            {
                //Executes the SqlCommand
                int result = DataAccess.ReturnSingleValue(command);

                if (result == 1)
                    publisherExists = true;
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }

            return publisherExists;
        }

        /*******************************************************A method to retrieve Publisher By their names from database************************************************************/
        public DataSet SearchPublishersByName(string searchTerm)
        {
            DataSet ds = new DataSet();

            //Creates an instance of SqlCommand & Sets its type
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spSearchPublishersByName",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            command.Parameters.Add("@searchTerm", SqlDbType.NVarChar, 50).Value = searchTerm;

            try
            {
                //Executes the SqlCommand
                ds = DataAccess.SelectData(command);
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }

            return ds;
        }
        /*******************************************************A method to bind publishers************************************************************/
        public DataSet BindPublishers()
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spBindPublishers",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                //Executes the SqlCommand
                ds = DataAccess.SelectData(command);
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }

            return ds;
        }

        /*******************************************************A method to retrieve a publisher from database************************************************************/
        public Publisher GetPublisherByID(int publisherID)
        {
            DataSet ds = new DataSet();
            Publisher publisher = new Publisher();

            //Creates an instance of SqlCommand & Sets its type
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spGetPublisherByID",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            command.Parameters.Add("@publisherID", SqlDbType.Int).Value = publisherID;

            try
            {
                //Executes the SqlCommand
                ds = DataAccess.SelectData(command);

                if (ds != null)
                {
                    ds.Tables[0].TableName = "publisher";
                    publisher.Name = ds.Tables["publisher"].Rows[0][0].ToString();
                    publisher.Country = ds.Tables["publisher"].Rows[0][1].ToString();
                    publisher.Description = ds.Tables["publisher"].Rows[0][2].ToString();
                }
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }

            return publisher;
        }
    }
}

    

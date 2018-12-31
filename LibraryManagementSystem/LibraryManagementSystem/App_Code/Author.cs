using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Origin { get; set; }
        public string Photo { get; set; }
        public string Biography { get; set; }

        public Author()
        {

        }

        public Author(string firstName, string lastName, string origin, string photo, string biography)
        {
            FirstName = firstName;
            LastName = lastName;
            Origin = origin;
            Photo = photo;
            Biography = biography;
        }

        /************************************************A method to append a new Author into database*************************************************/
        public void AddAuthor(Author author)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddAuthor",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = author.FirstName;
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = author.LastName;
            sqlCommand.Parameters.Add("@origin", SqlDbType.NVarChar).Value = author.Origin;
            sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = author.Photo;
            sqlCommand.Parameters.Add("@biography", SqlDbType.NVarChar).Value = author.Biography;

            try
            {
                //Calls a DataAccess layer method to execute the Sqlcommand's text
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

        /************************************************A method to update an existing Author into database *************************************************/
        public void UpdateAuthor(int authorID, Author author)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdateAuthor",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@authorID", SqlDbType.Int).Value = authorID;
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = author.FirstName;
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = author.LastName;
            sqlCommand.Parameters.Add("@origin", SqlDbType.NVarChar).Value = author.Origin;
            sqlCommand.Parameters.Add("@photo", SqlDbType.NVarChar).Value = author.Photo;
            sqlCommand.Parameters.Add("@biography", SqlDbType.NVarChar).Value = author.Biography;

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

        /************************************************A method to delete an author from database *************************************************/
        public void DeleteAuthor(int authorID)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeleteAuthor",
                CommandType = CommandType.StoredProcedure
            };

            //Add a parameter to the SqlCommand & Sets its value
            sqlCommand.Parameters.Add("@authorID", SqlDbType.Int).Value = authorID;

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

        /*******************************************************A method to Check whether Author exists or not ************************************************************/
        public bool CheckIfAuthorExists(string firstName, string lastName)
        {
            bool authorExists = false;
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spCheckIfAuthorExists",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;

            try
            {
                //Executes the SqlCommand
                int result = DataAccess.ReturnSingleValue(command);

                if (result == 1)
                    authorExists = true;
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

            return authorExists;
        }

        /*******************************************************A method to retrieve Authors By their names from database************************************************************/
        public DataSet SearchAuthorsByName(string searchTerm)
        {
            DataSet ds = new DataSet();

            //Creates an instance of SqlCommand & Sets its type
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spSearchAuthorsByName",
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

        /*******************************************************A method to bind authors from database************************************************************/
        public DataSet BindAuthors()
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spBindAuthors",
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


        /*******************************************************A method to bind authors from database************************************************************/
        public Author BindAuthorByID(int authorID)
        {
            DataSet ds = new DataSet();
            Author author = new Author();

            //Creates an instance of SqlCommand & Sets its type
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spBindAuthorByID",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@authorID", SqlDbType.Int).Value = authorID;

            try
            {
                //Executes the SqlCommand
                ds = DataAccess.SelectData(sqlCommand);
                if (ds != null)
                {
                    ds.Tables[0].TableName = "author";
                    author.FirstName = ds.Tables["author"].Rows[0][0].ToString();
                    author.LastName = ds.Tables["author"].Rows[0][1].ToString();
                    author.Origin = ds.Tables["author"].Rows[0][2].ToString();
                    author.Photo = ds.Tables["author"].Rows[0][3].ToString();
                    author.Biography = ds.Tables["author"].Rows[0][4].ToString();
                }
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears Parameters
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return author;
        }
    }
}
  

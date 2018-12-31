using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        /************************************************A method to append a new user into database*************************************************/
        public void AddUser(User user)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddUser",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.Email;
            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;

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

        /*********************************************A method to update an existing user into database *************************************************/
        public void UpdateUser(int userID, User user)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdateUser",
                CommandType = CommandType.StoredProcedure
            };

            //Add parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
            sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.Email;
            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;

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

        /************************************************A method to delete a user from database *************************************************/
        public void DeleteUser(int userID)
        {        
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeleteUser",
                CommandType = CommandType.StoredProcedure
            };

            //Add a parameter to the SqlCommand & Sets its value
            sqlCommand.Parameters.Add("@userID", SqlDbType.Int).Value = userID;

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

        /*************************************A method to authenticate a user's Login details & Retrieves a user's details from database*************************************************/
        public User AuthenticateLogin(string username, string password)
        {
            DataSet ds = new DataSet();
            User user = new User();

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAuthenticateLogin",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand & Sets their values
            sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

            try
            {
                //Calls a DataAccess layer method to check if a user exists with provided login details
                ds = DataAccess.SelectData(sqlCommand);

                //If yes, it retrieves the additional user's data
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].TableName = "UserData";
                    user.Username = ds.Tables["UserData"].Rows[0][1].ToString();
                    user.Email = ds.Tables["UserData"].Rows[0][2].ToString();
                    user.Password = ds.Tables["UserData"].Rows[0][3].ToString();
                }

                else
                {
                    user = null;
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                //Clears parameters & Disposes the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return user;
        }

        /*********************************A method to verify whether an account exists or not before registering into database*************************************************/
        public bool CheckIfAccountExists(string username, string email)
        {
            bool accountExists = false;

            //Initializes an SqlCommand object & Sets properties to its Values 
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spCheckIfAccountExists",
                CommandType = CommandType.StoredProcedure
            };

            //Add parameters to the SqlCommand & Sets their values
            sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

            try
            {
                //Calls a DataAccess layer method to check if a user exists or not in database
                int result = DataAccess.ReturnSingleValue(sqlCommand);

                if (result == 1)
                    accountExists = true;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                //Clears parameters & Disposes the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return accountExists;
        }

        /*************************************A method to retrieve a user's data by providing their Email*************************************************/
        public User GetUserByEmail(string email)
        {
            DataSet dataSet = new DataSet();
            User user = new User();

            //Initializes an instance of SqlCommand class 
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spGetUserByEmail",
                CommandType = CommandType.StoredProcedure
            };

            //Adds a parameter to the SqlCommand object & Sets its value
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

            try
            {
                dataSet = DataAccess.SelectData(sqlCommand);

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataSet.Tables[0].TableName = "UserData";
                    user.ID = Convert.ToInt32(dataSet.Tables["UserData"].Rows[0][0].ToString());
                    user.Username = dataSet.Tables["UserData"].Rows[0][1].ToString();
                    user.Email = dataSet.Tables["UserData"].Rows[0][2].ToString();
                    user.Password = dataSet.Tables["UserData"].Rows[0][3].ToString();
                }
                else
                {
                    user = null;
                }
            }

            catch (SqlException ex)
            {
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return user;
        }

        /*************************************A method to change a user's password ******************************************************/
        public void ChangePassword(int userID, string password)
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spChangePassword",
                CommandType = CommandType.StoredProcedure
            };

            //Add parameters to the SqlCommand object & Sets its value
            sqlCommand.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

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
                //Clears parameters & Disposes the SqlCommand object
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }
        }
    }
}
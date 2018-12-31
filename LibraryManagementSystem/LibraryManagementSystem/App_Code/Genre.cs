using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Genre()
        {

        }

        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /*********************************************A method to append a new Genre into database****************************************/
        public void AddGenre(Genre genre)
        {
            //Creates an instance of SqlCommand
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spAddGenre",
                CommandType = CommandType.StoredProcedure
            };

            //Sets Parameters' values & Adds them to the SqlCommand object
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = genre.Name;
            command.Parameters.Add("@description", SqlDbType.NVarChar, 50).Value = genre.Description;

            try
            {
                //Executes the SqlCommand
                DataAccess.ExecuteProcedure(command);
            }
            catch (SqlException ex)
            {
                ex.ToString();
                return;
            }

            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }
        }

        /*********************************************A method to update an existing Genre into database****************************************/
        public void UpdateGenre(int genreID, Genre genre)
        {
            //Creates an instance of SqlCommand
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spUpdateGenre",
                CommandType = CommandType.StoredProcedure
            };

            //Sets Parameters' values & Adds them to the SqlCommand object
            command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = genre.Name;
            command.Parameters.Add("@description", SqlDbType.NVarChar, 50).Value = genre.Description;

            try
            {
                //Executes the SqlCommand object's query
                DataAccess.ExecuteProcedure(command);
            }
            catch (SqlException ex)
            {
                ex.ToString();
                return;
            }

            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }
        }

        /*******************************************************A method to delete a Genre from database* ************************************************************/
        public void DeleteGenre(int genreID)
        {
            //Creates an instance of SqlCommand
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spDeleteGenre",
                CommandType = CommandType.StoredProcedure
            };

            //Sets Parameters' values & Adds them to the SqlCommand object
            command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;

            try
            {
                //Executes the SqlCommand
                DataAccess.ExecuteProcedure(command);
            }
            catch (SqlException ex)
            {
                ex.ToString();
                return;
            }

            finally
            {
                //Clears Parameters
                command.Parameters.Clear();
                command.Dispose();
            }
        }

        /*******************************************************A method to Check whether Genre Name exists or not ************************************************************/
        public bool CheckIfGenreExists(string genreName)
        {
            bool genreExists = false;
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spCheckIfGenreExists",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            command.Parameters.Add("@genreName", SqlDbType.NVarChar).Value = genreName;

            try
            {
                //Executes the SqlCommand
                int result = DataAccess.ReturnSingleValue(command);

                if (result == 1)
                    genreExists = true;
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
            return genreExists;
        }

        /*******************************************************A method to retrieve a Genre By their names from database************************************************************/
        public DataSet SearchGenresByName(string searchTerm)
        {
            DataSet ds = new DataSet();

            //Creates an instance of SqlCommand & Sets its type
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spSearchGenresByName",
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

        /*******************************************************A method to retrieve Genres from database************************************************************/
        public DataSet BindGenres()
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spBindGenres",
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
        /*******************************************************A method to retrieve a genre by its ID from database************************************************************/
        public Genre GetGenreByID(int genreID)
        {
            DataSet ds = null;
            Genre genre = new Genre();

            //Creates an instance of SqlCommand & Sets its type
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spGetGenreByID",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds it to the SqlCommand object
            command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;

            try
            {
                //Executes the SqlCommand
                ds = DataAccess.SelectData(command);

                if (ds != null)
                {
                    ds.Tables[0].TableName = "genre";
                    genre.Name = ds.Tables["genre"].Rows[0][0].ToString();
                    genre.Description = ds.Tables["genre"].Rows[0][1].ToString();
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

            return genre;
        }
    }
}
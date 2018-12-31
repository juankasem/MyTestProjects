using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Edition { get; set; }
        public string Language { get; set; }
        public int PagesNumber { get; set; }
        public double Price { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Book()
        {

        }

        public Book(string isbn, string title, int genreID, string coverImage, string description, int authorID, int publisherID, DateTime publicationDate,
                    int edition, string language, int pagesNumber, double price, DateTime registrationDate)
        {
            ISBN = isbn;
            Title = title;
            GenreID = genreID;
            CoverImage = coverImage;
            Description = description;
            AuthorID = authorID;
            PublisherID = publisherID;
            PublicationDate = publicationDate;
            Edition = edition;
            Language = language;
            PagesNumber = pagesNumber;
            Price = price;
            RegistrationDate = registrationDate;
        }

        /************************************************A method to append a new Author into database*************************************************/
        public int AddBook(Book book)
        {
            int bookID = -1;

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddBook",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = book.ISBN;
            sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = book.Title;
            sqlCommand.Parameters.Add("@genreID", SqlDbType.Int).Value = book.GenreID;
            sqlCommand.Parameters.Add("@coverImage", SqlDbType.NVarChar).Value = book.CoverImage;
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = book.Description;
            sqlCommand.Parameters.Add("@authorID", SqlDbType.Int).Value = book.AuthorID;
            sqlCommand.Parameters.Add("@publisherID", SqlDbType.Int).Value = book.PublisherID;
            sqlCommand.Parameters.Add("@publicationDate", SqlDbType.Date).Value = book.PublicationDate;
            sqlCommand.Parameters.Add("@edition", SqlDbType.Int).Value = book.Edition;
            sqlCommand.Parameters.Add("@language", SqlDbType.NVarChar).Value = book.Language;
            sqlCommand.Parameters.Add("@pagesNumber", SqlDbType.Int).Value = book.PagesNumber;
            sqlCommand.Parameters.Add("@price", SqlDbType.Float).Value = book.Price;
            sqlCommand.Parameters.Add("@registrationDate", SqlDbType.Date).Value = book.RegistrationDate;
            
            //Initializes an outpt parameter to retrieve the ID of the Book
            sqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@bookID", SqlDbType = SqlDbType.Int,
                Value = -1, Direction = ParameterDirection.Output
            });

            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                DataAccess.ExecuteProcedure(sqlCommand);

                //Sets the ID value of the registered book to a variable 
                bookID = Convert.ToInt32(sqlCommand.Parameters["@bookID"].Value);
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

            return bookID;
        }

        /***************************************************A Method to update an existing book into database************************************************************/
        public void UpdateBook(int bookID, Book book)
        {
            //Creates an instance of SqlCommand
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdateBook",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;
            sqlCommand.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = book.ISBN;
            sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = book.Title;
            sqlCommand.Parameters.Add("@genreID", SqlDbType.Int).Value = book.GenreID;
            sqlCommand.Parameters.Add("@coverImage", SqlDbType.NVarChar).Value = book.CoverImage;
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = book.Description;
            sqlCommand.Parameters.Add("@authorID", SqlDbType.Int).Value = book.AuthorID;
            sqlCommand.Parameters.Add("@publisherID", SqlDbType.Int).Value = book.PublisherID;
            sqlCommand.Parameters.Add("@publicationDate", SqlDbType.Date).Value = book.PublicationDate;
            sqlCommand.Parameters.Add("@edition", SqlDbType.Int).Value = book.Edition;
            sqlCommand.Parameters.Add("@language", SqlDbType.NVarChar).Value = book.Language;
            sqlCommand.Parameters.Add("@pagesNumber", SqlDbType.Int).Value = book.PagesNumber;
            sqlCommand.Parameters.Add("@price", SqlDbType.Float).Value = book.Price;
            sqlCommand.Parameters.Add("@registrationDate", SqlDbType.Date).Value = book.RegistrationDate;

            try
            {
                //Executes the command
                DataAccess.ExecuteProcedure(sqlCommand);
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
        }

        /***************************************************A Method to delete a book from database************************************************************/
        public void DeleteBook(int bookID)
        {
            //Creates an instance of SqlCommand
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spDeleteBook",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;
    
            try
            {
                DataAccess.ExecuteProcedure(command);
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                command.Parameters.Clear();
                command.Dispose();
            }
        }

        /*******************************************************A method to Check whether book alreadyt exists or not ************************************************************/
        public bool CheckIfBookExists(string title, int edition)
        {
            bool bookExists = false;

            //Creates an instance of SqlCommand
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spCheckIfBookExists",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameters' values & Adds them to the SqlCommand object
            command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
            command.Parameters.Add("@edition", SqlDbType.Int).Value = edition;

            try
            {
                //Executes the SqlCommand
                int result = DataAccess.ReturnSingleValue(command);

                if (result == 1)
                    bookExists = true;
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

            return bookExists;
        }

        /*******************************************************A method to Bind Book Title ************************************************************/
        public DataSet BindBooks()
        {
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand()
            {
                CommandText = "spBindBooks",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                //Executes the SqlComman
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

        /*******************************************************A method to Get a book By its ID ************************************************************/
        public Book GetBookByID(int bookID)
        {
            DataSet ds = new DataSet();
            Book book = new Book();

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spGetBookByID",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds them to the SqlCommand object
            command.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;

            try
            {
                //Executes the SqlComman
                ds = DataAccess.SelectData(command);
                
                if(ds != null)
                {
                    ds.Tables[0].TableName = "Book";
                    book.ISBN = ds.Tables["Book"].Rows[0][0].ToString();
                    book.Title= ds.Tables["Book"].Rows[0][1].ToString();
                    book.GenreID= Convert.ToInt32( ds.Tables["Book"].Rows[0][2].ToString());
                    book.CoverImage= ds.Tables["Book"].Rows[0][3].ToString();
                    book.Description= ds.Tables["Book"].Rows[0][4].ToString();
                    book.AuthorID= Convert.ToInt32(ds.Tables["Book"].Rows[0][5].ToString());
                    book.PublisherID= Convert.ToInt32(ds.Tables["Book"].Rows[0][6].ToString());
                    book.PublicationDate = Convert.ToDateTime(ds.Tables["Book"].Rows[0][7].ToString());
                    book.Edition= Convert.ToInt32(ds.Tables["Book"].Rows[0][8].ToString());
                    book.Language= ds.Tables["Book"].Rows[0][9].ToString();
                    book.PagesNumber= Convert.ToInt32(ds.Tables["Book"].Rows[0][10].ToString());
                    book.Price= Convert.ToDouble(ds.Tables["Book"].Rows[0][11].ToString());
                    book.RegistrationDate= Convert.ToDateTime(ds.Tables["Book"].Rows[0][12].ToString());
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

            return book;
        }
        /*******************************************************A method to Bind Books By Genre ************************************************************/
        public DataSet GetBookByISBN(string isbn)
        {
            DataSet ds = new DataSet();

            //Creates an instance of SqlCommand & Sets its properties
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spGetBookByISBN",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds them to the SqlCommand object
            command.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = isbn;

            try
            {
                //Executes the SqlComman
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

        /*******************************************************A method to Bind Books By Genre ************************************************************/
        public DataSet BindBooksByGenre(int genreID)
        {
            DataSet ds = new DataSet();
            SqlCommand command = new SqlCommand()
            {
                CommandText = "spBindBooksByGenre",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a Parameter's value & Adds them to the SqlCommand object
            command.Parameters.Add("@genreID", SqlDbType.Int).Value = genreID;

            try
            {
                //Executes the SqlComman
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
    }
}
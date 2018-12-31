using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Inventory
    {
        public int BookID { get; set; }
        public int TotalCopies { get; set; }
        public int IssuedCopies { get; set; }
        public string Status { get; set; }
        public string SectionID { get; set; }
        public string RackID { get; set; }
        public string ShelfID { get; set; }

        public Inventory()
        {

        }

        public Inventory(int bookID,int totalCopies, int issuedCopies, string status, string sectionID, string rackID, string shelfID)
        {
            BookID = bookID;
            TotalCopies = totalCopies;
            IssuedCopies = issuedCopies;
            Status = status;
            SectionID = sectionID;
            RackID = rackID;
            ShelfID = shelfID;
        }

        /************************************************A method to append a new Inventory into database*************************************************/
        public void AddInventory(Inventory inventory)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spAddInventory",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int).Value = inventory.BookID;
            sqlCommand.Parameters.Add("@totalCopies", SqlDbType.Int).Value = inventory.TotalCopies;
            sqlCommand.Parameters.Add("@issuedCopies", SqlDbType.Int).Value = inventory.IssuedCopies;
            sqlCommand.Parameters.Add("@status", SqlDbType.NVarChar).Value = inventory.Status;
            sqlCommand.Parameters.Add("@sectionID", SqlDbType.NVarChar).Value = inventory.SectionID;
            sqlCommand.Parameters.Add("@rackID", SqlDbType.NVarChar).Value = inventory.RackID;
            sqlCommand.Parameters.Add("@shelfID", SqlDbType.NVarChar).Value = inventory.ShelfID;

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

        /************************************************A method to update an existig inventory into database*************************************************/
        public void UpdateInventory(Inventory inventory)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spUpdateInventory",
                CommandType = CommandType.StoredProcedure
            };

            //Sets parameters' values & Adds them to the SqlCommand object
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int).Value = inventory.BookID;
            sqlCommand.Parameters.Add("@totalCopies", SqlDbType.Int).Value = inventory.TotalCopies;
            sqlCommand.Parameters.Add("@issuedCopies", SqlDbType.Int).Value = inventory.IssuedCopies;
            sqlCommand.Parameters.Add("@status", SqlDbType.NVarChar).Value = inventory.Status;
            sqlCommand.Parameters.Add("@sectionID", SqlDbType.NVarChar).Value = inventory.SectionID;
            sqlCommand.Parameters.Add("@rackID", SqlDbType.NVarChar).Value = inventory.RackID;
            sqlCommand.Parameters.Add("@shelfID", SqlDbType.NVarChar).Value = inventory.ShelfID;

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

        /************************************************A method to delete an inventory from database*************************************************/
        public void DeleteInventory(int bookID)
        {
            //Initializes an instance of SqlCommand class
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "spDeleteInventory",
                CommandType = CommandType.StoredProcedure
            };

            //Sets a parameter's value & Adds it to the SqlCommand object
            sqlCommand.Parameters.Add("@bookID", SqlDbType.Int, 5).Value = bookID;

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
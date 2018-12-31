using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class Membership
    {
        public int MemberID { get; set; }
        public string LibraryCardNo { get; set; }
        public string Type { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Membership()
        {

        }

        public Membership(int memberID, string libraryCardNo, string type, DateTime validFromDate, DateTime expirationDate)
        {
            MemberID = memberID;
            LibraryCardNo = libraryCardNo;
            Type = type;
            ValidFromDate = validFromDate;
            ExpirationDate = expirationDate;
        }

        /************************************************A method to append a new membership into database*************************************************/
        public void AddMembership(Membership membership)
        {

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddMembership",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@membershipID", SqlDbType.Int).Value = membership.MemberID;
            sqlCommand.Parameters.Add("@libraryCardNo", SqlDbType.NVarChar).Value = membership.LibraryCardNo;
            sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar).Value = membership.Type;
            sqlCommand.Parameters.Add("@validFromDate", SqlDbType.Date).Value = membership.ValidFromDate;
            sqlCommand.Parameters.Add("@expirationDate", SqlDbType.Date).Value = membership.ExpirationDate;
        
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

        /************************************************A method to update an existig membership into database*************************************************/
        public void UpdateMembership(Membership membership)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spUpdateMembership",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@membershipID", SqlDbType.Int).Value = membership.MemberID;
            sqlCommand.Parameters.Add("@libraryCardNo", SqlDbType.NVarChar).Value = membership.LibraryCardNo;
            sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar).Value = membership.Type;
            sqlCommand.Parameters.Add("@validFromDate", SqlDbType.Date).Value = membership.ValidFromDate;
            sqlCommand.Parameters.Add("@expirationDate", SqlDbType.Date).Value = membership.ExpirationDate;

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

        /************************************************A method to delete a membership from database*************************************************/
        public void DeleteMembership(int membershipID)
        {
            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeleteMembership",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameter to the SqlCommand object & Sets its value
            sqlCommand.Parameters.Add("@membershipID", SqlDbType.Int).Value = membershipID;

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

        /************************************************A method to delete a membership from database*************************************************/
        public DataSet GetMemberByLibraryCardNo(string cardNo)
        {
            DataSet ds = new DataSet();

            //Initializes an SqlCommand object & Sets Values to its properties
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spGetMemberByLibraryCardNo",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameter to the SqlCommand object & Sets its value
            sqlCommand.Parameters.Add("@cardNo", SqlDbType.NVarChar).Value = cardNo;

            try
            {
                //Calls a DataAccess layer method to execute the Sql command
                ds= DataAccess.SelectData(sqlCommand);
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

            return ds;
        }
    } 
}
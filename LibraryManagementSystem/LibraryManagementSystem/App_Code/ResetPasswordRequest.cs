using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.App_Code
{
    public class ResetPasswordRequest
    {
        public string GUID { get; set; }
        public int UserID { get; set; }
        public DateTime RequestDateTime { get; set; }

        public ResetPasswordRequest()
        {

        }

        public ResetPasswordRequest(string guid, int userID, DateTime requestDateTime)
        {
            GUID = guid;
            UserID = userID;
            RequestDateTime = requestDateTime;
        }

        /************************************************A method to append a new request to reset Password into database*************************************************/
        public void AddResetPasswordRequest(ResetPasswordRequest request)
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spAddResetPasswordRequest",
                CommandType = CommandType.StoredProcedure
            };

            //Adds parameters to the SqlCommand object & Sets their values
            sqlCommand.Parameters.Add("@guid", SqlDbType.NVarChar).Value = request.GUID;
            sqlCommand.Parameters.Add("@userID", SqlDbType.Int).Value = request.UserID;
            sqlCommand.Parameters.Add("@requestDateTime", SqlDbType.DateTime).Value = request.RequestDateTime;

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
                sqlCommand.Dispose();
            }
        }

        /******************************************A method to delete a request to reset Password from database*************************************************/
        public void DeleteResetPasswordRequest(int userID)
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spDeleteResetPasswordRequest",
                CommandType = CommandType.StoredProcedure
            };

            //Add a parameter to the SqlCommand & Sets its value
            sqlCommand.Parameters.Add("@userID", SqlDbType.Int).Value = UserID;

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
                sqlCommand.Dispose();
            }
        }

        /************************************************A method to retrieve a user's ID from database by providing their GUID*************************************************/
        public int GetUserIDByGUID(string guid)
        {
            int userID = -1;
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = "spGetUserIDByGUID",
                CommandType = CommandType.StoredProcedure
            };

            //Adds a parameter to the SqlCommand object
            sqlCommand.Parameters.Add("@guid", SqlDbType.NVarChar).Value = guid;

            try
            {
                userID = DataAccess.ReturnSingleValue(sqlCommand);
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
            }

            return userID;
        }
    }
}
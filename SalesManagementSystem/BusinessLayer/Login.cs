using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SalesManagementSystem.DataAccessLayer;

namespace SalesManagementSystem.BusinessLayer
{
    class Login
    {
      
        public DataTable UserLogin(string ID, string password)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = DataAccess.AddParameter("@ID", ID, SqlDbType.VarChar, 50);
            parameters[1] = DataAccess.AddParameter("@password", password, SqlDbType.VarChar, 50);

            //Execute the stored procedure
            DataTable dt = DataAccess.Selectdata("spLogin", parameters);

            return dt;
        }

        public void AddUser(string username, string password,string usertype, string fullname)
        {
            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[4];

            //Set array of parameters with required values
            param[0] = DataAccess.AddParameter("@username",username, SqlDbType.VarChar, 50);
            param[1] = DataAccess.AddParameter("@password", password, SqlDbType.VarChar, 50);
            param[2] = DataAccess.AddParameter("@usertype", usertype, SqlDbType.VarChar, 50);
            param[3] = DataAccess.AddParameter("@fullname", fullname, SqlDbType.VarChar, 50);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("AddUser", param);
        }

        public void UpdateUser(string username, string password, string usertype, string fullname)
        {
            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[4];

            //Set array of parameters with required values
            param[0] = DataAccess.AddParameter("@username", username, SqlDbType.VarChar, 50);
            param[1] = DataAccess.AddParameter("@password", password, SqlDbType.VarChar, 50);
            param[2] = DataAccess.AddParameter("@usertype", usertype, SqlDbType.VarChar, 50);
            param[3] = DataAccess.AddParameter("@fullname", fullname, SqlDbType.VarChar, 50);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("UpdateUser", param);
        }

        public void DeleteUser(string username)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@username", username, SqlDbType.VarChar, 50);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("DeleteUser", param);
        }
        public DataTable SearchUser(string searchText)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@searchText", searchText, SqlDbType.VarChar, 50);

            //Execute the stored procedure
            dt = DataAccess.Selectdata("SearchUser", param);

            return dt;
        }
    }
}

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
    class Customer
    {

        public DataTable Get_All_Customers()
        {
            DataTable dt = DataAccess.Selectdata("Get_All_Customers", null);

            return dt;

        }


        public void AddCustomer(string firstName, string lastName, string phone, string email, byte[] image,string criterion)
        {
            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[6];

            //Set array of parameters with required values
            param[0] = DataAccess.AddParameter("@firstName", firstName, SqlDbType.VarChar, 50);
            param[1] = DataAccess.AddParameter("@lastName", lastName, SqlDbType.VarChar, 50);
            param[2] = DataAccess.AddParameter("@phone", phone, SqlDbType.VarChar, 50);
            param[3] = DataAccess.AddParameter("@email", email, SqlDbType.VarChar, 50);
            param[4] = new SqlParameter("@image", SqlDbType.Image);
            param[4].Value = image;
            param[5] = DataAccess.AddParameter("@criterion", criterion, SqlDbType.VarChar, 20);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("AddCustomer", param);
        }

        public void EditCustomer(string firstName, string lastName, string phone, string email, byte[] image, string criterion,int id)
        {

            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[7];

            //Set array of parameters with required values
            param[0] = DataAccess.AddParameter("@firstName", firstName, SqlDbType.VarChar, 50);
            param[1] = DataAccess.AddParameter("@lastName", lastName, SqlDbType.VarChar, 50);
            param[2] = DataAccess.AddParameter("@phone", phone, SqlDbType.VarChar, 50);
            param[3] = DataAccess.AddParameter("@email", email, SqlDbType.VarChar, 50);
            param[4] = new SqlParameter("@image", SqlDbType.Image);
            param[4].Value = image;
            param[5] = DataAccess.AddParameter("@criterion", criterion, SqlDbType.VarChar, 20);
            param[6] = DataAccess.AddParameter("@id", id, SqlDbType.Int, 10);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("EditCustomer", param);
        }

        public void DeleteCustomer(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@id", id, SqlDbType.Int, 20);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("DeleteCustomer", param);
        }

        public DataTable SearchCustomer(string searchText)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@searchText", searchText, SqlDbType.VarChar, 50);

            //Execute the stored procedure
           dt= DataAccess.Selectdata("SearchCustomer", param);

            return dt;
        }
    }
}

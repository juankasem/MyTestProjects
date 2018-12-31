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
    class Product
    {
        public DataTable Get_All_Categories()
        {
            DataTable dt = DataAccess.Selectdata("Get_All_Categories", null);

            return dt;   
        }


        public void AddProduct(string productID, string label, int quantity, double price, byte[] image, int catID)
        {
            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[6];

            //Set array of parameters with required values
            param[0] = DataAccess.AddParameter("@product_ID", productID, SqlDbType.VarChar, 20);
            param[1] = DataAccess.AddParameter("@label", label, SqlDbType.VarChar, 50);
            param[2] = DataAccess.AddParameter("@quantity", quantity, SqlDbType.Int, 10);
            param[3] = DataAccess.AddParameter("@price", price, SqlDbType.Float, 10);
            param[4] = new SqlParameter("@image", SqlDbType.Image);
            param[4].Value = image;
            param[5] = DataAccess.AddParameter("@cat_ID", catID, SqlDbType.Int, 10);

            //Execute the stored procedure
             DataAccess.ExecuteProcedure("Add_Product", param);          
        }

        public void DeleteProduct(string productID)
        {
            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@id", productID, SqlDbType.VarChar, 20);
          
            //Execute the stored procedure
             DataAccess.ExecuteProcedure("DeleteProduct", param);            
        }

        public void UpdateProduct(string productID, string label, int quantity, double price, byte[] image, int catID)
        {
            //Create An SqlParameter array object 
            SqlParameter[] param = new SqlParameter[6];

            //Set array of parameters with required values
            param[0] = DataAccess.AddParameter("@product_ID", productID, SqlDbType.VarChar, 20);
            param[1] = DataAccess.AddParameter("@label", label, SqlDbType.VarChar, 50);
            param[2] = DataAccess.AddParameter("@quantity", quantity, SqlDbType.Int, 10);
            param[3] = DataAccess.AddParameter("@price", price, SqlDbType.Float, 10);
            param[4] = new SqlParameter("@image", SqlDbType.Image);
            param[4].Value = image;
            param[5] = DataAccess.AddParameter("@cat_ID", catID, SqlDbType.Int, 10);

            //Execute the stored procedure
            DataAccess.ExecuteProcedure("UpdateProduct", param);
        }

        public DataTable VerifyProductID(string productID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@id", productID, SqlDbType.VarChar, 20);

            DataTable dt = DataAccess.Selectdata("VerifyProductID", param);

            return dt;
        }

        public DataTable SearchProduct(string searchString)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@ID", searchString, SqlDbType.VarChar, 20);

            DataTable dt = DataAccess.Selectdata("SearchProduct", param);

            return dt;
        }

        public DataTable GetProductImage(string id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DataAccess.AddParameter("@id", id, SqlDbType.VarChar, 20);

            DataTable dt = DataAccess.Selectdata("GetProductImage", param);

            return dt;
        }
        public DataTable Get_All_Products()
        {
            DataTable dt = DataAccess.Selectdata("Get_All_Products", null);

            return dt;

        }
    }
}

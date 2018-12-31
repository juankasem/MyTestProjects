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
    class Order
    {
        public DataTable GetLastOrderID()
        {
            DataTable dt = DataAccess.Selectdata("GetLastOrderID", null);

            return dt;
        }

        public DataTable GetLastOrderIDForPrint()
        {
            DataTable dt = DataAccess.Selectdata("GetLastOrderIDForPrint", null);

            return dt;
        }

        public void AddOrder(int orderID, DateTime orderDate, int customerID, string description, string salesman)
        {
            //Set up the array of SqlParameters object with their values
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParameter("@orderID", orderID, SqlDbType.Int, 20);
            param[1] = DataAccess.AddParameter("@orderDate", orderDate, SqlDbType.DateTime, 50);
            param[2] = DataAccess.AddParameter("@customerID", customerID, SqlDbType.Int, 20);
            param[3] = DataAccess.AddParameter("@description", description, SqlDbType.VarChar, 200);
            param[4] = DataAccess.AddParameter("@salesman", salesman, SqlDbType.VarChar, 50);

            //Excecute te stored procedure
            DataAccess.ExecuteProcedure("AddOrder", param);
        }

        //orderID, @productID, @quantity, @price, @discount,@amount, @totalAmount
        public void AddOrderDetails(int orderID, string productID, int quantity, double price, double discount, double amount, double totalAmount)
        {
            //Set up the array of SqlParameters object with their values
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParameter("@orderID", orderID, SqlDbType.Int, 20);
            param[1] = DataAccess.AddParameter("@productID", productID, SqlDbType.VarChar, 20);
            param[2] = DataAccess.AddParameter("@quantity", quantity, SqlDbType.Int, 20);
            param[3] = DataAccess.AddParameter("@price", price, SqlDbType.Float, 20);
            param[4] = DataAccess.AddParameter("@discount", discount, SqlDbType.Float, 20);
            param[5] = DataAccess.AddParameter("@amount", amount, SqlDbType.Float, 20);
            param[6] = DataAccess.AddParameter("@totalAmount", totalAmount, SqlDbType.Float, 20);


            //Excecute te stored procedure
            DataAccess.ExecuteProcedure("AddOrderDetails", param);
        }

        public DataTable VerifyQuantity(string productID, int quantity)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DataAccess.AddParameter("@productID", productID, SqlDbType.VarChar, 20);
            param[1] = DataAccess.AddParameter("@quantity", quantity, SqlDbType.Int, 20);

            DataTable dt = DataAccess.Selectdata("VerifyQuantity", param);

            return dt;
        }

    }
}

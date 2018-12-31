using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.Entities
{
    class Order
    {
        public int Order_ID { get; set; }
        public DateTime  Order_Date { get; set; }
        public int Customer_ID { get; set; }

        public Order(int orderId, DateTime orderDate, int customerId)
        {
            Order_Date = orderDate;
            Customer_ID = customerId;
        }
    }
}

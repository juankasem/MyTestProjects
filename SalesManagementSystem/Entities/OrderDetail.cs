using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.Entities
{
    class OrderDetail
    {
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }

        public OrderDetail(int orderId, int productId, int quantity)
        {
            Order_ID = orderId;
            Product_ID = productId;
            Quantity = quantity;
        }
    }


}

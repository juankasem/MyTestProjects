using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.Entities
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Product_Label { get; set; }
        public int  Quantity{ get; set; }
        public double Unit_Price { get; set; }
        public string Product_Image { get; set; }
        public int Cat_ID { get; set; }

        public Product (string label, int quantity, double price, string image, int catId)
        {
            Product_Label = label;
            Quantity = quantity;
            Unit_Price = price;
            Product_Image = image;
            Cat_ID = catId;
        }
    }
}

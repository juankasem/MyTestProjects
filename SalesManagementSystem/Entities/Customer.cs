using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.Entities
{
    class Customer
    {
        public int Customer_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Customer_Image { get; set; }

        public Customer(string firstName, string lastName, string phone, string email, string customerImage)
        {
            First_Name = firstName;
            Last_Name = lastName;
            Phone = phone;
            Email = email;
            Customer_Image = customerImage;
        }
    }
}

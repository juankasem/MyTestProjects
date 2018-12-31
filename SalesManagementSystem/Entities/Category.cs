﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.Entities
{
    public class Category
    {
        public int Category_ID { get; set; }
        public string  Category_Description { get; set; }

        public Category( string description)
        {
            Category_Description = description;

        }
    }

    
}
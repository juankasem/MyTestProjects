using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace MVCWineShop.Models
{
    public class WineDBContext:DbContext
    {
        public WineDBContext(): base("name=WineDBConnectionString")
        { }
     
        public DbSet<Wine> Wine { get; set; }
        public DbSet<Winery> Winery{ get; set; }
    }
}
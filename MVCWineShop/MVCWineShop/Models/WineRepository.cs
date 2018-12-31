using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWineShop.Models
{
    public class WineRepository
    {
        public List<Wine> GetWines()
        {
            WineDBContext wineDBContext = new WineDBContext();
            return wineDBContext.Wine.ToList();
        }
    }
}
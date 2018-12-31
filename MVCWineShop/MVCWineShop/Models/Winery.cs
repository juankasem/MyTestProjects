using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MVCWineShop.Models
{
    public class Winery
    {    
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public Country  Country { get; set; }
        public virtual  ICollection<Wine> Wines { get; set; }
    }

    public enum Country
    {
        France, Germany, Italy, Poland, India, UK, Netherlands, Other
    }
}
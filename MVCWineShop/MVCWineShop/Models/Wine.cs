using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MVCWineShop.Models
{
    public class Wine
    { 
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength (25, ErrorMessage ="Name must be shorter than 25 characters")]
        public string  Name { get; set; }

        [Range(10,200)]
        public double Price { get; set; }

        [Range(1950,2020)]
        public int YearOfBottling { get; set; }

        [Range(4.5,22,ErrorMessage ="Alcohol percentage must be between 4.5 and 22 %")]
        public double AlcoholPercentage { get; set; }
        public string ImagePath { get; set; }

        [DataType (DataType.MultilineText)]
        public string Description { get; set; }
        public WineType WineType { get; set; }
        [Display(Name ="Winery")]
        public int WineryId { get; set; }
        public virtual Winery Winery { get; set; }
    }

    public enum WineType
    {
        Sauvignon, Rieslinger, Syrah, Merlot,
        Cabernet, Other
    }
}
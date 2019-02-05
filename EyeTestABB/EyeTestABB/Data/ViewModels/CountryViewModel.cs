using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = " Enter a Name please")]
        public string Name { get; set; }
    }
}

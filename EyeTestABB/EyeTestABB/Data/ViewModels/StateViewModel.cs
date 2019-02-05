using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.ViewModels
{
    public class StateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Select a Country please")]
        public int CountryId { get; set; }

        [NotMapped]
        public List<SelectListItem> CountryList { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Enter a Name please")]
        public string Name { get; set; }
    }
}

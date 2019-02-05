using EyeTestABB.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyeTestABB.Data.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "First Name")]
        [DataType(DataType.Text, ErrorMessage = "Enter a valid Name please")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DataType(DataType.Text, ErrorMessage = "Enter a valid Name please")]
        public string LastName { get; set; }

        [Display(Name = "Contact Number 1")]
        public string ContactNumber1 { get; set; }

        [Display(Name = "Contact Number 2")]
        public string ContactNumber2 { get; set; }

        [Display(Name = "Contact Number 3")]
        public string ContactNumber3 { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailID { get; set; }

        [Display(Name = "Country")]
        //[Required(ErrorMessage = "Select Country please", AllowEmptyStrings = false)]
        public int CountryID { get; set; }

        [Display(Name = "State")]
        //[Required(ErrorMessage = "Select State please", AllowEmptyStrings = false)]
        public int StateID { get; set; }

        [NotMapped]
        public List<SelectListItem> CountryList { get; set; }

        [NotMapped]
        public List<SelectListItem> StateList { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Work Address")]
        public string WorkAddress { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }
}

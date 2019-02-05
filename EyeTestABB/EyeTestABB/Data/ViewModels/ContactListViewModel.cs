using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.ViewModels
{
    public class ContactListViewModel
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Contact Number1")]
        public string ContactNumber1 { get; set; }

        [Display(Name = "Contact Number2")]
        public string ContactNumber2 { get; set; }

        [Display(Name = "Contact Number3")]
        public string ContactNumber3 { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailId { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Work Address")]
        public string WorkAddress { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNumber1 { get; set; }

        public string ContactNumber2 { get; set; }

        public string ContactNumber3 { get; set; }

        public string CompanyName { get; set; }

        public string EmailId { get; set; }

        [Required]
        public int CountryId{ get; set; }

        [Required]
        public int StateId { get; set; }

        public string HomeAddress { get; set; }

        public string WorkAddress { get; set; }

        public string ImagePath { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}

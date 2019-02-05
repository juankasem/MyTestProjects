using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<State> States { get; set; }

    }
}

using EyeTestABB.Data.Interfaces;
using EyeTestABB.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ContactDbContext context) : base(context)
        {

        }

        public IEnumerable<Contact> GetAllContacts()
        {
                return _context.Contacts.Include("Country").Include("State");
        }

        public Contact GetContactById(int? id)
        {
            return _context.Contacts.Include("Country").Include("State").FirstOrDefault(c => c.ContactId == id);
        }
    }

}

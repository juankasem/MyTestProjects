using EyeTestABB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int? id);

    }
}

using EyeTestABB.Data.Interfaces;
using EyeTestABB.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(ContactDbContext context) : base(context)
        {

        }

        public IEnumerable<State> GetAllStates()
        {
            return _context.States.Include("Country");
        }

        public IEnumerable<State> GetStatesByCountryId(int id)
        {
            return _context.States.Where(c => c.CountryId == id);
        }
    }
}

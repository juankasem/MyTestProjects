using EyeTestABB.Data.Interfaces;
using EyeTestABB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(ContactDbContext context) : base(context)
        {

        }
    }
}

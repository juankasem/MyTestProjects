using EyeTestABB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTestABB.Data.Interfaces
{
    public interface IStateRepository : IRepository<State>
    {
        IEnumerable<State> GetAllStates();

        IEnumerable<State> GetStatesByCountryId(int id);
    }
}

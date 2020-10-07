using ATOM_CTO_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATOM_CTO_API.Data
{
    public interface ILocationRepository
    {
        void Add<T>(T entity) where T : class;
        Task<bool> SaveAllAsync();
    }
}

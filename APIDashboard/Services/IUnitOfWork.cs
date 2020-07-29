using APIDashboard.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDashboard.Services
{
    public interface IUnitOfWork
    {
        IRepository<TdCombustibles> Combustibles { get; }

        void Save();

    }
}

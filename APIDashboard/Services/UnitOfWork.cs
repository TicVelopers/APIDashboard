using APIDashboard.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDashboard.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBAPIDASHBOARDContext dbContext;
        private BaseRepository<TdCombustibles> _combustibles;
        public UnitOfWork(DBAPIDASHBOARDContext _dbContext) {
            dbContext = _dbContext;
        }

        public IRepository<TdCombustibles> Combustibles 
        {

            get {
                return _combustibles ?? (_combustibles = new BaseRepository<TdCombustibles>(dbContext));
            }
        
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}

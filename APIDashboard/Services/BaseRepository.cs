using APIDashboard.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIDashboard.Services
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DBAPIDASHBOARDContext dbContext;
        internal DbSet<TEntity> DbSet;

        public BaseRepository(DBAPIDASHBOARDContext dbContext) {

            this.dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (dbContext.Entry(entityToDelete).State == EntityState.Detached) {
                dbContext.Attach(entityToDelete);
            }
            dbContext.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null) {
                query = query.Where(filter);
            }

            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
           return DbSet.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            DbSet.Add(entityToInsert);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

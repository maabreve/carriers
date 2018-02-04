using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using FleetTracker.Data.Contract;

namespace FleetTracker.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public EfRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        //Insert
        public async Task<int> AddAsync(T t)
        {
            DbContext.Set<T>().Add(t);
            return await DbContext.SaveChangesAsync();
        }

        //Delete
        public async Task<int> RemoveAsync(T t)
        {
            DbContext.Entry(t).State = EntityState.Deleted;
            return await DbContext.SaveChangesAsync();
        }

        //Update
        public async Task<int> UpdateAsync(T t)
        {
            DbContext.Entry(t).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        //Get All
        public async Task<List<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        //Get Single
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        //Get All By Parameter
        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await DbContext.Set<T>().Where(match).ToListAsync();
        }

        //Count
        public async Task<int> CountAsync()
        {
            return await DbContext.Set<T>().CountAsync();
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.DbContext.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}

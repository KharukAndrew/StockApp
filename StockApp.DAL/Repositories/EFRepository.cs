using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.DAL.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        DbContext db;
        DbSet<T> dbSet;

        public EFRepository(DbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            T item = await GetAsync(id);
            if(item != null)
                dbSet.Remove(item);
        }        
    }
}

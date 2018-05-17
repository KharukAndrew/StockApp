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

        public T Get(int id)
        {
            return dbSet.Find(id);
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

        public void Delete(int id)
        {
            T item = Get(id);
            if(item != null)
                dbSet.Remove(item);
        }        
    }
}

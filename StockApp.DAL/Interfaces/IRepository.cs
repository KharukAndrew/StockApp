using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        //TODO: make to async method Find()
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        Task DeleteAsync(int id);
    }
}

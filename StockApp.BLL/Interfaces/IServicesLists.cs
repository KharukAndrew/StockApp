using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.BLL.Interfaces
{
    public interface IServicesLists<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}

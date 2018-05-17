﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.BLL.Interfaces
{
    public interface IServicesLists<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}

using StockApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Stock> Stocks { get; }
        IRepository<Product> Products { get; }
        IRepository<Provider> Providers { get; }

        void Save();
    }
}

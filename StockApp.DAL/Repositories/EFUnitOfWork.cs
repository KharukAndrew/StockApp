using StockApp.DAL.EF;
using StockApp.DAL.Entities;
using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ModelContext db;
        EFRepository<Stock> stocksRepository;
        EFRepository<Product> productsRepository;
        EFRepository<Provider> providersRepository;

        public EFUnitOfWork()
        {
            db = new ModelContext();
        }

        public IRepository<Stock> Stocks
        {
            get
            {
                if (stocksRepository == null)
                    stocksRepository = new EFRepository<Stock>(db);
                return stocksRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new EFRepository<Product>(db);
                return productsRepository;
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                if (providersRepository == null)
                    providersRepository = new EFRepository<Provider>(db);
                return providersRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

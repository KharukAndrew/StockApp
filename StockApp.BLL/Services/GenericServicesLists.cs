using AutoMapper;
using StockApp.BLL.Interfaces;
using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.BLL.Services
{
    //TODO: возможность создания генерик сервиса - как преобразовать Database.Stocks?
    public class GenericServicesLists<T, D> : IServicesLists<T> where T : class
    {
        IUnitOfWork Database { get; set; }

        public GenericServicesLists(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> list = Mapper.Map<IEnumerable<T>>(Database.Stocks.GetAll());

            return list;
        }

        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}

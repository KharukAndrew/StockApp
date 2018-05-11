using AutoMapper;
using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using StockApp.DAL.Entities;
using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace StockApp.BLL.Services
{
    public class StockService : IServicesLists<StockDTO>
    {
        IUnitOfWork Database { get; set; }

        public StockService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<StockDTO> GetAll()
        {
            IEnumerable<StockDTO> list = Mapper.Map<IEnumerable<StockDTO>>(Database.Stocks.GetAll());

            return list;
        }

        public StockDTO Get(int id)
        {
            StockDTO item = Mapper.Map<StockDTO>(Database.Stocks.Get(id));

            return item;
        }

        //TODO: необходимо сопоставление predicate
        public IEnumerable<StockDTO> Find(Func<StockDTO, bool> predicate)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stock, StockDTO>()).CreateMapper();
            IEnumerable<StockDTO> list = null;
                //mapper.Map<IEnumerable<Stock>, List<StockDTO>>(Database.Stocks.Find(predicate));

            return list;
        }

        public void Create(StockDTO item)
        {
            Stock stock = Mapper.Map<Stock>(item);
            Database.Stocks.Create(stock);
            Database.Save();
        }

        public void Update(StockDTO item)
        {
            Stock stock = Mapper.Map<Stock>(item);
            Database.Stocks.Update(stock);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Stocks.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }  
    }
}

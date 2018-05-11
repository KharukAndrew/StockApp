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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stock, StockDTO>()).CreateMapper();
            IEnumerable<StockDTO> list = mapper.Map<IEnumerable<Stock>, List<StockDTO>>(Database.Stocks.GetAll());

            return list;
        }

        public StockDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stock, StockDTO>()).CreateMapper();
            StockDTO item = mapper.Map<Stock, StockDTO>(Database.Stocks.Get(id));

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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, Stock>()).CreateMapper();
            Stock stock = mapper.Map< StockDTO, Stock>(item);
            Database.Stocks.Create(stock);
            Database.Save();
        }

        public void Update(StockDTO item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, Stock>()).CreateMapper();
            Stock stock = mapper.Map<StockDTO, Stock>(item);
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

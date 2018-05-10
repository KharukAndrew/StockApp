using AutoMapper;
using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using StockApp.DAL.Entities;
using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Update(StockDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }  
    }
}

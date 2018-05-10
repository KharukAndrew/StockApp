using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockApp.DAL.Entities;

namespace StockApp.BLL.Services
{
    public class ProviderService : IServicesLists<ProviderDTO>
    {
        IUnitOfWork Database { get; set; }

        public ProviderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ProviderDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Provider, ProviderDTO>()).CreateMapper();
            
            return mapper.Map<IEnumerable<Provider>, List<ProviderDTO>>(Database.Providers.GetAll());
        }

        public void Create(ProviderDTO item)
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

        public IEnumerable<ProviderDTO> Find(Func<ProviderDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ProviderDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        

        public void Update(ProviderDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

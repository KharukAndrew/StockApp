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

        public ProviderDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Provider, ProviderDTO>()).CreateMapper();

            return mapper.Map<Provider, ProviderDTO>(Database.Providers.Get(id));
        }

        //TODO: Create this method!
        public IEnumerable<ProviderDTO> Find(Func<ProviderDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(ProviderDTO item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, Provider>()).CreateMapper();

            Database.Providers.Create(mapper.Map<ProviderDTO, Provider>(item));
            Database.Save();
        }

        public void Update(ProviderDTO item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, Provider>()).CreateMapper();

            Database.Providers.Update(mapper.Map<ProviderDTO, Provider>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Providers.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

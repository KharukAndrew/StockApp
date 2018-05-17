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

        public async Task<IEnumerable<ProviderDTO>> GetAllAsync()
        {            
            return Mapper.Map<IEnumerable<ProviderDTO>>(await Database.Providers.GetAllAsync());
        }

        public async Task<ProviderDTO> GetAsync(int id)
        {
            return Mapper.Map<ProviderDTO>(await Database.Providers.GetAsync(id));
        }

        //TODO: Create this method!
        public IEnumerable<ProviderDTO> Find(Func<ProviderDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(ProviderDTO item)
        {
            Database.Providers.Create(Mapper.Map<Provider>(item));
            await Database.SaveAsync();
        }

        public async Task UpdateAsync(ProviderDTO item)
        {
            Database.Providers.Update(Mapper.Map<Provider>(item));
            await Database.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Database.Providers.DeleteAsync(id);
            await Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

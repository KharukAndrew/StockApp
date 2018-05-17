using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using StockApp.DAL.Entities;
using StockApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace StockApp.BLL.Services
{
    public class ProductService : IServicesLists<ProductDTO>
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> list = await Database.Products.GetAllAsync();

            IEnumerable<ProductDTO> listDTO = Mapper.Map<IEnumerable<ProductDTO>>(list);

            return listDTO;
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            Product product = await  Database.Products.GetAsync(id);

            ProductDTO productDTO = Mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        //TODO: create method
        public IEnumerable<ProductDTO> Find(Func<ProductDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            Product product = Mapper.Map<Product>(productDTO);

            Database.Products.Create(product);
            await Database.SaveAsync();
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            Product product = Mapper.Map<Product>(productDTO);

            Database.Products.Update(product);
            await Database.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Database.Products.DeleteAsync(id);
            await Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

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

        public ProductDTO Get(int id)
        {
            Product product =  Database.Products.Get(id);

            ProductDTO productDTO = Mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        //TODO: create method
        public IEnumerable<ProductDTO> Find(Func<ProductDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(ProductDTO productDTO)
        {
            Product product = Mapper.Map<Product>(productDTO);

            Database.Products.Create(product);
            Database.Save();
        }

        public void Update(ProductDTO productDTO)
        {
            Product product = Mapper.Map<Product>(productDTO);

            Database.Products.Update(product);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Products.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

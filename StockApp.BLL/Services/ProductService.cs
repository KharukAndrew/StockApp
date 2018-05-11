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

        public IEnumerable<ProductDTO> GetAll()
        {
            IEnumerable<Product> list = Database.Products.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            IEnumerable<ProductDTO> listDTO = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(list);

            return listDTO;
        }

        public ProductDTO Get(int id)
        {
            Product product =  Database.Products.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            ProductDTO productDTO = mapper.Map<Product, ProductDTO>(product);

            return productDTO;
        }

        //TODO: create method
        public IEnumerable<ProductDTO> Find(Func<ProductDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            Database.Products.Create(product);
            Database.Save();
        }

        public void Update(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

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

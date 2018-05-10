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

        public void Create(ProductDTO item)
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

        public IEnumerable<ProductDTO> Find(Func<ProductDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        

        public void Update(ProductDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

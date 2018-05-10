using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StockApp.WEB.Models;

namespace StockApp.WEB.Controllers
{
    public class ProductsController : Controller
    {
        IServicesLists<ProductDTO> productService;

        public ProductsController(IServicesLists<ProductDTO> serv)
        {
            productService = serv;
        }
        // GET: Products
        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            IEnumerable<ProductViewModel> listView = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productService.GetAll());
            return View(listView);
        }
    }
}
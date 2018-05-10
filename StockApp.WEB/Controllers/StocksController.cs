using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockApp.BLL.Interfaces;
using StockApp.WEB.Models;
using AutoMapper;
using StockApp.BLL.DTO;

namespace StockApp.WEB.Controllers
{
    public class StocksController : Controller
    {
        IServicesLists<StockDTO> stockService;

        public StocksController(IServicesLists<StockDTO> serv)
        {
            this.stockService = serv;
        }
        // GET: Stocks
        public ActionResult Index()
        {
            IEnumerable<StockDTO> stockDTOs = stockService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
            IEnumerable<StockViewModel> list = mapper.Map<IEnumerable<StockDTO>, List<StockViewModel>>(stockDTOs);

            return View(list);
        }
    }
}
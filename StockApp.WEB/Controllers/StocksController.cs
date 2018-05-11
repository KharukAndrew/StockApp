using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockApp.BLL.Interfaces;
using StockApp.WEB.Models;
using AutoMapper;
using StockApp.BLL.DTO;
using System.Net;

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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StockViewModel stockView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockViewModel, StockDTO>()).CreateMapper();
            StockDTO stockDTO = mapper.Map<StockViewModel, StockDTO>(stockView);
            stockService.Create(stockDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockDTO stockDTO = stockService.Get(id.Value);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
            StockViewModel stockView = mapper.Map<StockDTO, StockViewModel>(stockDTO);

            return View(stockView);
        }

        [HttpPost]
        public ActionResult Edit(StockViewModel stockView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockViewModel, StockDTO>()).CreateMapper();
            StockDTO stockDTO = mapper.Map<StockViewModel, StockDTO>(stockView);

            stockService.Update(stockDTO);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockDTO stockDTO = stockService.Get(id.Value);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
            StockViewModel stockView = mapper.Map<StockDTO, StockViewModel>(stockDTO);

            return View(stockView);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockDTO stockDTO = stockService.Get(id.Value);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
            StockViewModel stockView = mapper.Map<StockDTO, StockViewModel>(stockDTO);

            return View(stockView);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            stockService.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            stockService.Dispose();
            base.Dispose(disposing);
        }
    }
}
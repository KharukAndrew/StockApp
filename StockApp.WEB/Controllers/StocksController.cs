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
            IEnumerable<StockViewModel> list = Mapper.Map<IEnumerable<StockViewModel>>(stockService.GetAll());

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(StockViewModel stockView)
        {
            StockDTO stockDTO = Mapper.Map<StockDTO>(stockView);

            stockService.Create(stockDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockViewModel stockView = Mapper.Map<StockViewModel>(stockService.Get(id.Value));

            return PartialView(stockView);
        }

        [HttpPost]
        public ActionResult Edit(StockViewModel stockView)
        {
            stockService.Update(Mapper.Map<StockDTO>(stockView));

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockViewModel stockView = Mapper.Map<StockViewModel>(stockService.Get(id.Value));

            return PartialView(stockView);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockViewModel stockView = Mapper.Map<StockViewModel>(stockService.Get(id.Value));

            return PartialView(stockView);
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
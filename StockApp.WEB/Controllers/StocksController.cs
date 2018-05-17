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
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index()
        {
            IEnumerable<StockViewModel> list = Mapper.Map<IEnumerable<StockViewModel>>(await stockService.GetAllAsync());

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(StockViewModel stockView)
        {
            StockDTO stockDTO = Mapper.Map<StockDTO>(stockView);

            await stockService.CreateAsync(stockDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockViewModel stockView = Mapper.Map<StockViewModel>(await stockService.GetAsync(id.Value));

            return PartialView(stockView);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(StockViewModel stockView)
        {
            await stockService.UpdateAsync(Mapper.Map<StockDTO>(stockView));

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockViewModel stockView = Mapper.Map<StockViewModel>(await stockService.GetAsync(id.Value));

            return PartialView(stockView);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StockViewModel stockView = Mapper.Map<StockViewModel>(await stockService.GetAsync(id.Value));

            return PartialView(stockView);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await stockService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            stockService.Dispose();
            base.Dispose(disposing);
        }
    }
}
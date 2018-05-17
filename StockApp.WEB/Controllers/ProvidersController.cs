using StockApp.BLL.DTO;
using StockApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StockApp.WEB.Models;
using System.Net;
using System.Threading.Tasks;

namespace StockApp.WEB.Controllers
{
    public class ProvidersController : Controller
    {
        IServicesLists<ProviderDTO> providerService;

        public ProvidersController(IServicesLists<ProviderDTO> serv)
        {
            providerService = serv;
        }
        // GET: Providers
        public async Task<ActionResult> Index()
        {
            IEnumerable<ProviderViewModel> listView = Mapper.Map<IEnumerable<ProviderViewModel>>(await providerService.GetAllAsync());

            return View(listView);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ProviderViewModel providerView)
        {
            ProviderDTO providerDTO = Mapper.Map<ProviderDTO>(providerView);

            providerService.Create(providerDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = providerService.Get(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            ProviderViewModel providerView = Mapper.Map<ProviderViewModel>(providerDTO);

            return PartialView(providerView);
        }

        [HttpPost]
        public ActionResult Edit(ProviderViewModel providerView)
        {
            ProviderDTO providerDTO = Mapper.Map<ProviderDTO>(providerView);

            providerService.Update(providerDTO);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = providerService.Get(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            ProviderViewModel providerView = Mapper.Map<ProviderViewModel>(providerDTO);

            return PartialView(providerView);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = providerService.Get(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            ProviderViewModel providerView = Mapper.Map<ProviderViewModel>(providerDTO);

            return PartialView(providerView);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            providerService.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            providerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
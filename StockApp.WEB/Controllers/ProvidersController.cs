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
        public async Task<ActionResult> Create(ProviderViewModel providerView)
        {
            ProviderDTO providerDTO = Mapper.Map<ProviderDTO>(providerView);

            await providerService.CreateAsync(providerDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = await providerService.GetAsync(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            ProviderViewModel providerView = Mapper.Map<ProviderViewModel>(providerDTO);

            return PartialView(providerView);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProviderViewModel providerView)
        {
            ProviderDTO providerDTO = Mapper.Map<ProviderDTO>(providerView);

            await providerService.UpdateAsync(providerDTO);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = await providerService.GetAsync(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            ProviderViewModel providerView = Mapper.Map<ProviderViewModel>(providerDTO);

            return PartialView(providerView);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = await providerService.GetAsync(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            ProviderViewModel providerView = Mapper.Map<ProviderViewModel>(providerDTO);

            return PartialView(providerView);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await providerService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            providerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
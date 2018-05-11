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
        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, ProviderViewModel>()).CreateMapper();
            IEnumerable<ProviderViewModel> listView = mapper.Map<IEnumerable<ProviderDTO>, List<ProviderViewModel>>(providerService.GetAll());

            return View(listView);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProviderViewModel providerView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderViewModel, ProviderDTO>()).CreateMapper();
            ProviderDTO providerDTO = mapper.Map<ProviderViewModel, ProviderDTO>(providerView);

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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, ProviderViewModel>()).CreateMapper();
            ProviderViewModel providerView = mapper.Map<ProviderDTO, ProviderViewModel>(providerDTO);

            return View(providerView);
        }

        [HttpPost]
        public ActionResult Edit(ProviderViewModel providerView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderViewModel, ProviderDTO>()).CreateMapper();
            ProviderDTO providerDTO = mapper.Map<ProviderViewModel, ProviderDTO>(providerView);

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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, ProviderViewModel>()).CreateMapper();
            ProviderViewModel providerView = mapper.Map<ProviderDTO, ProviderViewModel>(providerDTO);

            return View(providerView);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProviderDTO providerDTO = providerService.Get(id.Value);

            if (providerDTO == null)
                return HttpNotFound();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProviderDTO, ProviderViewModel>()).CreateMapper();
            ProviderViewModel providerView = mapper.Map<ProviderDTO, ProviderViewModel>(providerDTO);

            return View(providerView);
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
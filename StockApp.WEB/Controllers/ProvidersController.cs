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
    }
}
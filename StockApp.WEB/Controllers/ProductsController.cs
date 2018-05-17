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
    public class ProductsController : Controller
    {
        IServicesLists<ProductDTO> productService;

        public ProductsController(IServicesLists<ProductDTO> serv)
        {
            productService = serv;
        }
        // GET: Products
        public async Task<ActionResult> Index()
        {
            IEnumerable<ProductViewModel> listView = Mapper.Map<IEnumerable<ProductViewModel>>(await productService.GetAllAsync());
            return View(listView);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productView)
        {
            ProductDTO productDTO = Mapper.Map<ProductDTO>(productView);
            productService.Create(productDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO productDTO = productService.Get(id.Value);

            if (productDTO == null)
                return HttpNotFound();

            ProductViewModel productView = Mapper.Map<ProductViewModel>(productDTO);
            return PartialView(productView);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productView)
        {
            ProductDTO productDTO = Mapper.Map<ProductDTO>(productView);

            productService.Update(productDTO);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO productDTO = productService.Get(id.Value);

            if (productDTO == null)
                return HttpNotFound();

            ProductViewModel productView = Mapper.Map<ProductViewModel>(productDTO);

            return PartialView(productView);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO productDTO = productService.Get(id.Value);

            if (productDTO == null)
                return HttpNotFound();

            ProductViewModel productView = Mapper.Map<ProductViewModel>(productDTO);

            return PartialView(productView);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            productService.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}
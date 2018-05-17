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
        public async Task<ActionResult> Create(ProductViewModel productView)
        {
            ProductDTO productDTO = Mapper.Map<ProductDTO>(productView);
            await productService.CreateAsync(productDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO productDTO = await productService.GetAsync(id.Value);

            if (productDTO == null)
                return HttpNotFound();

            ProductViewModel productView = Mapper.Map<ProductViewModel>(productDTO);
            return PartialView(productView);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel productView)
        {
            ProductDTO productDTO = Mapper.Map<ProductDTO>(productView);

            await productService.UpdateAsync(productDTO);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO productDTO = await productService.GetAsync(id.Value);

            if (productDTO == null)
                return HttpNotFound();

            ProductViewModel productView = Mapper.Map<ProductViewModel>(productDTO);

            return PartialView(productView);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductDTO productDTO = await productService.GetAsync(id.Value);

            if (productDTO == null)
                return HttpNotFound();

            ProductViewModel productView = Mapper.Map<ProductViewModel>(productDTO);

            return PartialView(productView);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await productService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}
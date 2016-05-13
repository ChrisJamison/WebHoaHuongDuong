using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using BusinessServices;
using BusinessEntities;

namespace WebHoaHuongDuong.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _iProductServices;
        private readonly ICategoryServices _iCategoryServices;

        public ProductController(IProductServices iProductServices, ICategoryServices iCategoryServices)
        {
            this._iProductServices = iProductServices;
            this._iCategoryServices = iCategoryServices;
        }
        //
        // GET: /Product/

        public ActionResult Index()
        {
            var products = _iProductServices.GetAllProduct();
            return View(products.ToList());
        }

        public ActionResult ViewIndex()
        {
            return View();
        }
        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductEntity product = _iProductServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            var category = _iCategoryServices.GetAllCategory();
            ViewBag.Category_ID = new SelectList(category, "Category_ID", "Name");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                _iProductServices.CreateProduct(productEntity);
                return RedirectToAction("Index");
            }
            var category = _iCategoryServices.GetAllCategory();
            ViewBag.Category_ID = new SelectList(category, "Category_ID", "Name", productEntity.Category_ID);
            return View(productEntity);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductEntity product = _iProductServices.GetProductById(id);
            var category = _iCategoryServices.GetAllCategory();
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(category, "Category_ID", "Name", product.Category_ID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEntity productEntity)
        {
            var category = _iCategoryServices.GetAllCategory();
            if (ModelState.IsValid)
            {
                _iProductServices.UpdateProduct(productEntity);
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(category, "Category_ID", "Name", productEntity.Category_ID);
            return View(productEntity);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductEntity product = _iProductServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iProductServices.DeleteProduct(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}
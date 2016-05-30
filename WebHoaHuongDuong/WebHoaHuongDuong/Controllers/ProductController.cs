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

        [ChildActionOnly]
        public ActionResult _SanPhamMoi()
        {
            var sanPham = _iProductServices.GetAllProduct().ToList();
            List<ProductEntity> sanPhamMoi = new List<ProductEntity>();
            sanPhamMoi.AddRange(sanPham);

            List<ProductEntity> sanPhamMoi2 = new List<ProductEntity>();
            for (var i = 0; i < 3; i++)
            {
                sanPhamMoi2.Add(sanPhamMoi.ElementAt(i));
            }
            return PartialView("_SanPhamMoiIndex", sanPhamMoi2);
        }

        [ChildActionOnly]
        public ActionResult _SanPhamXemNhieu()
        {
            var sanPham = _iProductServices.GetAllProduct().ToList();
            List<ProductEntity> sanPhamXemNhieu = new List<ProductEntity>();
            sanPhamXemNhieu.AddRange(sanPham);

            List<ProductEntity> sanPhamXemNhieu2 = new List<ProductEntity>();
            for (var i = 3; i < 6; i++)
            {
                sanPhamXemNhieu2.Add(sanPhamXemNhieu.ElementAt(i));
            }
            return PartialView("_SanPhamXemNhieuIndex", sanPhamXemNhieu2);
        }

        [ChildActionOnly]
        public ActionResult _SanPhamBanChay()
        {
            var sanPham = _iProductServices.GetAllProduct().ToList();
            List<ProductEntity> sanPhamBanChay = new List<ProductEntity>();
            sanPhamBanChay.AddRange(sanPham);

            List<ProductEntity> sanPhamBanChay2 = new List<ProductEntity>();
            for (var i = 9; i < 12; i++)
            {
                sanPhamBanChay2.Add(sanPhamBanChay.ElementAt(i));
            }
            return PartialView("_SanPhamBanChayIndex", sanPhamBanChay2);
        }

        [ChildActionOnly]
        public ActionResult _MyPham()
        {
            var sanPham = _iProductServices.GetAllProduct().ToList();
            List<ProductEntity> MyPham = new List<ProductEntity>();
            MyPham.AddRange(sanPham);

            List<ProductEntity> MyPham2 = new List<ProductEntity>();
            for (var i = 10; i < 13; i++)
            {
                MyPham2.Add(MyPham.ElementAt(i));
            }
            return PartialView("_MyPhamIndex", MyPham2);
        }

        [ChildActionOnly]
        public ActionResult _SuaXachTayChoBeYeu()
        {
            var sanPham = _iProductServices.GetAllProduct().ToList();
            List<ProductEntity> SuaXachTayChoBeYeu = new List<ProductEntity>();
            SuaXachTayChoBeYeu.AddRange(sanPham);

            List<ProductEntity> SuaXachTayChoBeYeu2 = new List<ProductEntity>();
            for (var i = 12; i < 15; i++)
            {
                SuaXachTayChoBeYeu2.Add(SuaXachTayChoBeYeu.ElementAt(i));
            }
            return PartialView("_SuaXachTayChoBeYeuIndex", SuaXachTayChoBeYeu2);
        }

        [ChildActionOnly]
        public ActionResult _ThucPhamDinhDuong()
        {
            var sanPham = _iProductServices.GetAllProduct().ToList();
            List<ProductEntity> ThucPhamDinhDuong = new List<ProductEntity>();
            ThucPhamDinhDuong.AddRange(sanPham);

            List<ProductEntity> ThucPhamDinhDuong2 = new List<ProductEntity>();
            for (var i = 15; i < 18; i++)
            {
                ThucPhamDinhDuong2.Add(ThucPhamDinhDuong.ElementAt(i));
            }
            return PartialView("_ThucPhamDinhDuongIndex", ThucPhamDinhDuong2);
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
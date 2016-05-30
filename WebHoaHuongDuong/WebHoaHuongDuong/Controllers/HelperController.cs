using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHoaHuongDuong.Controllers
{
    public class HelperController : Controller
    {
        //
        // GET: /Helper/
        private readonly ICategoryServices _iCategoryServices;
        private readonly IProductServices _iProductServices;
        public HelperController(ICategoryServices iCategoryServices, IProductServices iProductServices)
        {
            this._iCategoryServices = iCategoryServices;
            this._iProductServices = iProductServices;
        }

        [ChildActionOnly]
        public ActionResult _LeftMenu()
        {
            Menu menu = new Menu();
            menu.GetCategoryLevel1 = _iCategoryServices.GetAllCategory().Where(c => c.Parent_ID == 0);
            menu.GetCategoryLevel2 = _iCategoryServices.GetAllCategory().Where(c => c.Level == 2);
            menu.GetCategoryLevel3 = _iCategoryServices.GetAllCategory().Where(c => c.Level == 3);
            return PartialView("_LeftMenu",menu);
        }

        [ChildActionOnly]
        public ActionResult _TopMenu()
        {
            Menu menu = new Menu();
            menu.GetCategoryLevel1 = _iCategoryServices.GetAllCategory().Where(c => c.Parent_ID == 0);
            return PartialView("_TopMenu", menu);
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
            return PartialView("_TopMenu", sanPhamMoi2);
        }
    }
}

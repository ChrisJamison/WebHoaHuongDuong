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
        public HelperController(ICategoryServices iCategoryServices)
        {
            this._iCategoryServices = iCategoryServices;
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

    }
}

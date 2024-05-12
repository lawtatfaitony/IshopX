using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using LanguageResource;

namespace Ishop.Controllers
{
    [Authorize(Roles = "Supervisor,Admins,AdminAnalyst,BusinessPromotion,CustomerService,GlobalUser,StoreAdmin,StoreBusinessPromotion,StoreCustomersService,StorePreSales,StoreProductAdmin,StroeShippingClerk")]
    public class AdminController : BaseController
    {
        public AdminController() : base()
        {
        }
        // GET: Admin
        public ActionResult Index()
        {
            ShopInitialize();

            ViewBag.Title = Lang.Views_GeneralUI_Mgr_Platform;

            return View();
        }
    }
}
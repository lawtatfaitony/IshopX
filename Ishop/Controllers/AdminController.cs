using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}
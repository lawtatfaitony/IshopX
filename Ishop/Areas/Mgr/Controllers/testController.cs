using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ishop.Areas.Mgr.Models;
using Ishop.Controllers;

namespace Ishop.Areas.Mgr.Controllers
{
    public class testController : BaseController
    {
        // GET: Mgr/test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ModalDialogView F)
        {
            F.MsgCode = "12312321";
            F.Message = "Msgtest test test ";
            return View(F);
        }
    }
}
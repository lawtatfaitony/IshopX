using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PagedList;
using Ishop.Context;
using Ishop.Areas.Mgr.ModelView;
using Ishop.Areas.Mgr.Models;
using Ishop.Models.ProductMgr;
namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize(Roles = "StoreAdmin")]
    public class SupplierController : Controller
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Mgr/Supplier
        public ActionResult Index()
        {
            return View();
        } 
        [HttpGet] 
        public ActionResult SupplierAddOrUpd(string SupplierID)
        {
            if (!string.IsNullOrEmpty(SupplierID)) // 不等于null
            {
                // 返回 明细 
                var suppliers = db.Suppliers.Find(SupplierID);
                if (suppliers == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ViewBag.CurrentSupplierID = SupplierID; 
                return View(suppliers);
            }
            else
            { 
                return View();
            }

        }//ShopCampCreate
        [HttpPost]
        public ActionResult SupplierAddOrUpd(string SupplierID, [Bind(Include = "SupplierName,ContactNick,ContactName,PhoneNumber,CompanyName,CompanyAddress,ShopID,Remarks")]Supplier supplier)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            if (SupplierID == null)
            {
                supplier.SupplierID = db.GetTableIdentityID("Supp", "Supplier", 6);
                supplier.ShopID = WebCookie.ShopID; 
                supplier.OperatedUserName = User.Identity.Name;
                supplier.OperatedDate = DateTime.Now;
                //处理新增操作
                if (ModelState.IsValid)
                {
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "新增成功";
                    return Json(ModalDialogView1);
                }
                else
                {//处理输入无效数据
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "有无效的数据输入";
                    return Json(ModalDialogView1);
                }

            }
            else
            {
                //处理更新操作
                 
                supplier.OperatedUserName = User.Identity.Name;
                supplier.OperatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    UpdateModel<Supplier>(supplier);
                     
                    supplier.OperatedUserName = User.Identity.Name;
                    supplier.OperatedDate = DateTime.Now;
                    db.Entry(supplier).State = EntityState.Modified;
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "更新成功";
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "更新无效数据失败";
                    return Json(ModalDialogView1);
                }

            }
        }
        [HttpPost]
        public ActionResult SupplierDel(string SupplierID)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            if (SupplierID!= null)
            {
                //处理删除操作
                var suppliers = db.Suppliers.Find(SupplierID);
                if (suppliers!=null)
                {  
                    db.Entry(suppliers).State = EntityState.Deleted;
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "删除成功";
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "不存在记录"+ SupplierID;
                    return Json(ModalDialogView1);
                }
            }
            else
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "ID = null";
                return Json(ModalDialogView1);

            }
        }
        public ActionResult SupplierList(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var suppliers = from s in db.Suppliers
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            { 
                suppliers = suppliers.Where(s => s.ContactNick.Contains(searchString) || s.SupplierName.Contains(searchString) );
            }
            //店铺过滤
            suppliers = suppliers.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    suppliers = suppliers.OrderBy(s => s.OperatedDate);
                    break;
                case "date_desc":
                    suppliers = suppliers.OrderByDescending(s => s.OperatedDate);
                    break;
                default:  // Name ascending 
                    suppliers = suppliers.OrderBy(s => s.OperatedDate);
                    break;
            }

            int pageSize = 16;
            int pageNumber = (page ?? 1);
             
            return View(suppliers.ToPagedList(pageNumber, pageSize));
        }
    }
}
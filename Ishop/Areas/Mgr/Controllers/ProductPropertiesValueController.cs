using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ishop.Context;
using PagedList;
using Ishop.Models.ProductMgr; 
using Ishop.Models;
using Ishop.Appcode.Utilities;
using Ishop.Controllers;

namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize]
    public class ProductPropertiesValueController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
         
        public ActionResult Index(string ProdCateID, string ProdCateName, string PropertiesNameID, string PropertiesName,string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.ProdCateID = ProdCateID;
            ViewBag.ProdCateName = ProdCateName;
            ViewBag.PropertiesNameID = PropertiesNameID;
            ViewBag.PropertiesName = PropertiesName;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "PropertiesValueID" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var ProdPropertiesValue1 = from s in db.ProdPropertiesValues
                                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                ProdPropertiesValue1 = ProdPropertiesValue1.Where(s => s.PropertiesValueName.Contains(searchString)
                                       || s.PropertiesName.Contains(searchString) || s.ProdCateName.Contains(searchString));
            }
            else
            {
                ProdPropertiesValue1 = ProdPropertiesValue1.Where(s => s.PropertiesNameID.Contains(PropertiesNameID));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    ProdPropertiesValue1 = ProdPropertiesValue1.OrderBy(s => s.PropertiesValueName);
                    break;
                case "Date":
                    ProdPropertiesValue1 = ProdPropertiesValue1.OrderBy(s => s.OperatedDate.ToString());
                    break;
                case "date_desc":
                    ProdPropertiesValue1 = ProdPropertiesValue1.OrderByDescending(s => s.OperatedDate.ToString());
                    break;
                default:  // Name ascending 
                    ProdPropertiesValue1 = ProdPropertiesValue1.OrderByDescending(s => s.PropertiesValueName);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(ProdPropertiesValue1.ToPagedList(pageNumber, pageSize));
             
        }

        // GET: Mgr/ProductPropertiesValue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize(Roles = "Supervisor,Admins")]
        // GET: Mgr/ProductPropertiesValue/Create
        public ActionResult Create(string ProdCateID,string ProdCateName,string PropertiesNameID, string PropertiesName)
        { 
            if(string.IsNullOrEmpty(ProdCateID))
            {
                return RedirectToAction("index");

            } 
            ViewBag.ProdCateID = ProdCateID;
            ViewBag.ProdCateName = ProdCateName;
            ViewBag.PropertiesNameID = PropertiesNameID;
            ViewBag.PropertiesName = PropertiesName; 
            return View();
        }

        // POST: Mgr/ProductPropertiesValue/Create
        [Authorize(Roles = "Supervisor,Admins")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProdCateID, ProdCateName, PropertiesNameID,PropertiesName,PropertiesValueName")]ProdPropertiesValue prodPropertiesValue)
        {
            
            prodPropertiesValue.PropertiesValueID = db.GetTableIdentityID("1", "ProdPropertiesValue",4);
            prodPropertiesValue.OperatedUserName = User.Identity.Name;
            prodPropertiesValue.OperatedDate = DateTime.Now; 
            try
            {
                if (ModelState.IsValid)
                { 
                    db.ProdPropertiesValues.Add(prodPropertiesValue);
                    db.SaveChanges();
                    return RedirectToAction("Index",new { ProdCateID = prodPropertiesValue.ProdCateID, ProdCateName = prodPropertiesValue.ProdCateName, PropertiesNameID = prodPropertiesValue.PropertiesNameID, PropertiesName = prodPropertiesValue.PropertiesName });
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "尝试保存失败，如果多次无效，请联系管理员");
            }
            return View();
        } 
        [Authorize(Roles = "Supervisor,Admins")]
        public ActionResult Edit(string PropertiesValueID,string ProdCateID,string ProdCateName, string PropertiesNameID, string PropertiesName)
        {
            if (PropertiesValueID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ProdPropertiesValue prodPropertiesValue = db.ProdPropertiesValues.Find(PropertiesValueID);
            if (prodPropertiesValue == null)
            {
                return HttpNotFound();
            }
            //用于返回返回列表的url参数
            ViewBag.ProdCateID = ProdCateID;
            ViewBag.ProdCateName = ProdCateName;
            ViewBag.PropertiesNameID = PropertiesNameID;
            ViewBag.PropertiesName = PropertiesName;
            return View(prodPropertiesValue); 
        }

        [Authorize(Roles = "Supervisor,Admins")]
        [HttpPost]
        public ActionResult Edit(string PropertiesValueID, FormCollection collection)
        {
            if (PropertiesValueID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var prodPropertiesValueToUpdate = db.ProdPropertiesValues.Find(PropertiesValueID);
                prodPropertiesValueToUpdate.OperatedUserName = User.Identity.Name;
                prodPropertiesValueToUpdate.OperatedDate = DateTime.Now;

            if (TryUpdateModel(prodPropertiesValueToUpdate, "",
               new string[] { "PropertiesValueName", "UpdatedBy", "UpdatedDate" }))
            {
                try
                {
                    //用于返回返回列表的url参数
                    ViewBag.ProdCateID = prodPropertiesValueToUpdate.ProdCateID;
                    ViewBag.ProdCateName = prodPropertiesValueToUpdate.ProdCateName;
                    ViewBag.PropertiesNameID = prodPropertiesValueToUpdate.PropertiesNameID;
                    ViewBag.PropertiesName = prodPropertiesValueToUpdate.PropertiesName;

                    db.SaveChanges();

                    return RedirectToAction("Index", new { ProdCateID = prodPropertiesValueToUpdate.ProdCateID, ProdCateName = prodPropertiesValueToUpdate.ProdCateName, PropertiesNameID = prodPropertiesValueToUpdate.PropertiesNameID, PropertiesName = prodPropertiesValueToUpdate.PropertiesName });
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "无法保存变更。重试后问题依然存在请联系我们技术员管理员。");
                }
            }
            return View(prodPropertiesValueToUpdate);
        }

        [Authorize(Roles = "Supervisor,Admins")]
        public ActionResult Delete(string PropertiesValueID , bool? saveChangesError = false)
        {
            
            if (PropertiesValueID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            ProdPropertiesValue prodPropertiesValueToDel = db.ProdPropertiesValues.Find(PropertiesValueID);


            if (prodPropertiesValueToDel == null)
            { 
                return HttpNotFound();
            }
            //用于返回返回列表的url参数
            ViewBag.ProdCateID = prodPropertiesValueToDel.ProdCateID;
            ViewBag.ProdCateName = prodPropertiesValueToDel.ProdCateName;
            ViewBag.PropertiesNameID = prodPropertiesValueToDel.PropertiesNameID;
            ViewBag.PropertiesName = prodPropertiesValueToDel.PropertiesName;

            return View(prodPropertiesValueToDel);
        }

        [Authorize(Roles = "Supervisor,Admins")]
        [HttpPost]
        public ActionResult Delete(string PropertiesValueID, FormCollection collection)
        {
            ProdPropertiesValue prodPropertiesValueToDel = db.ProdPropertiesValues.Find(PropertiesValueID);
            try
            { 
                db.ProdPropertiesValues.Remove(prodPropertiesValueToDel);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { PropertiesValueID = PropertiesValueID, saveChangesError = true });
            }
            //用于返回返回列表的url参数
            ViewBag.ProdCateID = prodPropertiesValueToDel.ProdCateID;
            ViewBag.ProdCateName = prodPropertiesValueToDel.ProdCateName;
            ViewBag.PropertiesNameID = prodPropertiesValueToDel.PropertiesNameID;
            ViewBag.PropertiesName = prodPropertiesValueToDel.PropertiesName;

            return RedirectToAction("Index",new { ProdCateID = ViewBag.ProdCateID, ProdCateName = ViewBag.ProdCateName, PropertiesNameID = ViewBag.PropertiesNameID, PropertiesName = ViewBag.PropertiesName });
        }
        /// <summary>
        /// 返回序列化 属性性 数据集
        /// </summary>
        /// <param name="ProdCateID"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult ProdPropertiesName_Lst(string ProdCateID)
        {
            List<TreeviewsNode> IListPNdetails = new List<TreeviewsNode>();
            //DataSet DS_ProdPropertiesName_ListByProdCateID = ProductMgrDAL.ProdPropertiesName_ListByProdCateID(ProdCateID);
            var getItemByProdCateID = db.ProdPropertiesNames.Where(c => c.ProdCateID == ProdCateID);
            //DataTable DT = DS_ProdPropertiesName_ListByProdCateID.Tables[0];
            foreach (var item in getItemByProdCateID)
            {
                TreeviewsNode myTreeviewsNode = new TreeviewsNode();
                myTreeviewsNode.nodeid = item.PropertiesNameID;
                myTreeviewsNode.text = item.PropertiesName;
                myTreeviewsNode.custom = item.IsForTrading.ToString(); //传递其他值  是否交易属性
                IListPNdetails.Add(myTreeviewsNode);
            }
            //【反序列化】 输出 格式：[{"text":"裤脚","nodeid":"PN00000002","otherValue":"1"},{"text":"裤脚","nodeid":"PN00000002","otherValue":"1"}]
            //string json = JsonConvert.SerializeObject(IListPNdetails);
            //return json;

            //// 【反序列化 字符串】例如： {"d":"\"[{\\\"text\\\":\\\"裤脚\\\",\\\"nodeid\\\":\\\"PN00000002\\\",\\\"otherValue\\\":\\\"1\\\"},{\\\"text\\\":\\\"裤脚\\\",\\\"nodeid\\\":\\\"PN00000002\\\",\\\"otherValue\\\":\\\"1\\\"}]\""}  
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //String json = serializer.Serialize(ConvertJson.ListToTreeViewJson(IListPNdetails));
            //return json;


            ////【反序列化 II】 例如：{"d":"[{\"text\":\"裤脚\",\"nodeid\":\"PN00000002\",\"otherValue\":\"1\"},{\"text\":\"裤脚\",\"nodeid\":\"PN00000002\",\"otherValue\":\"1\"}]"}
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //String json = serializer.Serialize(IListPNdetails);
            //return json;

            // 【反序列化 字符串】例如： success/输出结果如下：{"d":"[{\"text\":\"裤脚\",\"nodeid\":\"PN00000002\",\"otherValue\":\"1\"},{\"text\":\"裤脚\",\"nodeid\":\"PN00000002\",\"otherValue\":\"1\"}]"}  

            //string json = ConvertJson.ListToTreeViewJson(IListPNdetails);
            //return json;
           
            return Json(IListPNdetails);
        }
        public class TreeviewsNode
        {
            public string text { get; set; }
            public string nodeid { get; set; }
            public string custom { get; set; }
        }
    }
}

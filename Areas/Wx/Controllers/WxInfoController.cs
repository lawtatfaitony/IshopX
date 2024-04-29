using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using Ishop.Context;
using Ishop.Models.Info;
using Ishop.Models.ProductMgr;
using Ishop.Models.PubDataModal;
using Ishop.Utilities;
using Ishop.ViewModes.Public;
using LanguageResource;
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Ishop.Areas.WxMiniProgram.ModelView;
using System.Web.Helpers;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using System.Collections;

namespace Ishop.Areas.WxMiniProgram.Controllers
{
    public class WxInfoController : Controller
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        // GET: WxMiniProgram/WxInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: WxMiniProgram/WxInfo/Details/5
        public JsonResult InfoDetails(string id)
        {
            MgInfoModelView mgInfoModelView = new MgInfoModelView();
            //获取InfoID
            UserTrace InfoTrace1 = db.UserTraces.Find(id);
            string InfoID = InfoTrace1.TableKeyID;

            InfoDetail infoDetail = db.InfoDetails.Find(InfoID);
            if (infoDetail == null)
            {
                return null;
            }

            infoDetail.Title = ChineseStringUtility.ToAutoTraditional(infoDetail.Title);
            infoDetail.SubTitle = ChineseStringUtility.ToAutoTraditional(infoDetail.SubTitle);
            infoDetail.Author = ChineseStringUtility.ToAutoTraditional(infoDetail.Author);
            infoDetail.InfoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.InfoDescription);
            infoDetail.SeoKeyword = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoKeyword);
            infoDetail.SeoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoDescription);
            string d = ConfigurationManager.AppSettings["DomainName"].ToString();
            infoDetail.TitleThumbNail = "http://" + PictureSuffix.ReturnSizePicUrl(d + infoDetail.TitleThumbNail, PictureSize.s310X310);

            var TopView = db.InfoDetails.Where(c => c.InfoID != infoDetail.InfoID && c.ShopID == infoDetail.ShopID).OrderByDescending(s => s.Views).Take(6).ToList();
            TopView = TopView.Where(c => c.InfoID != InfoID).ToList();
            
            //作者（UserId）分享
            ShopStaff shopStaff = new ShopStaff();
            //Editor Introduce
            if (!string.IsNullOrEmpty(infoDetail.ShopStaffID))
            {
                shopStaff = db.ShopStaffs.Find(infoDetail.ShopStaffID);
                if (shopStaff == null)
                {
                    shopStaff = null;
                }
            }
            else
            {
                shopStaff = null;
            }
            mgInfoModelView.shop = db.Shops.Find(infoDetail.ShopID);
            mgInfoModelView.infoDetail = infoDetail;
             
            mgInfoModelView.shopStaff = shopStaff;
            mgInfoModelView.shopStaff.ChannelID = db.Channels.Find(shopStaff.ChannelID).ChannelName;
            mgInfoModelView.InfoDetailRalateList = TopView;
            return Json(mgInfoModelView,JsonRequestBehavior.AllowGet);
        }

        public JsonResult InfoDetailRalateList()
        {
            var InfoDetailRalateList = db.InfoDetails.Take(6).ToList();
            var List1 = new List<InfoDetail>();
            foreach (var item in InfoDetailRalateList)
            {
                item.InfoDescription = "";
                List1.Add(item);
            }
            return Json(List1, JsonRequestBehavior.AllowGet);
        }

        // GET: WxMiniProgram/WxInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WxMiniProgram/WxInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WxMiniProgram/WxInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WxMiniProgram/WxInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WxMiniProgram/WxInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WxMiniProgram/WxInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

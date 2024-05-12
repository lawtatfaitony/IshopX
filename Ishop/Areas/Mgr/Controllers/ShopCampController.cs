using System;
using System.Threading;
using System.Text;
using System.Net;
using PagedList;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Ishop.Models;
using Ishop.ViewModes.Public;
using Ishop.Identity.Models;
using Ishop.Areas.Mgr.Models;
using Ishop.Context;
using Ishop.Models.CampaignMgr; 
using Ishop.Areas.Mgr.ModelView;
using Ishop.Controllers;

namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion")]
    public class ShopCampController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Mgr/ShopCamp
        //优惠活动列表  
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult Index()
        {
            return View();
        }
        //优惠活动创建
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult ShopCampCreate(string CampaignID)
        {
            if (!string.IsNullOrEmpty(CampaignID)) // 不等于null
            {
                // 返回 活动明细 
                var campaigns = db.Campaigns.Find(CampaignID);
                if (campaigns == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ViewBag.CurrentCampaignID = CampaignID;
                ViewBag.CampaignDesc = campaigns.CampaignDesc;
                ViewBag.StartDate = campaigns.StartDate.ToString("yyyy-MM-dd HH:mm");
                ViewBag.EndDate = campaigns.EndDate.ToString("yyyy-MM-dd HH:mm");
                return View(campaigns);
            }
            else
            {
                ViewBag.StartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); //string.Format("{0:YYYY-MM-DD hh:mm}", DateTime.Now.ToString());
                ViewBag.EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                return View();
            }

        }//ShopCampCreate

        [HttpPost]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult ShopCampCreate(string CampaignID, [Bind(Include = "CampaignName,CampaignLabel,ShopID,StartDate,EndDate,CampaignDesc")]Campaign campaign)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            if (CampaignID == null)
            {
                campaign.CampaignID = db.GetTableIdentityID("Camp", "Campaign", 6);
                campaign.ShopID = WebCookie.ShopID;
                campaign.CampaignDesc = HttpUtility.UrlDecode(campaign.CampaignDesc, Encoding.UTF8);
                campaign.OperatedUserName = User.Identity.Name;
                campaign.OperatedDate = DateTime.Now;
                //处理新增操作
                if (ModelState.IsValid)
                {
                    db.Campaigns.Add(campaign);
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
                campaign.OperatedUserName = User.Identity.Name;
                campaign.OperatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    UpdateModel<Campaign>(campaign);
                    campaign.OperatedUserName = User.Identity.Name;
                    campaign.OperatedDate = DateTime.Now;
                    campaign.CampaignDesc = HttpUtility.UrlDecode(campaign.CampaignDesc, Encoding.UTF8);
                    db.Entry(campaign).State = EntityState.Modified;
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

        }//ShopCampCreate
        //优惠活动列表
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult ShopCampList(string sortOrder, string currentFilter, string searchString, int? page)
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

            var campaigns = from s in db.Campaigns
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                campaigns = campaigns.Where(s => s.CampaignName.Contains(searchString)
                                       || s.CampaignLabel.Contains(searchString));

            }
            //店铺过滤
            campaigns = campaigns.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    campaigns = campaigns.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    campaigns = campaigns.OrderByDescending(s => s.StartDate);
                    break;
                default:  // Name ascending 
                    campaigns = campaigns.OrderBy(s => s.StartDate);
                    break;
            }

            int pageSize = 16;
            int pageNumber = (page ?? 1);
            List<ShopCampModelview> ListViewModel = new List<ShopCampModelview>();
            foreach (var item in campaigns)
            {
                Campaign campaign = db.Campaigns.Find(item.CampaignID);
                ShopCampModelview shopCampModelview = new ShopCampModelview();
                shopCampModelview.CampaignID = campaign.CampaignID;
                shopCampModelview.CampaignName = campaign.CampaignName;
                shopCampModelview.CampaignLabel = campaign.CampaignLabel;
                shopCampModelview.ShopID = campaign.ShopID;
                shopCampModelview.StartDate = campaign.StartDate;
                shopCampModelview.EndDate = campaign.EndDate;
                shopCampModelview.OperatedDate = campaign.OperatedDate;
                shopCampModelview.OperatedUserName = campaign.OperatedUserName;
                shopCampModelview.CampaignDesc = campaign.CampaignDesc;

                ListViewModel.Add(shopCampModelview);
            }
            return View(ListViewModel.ToPagedList(pageNumber, pageSize));

        }


        //优惠劵列表
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult CouponList(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentStartDate = StartDate == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : StartDate;
            ViewBag.CurrentEndDate = EndDate == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : EndDate;

            ViewBag.SortSign = "<i class='fa fa-calendar-check-o' style='color: mediumslateblue'>&nbsp;</i>";  //没用到
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var coupons = from s in db.Coupons
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {


                coupons = coupons.Where(s => s.CouponName.Contains(searchString));
                int intResult = 0;
                if (int.TryParse(searchString, out intResult))
                {
                    coupons = coupons.Where(s => s.FaceValue == intResult);
                }
            }
            //DaySpan filter 时间段过滤
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;

                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                coupons = coupons.Where(s => s.StartDate > pStartDate && s.StartDate < pEndDate);
            }
            //店铺过滤
            coupons = coupons.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    coupons = coupons.OrderBy(s => s.OperatedDate);
                    break;
                case "date_desc":
                    coupons = coupons.OrderByDescending(s => s.OperatedDate);
                    break;
                default:  // Name ascending 
                    coupons = coupons.OrderBy(s => s.OperatedDate);
                    break;
            }

            int pageSize = 16;
            int pageNumber = (page ?? 1);

            return View(coupons.ToPagedList(pageNumber, pageSize));
        }


        //优惠卷面值
        public IList<decimal> FaceValues = new List<decimal>() { 3, 5, 10, 20, 30, 50, 100, 200 };
        public IList<IssueMode> Modes = new List<IssueMode>() { IssueMode.BuyerGet, IssueMode.SellerSend };
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult CouponAddOrUpd(string CouponID)
        {
            if (!string.IsNullOrEmpty(CouponID)) // 不等于null
            {
                // 返回 明细 
                var coupons = db.Coupons.Find(CouponID);
                if (coupons == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ViewBag.CurrentCouponID = CouponID;
                ViewBag.FaceValue = new SelectList(FaceValues, coupons.FaceValue);
                ViewBag.Mode = new SelectList(Modes, coupons.Mode);

                ViewBag.StartDate = coupons.StartDate.ToString("yyyy-MM-dd HH:mm");
                ViewBag.EndDate = coupons.EndDate.ToString("yyyy-MM-dd HH:mm");
                return View(coupons);
            }
            else
            {
                ViewBag.FaceValue = new SelectList(FaceValues);
                ViewBag.Mode = new SelectList(Modes);
                ViewBag.StartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                ViewBag.EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                return View();
            }

        }//CouponAddOrUpd



        [HttpPost]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult CouponAddOrUpd(string CouponID, [Bind(Include = "CouponID,ShopID,CouponName,FaceValue,StartDate,EndDate,IssueQuantity,Mode,Conditions")]Coupon coupon)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            if (coupon.CouponID == null)
            {
                coupon.CouponID = db.GetTableIdentityID("C", "Coupon", 6);
                coupon.ShopID = WebCookie.ShopID;
                coupon.OperatedUserName = User.Identity.Name;
                coupon.OperatedDate = DateTime.Now;
                //处理新增操作
                if (ModelState.IsValid)
                {
                    db.Coupons.Add(coupon);
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
                coupon.CouponID = CouponID;
                coupon.OperatedUserName = User.Identity.Name;
                coupon.OperatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.Entry(coupon).State = EntityState.Modified;
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

            }//if-else
        }//CouponAddOrUpd 

        [HttpPost]
        public ActionResult CouponDel(string CouponID)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            if (CouponID != null)
            {
                //处理删除操作
                var coupons = db.Coupons.Find(CouponID);
                //删除会员持有的优惠券 如下
                // var userCoupons = db.UserCoupons.Find(CouponID);

                if (coupons != null)
                {
                    db.Entry(coupons).State = EntityState.Deleted;
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "删除成功";
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "不存在记录" + CouponID;
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

        [HttpPost]
        [Authorize]
        public JsonResult UserCoupon(string UserName, string CouponID)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            UserCoupon userCoupon = new Ishop.Models.CampaignMgr.UserCoupon(); 
            if (string.IsNullOrEmpty(CouponID))
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "缺少CouponID";
                return Json(ModalDialogView1, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(UserName))
            {
                UserName = User.Identity.Name;
            }
            var couponsExists = db.Coupons.Find(CouponID);
            if (couponsExists == null)
            {
                ModalDialogView1.MsgCode = "3";
                ModalDialogView1.Message = "优惠卷编号不存在";
                return Json(ModalDialogView1, JsonRequestBehavior.AllowGet);
            }
            var UserExists = db.Users.Where(c => c.UserName.Contains(UserName));
            if (UserExists.Count() == 0)
            {
                ModalDialogView1.MsgCode = "3";
                ModalDialogView1.Message = "用户不存在";
                return Json(ModalDialogView1, JsonRequestBehavior.AllowGet);
            }

            var coupons = db.UserCoupons.Where(c=>c.CouponID == CouponID && c.UserName == UserName);
            if (coupons.Count()>0)
            {
                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message = "已经领取成功";
                return Json(ModalDialogView1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                userCoupon.UserCouponID = db.GetTableIdentityID("UC", "UserCoupon", 16);
                userCoupon.UserName = UserName;
                userCoupon.CouponID = CouponID;
                userCoupon.OperatedDate = DateTime.Now;
                
                try {
                    db.Entry(userCoupon).State = EntityState.Added;
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "领取成功";
                }  
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    ModalDialogView1.MsgCode = "-1";
                    ModalDialogView1.Message = e.InnerException.Message;
                    throw e.InnerException ;
                }
                   
               
                return Json(ModalDialogView1, JsonRequestBehavior.AllowGet);
                
            }
             
        }
    }
}
using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ishop.Models.ProductMgr;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Ishop.Models;
using Ishop.ViewModes.Public;
using Ishop.Identity.Models;
using Ishop.Areas.Mgr.Models;
using System.Data.Entity;
using Ishop.Context;
using Ishop.Models.Info;
using LanguageResource;
using PagedList;
using Ishop.Utilities;
using System.Configuration;

namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize]
    public class ShopAdminController : Controller
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
        // GET: Mgr/ShopAdmin
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult ShopCategory(string CategoryID)
        {
            Category category = new Category();
            Category parentCategory = new Category();
            if (!string.IsNullOrEmpty(CategoryID))
            {
                // 返回 Category明细
                ViewBag.CurrentCategoryID = CategoryID;
                category = db.Categorys.Find(CategoryID);
                if (category.ParentsCategoryID.Trim() != "0" )
                {
                    parentCategory = db.Categorys.Find(category.ParentsCategoryID);
                    ViewBag.ParentsCategoryName = parentCategory.CategoryName;
                }
                else
                {
                    ViewBag.ParentsCategoryName = "0";
                }
               
                ViewBag.CategoryDesc = category.CategoryDesc;


                return View(category);
            }else
            {
                ViewBag.CurrentCategoryID = null;
                category.CategoryID = "0";
                return View(category);
            } 
        }// GET: Mgr/ShopAdmin
       
        [HttpPost]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult ShopCategoryAddOrUpdate(string CategoryID, [Bind(Include = "CategoryID,ParentsCategoryID,ShopID,CategoryName,CategoryDesc,CategoryDesc")]Category category)
         { 
                ModalDialogView ModalDialogView1 = new ModalDialogView(); 
                if (CategoryID==null)
                    {
                        if (string.IsNullOrEmpty(category.ParentsCategoryID) )
                        {
                            category.ParentsCategoryID = "0";
                        } 
                        category.CategoryID = db.GetTableIdentityID("CA", "Category", 6);
                     
                        category.ShopID = WebCookie.ShopID ;
                        category.CategoryDesc = HttpUtility.UrlDecode(category.CategoryDesc, Encoding.UTF8); //html解码

                        category.OperatedUserName = User.Identity.Name;
                        category.OperatedDate = DateTime.Now;
                   
                        db.Categorys.Add(category);
                        db.SaveChanges();
                    
                        ViewBag.CurrentCategoryID = category.CategoryID;
                        ModalDialogView1.MsgCode = "1";
                        ModalDialogView1.Message = "新增成功";
                        return Json(ModalDialogView1);

                }
                else
                {
                    // 返回 更新 
                    ViewBag.CurrentCategoryID = CategoryID;  
                    if (ModelState.IsValid)
                    {
                        UpdateModel<Category>(category);
                        category.OperatedUserName = User.Identity.Name;
                        category.OperatedDate = DateTime.Now;
                        category.CategoryDesc = HttpUtility.UrlDecode(category.CategoryDesc, Encoding.UTF8);
                        db.Entry(category).State = EntityState.Modified; 
                        db.SaveChanges();

                        ModalDialogView1.MsgCode = "1";
                        ModalDialogView1.Message = "更新成功";
                        return Json(ModalDialogView1);
                    }
                    else
                    {
                        ModalDialogView1.MsgCode = "0";
                        ModalDialogView1.Message = "更新无效.更新失败";
                        return Json(ModalDialogView1);
                    }
                 }   
            
            
        }

        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult CategoryDelete(string CategoryID,string ParentsCategoryID)
        {
            ViewBag.CurrentCategoryID = CategoryID;
            ViewBag.CurrentParentsCategoryID = ParentsCategoryID;

            Category category = new Category();
            Category parentCategory = new Category();
            if (!string.IsNullOrEmpty(CategoryID))
            {
                // 返回 Category明细 
                category = db.Categorys.Find(CategoryID);
                if (category.ParentsCategoryID.Trim() != "0")
                {
                    parentCategory = db.Categorys.Find(category.ParentsCategoryID);
                    ViewBag.ParentsCategoryName = parentCategory.CategoryName;
                }
                else
                {
                    ViewBag.ParentsCategoryName = "店铺主分类";
                }
                 
                return View(category);
            }
            else
            {
                ModalDialogView ModalDialogView1 = new ModalDialogView();
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "没有查询到记录";
                return View("ModalDialogView", category);
            }
             
        }
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult ShopCategoryList()
        {
            return View();

        }
       [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public ActionResult CategoryDelete(string CategoryID)
        {
            string msg = "<br/><h3>店铺分类及其节点成功删除</h3><br/>" + CategoryID;
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };
             
            try
            {
                Category Categories = db.Categorys.Find(CategoryID);
                if (Categories.ShopID == WebCookie.ShopID)
                {
                    db.Categorys.Remove(Categories);
                } 
                int rest = db.SaveChanges();
                if (rest > 0)
                {
                    var deleteQuery = db.Categorys.Where(p => p.ParentsCategoryID == CategoryID);

                    foreach (var item in deleteQuery)
                    {
                        db.Categorys.Remove(item);
                    }
                    db.SaveChanges();
                }

                return Json(modalDialogView);
            }
            catch
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = "<br/><h3>程序出错,操作失败</h3><br/>" + CategoryID };
                return Json(modalDialogView);
            }
        }

        [HttpGet]
        public JsonResult GetNodeOfShopCategory(string ParentsCategoryID)  // 所以节点 :  ParentsMenuItemID="0"
        { 
            if(string.IsNullOrEmpty(ParentsCategoryID))
            {
                ParentsCategoryID = "0";
            }
            List<Category> CategoryItem = db.Categorys.Where(c=>c.ShopID== WebCookie.ShopID).ToList();
            GetTreeJsonByCategoryItem(CategoryItem, ParentsCategoryID);
            string strResult = resultSB.ToString();
            return Json(strResult, JsonRequestBehavior.AllowGet); 
        }
        StringBuilder resultSB = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetTreeJsonByCategoryItem(List<Category> CategoryItem1, string ParentsCategoryID)
        {
            TreeView TreeView1 = new TreeView();
            resultSB.Append(sb);
            sb.Clear();
            if (CategoryItem1.Count<Category>() > 0)
            {
                sb.Append("\n[");

                var CategoryItem2 = CategoryItem1.Where(c => c.ParentsCategoryID == ParentsCategoryID).OrderByDescending(p => p.OperatedDate);
                if (CategoryItem2.Count<Category>() > 0)
                {
                    foreach (var row in CategoryItem2)
                    {
                       
                        sb.Append("{\"nodeid\":\"" + row.CategoryID + "\",\"text\":\"" + row.CategoryName + "\",\"custom\":\"" + row.ParentsCategoryID + "\"");
                        
                        var CategoryItem3 = db.Categorys.Where(c => c.ParentsCategoryID == row.CategoryID);
                        if (CategoryItem3.Count<Category>() > 0)
                        {
                            sb.Append(",\"nodes\":");
                            GetTreeJsonByCategoryItem(CategoryItem3.ToList(), row.CategoryID);
                            resultSB.Append(sb);
                            sb.Clear();
                        }
                        resultSB.Append(sb);
                        sb.Clear();
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                resultSB.Append(sb);
                sb.Clear();
            }
        }
        
        // GET: Mgr/ShopAdmin
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult ShopStaffList()
        { 
            var ShopStaffs = from s in db.ShopStaffs
                             select s; 
            //店铺过滤
            ShopStaffs = ShopStaffs.Where(s => s.ShopID == WebCookie.ShopID);
            //下拉数据
            ChannelDropDownList();

            return View(ShopStaffs.ToList());
        }

        // GET: Mgr/ShopAdmin
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult UserChannelList(string UserId)
        {
            var userChannels = from s in db.UserChannels
                               select s;
            //UserId 过滤
            userChannels = userChannels.Where(s => s.UserId == UserId);
            //店铺过滤
            userChannels = userChannels.Where(s => s.ShopID == WebCookie.ShopID); 
            return View("UserChannelList", userChannels.ToList());
        }
         
        // HttpPost: Mgr/ShopAdmin
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public ActionResult AddUserChannel(string UserId, string ChannelID,string ChannelName ,string LoginID, string ChannelQRcode)  
        {
            //Thread.Sleep(5000); // only for test
            UserChannel userChannel = new UserChannel()
            {
                 UserChannelID = db.GetTableIdentityID("UCH", "UserChannel", 6) 
                ,UserId = UserId
                ,ChannelID = ChannelID
                ,ChannelName = ChannelName
                ,LoginID = LoginID
                ,ChannelQRcode = ChannelQRcode 
                ,ShopID = WebCookie.ShopID
                ,OperatedUserName = User.Identity.Name
                ,OperatedDate = DateTime.Now
             };
              
            db.Entry(userChannel).State = EntityState.Added;
            db.SaveChanges(); 

            //返回用户渠道列表
            var userChannels = from s in db.UserChannels
                               select s;
            //UserId 过滤
            userChannels = userChannels.Where(s => s.UserId == userChannel.UserId);
            //店铺过滤
            userChannels = userChannels.Where(s => s.ShopID == WebCookie.ShopID);
             
            return View("UserChannelList", userChannels.ToList()); //返回 ajax结果  
        }
        ////渠道
        private void ChannelDropDownList(object selectedChannelID = null)
        {
            var IChannelQuery = from d in db.Channels
                                orderby d.ChannelID
                                select d;
            ViewBag.ChannelID = new SelectList(IChannelQuery, "ChannelID", "ChannelName", selectedChannelID);
        }
        // GET: Mgr/ShopAdmin
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet]
        public ActionResult ShopStaffAdd(string ShopStaffID)
        {

            //获取店铺ID
            Shop shop = new Shop();
            var shop1 = from s in db.Shops select s;
            shop1 = shop1.Where(c => c.UserName.Contains(User.Identity.Name));
            if (shop1.Count() < 1)
            {
                return RedirectToAction("CreateShop", "Manage", new { area = "", msg = "添加员工前,请先添加店铺!" });  //area ="" 是根目录下的区域
            }
            shop = shop1.FirstOrDefault<Shop>();

            ShopStaff shopStaff = new ShopStaff();
            if(string.IsNullOrEmpty(ShopStaffID))
            {
               shopStaff.ShopStaffID = db.GetTableIdentityID("SF", "ShopStaff", 6);
               ViewBag.TempShopStaffID = ViewBag.TempInfoID = "ShopStaff" + Guid.NewGuid().ToString("N");
            }
            else
            {
                shopStaff.ShopStaffID = ShopStaffID;
                shopStaff = db.ShopStaffs.Find(shopStaff.ShopStaffID);
                ViewBag.vIntroduction = shopStaff.Introduction;
            }
            shopStaff.ShopID = shop.ShopID;
            shopStaff.IsConfirmed = true;
            //下拉数据
            ChannelDropDownList(shopStaff.ChannelID);
            return View("ShopStaffAdd", shopStaff);
        }
        //店铺管理员 和 超级管理员 ,平台管理员 才可以 为 店铺添加员工
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]
        public ActionResult ShopStaffAdd([Bind(Include = "ShopID,ShopStaffID,UserId,IconPortrait,StaffName,PublicNo,ContactTitle,Introduction,ChannelID,Qrcode,OtherChannelName,OtherQrcode,IsConfirmed")] ShopStaff shopStaff)
        {
            shopStaff.Introduction = HttpUtility.UrlDecode(shopStaff.Introduction, Encoding.UTF8);   
            shopStaff.OperatedUserName = User.Identity.Name; 
            shopStaff.OperatedDate = DateTime.Now;
            var User1 = db.Users.Find(shopStaff.UserId);
             
            if (User1 == null)
            {
                ModelState.AddModelError("", "会员ID(UserId)不存在,请联系该会员索取"); 
            }
            else
            {
                var HasExistsShopStaff = db.ShopStaffs.Where(c => c.ShopStaffID == shopStaff.ShopStaffID);
                shopStaff.UserName = UserManager.FindById(shopStaff.UserId).UserName;
                if (HasExistsShopStaff.Count() == 0)
                { 
                    db.ShopStaffs.Add(shopStaff);
                    db.SaveChanges();
                }
                else  //更新
                {
                    db.Entry(shopStaff).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
               
                //会员在其他店铺的情况
                var HasShopStaff = db.ShopStaffs.Where(c=>c.UserId == shopStaff.UserId && c.ShopID != shopStaff.ShopID);   
                if(HasShopStaff.Count() > 0)
                { 
                    db.ShopStaffs.RemoveRange(HasShopStaff); //删除全部 这个用户存在的 店铺ID 规则: 一个用户只能管理一个店铺
                    db.SaveChanges();
                } 
                //下拉数据
                ChannelDropDownList(shopStaff.ChannelID);
                ViewBag.Result = "OK";

            }
            return View(shopStaff);
        }
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet]
        public ActionResult ShopStaffAddRole(string UserId)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ViewBag.UserId = UserId;
            ApplicationUser user = db.Users.Find(UserId);
            PopulateAssignedRoleData(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("ShopStaffAddRoleView", user); 
        }
        private void PopulateAssignedRoleData(ApplicationUser applicationUser)
        {
            // allRoles 只包含 店铺管理的相关角色
            var allRoles = db.AspNetRoles.Where(c=>c.Name.Contains("StoreCustomersService") ||c.Name.Contains("StoreAdmin") || c.Name.Contains("StoreProductAdmin") || c.Name.Contains("StorePreSales") || c.Name.Contains("StoreBusinessPromotion") || c.Name.Contains("StroeShippingClerk")).OrderBy(s => s.Name); ;

            var UserRoles = new HashSet<string>(db.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserID='" + applicationUser.Id + "'").ToList<string>());
            var viewModel = new List<AssignedRoles>();
            foreach (var item in allRoles)
            {
                viewModel.Add(new AssignedRoles
                {
                    UserId = applicationUser.Id.ToString(),
                    RoleId = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Assigned = UserRoles.Contains(item.Id)
                });
            }
            ViewBag.UserRoles = viewModel;
        }
       
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]
        public JsonResult ShopStaffAddRole(string UserId, string[] selectedRoles)
        {
            Ishop.Areas.Mgr.Models.ModalDialogView modalDialogView = new Models.ModalDialogView();

            if (UserId == null)
            {
                modalDialogView.MsgCode = "0";
                modalDialogView.Message = "没有对应的UserId参数";
                return Json(modalDialogView); 
            } 
      
            UpdateUserRoles(selectedRoles, UserId);

            db.SaveChanges();

           
            modalDialogView.MsgCode = "1";
            modalDialogView.Message = "授权成功";
            return Json(modalDialogView);
        }
        
        public void UpdateUserRoles(string[] selectedRoles, string UserId)
        {
            if (selectedRoles == null)
            {
                return;
            }

            var selectedRolesHashSet = new HashSet<string>(selectedRoles);
            var UserRoles = new HashSet<string>(db.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserID='" + UserId + "'").ToList<string>());
            foreach (var Role in db.Roles.Where(c => c.Name.Contains("StoreCustomersService") || c.Name.Contains("StoreAdmin") || c.Name.Contains("StoreProductAdmin") || c.Name.Contains("StorePreSales") || c.Name.Contains("StoreBusinessPromotion") || c.Name.Contains("StroeShippingClerk")).OrderBy(s => s.Name))
            {
                if (selectedRolesHashSet.Contains(Role.Id.ToString()))
                {
                    if (!UserRoles.Contains(Role.Id.ToString()))
                    {
                        ViewBag.Result = db.AddUserToRole(UserManager, UserId, Role.Name);
                    }
                }
                else
                {
                    if (UserRoles.Contains(Role.Id.ToString()))
                    {
                        db.RemoveFromRole(UserManager, UserId, Role.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 上存发邮件模板与定义
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet] 
        public ActionResult UpEmailTaskHtmlTemplate()
        {
            string shopId = WebCookie.ShopID;

            DateTimeOffset df = new DateTimeOffset(DateTime.Now);
            EmailTask emailTask = new EmailTask
            {
                Id = df.ToUnixTimeMilliseconds().ToString(),
                Status = 0,
                OperatedUserName = User.Identity.Name,
                OperatedDate = DateTime.Now,
                ShopId = shopId
            };  
            return View(emailTask);
        }

        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]  
        public ActionResult UpEmailTaskHtmlTemplate([Bind(Include = "Id,Name,EmailTemplate,Subject,CallBackUrl,SenderAccountArr,OperatedUserName,OperatedDate,Status,ShopId")]EmailTask emailTask)
        { 
            //string ShopId = WebCookie.ShopID;

            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(emailTask.ShopId))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "NO SHOP ID"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }

            if(!string.IsNullOrEmpty(emailTask.EmailTemplate))
            {
                if(System.IO.File.Exists(Server.MapPath(emailTask.EmailTemplate))==false)
                {
                    responseModalX.meta = new MetaModalX
                    {
                        ErrorCode = (int)GeneralReturnCode.FAIL,
                        Success = false,
                        Message = $"{emailTask.EmailTemplate} NOT EXIST"
                    };
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                }
            }

            //---------------------
            // 新增前，加入各种验证
            //---------------------
            db.EmailTask.Add(emailTask);
            bool result = db.SaveChanges() > 0;

            if (result)
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = true,
                    Message = Lang.Views_GeneralUI_SavedSuccessfully
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            else
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = Lang.GeneralUI_Fail + "DB ERROR"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }
 
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult EmailTaskList(int? page)
        {
            var emailTasks = from s in db.EmailTask
                             select s;
            List<EmailTask> emailTaskList = new List<EmailTask>();
            emailTasks = emailTasks.Where(s => s.ShopId == WebCookie.ShopID).OrderByDescending(c=>c.Id);
           
            foreach (var item in emailTasks)
            {
                List<SendMailInfo> sendMailInfoList = new List<SendMailInfo>();
                var arrStr = item.SenderAccountArr.Split(',');  
                foreach (var x in arrStr)
                {
                    var sendMailInfoX =  db.SendMailInfo.Find(x);
                    sendMailInfoList.Add(sendMailInfoX);
                }
                item.SenderAccountArr =string.Join(",", sendMailInfoList.Select(c => c.FromMailAddress).ToArray());
                emailTaskList.Add(item);
            } 
            int pageSize = 50;
            int pageNumber = (page ?? 1);

            return View(emailTaskList.ToPagedList(pageNumber, pageSize));  
        }
        
        [HttpPost]
        [Route("/Mgr/[controller]/[action]")]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult DeleteEmailTask(string MailTaskId)
        {
            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(MailTaskId))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "NO MailTaskId"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var emailTask =  db.EmailTask.Find(MailTaskId);
                if(emailTask==null)
                {
                    responseModalX.meta = new MetaModalX
                    {
                        ErrorCode = (int)GeneralReturnCode.FAIL,
                        Success = false,
                        Message = "NO RECORD EXIST"
                    };
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                }
                if(!string.IsNullOrEmpty(emailTask.EmailTemplate))
                {
                    if (System.IO.File.Exists(Server.MapPath(emailTask.EmailTemplate)) == true)
                    {
                        System.IO.File.Delete(Server.MapPath(emailTask.EmailTemplate)); 
                    }
                }

                db.EmailTask.Remove(emailTask);
                db.SaveChanges();

                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.SUCCESS,
                    Success = true,
                    Message = "Successful to delete"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            } 
        }

        [HttpPost]
        [Route("/Mgr/[controller]/[action]")]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult StopTask(string MailTaskId)
        {
            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(MailTaskId))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "NO MailTaskId"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var emailTask = db.EmailTask.Find(MailTaskId);
                if (emailTask == null)
                {
                    responseModalX.meta = new MetaModalX
                    {
                        ErrorCode = (int)GeneralReturnCode.FAIL,
                        Success = false,
                        Message = "NO RECORD EXIST"
                    };
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                }
                emailTask.Status = (int)StatusCode.INACTIVE;
                db.Entry(emailTask).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();  
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.SUCCESS,
                    Success = true,
                    Message = "Successful to Status STOP"
                };
                responseModalX.data = emailTask;
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("/Mgr/[controller]/[action]")]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult StartTask(string MailTaskId)
        {
            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(MailTaskId))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "NO MailTaskId"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var emailTask = db.EmailTask.Find(MailTaskId);
                if (emailTask == null)
                {
                    responseModalX.meta = new MetaModalX
                    {
                        ErrorCode = (int)GeneralReturnCode.FAIL,
                        Success = false,
                        Message = "NO RECORD EXIST"
                    };
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                }
                emailTask.Status = (int)StatusCode.ACTIVE;
                emailTask.OperatedDate = DateTime.Now;
                emailTask.OperatedUserName = User.Identity.Name;
                db.Entry(emailTask).State = System.Data.Entity.EntityState.Modified;

                db.EmailSubscribe.ForEachAsync(c=>c.Status = (int)StatusCode.ACTIVE).Wait();  //设置为ACTIVE等待发送。
                db.EmailSubscribe.ForEachAsync(c => c.EmailTaskId = emailTask.Id).Wait(); //等待发送的模板ID。
  
                db.SaveChanges();
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.SUCCESS,
                    Success = true,
                    Message = "Successful to Status START"
                };
                responseModalX.data = emailTask;
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// 发邮件账号管理
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet]
        public ActionResult UpEmailSenderInfo()
        {
            string shopId = WebCookie.ShopID;
            DateTimeOffset df = new DateTimeOffset(DateTime.Now);
            SendMailInfo sendMailInfo = new SendMailInfo
            {
                SendMailInfoId = df.ToUnixTimeMilliseconds().ToString(),
                SenderOfCompany = SenderOfCompanyEnumCode.SMTPGOOGLE.ToString().Replace("SMTP",""),
                EnableSSL = true,
                EnableTSL = true,
                EnablePasswordAuthentication = true,
                SenderServerHost = "smpt.gmail.com",
                SenderServerHostPort=587,
                FromMailAddress="",
                SenderUserName = "",
                SenderUserPassword="",
                ShopId = WebCookie.ShopID
            };
            return View(sendMailInfo);
        }

        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]
        public ActionResult UpEmailSenderInfo([Bind(Include = "SendMailInfoId,SenderOfCompany,EnableSSL,EnableTSL,EnablePasswordAuthentication,SenderServerHost,SenderServerHostPort,FromMailAddress,SenderUserName,SenderUserPassword,ShopId")] SendMailInfo sendMailInfo)
        {
            //string ShopId = WebCookie.ShopID;

            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(sendMailInfo.ShopId))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "NO SHOP ID"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(sendMailInfo.SenderServerHost) || string.IsNullOrEmpty(sendMailInfo.SenderUserName) || string.IsNullOrEmpty(sendMailInfo.FromMailAddress))
            { 
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "SMTP OR FromMailAddress OR SenderUserName ... REQUIED"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet); 
            }
            if (!string.IsNullOrEmpty(sendMailInfo.SenderOfCompany))
            {
                sendMailInfo.SenderOfCompany = sendMailInfo.SenderOfCompany.ToUpper().ToString().Replace("SMTP", "");
            }
            bool existRecord = db.SendMailInfo.Where(c => c.FromMailAddress.ToLower().Contains(sendMailInfo.FromMailAddress.ToLower())).Any();
            if(existRecord)
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = $"EXIST RECORD {sendMailInfo.FromMailAddress}"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            //---------------------
            // 新增前，加入各种验证
            //---------------------
            db.SendMailInfo.Add(sendMailInfo);
            bool result = db.SaveChanges() > 0;

            if (result)
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = true,
                    Message = Lang.Views_GeneralUI_SavedSuccessfully
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            else
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = Lang.GeneralUI_Fail + "DB ERROR"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult SendMailInfoList(int? page)
        {
            var sendMailInfos = from s in db.SendMailInfo
                                select s;

            sendMailInfos = sendMailInfos.Where(s => s.ShopId == WebCookie.ShopID).OrderByDescending(c => c.SendMailInfoId);

            int pageSize = 150;
            int pageNumber = (page ?? 1);
            return View(sendMailInfos.ToPagedList(pageNumber, pageSize));
        }

       
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult SendMailInfoList2()
        {
            ResponseModalX responseModalX = new ResponseModalX();
            try
            { 
                    var sendMailInfos = db.SendMailInfo.ToList();

                    List<SendMailInfoSelect> sendMailInfoSelects = new List<SendMailInfoSelect>();
                    foreach (var item in sendMailInfos)
                    {
                        SendMailInfoSelect sendMailInfoSelect = new SendMailInfoSelect { label = item.FromMailAddress, value = item.SendMailInfoId };
                        sendMailInfoSelects.Add(sendMailInfoSelect);
                    }
                    responseModalX.data = sendMailInfoSelects;
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception ex)
            {
                responseModalX.meta = new MetaModalX
                {
                    Success = false,
                    Message = string.Format("{0}-{1}", Lang.GeneralUI_Fail, ex.Message),
                    ErrorCode = (int)GeneralReturnCode.EXCEPTION
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("/Mgr/[controller]/[action]")]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult DeleteSendMailInfo(string SendMailInfoId)
        {
            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(SendMailInfoId))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = "NO SendMailInfoId"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sendMailInfo = db.SendMailInfo.Find(SendMailInfoId);
                if (sendMailInfo == null)
                {
                    responseModalX.meta = new MetaModalX
                    {
                        ErrorCode = (int)GeneralReturnCode.FAIL,
                        Success = false,
                        Message = "NO RECORD EXIST"
                    };
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                } 
                db.SendMailInfo.Remove(sendMailInfo);
                db.SaveChanges();

                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.SUCCESS,
                    Success = true,
                    Message = "Successful to delete"
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[controller]/[action]/{Id}")]
        public ActionResult GetMailTaskJobRequest(string Id)
        {
            
            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(Id))
            { 
                MailTaskJobRequest mailTaskJobRequestNoToken = new MailTaskJobRequest
                {
                    Success = false,
                    SendMailInfo = null,
                    ToMailArray = null,
                    Subject = "NO dynamicTokenId/Id",
                    EmailBody = ""
                };
                return Json(mailTaskJobRequestNoToken, JsonRequestBehavior.AllowGet); 
            }else
            {
                string dynamicTokenB = Id;
                //检测
                string Secret = ConfigurationManager.AppSettings["TokenManagement.Secret"];  //和AppSetting.json下的节点 TokenManagement.Secret 必须一致，用于不对称加密的密钥
                string dynamicTokenA =mvcCommeBase.CreateDynamicToken(Secret);
                dynamicTokenA = "123"; //test 发布去掉
                dynamicTokenB = "123";//test 发布去掉
                if (dynamicTokenA!= dynamicTokenB)
                {
                    MailTaskJobRequest mailTaskJobRequestNoToken = new MailTaskJobRequest
                    {
                        Success = false,
                        SendMailInfo = null,
                        ToMailArray = null,
                        Subject = $"(TEST) dynamicTokenId is not consistency A={dynamicTokenA} B(id)={dynamicTokenB} ",
                        EmailBody = ""
                    };
                    return Json(mailTaskJobRequestNoToken, JsonRequestBehavior.AllowGet);
                }
            }
            
            //Three Part 1.Get SendMailInfo By time
            var emailTask = db.EmailTask.Where(c=>c.Status== (int)StatusCode.ACTIVE).OrderByDescending(c=>c.OperatedDate).FirstOrDefault();
             
            List<SendMailInfo> sendMailInfoList = new List<SendMailInfo>();
            var arrStr = emailTask.SenderAccountArr.Split(',');
            foreach (var x in arrStr)
            {
                var sendMailInfoX = db.SendMailInfo.Find(x);
                sendMailInfoList.Add(sendMailInfoX);
            }
            var sendMailInfo = sendMailInfoList.OrderBy(s => Guid.NewGuid()).Take(1).FirstOrDefault();
            if (sendMailInfo == null)
            {
                MailTaskJobRequest mailTaskJobRequestNoSendMailInfo = new MailTaskJobRequest
                {
                    Success = false,
                    SendMailInfo = null,
                    ToMailArray = null,
                    Subject = "EmailTask Has no SendMailInfo (SenderAccountArr)",
                    EmailBody = ""
                };
                return Json(mailTaskJobRequestNoSendMailInfo, JsonRequestBehavior.AllowGet);
            }

            MailTaskJobRequest mailTaskJobRequest = new MailTaskJobRequest();
            mailTaskJobRequest.SendMailInfo = sendMailInfo;

            string emailTemplatePathFileName = Server.MapPath(emailTask.EmailTemplate);

            if(!string.IsNullOrEmpty(emailTemplatePathFileName))
            {
                if (!System.IO.File.Exists(emailTemplatePathFileName))
                {
                    MailTaskJobRequest mailTaskJobRequestNoFile = new MailTaskJobRequest
                    {
                        Success = false,
                        SendMailInfo = null,
                        ToMailArray = null,
                        Subject = "Email Template Path FileName Not Exists",
                        EmailBody = ""
                    };
                    return Json(mailTaskJobRequestNoFile, JsonRequestBehavior.AllowGet);
                }
            }else
            {
                MailTaskJobRequest mailTaskJobRequestNoFile = new MailTaskJobRequest
                {
                    Success = false,
                    SendMailInfo = null,
                    ToMailArray = null,
                    Subject = "Email Template Path FileName Not Exists(Empty)",
                    EmailBody = ""
                };
                return Json(mailTaskJobRequestNoFile, JsonRequestBehavior.AllowGet);
            }

            string EmailBody = mvcCommeBase.ReadDataFromHtml(emailTemplatePathFileName);
            if(string.IsNullOrEmpty(emailTask.Subject))
            {
                string htmlText = GetHtmlText(EmailBody);
                emailTask.Subject = htmlText.Substring(0, 20);
            }
            EmailBody = mvcCommeBase.StringToBase64(EmailBody);

            mailTaskJobRequest.Subject = emailTask.Subject;
            mailTaskJobRequest.EmailBody = EmailBody;
            string[] ToMailArray = new string[] { "" };
            var emailSubscribe = db.EmailSubscribe.Where(c => c.EmailTaskId == emailTask.Id && c.Status == (int)StatusCode.ACTIVE).OrderByDescending(c => c.OperatedDate).FirstOrDefault();
            if (emailSubscribe == null)
            {
                MailTaskJobRequest mailTaskJobRequestNoEmailArr = new MailTaskJobRequest
                {
                    Success = false,
                    SendMailInfo = null,
                    ToMailArray = null,
                    Subject = "emailSubscribe has no record to send",
                    EmailBody = ""
                };
                return Json(mailTaskJobRequestNoEmailArr, JsonRequestBehavior.AllowGet);
            }
            ToMailArray[0] = emailSubscribe.Email;
            mailTaskJobRequest.ToMailArray = ToMailArray;
            mailTaskJobRequest.Success = true;

            emailSubscribe.Status = (int)StatusCode.INACTIVE; //视为已经发送了的。
            db.Entry(emailSubscribe).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //是否发送完成
            bool isNotCompleted = db.EmailSubscribe.Where(c => c.EmailTaskId == emailTask.Id && c.Status == (int)StatusCode.INACTIVE).Any();
            if(isNotCompleted == false)
            {
                emailTask.Status = (int)StatusCode.INACTIVE;
                emailTask.OperatedDate = DateTime.Now;
                db.Entry(emailTask).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(mailTaskJobRequest, JsonRequestBehavior.AllowGet); 
        }
        [HttpGet]
        [Route("[controller]/[action]")]
        public ActionResult CreateDynamicToken()
        {
            string Secret = ConfigurationManager.AppSettings["TokenManagement.Secret"];

            string dynamicToken = mvcCommeBase.CreateDynamicToken(Secret);

            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now);
            long ts1 = dateTimeOffset.ToUnixTimeSeconds();
            long oddL1 = ts1 % 10;
            ts1 = ts1 - oddL1;

            return Json(new { dynamicToken, ts1 }, JsonRequestBehavior.AllowGet);
        }

        private string GetHtmlText(string html)
        {
            html = System.Text.RegularExpressions.Regex.Replace(html, @"<\/*[^<>]*>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = html.Replace("\r\n", "").Replace("\r", "").Replace("&nbsp;", "").Replace(" ", "");
            return html;
        }
    }
}
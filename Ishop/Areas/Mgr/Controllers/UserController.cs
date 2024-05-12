using Ishop.Areas.Mgr.Models;
using Ishop.Areas.Mgr.ModelView;
using Ishop.Context;
using Ishop.Controllers;
using Ishop.Models.PubDataModal;
using Ishop.Models.User;
using Ishop.Utilities;
using Ishop.ViewModes.Users;
using LanguageResource;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize]
    public class UserController : BaseController
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
        // GET: Mgr/User
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string UserTagID, string AccountMgrID , int? page)
        { 
            UserTagDropDownList();//TagName下拉列表
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CheckIsInRole = CheckIsInRole("StoreAdmin");
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var userProfiles = from s in db.UserProfiles.Where(s => s.ShopID == WebCookie.ShopID)  //过滤店铺
                              select s; 
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.TrimStart().TrimEnd();
                userProfiles = userProfiles.Where(s => s.UserId.Contains(searchString)
                || s.Email.Contains(searchString)
                || s.PhoneNumber.Contains(searchString)
                || s.RecievedPhoneNumber.Contains(searchString)
                || s.FullName.Contains(searchString)
                || s.NickName.Contains(searchString)
                || s.City.Contains(searchString)
                );
            }
            //客户资源来源标签过滤
            if (!String.IsNullOrEmpty(UserTagID))
            {
                userProfiles = userProfiles.Where(s => s.UserTagID.Contains(UserTagID));
            }
            //分发帐号条件过滤
            if (!String.IsNullOrEmpty(AccountMgrID))
            {
                userProfiles = userProfiles.Where(s => s.AsignAccountMgrIDs.Contains(AccountMgrID));
            }
            switch (sortOrder)
            {
                case "Date":
                    userProfiles = userProfiles.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    userProfiles = userProfiles.OrderByDescending(s => s.CreatedDate);
                    break;
                default:  // Name ascending 
                    userProfiles = userProfiles.OrderByDescending(s => s.CreatedDate);
                    break;
            }
            
            int pageSize = 100;
            int pageNumber = (page ?? 1);

            return View(userProfiles.ToPagedList(pageNumber, pageSize));
        }
         
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins ,CustomerService")]
        public ActionResult CustQuantization(string sortOrder, string currentFilter, string searchString, int? page)
        {
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var userProfiles = from s in db.UserProfiles.Where(s => s.ShopID == WebCookie.ShopID).OrderByDescending(s => s.QuantizationScore)  //过滤店铺
                               select s;
            //只显示有量化积分的潜在客户
            userProfiles = userProfiles.Where(s => s.QuantizationScore >0);

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.TrimStart().TrimEnd();
                userProfiles = userProfiles.Where(s => s.UserId.Contains(searchString)
                || s.Email.Contains(searchString)
                || s.PhoneNumber.Contains(searchString)
                || s.RecievedPhoneNumber.Contains(searchString)
                || s.FullName.Contains(searchString)
                || s.NickName.Contains(searchString)
                || s.City.Contains(searchString)
                );
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortParm = sortOrder == "Asc" ? "Desc" : "Asc";
            switch (sortOrder)
            {
                case "Asc":
                    userProfiles = userProfiles.OrderBy(s => s.QuantizationScore);
                    break;
                case "Desc":
                    userProfiles = userProfiles.OrderByDescending(s => s.QuantizationScore);
                    break;
                default:  // Name ascending 
                    userProfiles = userProfiles.OrderByDescending(s => s.QuantizationScore);
                    break;
            }
            //排除黑名单
            userProfiles = userProfiles.Where(s => s.IsBlock != true );

            int pageSize = 50;
            int pageNumber = (page ?? 1);

            return View(userProfiles.ToPagedList(pageNumber, pageSize));
        }


        private void UserTagDropDownList(object selectedUserTagID = null)
        {
            var UserTagQuery = from d in db.UserTags
                                      orderby d.TagName
                                      select d; 
            ViewBag.UserTagID = new SelectList(UserTagQuery, "UserTagID", "TagName", selectedUserTagID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountMgrID">分发推广渠道帐号ID</param>
        /// <param name="skip">从0开始按顺序跳过多少个,不能大于总的数据记录</param>
        /// <param name="take">获取跳过后的记录开始的多少条记录</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult AsignToAccountMgrID(string AccountMgrID,string UserTagID)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            UserTagDropDownList(UserTagID);
            //分发帐号合法性
            if (String.IsNullOrEmpty(AccountMgrID) || String.IsNullOrEmpty(UserTagID))
            { 
                ModalDialogView1.MsgCode = "1"; //0 = OK  1 = 请选择f分发推广渠道帐号ID ( AccountMgrID ) 
                ModalDialogView1.Message = Lang.User_AsignToAccountMgrID_Msg3 + "<br> <img src='/Content/Images/Mgr/selectOKAccountMgrID.jpg' class='center img-rounded'/>";
                return View("ModalDialogView", ModalDialogView1);
            }
            AccountMgr accountMgr = db.AccountMgrs.Find(AccountMgrID);
            if(accountMgr==null)
            {
                ModalDialogView1.MsgCode = "1"; //0 = OK  1 = 请选择f分发推广渠道帐号ID ( AccountMgrID ) 
                ModalDialogView1.Message = string.Format(Lang.User_AsignToAccountMgrID_Msg2, AccountMgrID )+"<img src='/Content/Images/Mgr/selectOKAccountMgrID.jpg' class='center img-rounded'/>";
                return View("ModalDialogView", ModalDialogView1);
            }
            AsignToAccountMgrID asignToAccountMgrID = new AsignToAccountMgrID() {
                  AccountMgrID = AccountMgrID
                , SiteName = accountMgr.SiteName 
                , LoginID = accountMgr .LoginID 
                , Mobile = accountMgr.Mobile 
                , LoginEmail = accountMgr.LoginEmail 
                , Take = 50 
                , UserTagID = UserTagID
                ,IsMonopoly = true //默认值=true
            }; 

            return View(asignToAccountMgrID);
        }
        [HttpPost]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public ActionResult AsignToAccountMgrID(string AccountMgrID,string LoginID, string UserTagID, int take,bool IsMonopoly)
        {
            //只有 Admin 或者 Supervisor 才可以分配资源大于500以上的,否则只能最大500个每次
            if(take>500)
            {
                take = CheckIsInRole("StoreAdmin") == true ? take : 500;
            }
             
            AsignToAccountMgrIDResult asignToAccountMgrIDResult = new AsignToAccountMgrIDResult();
            //获取 UserTagID 并 排除 AccountMgrID
            var userProfiles = db.UserProfiles.Where(c =>c.UserTagID.Contains(UserTagID) && c.IsBlock == false && c.IsMonopoly == false).Except(from s in db.UserProfiles.Where(c => c.AsignAccountMgrIDs.Contains(AccountMgrID)) select s).Take(take);
            //无可分配的资源
            if ( userProfiles.Count()==0)
            {
                asignToAccountMgrIDResult = new AsignToAccountMgrIDResult
                {
                    AccountMgrID = AccountMgrID  ,
                    LoginID = LoginID,
                    Take = take ,
                    GenerateResult =Lang.User_AsignToAccountMgrID_Msg_NoAssigned + "-" + UserTagID ,
                    VcardDownUrl = "#"
                };
                 
                return View("AsignToAccountMgrIDResult", asignToAccountMgrIDResult);
            } 
            StringBuilder sbGenerateResult = new StringBuilder();
            StringBuilder sbTextResult = new StringBuilder();

            //保存Vcard文件
            string localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
            string FormatPath =Server.MapPath("/Areas/Mgr/Views/User/VcardFormat");// System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "/Areas/Mgr/Views/User/VcardFormat"); //\Areas\Mgr\Views\User\VcardFormat
            localPath = System.IO.Path.Combine(localPath, "Vcard");
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            DateTime FileDateTime = DateTime.Now;
            string filename1 = AccountMgrID + string.Format("_{0:yyyyMMddHHmmss}.vcf", FileDateTime);
            string filename2 = AccountMgrID + string.Format("_{0:yyyyMMddHHmmss}.txt", FileDateTime);
            System.IO.File.Copy(Path.Combine(FormatPath, "VcardFormatQQ.vcf"), Path.Combine(localPath, filename1), true); //true : 覆盖原有文件(如有)
            StreamWriter sw = new StreamWriter(Path.Combine(localPath, filename1), false);
            StreamWriter sw2 = new StreamWriter(Path.Combine(localPath, filename2), false);
            // SW end
            foreach (var item in userProfiles)
            {
                string FullName = item.FullName.Trim();
                string a =""; 
                int TotalLenght = 9;
                int NameLength = 6;
                //判断中文则截取 三个字 否则 截图英文6个字符
                if (mvcCommeBase.IsChinaString(FullName))
                {
                    TotalLenght = 6;
                    NameLength = 3;
                }
                //如果 FufullName 长度不足则使用 FufullName的长度
                NameLength = FullName.Length < NameLength == true ? FullName.Length : NameLength ;
                a = FullName.Substring(0, NameLength).PadRight(TotalLenght, '\t') + item.PhoneNumber + "\r\n";
                sw2.WriteLine(item.PhoneNumber); //文本格式保存
                sbGenerateResult.Append(a);
                 
                //生成VCARD 文本 text/x-vcard 
                sw.WriteLine("BEGIN:VCARD");
                sw.WriteLine("VERSION:2.1");
                sw.WriteLine("N;CHARSET=UTF-8:{0};;;", FullName);
                sw.WriteLine("FN;CHARSET=UTF-8:{0}", FullName);
                sw.WriteLine("TEL;CELL:{0}", item.PhoneNumber);
                sw.WriteLine("TEL;WORK:{0}", item.RecievedPhoneNumber);
                if (mvcCommeBase.IsValidEmail(item.Email) == true)
                {
                    sw.WriteLine("EMAIL;HOME:{0}", item.Email.Trim());
                }
                sw.WriteLine("END:VCARD");
                //更改数据库的分配值
                item.IsMonopoly = IsMonopoly;
                item.AsignAccountMgrIDs = item.AsignAccountMgrIDs + "," + AccountMgrID;
                item.AsignAccountMgrIDs = item.AsignAccountMgrIDs.TrimStart(',');
                item.AsignAccountMgrIDs = item.AsignAccountMgrIDs.TrimEnd(',');
                DbEntityEntry<UserProfile> userProfileEntry = db.Entry<UserProfile>(item);
                db.UserProfiles.Attach(item);
                userProfileEntry.Property(e => e.AsignAccountMgrIDs).IsModified = true;
                userProfileEntry.Property(e => e.IsMonopoly).IsModified = true;
               
            }

            //保存变更数据分配 AccountMgrID
            try
            {
                int rank = db.AccountDownLogs.Where(c => c.AccountMgrID == AccountMgrID).Count<AccountDownLog>() + 1;
                
                //保存通讯录文件accountDownLog记录
                AccountDownLog accountDownLog = new AccountDownLog
                {
                    AccountMgrID = AccountMgrID ,
                    UserTagID = UserTagID ,
                    TagName = db.UserTags.Find(UserTagID).TagName ,
                    ResourceFile = "/upload/vcard/" + filename1.ToLower() ,
                    OperatedUserName = User.Identity.Name ,
                    CreatedDate = DateTime.Now ,
                    OperatedDate = DateTime.Now,
                    Rank = rank
                };
                db.AccountDownLogs.Add(accountDownLog);
                db.SaveChanges(); //保存 

                asignToAccountMgrIDResult = new AsignToAccountMgrIDResult
                {
                     AccountMgrID = AccountMgrID
                    ,LoginID = LoginID
                    ,Take = take
                    ,GenerateResult = sbGenerateResult.ToString()
                    ,VcardDownUrl = Url.Content("/upload/Vcard/" + filename1)
                };
                return View("AsignToAccountMgrIDResult", asignToAccountMgrIDResult);

            }
            catch (DbEntityValidationException dbEx)
            {
                //看看dbEX错误信息

                string operateLog = string.Format("AsignToAccountMgrID >case:: dbEx ::{0}", dbEx.Message);
                mvcCommeBase.OperateLoger(operateLog);

                throw dbEx;
            }
            finally
            {
                //sw.Write(sbVcard.ToString(),Encoding.UTF8);
                sw.Close();
                sw2.Close();
                 
            }
        } 
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "ParentsMenuItemID")]  ///缓存3600秒(内存)  VaryByParam = "*"
        public JsonResult LoadAccountMgrDropDownData(string searchString)  // WebSite
        {  
            //查询 推广帐号数据集
            var accountMgrs = from s in db.AccountMgrs
                              select new { s.AccountMgrID,s.LoginID ,s.SiteName,s.AssignedToUserID,s.NickName,s.WebSite,s.ShopID };
            if (!String.IsNullOrEmpty(searchString))
            {
                accountMgrs = accountMgrs.Where(s => s.SiteName.Contains(searchString) 
                || s.LoginID.Contains(searchString) 
                || s.AssignedToUserID.Contains(searchString) 
                || s.NickName.Contains(searchString) 
                || s.WebSite.Contains(searchString));
            } 
            ////IsInRole 判断是否店长角色(StoreAdmin)，则列出全店的推广帐号，否则 过滤用户，只列出分配用户使用的推广帐号
            //这里要改一下： 加入 if InRole 

            //具有一下身份才能浏览推广帐号的详细注册资料

            //1、店长（StoreAdmin）

            //2、推广帐号创建者

            if (CheckIsInRole("StoreAdmin") == true)
            {
                //如果店长,则列出所有
                accountMgrs = accountMgrs.Where(s => s.ShopID == WebCookie.ShopID);
            }
            else
            {
                //创建时分配给自己(创建者的)
                accountMgrs = accountMgrs.Where(s => s.AssignedToUserID.Contains(User.Identity.Name));
            }
            //Shop Filter (Ultimate Filter)
            accountMgrs = accountMgrs.Where(s => s.ShopID == WebCookie.ShopID);
            //Take TOP20 records
            accountMgrs = accountMgrs.Take(20);
            List<TreeView> AccountMgrDropDownData = new List<TreeView>();
            if(accountMgrs.Count() >  0) 
            {
                accountMgrs = accountMgrs.Where(s => s.ShopID == WebCookie.ShopID); //测试
                foreach (var item in accountMgrs)
                {
                    TreeView TreeViewItem = new TreeView()
                    {
                        nodeid = item.AccountMgrID,
                        text = item.SiteName + "-" + item.LoginID,
                        custom = item.LoginID
                    };
                    AccountMgrDropDownData.Add(TreeViewItem);
                } 
            }
            else
            {
                TreeView TreeViewItem = new TreeView()
                {
                    nodeid = "0",
                    text = Lang.User_LoadAccountMgrDropDownData_Msgtext,
                    custom = ""
                };
                AccountMgrDropDownData.Add(TreeViewItem);
            } 
            return Json(AccountMgrDropDownData.ToList(), "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet); 
        }

        public ActionResult LoadAccountDownLog(string AccountMgrID , string sortOrder , int? page)  // WebSite
        {
            ModalDialogView modalDialogView = new ModalDialogView();
            var accountDownLogs = from s in db.AccountDownLogs
                                  select s;
            
            if (string.IsNullOrEmpty(AccountMgrID))
            {
                modalDialogView = new ModalDialogView { MsgCode = "1", Message = string.Format("<h1>{0}</h1>", Lang.User_LoadAccountDownLog_NoAccountID) };
                return View("ModalDialogView", modalDialogView);
            }
             
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (!CheckIsInRole("BusinessPromotion"))
            {
                modalDialogView = new ModalDialogView { MsgCode = "1", Message = Lang.User_LoadAccountDownLog_Message1 };
                return View("ModalDialogView", modalDialogView);
            }
            if (!db.AccountMgrs.Find(AccountMgrID).AssignedToUserID.Contains(User.Identity.Name))
            {
                modalDialogView = new ModalDialogView { MsgCode = "1", Message = Lang.User_LoadAccountDownLog_Message2 };
                return View("ModalDialogView", modalDialogView);
            }
            
            ViewBag.AccountMgrID = AccountMgrID;
            //帐户ID过滤 
            if (!String.IsNullOrEmpty(AccountMgrID))
            {
                AccountMgrID = AccountMgrID.TrimStart().TrimEnd();
                accountDownLogs = accountDownLogs.Where(s => s.AccountMgrID.Contains(AccountMgrID) );
            }
            else
            {
                modalDialogView = new ModalDialogView { MsgCode = "1", Message = "<h1>"+ Lang.User_LoadAccountDownLog_NotAssignedAnyResourceData + "</h1>" };
                return View("ModalDialogView", modalDialogView);
            }
            
            switch (sortOrder)
            {
                case "Date":
                    accountDownLogs = accountDownLogs.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    accountDownLogs = accountDownLogs.OrderByDescending(s => s.CreatedDate);
                    break;
                default:  // 
                    accountDownLogs = accountDownLogs.OrderByDescending(s => s.CreatedDate);
                    break;
            } 
            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(accountDownLogs.ToPagedList(pageNumber, pageSize));
        }

       
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        [HttpGet]
        public ActionResult IsBlockPhoneNumber()
        { 
            return View();
        } 
        /// <summary>
        /// 黑名单 不下载到通讯录;
        /// </summary>
        /// <param name="id">便于简化连接(手机号码)</param>
        /// <param name="PhoneNumber">手机号码</param>
        /// <returns></returns>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        [HttpPost]
        public JsonResult IsBlockPhoneNumber(string id, string PhoneNumber, string Name ,string Email ,string Remarks)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            if (!string.IsNullOrEmpty(id))
            {
                PhoneNumber = id;
            }
            if (!string.IsNullOrEmpty(id))
            {
                PhoneNumber = id;
            }
            BlockList blockList = new BlockList()
            {
                Name = Name ,
                PhoneNumber = PhoneNumber ,
                Email = Email ,
                Remarks = Remarks ,
                ShopID = WebCookie.ShopID ,
                OperatedUserName = User.Identity.Name ,
                OperatedDate = DateTime.Now
            };
            if (db.BlockLists.Where(c => c.PhoneNumber.Contains(PhoneNumber)).ToList().Count < 1)
            {
                db.BlockLists.Add(blockList);
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                if (!mvcCommeBase.IsNumber(PhoneNumber.Trim().Replace("+", "").Replace(".", "")))
                {
                    return Json(new ModalDialogView { MsgCode = "1", Message = Lang.Views_GeneralUI_InvalidMobilePhone });
                }
               
            }
            if (!string.IsNullOrEmpty(Email))
            {
                if (!mvcCommeBase.IsValidEmail(Email.Trim()))
                {
                    return Json(new ModalDialogView { MsgCode = "1", Message = Lang.Views_GeneralUI_InvalidEmail });
                }  
            }
            UserProfile userProfile_Email = db.UserProfiles.Where(c => c.Email.Contains(Email) && c.IsBlock==false).FirstOrDefault();
            UserProfile userProfile_PhoneNumber = db.UserProfiles.Where(c => c.PhoneNumber.Contains(PhoneNumber) && c.IsBlock == false).FirstOrDefault();
             
            //更新
            if (userProfile_Email != null)
            {
                userProfile_Email.IsBlock = true;
                DbEntityEntry<UserProfile> userProfile_EmailEntry = db.Entry<UserProfile>(userProfile_Email);
                db.UserProfiles.Attach(userProfile_Email);
                userProfile_EmailEntry.Property(e => e.IsBlock).IsModified = true;
            }
            if (userProfile_PhoneNumber != null)
            {
                userProfile_PhoneNumber.IsBlock = true;
                DbEntityEntry<UserProfile> userProfile_PhoneNumberEntry = db.Entry<UserProfile>(userProfile_PhoneNumber);
                db.UserProfiles.Attach(userProfile_PhoneNumber);
                userProfile_PhoneNumberEntry.Property(e => e.IsBlock).IsModified = true;
            }
            try
            {
                db.SaveChanges(); 
                
            }
            catch (DbEntityValidationException dbEx)
            {
                 //throw dbEx;
                 return Json(new ModalDialogView { MsgCode = "1", Message =Lang.Views_GeneralUI_ServerError + "<br>"+ dbEx.Message });
            }
            return Json(new ModalDialogView { MsgCode = "0", Message = "OK" });
        } 
        // GET: Mgr/User/Details/5
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        public ActionResult RenderPhoneNumber(int? id)
        {
            ViewBag.AreaCode = EnumHelper.GetSelectList<RenderAreaCode>();
            ViewBag.RenderAmount = EnumHelper.GetSelectList<RenderAmountUnit>();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        public JsonResult RenderPhoneNumber([Bind(Include = "AreaCode ,RenderAmount ,IsSaveDB ,RenderResult")]RenderPhoneNumber renderPhoneNumber)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView(); 
            StringBuilder sbGenerateResult = new StringBuilder();
             
            for (int i=0; i< (int)renderPhoneNumber.RenderAmount;i++)
            {
                string FullName = "";
                FullName = renderPhoneNumber.AreaCode + Guid.NewGuid().ToString("N").Substring(0, 6);
                string PhoneNumber = RandomPhoneNumberFun(renderPhoneNumber.AreaCode.ToString()); 
                string a = FullName  + "\t" + PhoneNumber + "\r\n";
                sbGenerateResult.Append(a);

                //数据库保存 
                if (renderPhoneNumber.IsSaveDB)
                {
                    UserProfile userProfile = new UserProfile()
                    {
                        PhoneNumber = PhoneNumber ,
                        NickName = FullName ,
                        FullName = FullName ,
                        Gender  = Genders.Unkown ,
                        UserTagID = ("SystemRandom_" + renderPhoneNumber.AreaCode.ToString()).ToLower(), // UserTag必需具有当前的UserTagID数据 否则无法通过查询生成通讯录  
                        Birthday = DateTime.Parse("1900-01-01") ,
                        ShopID = WebCookie.ShopID ,
                        OperatedUserName = User.Identity.GetUserId() ,
                        CreatedDate = DateTime.Now ,
                        OperatedDate = DateTime.Now ,
                        IsBlock = false ,
                        IsMonopoly = false   // 是否独占此电话资源  生成时候不能决定是否独占,只有分配操作时候决定是否分配独占
                    };
                    db.UserProfiles.Add(userProfile);
                }
                Thread.Sleep(30); // avoid faster to create same ramdom
            }
            if (renderPhoneNumber.IsSaveDB)
            {
                try
                {
                     db.SaveChanges(); 
                }
                catch (DbUpdateException dbEx)  //1:DbUpdateException  2:DbEntityValidationException
                {
                    //throw dbEx;
                    return Json(new ModalDialogView { MsgCode = "1", Message = Lang.Views_GeneralUI_ServerError + "<br>" + dbEx.Message + "<br>" + dbEx.InnerException.Message });
                }
            }
             
            renderPhoneNumber.RenderResult = sbGenerateResult.ToString();

            //绑定 下拉菜单
            ViewBag.AreaCode = new SelectList(EnumHelper.GetSelectList<RenderAreaCode>().ToList(), "Text", "Value", renderPhoneNumber.AreaCode.ToString()); // EnumHelper.GetSelectList<RenderAreaCode>();
            ViewBag.RenderAmount = new SelectList(EnumHelper.GetSelectList<RenderAmountUnit>().ToList(), "Text", "Value", renderPhoneNumber.RenderAmount.ToString());
            ModalDialogView1 = new ModalDialogView() { MsgCode = "0", Message = sbGenerateResult.ToString() };
            return Json(ModalDialogView1);
        }
        public string getTagName(string UserTagID)
        {
            return db.UserTags.Find(UserTagID).TagName;
        } 
        // GET: Mgr/User/Create
        public ActionResult Create()
        {
            return View();
        } 
        // POST: Mgr/User/Create
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

        // GET: Mgr/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        } 
        // POST: Mgr/User/Edit/5
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

        // GET: Mgr/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mgr/User/Delete/5
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
        [Authorize]
        [HttpGet]
        public bool CheckIsInRole(string roleName)
        {
            string UserId = User.Identity.GetUserId();
            bool A;
            try
            {
                A = UserManager.IsInRole(UserId, roleName);
            }
            catch
            {
                A = false;
            }
            //如果超级管理员 属于例外情况
            if (UserManager.IsInRole(UserId, "Supervisor"))
            {
                A = true;
            }
            return A;
        }

        [HttpGet]
        public JsonResult RandomPhoneNumber(string AreaCode)
        {
            if (string.IsNullOrEmpty(AreaCode))
            {
                return Json(new { PhoneNumber = "0" }, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
            }
            AreaCode = AreaCode.Trim().ToLower();
            switch (AreaCode)
            {
                case "cn":
                    return Json(new { PhoneNumber = mvcCommeBase.RandomCNphoneNumber() }, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
                case "hk":
                    return Json(new { PhoneNumber = mvcCommeBase.RandomHKphoneNumber() },"text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
                default:
                    return Json(new { PhoneNumber = "0" }, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);

            }
             
        }
        public string RandomPhoneNumberFun(string AreaCode)
        {
            if (string.IsNullOrEmpty(AreaCode))
            {
                return "0"  ;
            }
            AreaCode = AreaCode.Trim().ToLower();
            switch (AreaCode)
            {
                case "cn":
                    return "+86" + mvcCommeBase.RandomCNphoneNumber() ;
                case "hk":
                    return  "+852" + mvcCommeBase.RandomHKphoneNumber()  ;
                default:
                    return  "0";  //其他国家的先保留，暂时不展示。 
            }

        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "ParentsID")]
        public JsonResult GetNodeOfQuantFactor(string ParentsID)  // Node :  ParentsMenuItemID="0"
        {
            if (string.IsNullOrEmpty(ParentsID))
            {
                ParentsID = "0";
            }
            List<QuantFactor> QuantFactorItem = db.QuantFactors.Where(c => c.ShopID == WebCookie.ShopID).OrderBy(c=>c.TopRank50).ToList();
            GetTreeJsonByQuantFactorItem(QuantFactorItem, ParentsID);
            string strResult = resultSB.ToString();
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        StringBuilder resultSB = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetTreeJsonByQuantFactorItem(List<QuantFactor> QuantFactorItem1, string ParentsID)
        {
            TreeView TreeView1 = new TreeView();
            resultSB.Append(sb);
            sb.Clear();
            if (QuantFactorItem1.Count<QuantFactor>() > 0)
            {
                sb.Append("\n[");

                var QuantFactorItem2 = QuantFactorItem1.Where(c => c.ParentsID == ParentsID).OrderBy(p => p.TopRank50);
                if (QuantFactorItem2.Count<QuantFactor>() > 0)
                {
                    foreach (var row in QuantFactorItem2)
                    {

                        sb.Append("{\"nodeid\":\"" + row.QuantFactorID + "\",\"text\":\"" + row.FactorName + "-" + row.Score + "\",\"custom\":\"" + row.ParentsID  + "\",\"Score\":\"" + row.Score + "\"");

                        var QuantFactorItem3 = db.QuantFactors.Where(c => c.ParentsID == row.QuantFactorID);
                        if (QuantFactorItem3.Count<QuantFactor>() > 0)
                        {
                            sb.Append(",\"nodes\":");
                            GetTreeJsonByQuantFactorItem(QuantFactorItem3.ToList(), row.QuantFactorID);
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
         
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        [HttpGet]
        public ActionResult QuantList()
        {
            return View();
        }
         
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        [HttpGet]
        public ActionResult QuantFactor(string QuantFactorID)
        {
            QuantFactor QuantFactor1 = new QuantFactor();
            QuantFactor parentQuantFactor = new QuantFactor();
            if (!string.IsNullOrEmpty(QuantFactorID))
            { 
                ViewBag.CurrentQuantFactorID = QuantFactorID;
                QuantFactor1 = db.QuantFactors.Find(QuantFactorID);
                if (QuantFactor1.ParentsID.Trim() != "0")
                {
                    parentQuantFactor = db.QuantFactors.Find(QuantFactor1.ParentsID);
                    ViewBag.ParentsName = parentQuantFactor.FactorName;
                }
                else
                {
                    ViewBag.ParentsCategoryName = "0";
                }
                return View(QuantFactor1);
            }
            else
            {
                ViewBag.CurrentQuantFactorID = string.Empty;
                QuantFactor1.ParentsID = "0";
                return View(QuantFactor1);
            } 
        }
         
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,StoreBusinessPromotion")]
        [HttpPost]
        public ActionResult QuantFactor(string QuantFactorID , [Bind(Include = "QuantFactorID,ParentsID,FactorName,Score,TopRank50,ShopID")]QuantFactor QuantFactor1)  
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            if (QuantFactorID == null)
            {
                if (string.IsNullOrEmpty(QuantFactor1.ParentsID))
                {
                    QuantFactor1.ParentsID = "0";
                }
                QuantFactor1.QuantFactorID = db.GetTableIdentityID("QF", "QuantFactor", 5);  //QF00003

                QuantFactor1.ShopID = WebCookie.ShopID;

                QuantFactor1.OperatedUserName = User.Identity.Name;
                QuantFactor1.OperatedDate = DateTime.Now;

                db.QuantFactors.Add(QuantFactor1);
                db.SaveChanges();

                ViewBag.CurrentQuantFactorID = QuantFactor1.QuantFactorID;
                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message = Lang.Views_GeneralUI_AddNewOk;
                return Json(ModalDialogView1);

            }
            else
            {
                // 返回 更新 
                ViewBag.CurrentQuantFactorID = QuantFactorID;
                if (ModelState.IsValid)
                {
                    UpdateModel<QuantFactor>(QuantFactor1);
                    QuantFactor1.ShopID = WebCookie.ShopID;
                    QuantFactor1.OperatedUserName = User.Identity.Name;
                    QuantFactor1.OperatedDate = DateTime.Now; 
                    db.Entry(QuantFactor1).State = EntityState.Modified;
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_UpdateOK;
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_UpdateFail;
                    return Json(ModalDialogView1);
                }
            }
            
        }

        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public ActionResult QuantFactorDelete(string QuantFactorID)
        {
            string msg = string.Format("<br/><h3>OK，{0}</h3><br/>" + QuantFactorID, Lang.User_QuantFactorDelete_msg);
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            try
            {
                QuantFactor QuantFactor1 = db.QuantFactors.Find(QuantFactorID);
                if (QuantFactor1.ShopID == WebCookie.ShopID)
                {
                    db.QuantFactors.Remove(QuantFactor1);
                }
                int rest = db.SaveChanges();
                if (rest > 0)
                {
                    var deleteQuery = db.QuantFactors.Where(p => p.ParentsID == QuantFactorID);

                    foreach (var item in deleteQuery)
                    {
                        db.QuantFactors.Remove(item);
                    }
                    db.SaveChanges();
                }

                return Json(modalDialogView);
            }
            catch
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = string.Format("<br/><h3>{0}</h3><br/>" + QuantFactorID, Lang.User_QuantFactorDelete_msgError) };
                return Json(modalDialogView);
            }
        } 
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpGet]
        public ActionResult Details(string UserProfileID ,string ID)
        {  
            EnumHelper EnumHelper1 = new Utilities.EnumHelper(); //性别
            ViewBag.GenderList = EnumHelper.GetSelectList<Genders>();

            if (!string.IsNullOrEmpty(ID)) // ID不等于null
            {
                UserProfileID = ID;
            }
            //
            if (!string.IsNullOrEmpty(UserProfileID)) // 不等于null
            { 
                // 返回 活动明细   
                ViewBag.CurrentUserProfileID = UserProfileID;
  
                var UserProfile1 = db.UserProfiles.Find(int.Parse(UserProfileID));
                
                //只允许是当前店铺
                if (UserProfile1.ShopID != WebCookie.ShopID)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (UserProfile1 == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                } 
                return View(UserProfile1);
            }
            else
            {
                UserProfile UserProfile2 = new UserProfile();
                UserProfile2.Gender = Genders.Unkown;
                UserProfile2.Birthday =DateTime.Parse(DateTime.Now.ToShortDateString());
                return View(UserProfile2);
            } 
        }

        //客户管理
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpPost]
        public ActionResult Details(string UserProfileID, [Bind(Include = "UserProfileID,UserId ,PhoneNumber ,WechatID,Email,NickName,VipLevelID" +
            ",UserTagID,AsignAccountMgrIDs,IsMonopoly,ResourceFile,QuantizationScore,Remarks, FullName,Gender, Birthday,Country, State, City,District" +
            ",Address,RecievedPhoneNumber,ShopID,OperatedUserName ,OperatedDate,CreatedDate, IsBlock")]UserProfile UserProfile1)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            UserProfile1.OperatedUserName = User.Identity.Name;
            UserProfile1.OperatedDate = DateTime.Now;

            if (string.IsNullOrEmpty(UserProfileID)|| UserProfileID == "0")
            {

                UserProfile1.VipLevelID = 0 ;

                //有备案记录的潜在客户 初始量化积分 增加 1
                UserProfile1.QuantizationScore = 1;

                UserProfile1.ShopID = WebCookie.ShopID; 
                UserProfile1.OperatedUserName = User.Identity.Name;
                UserProfile1.CreatedDate = DateTime.Now;
                UserProfile1.OperatedDate = DateTime.Now;

                db.UserProfiles.Add(UserProfile1);
                db.SaveChanges();

                ViewBag.CurrentUserProfileID = UserProfile1.UserProfileID.ToString();
                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message = Lang.Views_GeneralUI_AddNewOk  + UserProfile1.UserProfileID.ToString();
                return Json(ModalDialogView1); 
            }
            else
            { 
                ViewBag.CurrentUserProfileID = UserProfileID;  
                if (ModelState.IsValid)
                {
                    UpdateModel<UserProfile>(UserProfile1);
                    UserProfile1.ShopID = WebCookie.ShopID;
                    db.Entry(UserProfile1).State = EntityState.Modified;
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_UpdateOK;
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_UpdateFail;
                    return Json(ModalDialogView1);
                }
            }

        }

        // POST: Mgr/Info/Delete/5
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpPost]
        public ActionResult UserProfile_Delete(string UserProfileID)
        {
            string msg = "<br/><h3>"+ Lang.Views_GeneralUI_DeleteOK + "</h3><br/>UserProfileID=" + UserProfileID;
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            try
            {
                UserProfile UserProfileItem = db.UserProfiles.Find(int.Parse(UserProfileID));

                //Security filtering: only the current Shop is allowed
                if (UserProfileItem.ShopID != WebCookie.ShopID)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                } 
                db.UserProfiles.Remove(UserProfileItem);
                db.SaveChanges();
                return Json(modalDialogView);
            }
            catch(Exception e)
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = "<br/><h3>程序出错,操作失败</h3><br/>" + e.Message };
                return Json(modalDialogView);
            }
        }


        /// <summary>
        /// UserQuantFactor
        /// </summary>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpGet]
        public ActionResult UserQuantFactor(string UserProfileID,string ID)
        {
            UserProfileID = string.IsNullOrEmpty(ID) ? UserProfileID : ID;
            ViewBag.CurrentUserProfileID = UserProfileID;
            //UserQuantFactor UserQuantFactor1 = new UserQuantFactor();
            //UserQuantFactor1.UserProfileID = int.Parse(UserProfileID);

            //return View(UserQuantFactor1);

            return View();

        }

        /// <summary>
        /// UserQuantFactor 插入新的用户量化记录
        /// </summary>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpPost]
        public ActionResult UserQuantFactor([Bind(Include = "UserProfileID,  QuantFactorID, Score, FactorNameRemarks")]UserQuantFactor UserQuantFactor1)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
 

            UserQuantFactor1.ShopID = WebCookie.ShopID;
            UserQuantFactor1.OperatedUserName = User.Identity.Name;
            UserQuantFactor1.CreatedDate = DateTime.Now;
            UserQuantFactor1.OperatedDate = DateTime.Now;

            try {
                db.UserQuantFactors.Add(UserQuantFactor1);
                int resultID = db.SaveChanges();

                //更新客户的量化积分
                var QuantizationScore = db.UserQuantFactors.Where(s => s.UserProfileID ==UserQuantFactor1.UserProfileID).Sum(c=>c.Score);
                UserProfile UserProfile1 = db.UserProfiles.Find(UserQuantFactor1.UserProfileID);
                
                UpdateModel<UserProfile>(UserProfile1);
                UserProfile1.QuantizationScore = QuantizationScore;
                db.Entry(UserProfile1).State = EntityState.Modified;
                db.SaveChanges();
  

                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message =Lang.Views_GeneralUI_SavedSuccessfully + " ," + resultID.ToString() + "<br/><br/>" + Lang.UserProfile_QuantizationScore +"=" + QuantizationScore.ToString();
                return Json(ModalDialogView1);
            }
            catch (Exception e) {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = Lang.Views_GeneralUI_ServerError + e.Message +"<br/>" + UserQuantFactor1.UserProfileID+ "-"+ UserQuantFactor1.QuantFactorID;
                return Json(ModalDialogView1);
            } 
        }

        /// <summary>
        /// 客户的量化因子列表 UserQuantFactorList 
        /// </summary>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpGet]
        public ActionResult UserQuantFactorList(string UserProfileID, string ID , int? page)
        {
            UserProfileID = string.IsNullOrEmpty(ID) ? UserProfileID : ID;
            ViewBag.CurrentUserProfileID = UserProfileID;
          
            if (page == null)
            {
                page = 1;
            }
            int intUserProfileID = int.Parse(UserProfileID);
            var UserQuantFactors = from s in db.UserQuantFactors.Where(s => s.ShopID == WebCookie.ShopID)  //过滤店铺
                                   select s;
            UserQuantFactors = db.UserQuantFactors.Where(s => s.UserProfileID == intUserProfileID ).OrderBy(c => c.CreatedDate);

            int pageSize = 100;
            int pageNumber = (page ?? 1);

            return View(UserQuantFactors.ToPagedList(pageNumber, pageSize));
              
    }

        // POST: Mgr/User/UserQuantfactorRemove
        /// <summary>
        /// 删除潜在客户的量化
        /// </summary>
        /// <param name="UploadItemId"></param>
        /// <returns></returns>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpPost]
        public ActionResult UserQuantfactorRemove(int ID)
        { 
            string msg = string.Format("<br/><h3>{0}</h3><br/> ID = {1} ",Lang.Views_GeneralUI_DeleteOK, ID.ToString());
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            try
            {
                UserQuantFactor UserQuantFactor1 = db.UserQuantFactors.Find(ID);
                db.UserQuantFactors.Remove(UserQuantFactor1);
                db.SaveChanges();

                //更新客户的量化积分
                UserProfile UserProfile1 = db.UserProfiles.Find(UserQuantFactor1.UserProfileID);
                int QuantizationScore = UserProfile1.QuantizationScore;
                QuantizationScore = QuantizationScore - UserQuantFactor1.Score;

                UpdateModel<UserProfile>(UserProfile1);
                UserProfile1.QuantizationScore = QuantizationScore;
                db.Entry(UserProfile1).State = EntityState.Modified;
                db.SaveChanges();

                return Json(modalDialogView);
            }
            catch(Exception e)
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = string.Format("{0},{1},ID = {2}", Lang.Views_GeneralUI_ServerError, e.Message, ID.ToString()) };
                return Json(modalDialogView);
            };
              
            
        }

        /// <summary>
        /// 获取客户备注
        /// </summary>
        /// <param name="SourceStatisticsID"></param> 
        /// <returns></returns>

        [HttpPost]
        public JsonResult UserProfileRemarksQuery(int UserProfileID)
        {
             
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = "-" };

            UserProfile UserProfile1 = db.UserProfiles.Find(UserProfileID);
            if (UserProfile1 != null )
            {
                modalDialogView.Message = UserProfile1.Remarks;

                return Json(modalDialogView);
            }
            else
            {
                return Json(modalDialogView);
            } 
        }

        /// <summary>
        /// 添加客户备注
        /// </summary> 
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpGet]
        public ActionResult UserProfileAddRemarks(string UserProfileID, string ID)
        {
            UserProfileID = string.IsNullOrEmpty(ID) ? UserProfileID : ID;
            ViewBag.CurrentUserProfileID = UserProfileID;

            UserProfile UserProfile1 = db.UserProfiles.Find(int.Parse(UserProfileID));
            UserProfileRemarks UserProfileRemarks1 = new UserProfileRemarks { FullName = UserProfile1.FullName, NickName = UserProfile1.NickName, Remarks = UserProfile1.Remarks } ;
            return View(UserProfileRemarks1); 
        }
        /// <summary>
        /// 添加客户备注
        /// </summary>
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins,CustomerService")]
        [HttpPost]
        public ActionResult UserProfileAddRemarks(int UserProfileID,[Bind(Include = "Remarks")]UserProfileRemarks UserProfileRemarks1)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            UserProfile UserProfile1 = db.UserProfiles.Find(UserProfileID);
            UserProfile1.UserProfileID = UserProfileID;
            UserProfile1.Remarks = UserProfileRemarks1.Remarks.Trim();
            UserProfile1.ShopID = WebCookie.ShopID;
            UserProfile1.OperatedUserName = User.Identity.Name;
            UserProfile1.OperatedDate = DateTime.Now;

            try
            { 
                UpdateModel<UserProfile>(UserProfile1); 
                db.Entry(UserProfile1).State = EntityState.Modified;
                db.SaveChanges();
                
                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message = string.Format("{0},{1}",Lang.Views_GeneralUI_UpdateOK, UserProfile1.UserProfileID.ToString());
                return Json(ModalDialogView1);
            }
            catch (Exception e)
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = string.Format("{0},{1},{2}",Lang.Views_GeneralUI_ServerError, e.Message, UserProfile1.UserProfileID.ToString());
                return Json(ModalDialogView1);
            } 
        }

        /// <summary>
        /// 統計來源
        /// </summary>
        [Authorize]
        [HttpGet]
        public ActionResult SourceStatisticByRecommList()
        {
            DateTime dt = DateTime.Now;

            BackEndShopInitialize();

            string UserId = User.Identity.GetUserId();
            var sourceStatistics = from s in db.SourceStatistics.Where(s => s.RecommUserId == UserId)
                                   select s;
            var sourceStatisticList = sourceStatistics.OrderByDescending(s => s.LastUpdateDate).Take(100).ToList();

            var statistics = from a in db.SourceStatistics.Select(c => new { c.SourceStatisticsID, c.CreatedDate }).Where(s => s.CreatedDate.Year == dt.Year && s.CreatedDate.Month==dt.Month)
                             select a;

            ViewBag.UserViewsCount = statistics.Count(); //本月的統計

            return View(sourceStatisticList);
        }
        public class TreeView
        {
            public string text { get; set; }
            public string nodeid { get; set; }
            public string custom { get; set; }
        }
         
    }
    
}

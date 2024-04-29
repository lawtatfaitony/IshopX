using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Ishop.ViewModes.Public;
using Ishop.Models.PubDataModal;
using Ishop.Areas.Mgr.Models;
using LanguageResource;
using PagedList;

namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize]
    public class MenuItemController : Controller
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
        // GET: Mgr/MenuItem
        [Authorize(Roles = "Supervisor")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mgr/MenuItem/Details/5
        [Authorize(Roles = "Supervisor")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mgr/MenuItem/Create
        [Authorize(Roles = "Supervisor")]
        public ActionResult Create()
        { 
            ViewBag.ForRoleName = new SelectList(db.Roles.OrderByDescending(c=>c.Name), "Name", "Description");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Supervisor")]
        public async Task<ActionResult> Create([Bind(Include = "MenuItemName,EngMenuItemName,ParentsMenuItemID,MenuLink,ForRoleName")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {   if (string.IsNullOrEmpty(menuItem.ParentsMenuItemID) || menuItem.ParentsMenuItemID.Trim() == "0")
                {
                    menuItem.ParentsMenuItemID = "0";
                }
                menuItem.MenuItemID = db.GetTableIdentityID("Menu", "MenuItem", 6);
                menuItem.Target = "self";
                menuItem.OperatedUserName = User.Identity.Name;
                menuItem.OperatedDate = DateTime.Now;

                db.MenuItems.Add(menuItem);
                await db.SaveChangesAsync();
                return View("ActionResultView");
            }
            
            ViewBag.ForRoleName = new SelectList(db.Roles.OrderByDescending(c => c.Name), "Name", "Description",menuItem.ForRoleName) ;
            return View(menuItem);
        }

        // GET: Mgr/MenuItem/Edit/5
        [Authorize(Roles = "Supervisor")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mgr/MenuItem/Edit/5
        [HttpPost]
        [Authorize(Roles = "Supervisor")]
        public ActionResult Edit(int id, System.Web.Mvc.FormCollection collection)
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

        // GET: Mgr/MenuItem/Delete/5
        [Authorize(Roles = "Supervisor")]
        public ActionResult Delete(string ParentsMenuItemID)
        {
            ViewBag.ParentsMenuItemID = ParentsMenuItemID;
            var menuItem = db.MenuItems.Find(ParentsMenuItemID);
            if(menuItem==null)
            {
                ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "0", Message = Lang.ManuItem_ActionMethod_Delete_NotExists };
                return View("ModalDialogView", modalDialogView);

            }
            return View(menuItem);
        }

        // POST: Mgr/MenuItem/Delete/5
        [HttpPost]
        [Authorize(Roles = "Supervisor")]

        public  JsonResult  DeleteMenuItem(string MenuItemID)
        { 

            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = Lang.ManuItem_ActionMethod_Del + MenuItemID }; 
            string json = JsonConvert.SerializeObject(modalDialogView);
           
            try
            {
                MenuItem menuItem = db.MenuItems.Find(MenuItemID);
                db.MenuItems.Remove(menuItem);
                int rest = db.SaveChanges();
                if(rest>0)
                {
                    var deleteQuery = db.MenuItems.Where(p => p.ParentsMenuItemID == MenuItemID );
                   
                    foreach (var item in deleteQuery)
                         {
                             db.MenuItems.Remove(item);  
                         }
                         db.SaveChanges();
                }
              
                return Json(json, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                 modalDialogView = new ModalDialogView { MsgCode = "0", Message = Lang.ManuItem_ActionMethod_DeleteMenuItem_Failure + MenuItemID };
                 return Json(json, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
            }
        }
       
        [HttpGet] 
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "ParentsMenuItemID")]  ///缓存3600秒(内存)  VaryByParam = "*"
        public JsonResult GetNodeOfMenuItem(string ParentsMenuItemID)  // 所以节点 :  ParentsMenuItemID="0"
        {
            ParentsMenuItemID = string.IsNullOrEmpty(ParentsMenuItemID) ? "0" : ParentsMenuItemID;
            List<MenuItem> MenuItem1 = db.MenuItems.ToList(); 
            GetTreeJsonByTable(GetMenuItemIsInRole(MenuItem1), ParentsMenuItemID);
            string strResult = result.ToString();
            return Json(strResult, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);  
 
        }
        /// <summary>
        /// 用于JS客户端判断 角色 范围
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public JsonResult CheckMenuPrevilege(string roleName)
        {
            // return UserManager.IsInRole(User.Identity.GetUserId(), roleName) ;

            // 
            bool  A = UserManager.IsInRole(User.Identity.GetUserId(), roleName);
           
            string UserId = User.Identity.GetUserId();
            return Json(new { UserId = UserId, IsInRole = A, RoleName= roleName }, JsonRequestBehavior.AllowGet);
        }
        private List<MenuItem> GetMenuItemIsInRole(List<MenuItem> AllList)
        {
            List<MenuItem> M1 = new List<MenuItem>();
            foreach (var item in AllList)
            {
                if(CheckIsInRole(item.ForRoleName))
                {
                    M1.Add(item);
                }  
            }
            return M1;
        }
        private bool CheckIsInRole(string roleName)
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
            // 如果超级管理员 属于例外情况 
            if (UserManager.IsInRole(UserId,"Supervisor" ))
            {
                A = true;
            }
            return A; 
        }
        #region
        /// <summary>
        /// 根据DataTable生成Json树结构
        /// </summary>

        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetTreeJsonByTable(List<MenuItem> MenuItems1, string ParentsMenuItemID)
        {
            TreeView TreeView1 = new TreeView();
            result.Append(sb);
            sb.Clear();
            if (MenuItems1.Count<MenuItem>() > 0)
            {
                sb.Append("\n[");

                var MenuItems2 = MenuItems1.Where(c => c.ParentsMenuItemID == ParentsMenuItemID).OrderByDescending(p=>p.OperatedDate);
                if (MenuItems2.Count<MenuItem>() > 0)
                {
                    foreach (var row in MenuItems2)
                    {
                        if (row.MenuLink.Trim() == "#")
                        {
                            if(LangUtilities.LanguageCode != "en")
                            {
                                sb.Append("{\"nodeid\":\"" + row.MenuItemID + "\",\"text\":\"" + ChineseStringUtility.ToAutoTraditional(row.MenuItemName) + "\",\"custom\":\"" + row.ParentsMenuItemID + "\",\"ForRoleName\":\"" + row.ForRoleName + "\"");
                            }else
                            {
                                sb.Append("{\"nodeid\":\"" + row.MenuItemID + "\",\"text\":\"" + row.EngMenuItemName + "\",\"custom\":\"" + row.ParentsMenuItemID + "\",\"ForRoleName\":\"" + row.ForRoleName + "\"");
                            }
                            
                        }
                        else
                        {
                            if (LangUtilities.LanguageCode != "en")
                            {
                                sb.Append("{\"nodeid\":\"" + row.MenuItemID + "\",\"text\":\"" + ChineseStringUtility.ToAutoTraditional(row.MenuItemName) + "\",\"custom\":\"" + row.ParentsMenuItemID + "\",\"href\":\"" + row.MenuLink + "\",\"Target\":\"" + row.Target + "\",\"ForRoleName\":\"" + row.ForRoleName + "\"");
                            }
                            else
                            {
                                sb.Append("{\"nodeid\":\"" + row.MenuItemID + "\",\"text\":\"" +  row.EngMenuItemName + "\",\"custom\":\"" + row.ParentsMenuItemID + "\",\"href\":\"" + row.MenuLink + "\",\"Target\":\"" + row.Target + "\",\"ForRoleName\":\"" + row.ForRoleName + "\"");
                            }
                        }
                        var MenuItems3 = db.MenuItems.Where(c => c.ParentsMenuItemID == row.MenuItemID);
                        if (MenuItems3.Count<MenuItem>() > 0)
                        {
                            sb.Append(",\"nodes\":");  
                            GetTreeJsonByTable(MenuItems3.ToList(), row.MenuItemID);
                            result.Append(sb);
                            sb.Clear();
                        }
                        result.Append(sb);
                        sb.Clear();
                        sb.Append("},");  
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                result.Append(sb);
                sb.Clear();
            }
        }

        #endregion

        #region // 仅用于备份:测试OK
        private void GetTreeJsonByTable2(List<MenuItem> MenuItems1, string ParentsMenuItemID)
        {
            TreeView TreeView1 = new TreeView();
            result.Append(sb);
            sb.Clear();
            if (MenuItems1.Count<MenuItem>() > 0)
            {
                sb.Append("\n[");

                var MenuItems2 = MenuItems1.Where(c => c.ParentsMenuItemID == ParentsMenuItemID);
                if (MenuItems2.Count<MenuItem>() > 0)
                {
                    foreach (var row in MenuItems2)
                    {
                        sb.Append("{\"nodeid\":\"" + row.MenuItemID + "\",\"text\":\"" + row.MenuItemName + "\",\"custom\":\"" + row.ParentsMenuItemID + "\",\"href\":\"" + row.MenuLink + "\",\"Target\":\"" + row.Target + "\",\"ForRoleName\":\"" + row.ForRoleName + "\"");

                        var MenuItems3 = db.MenuItems.Where(c => c.ParentsMenuItemID == row.MenuItemID);
                        if (MenuItems3.Count<MenuItem>() > 0)
                        {
                            sb.Append(",\"nodes\":");
                            GetTreeJsonByTable(MenuItems3.ToList(), row.MenuItemID);
                            result.Append(sb);
                            sb.Clear();
                        }
                        result.Append(sb);
                        sb.Clear();
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                result.Append(sb);
                sb.Clear();
            }
        }
        #endregion

        // GET: Mgr/Info
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet]
        public ActionResult LangList(string sortOrder, string currentFilter, string searchString,int? page)
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

            var LangList = from s in db.Languages
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                LangList = LangList.Where(s => s.KeyName.Contains(searchString) || s.KeyType.Contains(searchString)
                                                                                     || s.zh_CN.Contains(searchString)
                                                                                     || s.zh_HK.Contains(searchString)
                                                                                     || s.zh.Contains(searchString)
                                                                                     || s.en.Contains(searchString)
                                                                                     || s.fr.Contains(searchString)
                                                                                     || s.de.Contains(searchString)
                                                                                     || s.ru.Contains(searchString)
                                                                                     || s.ar.Contains(searchString)
                                                                                     || s.es.Contains(searchString)
                                                                                     || s.Remarks.Contains(searchString));
            }
              
            switch (sortOrder)
            {
                case "Date":
                    LangList = LangList.OrderBy(s => s.KeyName);
                    break;
                case "date_desc":
                    LangList = LangList.OrderByDescending(s => s.KeyName);
                    break;
                default:  // Name ascending 
                    LangList = LangList.OrderByDescending(s => s.KeyName);
                    break;
            }
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(LangList.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet]
        public ActionResult LangDetail(string KeyName)
        {
            Language language = new Language();
            
            if (!string.IsNullOrEmpty(KeyName))
            {
                ViewBag.KeyName = KeyName;
                language = db.Languages.Find(KeyName);
                return View(language);
            }
            return View(language);
        }
 
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]
        public ActionResult LangDetail(string KeyName, [Bind(Include = "KeyName,KeyType,zh_CN,zh_HK,zh,en,fr,de,ru,ar,es,ja,ko,Remarks")]Language language)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "1";
            ModalDialogView1.Message = Lang.GeneralUI_OK;

            if (!string.IsNullOrEmpty(KeyName))
            {
                try
                {
                    
                    if (ModelState.IsValid)
                    {
                        db.Entry(language).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges(); 
                        return Json(ModalDialogView1);
                    }
                    else
                    {
                        ModalDialogView1.MsgCode = "0";
                        ModalDialogView1.Message = Lang.GeneralUI_Fail;
                        return Json(ModalDialogView1);
                    } 
                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = Lang.GeneralUI_Fail + "\n\n" + e.Message; ;
                    return Json(ModalDialogView1);
                }
            }
            return View(language);
        }
    }
}

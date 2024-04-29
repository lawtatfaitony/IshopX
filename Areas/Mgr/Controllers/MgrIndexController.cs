using System.Text;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin; 
using Ishop.ViewModes.Public; 
using Ishop.Models.PubDataModal; 
using Ishop.Areas.Mgr.Models; 
namespace Ishop.Areas.Mgr.Controllers   //Ishop.Areas.Mgr
{
    public class MgrIndexController : Controller
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
        // GET: Mgr/MgrIndex
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LeftMenu(string ParentsMenuItemID)
        {
            if( string.IsNullOrEmpty(ParentsMenuItemID))
            {
                ParentsMenuItemID = "0";
            }
            List<MenuItem> MenuItem1 = db.MenuItems.ToList();
            GetULTreeByTable(GetMenuItemIsInRole(MenuItem1), ParentsMenuItemID); 
            string strResult = result.ToString();
            ViewBag.Result = strResult;
            ModalDialogView m = new ModalDialogView();
            m.MsgCode = "1";
            m.Message = strResult;
            return View(m); 
        }
        #region  ///ul树结构菜单
        /// <summary>
        /// 根据 生成html 的 ul树结构
        /// </summary>

        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetULTreeByTable(List<MenuItem> MenuItems1, string ParentsMenuItemID)
        {
            TreeView TreeView1 = new TreeView();
            result.Append(sb);
            sb.Clear();
            if (MenuItems1.Count<MenuItem>() > 0)
            {
                sb.Append("\n\r<ul id=\"left-sidebar-menu-widgets\" class=\"treeview-menu\">");   //"\n["

                         var MenuItems2 = MenuItems1.Where(c => c.ParentsMenuItemID == ParentsMenuItemID).OrderByDescending(p => p.OperatedDate);
                        if (MenuItems2.Count<MenuItem>() > 0)
                        {
                            foreach (var row in MenuItems2)
                            {
                       
                                sb.Append("\n\r<li class=\"treeview\" id = \"" + row.MenuItemID +"\" ><a href =\"" + row.MenuLink + "\"><i class=\"fa fa-circle-o\"></i> "+ row.MenuItemName + "</a>"); 
                        
                                var MenuItems3 = MenuItems1.Where(c => c.ParentsMenuItemID == row.MenuItemID);
                                if (MenuItems3.Count<MenuItem>() > 0)
                                {
                                    GetULTreeByTable(MenuItems3.ToList(), row.MenuItemID);
                                     
                                    result.Append(sb); 
                            
                                    sb.Clear(); 
                                }
                                sb.Append("\n\r</li>");
                                result.Append(sb);
                                sb.Clear();
                                
                            }
                          //  sb = sb.Remove(sb.Length - 5, 5);
                        }
                 sb.Append("\n\r</ul>");
                 result.Append(sb);
                 sb.Clear();
            }
        }

        #endregion
       
        private List<MenuItem> GetMenuItemIsInRole(List<MenuItem> AllList)
        {
            List<MenuItem> M1 = new List<MenuItem>();
            foreach (var item in AllList)
            {
                if (CheckIsInRole(item.ForRoleName))
                {
                    M1.Add(item);
                }
            }
            return M1;
        }
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
            //If the super administrator is an exception
            if (UserManager.IsInRole(UserId, "Supervisor"))
            {
                A = true;
            }
            return A;
        }
    }
}
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
using Ishop.Context; 
namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize(Roles = "StoreBusinessPromotion")]
    public class SeoController : Controller
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Mgr/Seo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "ParentsSeoExtandID")]  ///缓存3600秒(内存)  VaryByParam = "*"
        public JsonResult GetNodeOfSeoExtand(string searchString , string ParentsSeoExtandID)  // 所以节点 :  ParentsMenuItemID="0"
        {
            searchString = string.IsNullOrEmpty(searchString) ? "" : searchString.Trim();
            searchString = Server.UrlDecode(searchString); 
            ParentsSeoExtandID = string.IsNullOrEmpty(ParentsSeoExtandID) ? "0" : ParentsSeoExtandID;
            List<SeoExtand> SeoExtand1 = db.SeoExtands.Where(c=>c.SeoKeyWord.Contains(searchString) && c.ShopID == WebCookie.ShopID).ToList() ;//要过滤店铺ID
            if (SeoExtand1.Count() > 20)
            {
                SeoExtand1 = SeoExtand1.Take(20).ToList();
            } 
            GetTreeJsonByTable(SeoExtand1, ParentsSeoExtandID);
            string strResult = result.ToString();
            if (string.IsNullOrEmpty(strResult)|| strResult == "\n[]")
            {
                strResult = "[{\"nodeid\":\"0\",\"text\":\"OH,No KeyWord\",\"custom\":\" \"}]";
            } 
            return Json(strResult, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
        }
        #region
        /// <summary>
        /// Generate a Json tree structure based on the DataTable
        /// </summary>

        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetTreeJsonByTable(List<SeoExtand> SeoExtand1, string ParentsSeoExtandID)
        {
            TreeView TreeView1 = new TreeView();
            result.Append(sb);
            sb.Clear();
            if (SeoExtand1.Count<SeoExtand>() > 0)
            {
                sb.Append("\n[");

                var SeoExtand2 = SeoExtand1; // SeoExtand1.Where(c => c.ParentsSeoExtandID == ParentsSeoExtandID);
                if (SeoExtand2.Count<SeoExtand>() > 0)
                {
                    foreach (var row in SeoExtand2)
                    {
                        
                        sb.Append("{\"nodeid\":\"" + row.SeoExtandID + "\",\"text\":\"" + row.SeoKeyWord + "\",\"custom\":\"" + row.SeoKeyWord + "\"");
                        
                        var SeoExtand3 = db.SeoExtands.Where(c => c.ParentsSeoExtandID == row.SeoExtandID);
                        if (SeoExtand3.Count<SeoExtand>() > 0)
                        {
                            sb.Append(",\"nodes\":");
                            GetTreeJsonByTable(SeoExtand3.ToList(), row.SeoExtandID);
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
    }
}
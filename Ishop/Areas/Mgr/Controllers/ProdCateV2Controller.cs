using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ishop.DAL;
using Ishop.Models.ProductMgr;
using Ishop.ViewModes.Public;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Ishop.Areas.Mgr.Models;
using System.Data.Entity.Infrastructure;
using Ishop.Controllers;

namespace Ishop.Areas.Mgr.Controllers
{
    public class ProdCateV2Controller : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Mgr/ProdCateV2
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Supervisor,Admins")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult ProdPropertiesName_Lst(string ProdCateID)
        {
            //测试 ProdCateID = "PC000021";
            var ProdPropertiesName1 = from s in db.ProdPropertiesNames select s;
            if (!string.IsNullOrEmpty(ProdCateID))
            {
                ProdPropertiesName1 = ProdPropertiesName1.Where(s => s.ProdCateID.Contains(ProdCateID));
            }
            ProdPropertiesName1 = ProdPropertiesName1.OrderBy(s => s.PropertiesName);
            List<TreeView>  ListPNdetails = new List<TreeView>();
             
            foreach (var itemR in ProdPropertiesName1)
            {
                TreeView myTreeView = new TreeView();
                myTreeView.nodeid = itemR.PropertiesNameID ;
                myTreeView.text = itemR.PropertiesName;
                myTreeView.custom = itemR.IsForTrading.ToString(); //传递其他值  是否交易属性
                ListPNdetails.Add(myTreeView);
            }
            return Json(ListPNdetails.ToList(), JsonRequestBehavior.AllowGet);
            //return Json(ListPNdetails.ToList());  // JsonRequestBehavior.AllowGet: 正式发布时候去掉,防止异域获取
        }
        /// <summary>
        /// 属性项删除  /*存在属性项有定义的属性值,要先删除,否则不能删除*/
        /// </summary>
        /// <param name="PropertiesNameID"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult ProdPropertiesName_Del(string PropertiesNameID)
        {
            ProdPropertiesName DelItem = db.ProdPropertiesNames.Where(c => c.PropertiesNameID == PropertiesNameID).SingleOrDefault<ProdPropertiesName>();
            
            db.ProdPropertiesNames.Remove(DelItem);
            int result = db.SaveChanges();
            if(result > 0)
            {
                Dictionary<string, string> case1 = new Dictionary<string, string> { { "result", "1" } };
                return Json(case1);
            }else
            {
                Dictionary<string, string> case1 = new Dictionary<string, string> { { "result", "0" } };
                return Json(case1);
            }
            
                 
        }
        /// <summary>
        /// 更改 属性名称 { 1:成功 0：失败 }  
        /// </summary>
        /// <param name="PropertiesNameID">更新参数：{"PropertiesNameID":"PN00000001","ProdCateName":"是非得失3e","IsForTrading":"1"} ProdcateProp.js:321</param>
        /// <param name="PropertiesName"></param>
        /// <param name="IsForTrading">是否交易属性</param>
        /// <returns>{ 1:成功 0：失败 }  </returns>
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult ProdPropertiesName_Upd(string PropertiesNameID, string PropertiesName, string IsForTrading,int ShowPicture)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "1";
            ModalDialogView1.Message = "SUCCESS";

            ProdPropertiesName prodPropertiesName = db.ProdPropertiesNames.Find(PropertiesNameID);
            prodPropertiesName.IsForTrading = int.Parse(IsForTrading);
            prodPropertiesName.ShowPicture = ShowPicture;
            prodPropertiesName.PropertiesName = PropertiesName.Trim(); 
            db.Entry(prodPropertiesName).State = EntityState.Modified;
            int Result = db.SaveChanges(); 
            if (Result > 0)
            {
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", 1 } };
                return Json(result);
            }
            else
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "FAILURE";
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", 0 } };
                return Json(result);
            } 
        }
        /// <summary>
        /// 1:成功 0：插入失败
        /// </summary>
        /// <param name="ProdCateID"></param>
        /// <param name="ProdCateName"></param>
        /// <param name="PropertiesName"></param>
        /// <param name="IsForTrading"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult ProdPropertiesName_INS(string ProdCateID, string ProdCateName, string PropertiesName, int IsForTrading,int ShowPicture)
        {
            ProdPropertiesName ProdPropertiesName1=new ProdPropertiesName();
            ProdPropertiesName1.PropertiesNameID = db.GetTableIdentityID("PN", "ProdPropertiesName", 8);
            ProdPropertiesName1.ProdCateID = ProdCateID;
            ProdPropertiesName1.ProdCateName = ProdCateName;
            ProdPropertiesName1.PropertiesName = PropertiesName;
            ProdPropertiesName1.IsForTrading = IsForTrading;
            ProdPropertiesName1.ShowPicture = ShowPicture;
            
            db.ProdPropertiesNames.Add(ProdPropertiesName1);
            try
            { 
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message); 
            }
            Dictionary<string, int> result = new Dictionary<string, int> { { "result", 1 } };
            return Json(result,JsonRequestBehavior.AllowGet); 
            
        }
        /// <summary>
        /// 属性名称 检查统一类目下的重复  重名检测
        /// </summary>
        /// <param name="ProdCateID"></param>
        /// <param name="PropertiesName"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult ProdCate_CheckPropertiesName(string ProdCateID, string PropertiesName)
        {
            if (PropertiesName.Length < 1) //属性名称格式错误,返回。
            {
                Dictionary<string, string> result = new Dictionary<string, string> { { "result", "0" } };
                return Json(result);
            }

            //ProdPropertiesName prodPropertiesName = new ProdPropertiesName
            //{
            //    ProdCateID = ProdCateID 
            //    ,PropertiesName = PropertiesName
            //};
            //db.Entry(prodPropertiesName).State = EntityState.Modified;
            //int Result = db.SaveChanges();

            var d = db.ProdPropertiesNames.Where(c => c.PropertiesName == PropertiesName && c.ProdCateID == ProdCateID).ToList();
            if ( d.Count > 0)
            {
                Dictionary<string, string> result = new Dictionary<string, string> { { "result", "1" } };
                return Json(result);
            }
            else
            {
                Dictionary<string, string> result = new Dictionary<string, string> { { "result", "0" } };
                return Json(result);
            } 
        }
        [Authorize(Roles = "Supervisor,Admins")]
        public ActionResult ProdCateListByCateID()
        { 
            return View();
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]  ///缓存3600秒(内存)
        public JsonResult GetNodeOfProdCate(string ParentsProdCateID)  // 所以节点 :  ParentsMenuItemID="0"
        { 
            if(ParentsProdCateID==null)
            {
                ParentsProdCateID = "0";
            }
            List<Prodcate> Prodcate1 = db.Prodcates.ToList();
            GetProdCateTree(Prodcate1, ParentsProdCateID);
            string strResult = result.ToString();
            return Json(strResult, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);

        }
        #region
        /// <summary>
        /// 根据数据集list生成Json树结构
        /// </summary>

        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetProdCateTree(List<Prodcate> Prodcates1, string ParentsProdCateID)
        {
            TreeView TreeView1 = new TreeView();
            result.Append(sb);
            sb.Clear();
            if (Prodcates1.Count<Prodcate>() > 0)
            {
                sb.Append("\n[");

                var Prodcates2 = Prodcates1.Where(c => c.ParentsProdCateID == ParentsProdCateID);
                if (Prodcates2.Count<Prodcate>() > 0)
                {
                    foreach (var row in Prodcates2)
                    {
                        
                        sb.Append("{\"nodeid\":\"" + row.ProdCateID + "\",\"text\":\"" + row.ProdCateName + "\",\"IsLock\":\"" + row.IsLock + "\",\"ParentsProdCateID\":\"" + row.ParentsProdCateID + "\"");
                        
                        var Prodcates3 = db.Prodcates.Where(c => c.ParentsProdCateID == row.ProdCateID);
                        if (Prodcates3.Count<Prodcate>() > 0)
                        {
                            sb.Append(",\"nodes\":");
                            GetProdCateTree(Prodcates3.ToList(), row.ProdCateID);
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

        /// <summary>
        /// ProdCate Management
        /// </summary>
        /// <param name="action"></param>
        /// <param name="ProdCateID"></param>
        /// <param name="ParentsProdCateID"></param>
        /// <param name="ParentsProdCateName"></param>
        /// <param name="ProdCateName"></param>
        /// <returns></returns>
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult ProductCateMgr(string action,string ProdCateID, string ParentsProdCateID, string ParentsProdCateName,string ProdCateName)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "1";
            ModalDialogView1.Message = "SUCCESS"; 
             
            if (action == "insert")
            { 
                try
                {
                    Prodcate Pro1 = new Prodcate
                    {
                        ProdCateID = ProdCateID
                        ,
                        ParentsProdCateID = ParentsProdCateID.TrimStart().TrimEnd()
                        ,
                        ProdCateName = ProdCateName.Trim()
                    };
                    int Levels = db.Prodcates.Find(ParentsProdCateID).Levels + 1;
                    if (ParentsProdCateID == "0")
                    {
                        Levels = 0;
                    }
                    Pro1.Levels = Levels;
                    Pro1.ProdCateID = db.GetTableIdentityID("PC", "ProdCate", 6);
                    db.Prodcates.Add(Pro1);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = e.Message;
                }
            }
            if(action == "update")
            { 
                try
                {
                    Prodcate Pro_upd = db.Prodcates.Find(ProdCateID);
                    DbEntityEntry<Prodcate> ProdcateEntry = db.Entry<Prodcate>(Pro_upd); 
                    ProdcateEntry.Property(e => e.ProdCateName).IsModified = true;
                    db.Prodcates.Attach(Pro_upd);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = e.Message;
                }
            }
            if (action == "delete")
            {
                Prodcate Pro_del = db.Prodcates.Find(ProdCateID); 
                if(Pro_del == null)
                {
                    ModalDialogView1.MsgCode = "0";
                    return Json(ModalDialogView1);
                }
                try
                {
                    db.Prodcates.Remove(Pro_del);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = e.Message;
                }
            } 

            return Json(ModalDialogView1);
        }
        /// <summary>
        /// Check the Repeate Name
        /// </summary>
        /// <param name="ProdCateName"></param>
        /// <returns></returns>
        [Authorize(Roles = "Supervisor,Admins")]
        public JsonResult CheckProdCateName(string ProdCateName)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "0";
            ModalDialogView1.Message = "Not Exist";
            var HasExistNot = db.Prodcates.Where(c => c.ProdCateName == ProdCateName).ToList();
            
            if (HasExistNot.Count > 0)
            {
                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message = "HasExist ";
            }  
            return Json(ModalDialogView1);
        }
    }
    
}
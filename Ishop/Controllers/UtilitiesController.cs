using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using Ishop.Models.UploadItem;
using Ishop.Utilities;
using Ishop.AppCode.Utilities;
using Newtonsoft.Json;
using Ishop.Models.User;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace Ishop.Controllers
{
    [Authorize]
    public class UtilitiesController : Controller
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        static string urlPath = string.Empty;
        public UtilitiesController()
        {
            var applicationPath = VirtualPathUtility.ToAbsolute("~") == "/" ? "" : VirtualPathUtility.ToAbsolute("~");
            urlPath = applicationPath + "/Upload";

        }
        // GET: Utilities
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 上存模块
        /// </summary>
        /// <param name="id">随机ID,用于识别每次上存</param>
        /// <param name="name">源文件名</param>
        /// <param name="type">类型</param>
        /// <param name="lastModifiedDate">最后更新</param>
        /// <param name="size">文件尺寸</param>
        /// <param name="Prefix">文件名前缀AAA,如 AAA12356.jpg</param>
        /// <param name="SubPath">真实的子路径  注意: 扩展功能,虚拟文件夹 通过TreeView 实现,实际磁盘是没有这个文件夹的</param>
        /// <param name="TargetTalbeKeyID"> 目标表的主键ID, 例如:ProdcutID  , CategoryID </param>
        /// <param name="ShopID">必需的,用于提取访问集</param>
        /// <param name="RankOrder">同一级的排列顺序</param>
        /// <param name="file"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult UpLoadProcess(string id, string name, string type, string lastModifiedDate, int size, string Prefix, string SubPath, string TargetTalbeKeyID, string ShopID, int RankOrder, HttpPostedFileBase file)
        {
            string oSubPath = SubPath.ToLower();
            string targetTalbeKeyID = string.Empty;
            int rankOrder = 0;
            if (!string.IsNullOrEmpty(TargetTalbeKeyID))
            {
                targetTalbeKeyID = TargetTalbeKeyID;
            }
            if (RankOrder != 0)
            {
                rankOrder = RankOrder;
            }
            string filePathName = string.Empty;
            //文件名称前缀  
            if (Prefix.Length > 1)
            {
                filePathName = Prefix + filePathName;
            }
            string localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
            //指定 至文件夹
            if (SubPath.Length > 1)
            {
                localPath = System.IO.Path.Combine(localPath, SubPath);
                urlPath += "/" + SubPath;
            }


            if (Request.Files.Count == 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id", filePath = "no file input" });
            }

            string ex = System.IO.Path.GetExtension(file.FileName);
            //filePathName = Guid.NewGuid().ToString("N") + ex;
            filePathName += DateTime.Now.ToString("yyyyMMddHHmmssfff") + ex;
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            file.SaveAs(System.IO.Path.Combine(localPath, filePathName));

            #region //图片压缩
            //如果是产品主图 则生成不同规格的缩略图  PictureSize = IsNotPict= 0 ,s60x60= 1, s100X100 = 2,s160X160= 3 ,s250X250 = 4, s300X300 = 5, s350X350 = 6, s600X600 = 7

            bool thumbnail_ok = false;
            string sFile = System.IO.Path.Combine(localPath, filePathName);
            string dFile = System.IO.Path.Combine(localPath, filePathName);
            string dThumbnailFile;
            int flag = 100;
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            Size tem_size = new Size(iSource.Width, iSource.Height);

            switch (oSubPath)
            {
                case "producthead":
                    if (tem_size.Width > 60 || tem_size.Width > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }
                    if (tem_size.Width > 100 || tem_size.Width > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    if (tem_size.Width > 160 || tem_size.Width > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (tem_size.Width > 250 || tem_size.Width > 250)
                    {
                        dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                    }
                    if (tem_size.Width > 310 || tem_size.Width > 310)
                    {
                        dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                    }
                    if (tem_size.Width > 350 || tem_size.Width > 350)
                    {
                        dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 350, 350, flag);
                    }
                    if (tem_size.Width > 600 || tem_size.Width > 600)
                    {
                        dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 600, 600, flag);
                    }
                    break;
                case "shoplogo":
                    if (tem_size.Width > 230 || tem_size.Width > 230)
                    {
                        dThumbnailFile = dFile + PictureSize.s230X230.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 230, 230, flag);
                    }
                    if (tem_size.Width > 60 || tem_size.Width > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }
                    if (tem_size.Width > 100 || tem_size.Width > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    if (tem_size.Width > 160 || tem_size.Width > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                   
                    break;

                case "definitetemplatenote":
                    if (tem_size.Width > 160 || tem_size.Width > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    
                    break;

            }
            iSource.Dispose();

            #endregion

            //数据记录
            UploadItem uploadItem = new UploadItem();

            uploadItem.UploadItemId = db.GetTableIdentityID("UP", "UploadItem", 20);
            uploadItem.TargetTalbeKeyID = TargetTalbeKeyID;
            uploadItem.RankOrder = rankOrder;
            uploadItem.RawName = name;
            uploadItem.ShopID = ShopID;
            uploadItem.SubPath = SubPath;
            uploadItem.Url = urlPath + "/" + filePathName;
            uploadItem.FileExt = ex;
            uploadItem.OperatedUserName = User.Identity.Name;
            uploadItem.OperatedDate = DateTime.Now;

            db.UploadItems.Add(uploadItem);
            db.SaveChanges();




            return Json(new
            {
                jsonrpc = "2.0",
                id = id,
                filePath = urlPath + "/" + filePathName,
                UploadItemId = uploadItem.UploadItemId,
                Thumbnail = thumbnail_ok.ToString()
            });

        }

        /// <summary>
        ///  上存文件优化   4大关联查询图片要素 Prefix, SubPath, TargetTalbeKeyID,   ShopID[必要的]
        /// </summary>
        /// <param name="Prefix"> 前缀</param>
        /// <param name="SubPath"> 子目录</param>
        /// <param name="TargetTalbeKeyID"> 对应主键ID</param>
        /// <param name="ShopID"> 店铺ID</param>
        /// <param name="file"> 指定发送</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost] 
        public ActionResult UpLoadProcess2(string Prefix, string SubPath, string TargetTalbeKeyID, string ShopID , HttpPostedFileBase file)
        {
            //Prefix SubPath 默认是UE编辑器
            if (string.IsNullOrEmpty(Prefix)) 
            {
                Prefix = "UE";
            } 
            if (string.IsNullOrEmpty(SubPath))
            {
                SubPath = "UEditor";
            }

            string oSubPath = SubPath.ToLower();
            string targetTalbeKeyID ;
            if (!string.IsNullOrEmpty(TargetTalbeKeyID))
            {
                targetTalbeKeyID = TargetTalbeKeyID;
            }
            else
            {
                targetTalbeKeyID = string.Format("{0:yyyyMMddHHmmss}",DateTime.Now);
            }
            string filePathName = string.Empty;

            if(!string.IsNullOrEmpty(ShopID))
            {
                filePathName = ShopID;
            }
            //文件名称前缀  
            if (Prefix.Length > 1)
            {
                filePathName = Prefix + filePathName;
            }
            string localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
            //指定 至文件夹
            if (SubPath.Length > 1)
            {
                localPath = System.IO.Path.Combine(localPath, SubPath);
                urlPath += "/" + SubPath;
            }
            
            if (Request.Files.Count == 0)
            {
                return Json(new
                {
                    UploadItemId = "0"
                    ,filePathName = ""
                });
            }

            string ex = System.IO.Path.GetExtension(file.FileName);
            //filePathName = Guid.NewGuid().ToString("N") + ex;
            filePathName += DateTime.Now.ToString("yyyyMMddHHmmssfff") + ex;
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            file.SaveAs(System.IO.Path.Combine(localPath, filePathName));
             
            string UploadItemId = "0";
            
            #region //图片压缩
            //如果是产品主图 则生成不同规格的缩略图  PictureSize = IsNotPict= 0 ,s60x60= 1, s100X100 = 2,s160X160= 3 ,s250X250 = 4, s300X300 = 5, s350X350 = 6, s600X600 = 7

            bool thumbnail_ok = false;
            string sFile = System.IO.Path.Combine(localPath, filePathName);
            string dFile = System.IO.Path.Combine(localPath, filePathName);
            string dThumbnailFile;
            int flag = 100;
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            Size tem_size = new Size(iSource.Width, iSource.Height);
               
            switch (oSubPath)
            {
                case "producthead":
                    if (tem_size.Width > 60 || tem_size.Height > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }
                    if (tem_size.Width > 100 || tem_size.Height > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    if (tem_size.Width > 160 || tem_size.Height > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (tem_size.Width > 250 || tem_size.Height > 250)
                    {
                        dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                    }
                    if (tem_size.Width > 310 || tem_size.Height > 310)
                    {
                        dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                    }
                    if (tem_size.Width > 350 || tem_size.Height > 350)
                    {
                        dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 350, 350, flag);
                    }
                    if (tem_size.Width > 600 || tem_size.Height > 600)
                    {
                        dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 600, 600, flag);
                    }
                    break;
                case "shoplogo":
                    if (tem_size.Width > 48 || tem_size.Height > 48)
                    {
                        dThumbnailFile = dFile + PictureSize.s48X48.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 48, 48, flag);
                    }
                    if (tem_size.Width > 60 || tem_size.Height > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }
                    if (tem_size.Width > 100 || tem_size.Height > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    if (tem_size.Width > 160 || tem_size.Height > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (tem_size.Width > 230 || tem_size.Height > 230)
                    {
                        dThumbnailFile = dFile + PictureSize.s230X230.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 230, 230, flag);
                    }


                    break;
                case "info":

                    if (tem_size.Width > 160 || tem_size.Height > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (tem_size.Width > 250 || tem_size.Height > 250)
                    {
                        dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                    }
                    if (tem_size.Width > 310 || tem_size.Height > 310)
                    {
                        dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                    }
                    if (tem_size.Width > 350 || tem_size.Height > 350)
                    {
                        dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 350, 350, flag);
                    }
                    if (tem_size.Width > 600 || tem_size.Height > 600)
                    {
                        dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 600, 600, flag);
                    }
                    break;
                case "productmain":
                    if (tem_size.Width > 60 || tem_size.Height > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }

                    if (tem_size.Width > 100 || tem_size.Height > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    if (tem_size.Width > 160 || tem_size.Height > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (tem_size.Width > 250 || tem_size.Height > 250)
                    {
                        dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                    }
                    if (tem_size.Width > 310 || tem_size.Height > 310)
                    {
                        dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                    }
                    if (tem_size.Width > 350 || tem_size.Height > 350)
                    {
                        dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 350, 350, flag);
                    }
                    if (tem_size.Width > 600 || tem_size.Height > 600)
                    {
                        dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 600, 600, flag);
                    }
                    break;
                case "user":
                    if (tem_size.Width > 60 || tem_size.Height > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }

                    if (tem_size.Width > 100 || tem_size.Height > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    break;

            }
            iSource.Dispose();

            #endregion

            //数据记录
            UploadItem uploadItem = new UploadItem();
            UploadItemId = db.GetTableIdentityID("UP", "UploadItem", 20);
            uploadItem.UploadItemId = UploadItemId;
            uploadItem.TargetTalbeKeyID = targetTalbeKeyID;
            uploadItem.RankOrder = 0;   // 0: 表示 不排序
            uploadItem.RawName = file.FileName;
            uploadItem.ShopID = ShopID;
            uploadItem.SubPath = SubPath;
            uploadItem.Url = urlPath + "/" + filePathName;
            uploadItem.FileExt = ex;
            uploadItem.OperatedUserName = User.Identity.Name;
            uploadItem.OperatedDate = DateTime.Now;

            db.UploadItems.Add(uploadItem);
            db.SaveChanges();
             
            string ReturnReult = urlPath + "/" + filePathName;

            if (oSubPath.ToLower() == "info")
            {
                return Content(ReturnReult);
            }

            if (oSubPath.ToLower() == "productmain" || oSubPath.ToLower() == "user")
            {
                return Json(new
                {
                    UploadItemId = UploadItemId.Trim(),
                    filePathName = ReturnReult
                });
            }
            return Content(ReturnReult); 
        }

         
        /// <summary>
        /// 上存模块
        /// </summary>
        /// <param name="id">随机ID,用于识别每次上存</param>
        /// <param name="name">源文件名</param>
        /// <param name="type">类型</param>
        /// <param name="AcceptType">接受的文件类型 格式: ".jpg,.txt,.html"</param>
        /// <param name="lastModifiedDate">最后更新</param>
        /// <param name="size">文件尺寸</param>
        /// <param name="Prefix">文件名前缀AAA,如 AAA12356.jpg</param>
        /// <param name="SubPath">真实的子路径  注意: 扩展功能,虚拟文件夹 通过TreeView 实现,实际磁盘是没有这个文件夹的</param>
        /// <param name="TargetTalbeKeyID"> 目标表的主键ID, 例如:ProdcutID  , CategoryID </param>
        /// <param name="ShopID">必需的,用于提取访问集</param>
        /// <param name="file"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult UpLoadProcessFile(string id, string name, string type,string AcceptType, string lastModifiedDate, int size, string Prefix, string SubPath, string TargetTalbeKeyID, string ShopID, HttpPostedFileBase file)
        {
            //可接受的文件类型  	image/jpeg,image/gif,image/png,video/mpeg,application/vnd.ms-excel,application/vnd.ms-powerpoint,application/msword,application/pdf,application/zip,text/html'
            //if ( AcceptType.IndexOf(type)==-1 )
            //{
            //    return Json(new { jsonrpc = 2.0, error = new { code = -1, message = "不接受的文件类型,请重新选择" }, id = "id", filePath = "no file input，Not Accept the file Type" });
            //}
            switch (file.ContentType.ToLower())
            {
                case "image/jpeg":
                    break;
                case "image/gif":
                    break;
                case "image/png":
                    break;
                case "image/bmp":
                    break;
                case "video/mp4":
                    break;
                case "video/mpeg":
                    break;
                case "application/ocelet-stream": //rar  
                    break;
                case "application/zip": //zip
                    break;
                case "application/msword":
                    break;
                case "application/vnd.ms-excel":
                    break;
                case "application/mspowerpoint":
                    break; 
                case "text/plain":
                    break;
                case "text/html":
                    break; 
                case "application/pdf":
                    break; 
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":  //pptx
                    break;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":  //docx   
                    break;
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":  //xlsx
                    break;
                default:
                    return Json(new { jsonrpc = 2.0, error = new { code = -1, message = "不接受的文件类型,请重新选择" }, id = "id", filePath = "no file input，Not Accept the file Type" });
            }
            string oSubPath = SubPath.ToLower();
            string targetTalbeKeyID = string.Empty;
            int rankOrder = 0;
            if (!string.IsNullOrEmpty(TargetTalbeKeyID))
            {
                targetTalbeKeyID = TargetTalbeKeyID;
            }
            
            string filePathName = string.Empty;
            //文件名称前缀  
            if (Prefix.Length > 1)
            {
                filePathName = Prefix + filePathName;
            }
            string localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
            //指定 至文件夹
            if (SubPath.Length > 1)
            {
                localPath = System.IO.Path.Combine(localPath, SubPath);
                urlPath += "/" + SubPath;
            }
            
            if (Request.Files.Count == 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id", filePath = "no file input" });
            }

            string ex = System.IO.Path.GetExtension(file.FileName);
            
            if(Prefix == "SeoExt" && ex.ToLower()!=".jpg" && ex.ToLower() != ".gif" && ex.ToLower() != ".png" && ex.ToLower() != ".bmp")
            {
                filePathName += "_" + file.FileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ex;
            }
            else
            {
                filePathName +=  DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ex;
            }
            

            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            file.SaveAs(System.IO.Path.Combine(localPath, filePathName));
            
            //数据记录
            UploadItem uploadItem = new UploadItem();

            uploadItem.UploadItemId = db.GetTableIdentityID("UP", "UploadItem", 20);
            uploadItem.TargetTalbeKeyID = TargetTalbeKeyID;
            uploadItem.RankOrder = rankOrder;
            uploadItem.RawName = name;
            uploadItem.ShopID = ShopID;
            uploadItem.SubPath = SubPath;
            uploadItem.Url = urlPath + "/" + filePathName;
            uploadItem.FileExt = ex;
            uploadItem.OperatedUserName = User.Identity.Name;
            uploadItem.OperatedDate = DateTime.Now;

            db.UploadItems.Add(uploadItem);
            db.SaveChanges();

             
            return Json(new
            {
                jsonrpc = "2.0",
                id = id,
                filePath = urlPath + "/" + filePathName,
                UploadItemId = uploadItem.UploadItemId
            }); 
        }
         
        public ActionResult Image(string Ticks)
        { 
            string ImageCode = CreateCheckCodeImage.GenerateCheckCode();
             
            Session["ImageCode"] = ImageCode;
            MemoryStream ms = CreateCheckCodeImage.Production(ImageCode);
            byte[] buffurPic = ms.ToArray();
            return File(buffurPic, "image/jpeg");
        }

        /// <summary>
        /// Update  UserProfile  NickName / UserIcon
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UpdString"></param>
        /// <param name="Mode"> 1=UserIcon ,2 = NickName</param>
        /// <returns></returns>
        public UserProfile UpdateUserProfileNickNameOrUserIcon(string UserId, string UpdString, string Mode)
        {
            UserProfile userProfile = db.UserProfiles.Where(c => c.UserId == UserId).FirstOrDefault();
            switch (Mode)
            {
                case "UserIcon":
                    userProfile.UserIcon = UpdString;
                    break;
                case "NickName":
                    userProfile.NickName = UpdString;
                    break;
            }
            DbEntityEntry<UserProfile> userProfileEntry = db.Entry<UserProfile>(userProfile);
            db.UserProfiles.Attach(userProfile);
            userProfileEntry.Property(e => e.UserIcon).IsModified = true;
            userProfileEntry.Property(e => e.NickName).IsModified = true;
            db.SaveChanges();
            return userProfile;
        }
    }
}
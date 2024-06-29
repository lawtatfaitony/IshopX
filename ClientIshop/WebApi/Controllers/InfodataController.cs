using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.ModelView;
using WebApi.Controllers;
using WebApi.AppCode.PublicData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using WebApi.Utilities;
using Sakura.AspNetCore;
using Newtonsoft.Json.Linq; 
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    public class InfoDataController : ControllerBase
    {
       
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly TokenManagement TokenManagement;
        
        public InfoDataController(IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment, IOptions<TokenManagement> tokenManagement)
        {

            this.TokenManagement = tokenManagement.Value;
            this.httpContextAccessor = httpContextAccessor;
            this.hostingEnvironment = hostingEnvironment; 
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
         
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
        
        public InfoDetail InfoDetails(string id)
        {
            //getInfoID
            UserTrace userTrace = db.UserTrace.Find(id);
             
            string InfoID = userTrace.TableKeyId;

            InfoDetail infoDetail = db.InfoDetail.Find(InfoID);
            if (infoDetail == null)
            {
                return null;
            }
            infoDetail.OperatedUserName = string.Empty; 
            return infoDetail;
        }
        
        [HttpGet]
        [Route("[Controller]/[action]/{ShopId}")]
        public Shop ShopDetails(string ShopId)
        {
            Shop shop = db.Shop.Find(ShopId);
            shop.CerPath = string.Empty;
            shop.ShopLogo = $"{TokenManagement.CloudHost}{shop.ShopLogo}";
            shop.FooterTemplate = string.Empty;  // hide this system operator info  
            return shop;
        }
        
        [HttpGet]
        [Route("[controller]/[action]/{ShopStaffId}")]
        public ShopStaff ShopStaffDetails(string ShopStaffId)
        {
            ShopStaff shopStaff = new ShopStaff();
            shopStaff = db.ShopStaff.Find(ShopStaffId); //

            shopStaff.Qrcode = InfoDataCatche.TransCloudHostUrlImg(TokenManagement.CloudHost, shopStaff.Qrcode);
            shopStaff.OtherQrcode = InfoDataCatche.TransCloudHostUrlImg(TokenManagement.CloudHost, shopStaff.OtherQrcode);
            
            return shopStaff; 

            //if (!string.IsNullOrEmpty(ShopStaffId))
            //{
            //    shopStaff = db.ShopStaff.Find(ShopStaffId);
            //    if (shopStaff == null)
            //    {
            //        return shopStaff = null;
            //    }else
            //    {
            //        shopStaff.ChannelId = db.Channel.Find(shopStaff.ChannelId).ChannelName;
            //        return shopStaff;
            //    }
            //}
            //else
            //{
            //    shopStaff.OperatedUserName = string.Empty;   // hide this system operator info
            //    return shopStaff = null;
            //}
             
        }
       
        [HttpGet]
        [Route("[controller]/[action]/{UserTraceId}")]
        public IEnumerable<InfoDetail> InfoDetailRalateList(string UserTraceId)
        {
            UserTraceInfoIDset userTraceInfoIDset = InfoDataCatche.SaveJsonRtnUserTraceInfoIDset(this.hostingEnvironment, UserTraceId); 
            return InfoDataCatche.SaveJsonReturnInfoRalateList(this.hostingEnvironment, userTraceInfoIDset,DateTime.Now.AddDays(-1),8); 
        }
        //get relate Id set
         
        [HttpGet]
        [Route("[controller]/[action]/{UserTraceId}")]
        public InfoIDs GetInfoIds(string UserTraceId)
        {
            InfoIDs infoIDs = new InfoIDs();
            UserTraceInfoIDset userTraceInfoIDset = InfoDataCatche.SaveJsonRtnUserTraceInfoIDset(this.hostingEnvironment, UserTraceId);
            infoIDs.UserTraceId = userTraceInfoIDset.UserTraceId; 
            infoIDs.UserId = userTraceInfoIDset.UserId;
            infoIDs.InfoId  = userTraceInfoIDset.InfoId; 
            infoIDs.ShopId = userTraceInfoIDset.ShopId;

            InfoDetail infoDetail = db.InfoDetail.Find(infoIDs.InfoId);
            infoIDs.ShopStaffId = infoDetail.ShopStaffId;
            infoIDs.InfoCateId = infoDetail.InfoCateId;

            //infodetails
            infoIDs.Title = infoDetail.Title;
            infoIDs.InfoItemTemplateIDs = infoDetail.InfoItemTemplateIds;
            infoIDs.TitleThumbNail = infoDetail.TitleThumbNail;
            infoIDs.ShowTitleThumbNail = infoDetail.ShowTitleThumbNail;
            infoIDs.SubTitle = infoDetail.SubTitle;
            infoIDs.SeoKeyword = infoDetail.SeoKeyword;
            infoIDs.SeoDescription = infoDetail.SeoDescription;
            infoIDs.InfoDescription = infoDetail.InfoDescription;
            infoIDs.VideoUrl = infoDetail.VideoUrl;
            infoIDs.Author = infoDetail.Author;
            infoIDs.IsOriginal = infoDetail.IsOriginal;
            infoIDs.Views = infoDetail.Views;
            infoIDs.OperatedUserName = infoDetail.OperatedUserName;
            infoIDs.CreatedDate = infoDetail.CreatedDate;
            infoIDs.OperatedDate = infoDetail.OperatedDate;

            // ip counter
            IPcounterController pcounterController = new IPcounterController(this.httpContextAccessor);
            infoIDs.SourceStatisticsId = pcounterController.IPstatiticsAdd(infoIDs.UserId, infoIDs.ShopId, infoIDs.InfoId, infoDetail.Title);
            infoIDs.IpStatitics_StartDate_Token = IpStatitics_Token();

            //view counter
            infoDetail.Views += 1;
            EntityEntry<InfoDetail> InfoEntry = db.Entry<InfoDetail>(infoDetail);
            db.InfoDetail.Attach(infoDetail);
            InfoEntry.Property(e => e.Views).IsModified = true;  
            db.SaveChanges();

            string cloudHost = TokenManagement.CloudHost;
            if (!infoIDs.TitleThumbNail.Contains(cloudHost))
            {
                infoIDs.TitleThumbNail = $"{cloudHost}{PictureSuffix.ReturnSizePicUrl(infoIDs.TitleThumbNail, PictureSize.s250X250)}";
            }

            return infoIDs;
        }

        /// <summary>
        /// get relate Infolist set
        /// </summary>
        /// <param name="ShpId"></param>
        /// <param name="RecommUserId">RecommUserId = UserTrace.UserId if null param then default RecommUserId = Shop.UserId</param>
        /// <param name="pageX"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>   
        [HttpGet]
        [Route("[controller]/[action]/{ShpId}/{RecommUserId}/{pageX}/{pageSize}")]
        public IActionResult GetInfolist(string ShpId,string RecommUserId, int pageX, int pageSize)
        {
            bool isconnected = db.Database.CanConnect();
            string connStr = db.Database.GetDbConnection().ConnectionString;
            if (isconnected)
            {
                Console.WriteLine("database connect successfully{0}\n{1}", isconnected, connStr);
            }
            else
            {
                Console.WriteLine("database connect fail{0} \n{1}", isconnected, connStr);
            }
             
            //-------------------------------------------------------------
            string UserId = RecommUserId;
            string FileName = string.Format("{0}u{1}p{2}s{3}.json", ShpId, UserId, pageX, pageSize);
            string oPath = string.Format("{0}\\{1}", hostingEnvironment.WebRootPath, "jsonData");
            string targetPathFile = Path.Combine(oPath + "\\" + FileName);
            targetPathFile  = string.Format("{0}\\{1}", oPath, FileName);

            DateTime lastUpdate = db.InfoDetail.OrderByDescending(c => c.OperatedDate).Select(s => s.OperatedDate).First();
            DateTime lastAccessDate = System.IO.File.GetLastWriteTime(targetPathFile);

            if (System.IO.File.Exists(targetPathFile))
            {
                //update the json file
                if (lastUpdate > lastAccessDate)
                {
                    mvcCommeBase.OperateLoger(string.Format("Api>InfoData>GetInfolistCache> {0}=> JSON {1}::{2}::{3}::{4}::{5}::sFile> ", FileName, DateTime.Now, ShpId, UserId, pageX, pageSize, targetPathFile));
                    return Ok(InfoDataCatche.GetInfolistCache(TokenManagement.CloudHost, oPath, FileName, ShpId, UserId, pageX, pageSize));
                }
                else
                {
                    //return json
                    return Ok(getGetInfolistFromJson(targetPathFile));
                } 
            }
            else // Create the json file and return list
            {
                IEnumerable<InfoDetail> infolist  ;
                infolist = InfoDataCatche.GetInfolistCache(TokenManagement.CloudHost, oPath,  FileName, ShpId, UserId, pageX, pageSize);
                return Ok(infolist);
            }
        }
        private IEnumerable<InfoDetail> getGetInfolistFromJson(string sFile)
        {
            string JsonFileText = string.Empty;
            using (FileStream fs = new FileStream(sFile, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("UTF-8")))
                {
                    JsonFileText = sr.ReadToEnd().ToString();
                    IEnumerable<InfoDetail> m = JsonConvert.DeserializeObject<InfoDetail[]>(JsonFileText);
                    mvcCommeBase.OperateLoger("Api>InfoData>GetInfoIds> JsonData=> JSON MODE::getGetInfolistFromJson::> " + DateTime.Now.ToString());
                    fs.Flush();
                    fs.Close();
                    return m;
                }
            }
        }
         
        [HttpGet]
        [Route("[controller]/[action]/{ShpId}/{RecommUserId}/{InfoItemTemplateIds}")]
        public InfoDetail getInfoPaneAdSet(string ShpId, string RecommUserId,string InfoItemTemplateIds)
        {
            InfoDetail infodetail =db.InfoDetail.Where(c => c.ShopId == ShpId && c.InfoItemTemplateIds.Contains(InfoItemTemplateIds)).FirstOrDefault();

            infodetail.UserTraceId = InfoPublic.CreateUserTrace(infodetail.InfoId, RecommUserId, ShpId);


            string cloudHost = TokenManagement.CloudHost;
            if (!infodetail.TitleThumbNail.Contains(cloudHost))
            {
                infodetail.TitleThumbNail = $"{cloudHost}{infodetail.TitleThumbNail}";
            }
            Console.WriteLine(infodetail.TitleThumbNail); 
            infodetail.InfoDescription = string.Empty;
             
            return infodetail;
        }
         
        private string IpStatitics_Token()
        {
            //Record Count  and  Token Verification
            string IpStatitics_StartDate = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string IpStatitics_StartDate_Token = "";

            //test 
            this.httpContextAccessor.HttpContext.Response.Headers.Add("IpStatitics_StartDateX", IpStatitics_StartDate);
            this.httpContextAccessor.HttpContext.Response.Cookies.Append("IpStatitics_StartDateX", IpStatitics_StartDate);

            if (this.httpContextAccessor.HttpContext.Request.Cookies["IpStatitics_StartDate"] == null)
            {
                this.httpContextAccessor.HttpContext.Response.Cookies.Append("IpStatitics_StartDate", IpStatitics_StartDate);
                this.httpContextAccessor.HttpContext.Response.Headers.Add("IpStatitics_StartDate", IpStatitics_StartDate);
                IpStatitics_StartDate_Token = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);
            }
            else
            {
                IpStatitics_StartDate = this.httpContextAccessor.HttpContext.Request.Cookies["IpStatitics_StartDate"];
                IpStatitics_StartDate_Token = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);
            }
            return IpStatitics_StartDate_Token;

        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}

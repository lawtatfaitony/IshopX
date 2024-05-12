using Ishop.AppCode.Utilities;
using Ishop.Context;
using Ishop.DAL;
using Ishop.Models.Info;
using Ishop.Models.ProductMgr;
using Ishop.Models.PubDataModal;
using Ishop.Models.User;
using Ishop.Utilities;
using LanguageResource;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ishop.Areas.Mgr.Models;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Web.UI.WebControls; 
namespace Ishop.Controllers
{
    public class BaseController : Controller  
    {
        public BaseController()
        {
            //InitializeLanguageCode(); // Request = null
        }
         
        private string _Language;
        public string Language
        {
            get
            {
                return LangUtilities.StandardLanguageCode(_Language);
            }
            set
            {
                _Language = value;
            }
        }
        public string BaseUrl = ConfigurationManager.AppSettings["WebSiteUrl"];
        
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        
        /// <summary>
        /// Place in the first line  ( Add to the ActionResult Method to  Initialize) 
        /// </summary>
        public void ShopInitialize()
        {
            if (string.IsNullOrEmpty(WebCookie.Language))
            {
                WebCookie.Language = LangUtilities.LanguageCode;
            }
              
            ViewBag.Language = Language;
            ViewBag.LanguageCode = Language;

            Shop shop = db.Shops.Find(WebCookie.ShpID);
            ViewBag.Client_Shop = shop;
            ViewBag.ClientShop = shop;
            ViewBag.ShpID = WebCookie.ShpID;

            ViewBag.Description = shop.ShopName;
            ViewBag.ShopLogo = shop.ShopLogo;
            ViewBag.PhoneNumber = shop.PhoneNumber;
            ViewBag.ShopName = shop.ShopName;
            ViewBag.ShopCurrency = shop.ShopCurrency;
            ViewBag.ShopID = shop.ShopID;
            ViewBag.ShopUserId = shop.UserId;
            ViewBag.ShopHostName = shop.HostName;
            ViewBag.IsInfoMode = shop.IsInfoMode;
           
            //路由格式 zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN
            // 獲取當前的 URL
            Uri currentUri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathAndQuery = currentUri.PathAndQuery;
             
            string[] keywords = { "zh-HK", "zh-CN", "en-US", "hk", "cn", "en", "HK", "CN", "EN" };

            bool containsKeyword = false;
            foreach (string keyword in keywords)
            {
                if (pathAndQuery.Contains(keyword))
                {
                    containsKeyword = true;
                    break;
                }
            }

            if (containsKeyword)
            {
                string[] patharr = pathAndQuery.Split(new char[] { '/' });
                string pathAndQueryNew = pathAndQuery.TrimStart(new char[] { '/' });
                pathAndQueryNew = pathAndQueryNew.TrimStart(patharr[1].ToArray());
                 
                ViewBag.ZhCnUriPath = $"/zh-CN{pathAndQueryNew}";
                ViewBag.ZhHkUriPath = $"/zh-HK{pathAndQueryNew}";
                ViewBag.EnUsUriPath = $"/en-US{pathAndQueryNew}";
            }
            else
            {
                string defaultHomeUrl = "/Home/index";
                ViewBag.ZhCnUriPath = $"/zh-CN{defaultHomeUrl}";
                ViewBag.ZhHkUriPath = $"/zh-HK{defaultHomeUrl}";
                ViewBag.EnUsUriPath = $"/en-US{defaultHomeUrl}";
            }

            if (_Language == "zh-HK")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hant");
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-Hant");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_Language);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_Language);
            } 
        }
        /// <summary>
        /// 後台初始化
        /// </summary>
        public void BackEndShopInitialize()
        {
            if (string.IsNullOrEmpty(WebCookie.Language))
            {
                WebCookie.Language = LangUtilities.LanguageCode;
            }
             
            ViewBag.Language = Language;
            ViewBag.LanguageCode = Language;

            Shop shop = db.Shops.Find(WebCookie.ShopID);

            ViewBag.Client_Shop = shop;
            ViewBag.ClientShop = shop;

            ViewBag.ShpID = WebCookie.ShpID;

            ViewBag.Description = shop.ShopName;
            ViewBag.ShopLogo = shop.ShopLogo;
            ViewBag.PhoneNumber = shop.PhoneNumber;
            ViewBag.ShopName = shop.ShopName;
            ViewBag.ShopCurrency = shop.ShopCurrency;
            ViewBag.ShopID = shop.ShopID;
            ViewBag.ShopUserId = shop.UserId;
            ViewBag.ShopHostName = shop.HostName;
            ViewBag.IsInfoMode = shop.IsInfoMode;

            //路由格式 zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN
            // 獲取當前的 URL
            Uri currentUri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathAndQuery = currentUri.PathAndQuery;

            string[] keywords = { "zh-HK", "zh-CN", "en-US", "hk", "cn", "en", "HK", "CN", "EN" };

            bool containsKeyword = false;
            foreach (string keyword in keywords)
            {
                if (pathAndQuery.Contains(keyword))
                {
                    containsKeyword = true;
                    break;
                }
            }

            if (containsKeyword)
            {
                string[] patharr = pathAndQuery.Split(new char[] { '/' });
                string pathAndQueryNew = pathAndQuery.TrimStart(new char[] { '/' });
                pathAndQueryNew = pathAndQueryNew.TrimStart(patharr[1].ToArray());

                ViewBag.ZhCnUriPath = $"/zh-CN{pathAndQueryNew}";
                ViewBag.ZhHkUriPath = $"/zh-HK{pathAndQueryNew}";
                ViewBag.EnUsUriPath = $"/en-US{pathAndQueryNew}";
            }
            else
            {
                string defaultHomeUrl = "/Home/index";
                ViewBag.ZhCnUriPath = $"/zh-CN{defaultHomeUrl}";
                ViewBag.ZhHkUriPath = $"/zh-HK{defaultHomeUrl}";
                ViewBag.EnUsUriPath = $"/en-US{defaultHomeUrl}";
            }

            if (_Language == "zh-HK")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hant");
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-Hant");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_Language);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_Language);
            }

            //後台LayOutd的 右上的 [Notification]
            if (Request.IsAuthenticated)
            { 
                string userId = User.Identity.GetUserId();
                var sourceStatistics = from s in db.SourceStatistics.Where(s => s.RecommUserId == userId)
                                       select s;
                sourceStatistics = sourceStatistics.OrderByDescending(s => s.LastUpdateDate).Take(100);
                ViewBag.UserViewsCount = sourceStatistics.Count();
            }
            else
            {
                ViewBag.UserViewsCount = 0; //設置默認值避免出錯
            }
        }
        public string DoPost(string url, string data)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            byte[] postData = Encoding.UTF8.GetBytes(data);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length); reqStream.Close();
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }
        public HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            req.ContentType = "text/json";
            req.Method = method;
            req.KeepAlive = true;
            req.Timeout = 1000000;
            req.Proxy = null;
            return req;
        }
        public string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            StringBuilder result = new StringBuilder();
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                // 每次读取不大于256个字符，并写入字符串
                char[] buffer = new char[256];
                int readBytes = 0;
                while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(buffer, 0, readBytes);
                }
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }

            return result.ToString();
        }

        /// <summary>
        /// read the txt file
        /// </summary>
        /// <param name="Path">file path</param>
        public string ReadTxtContent(string Path)
        {
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            string line;
            string content = "";
            while ((line = sr.ReadLine()) != null)
            {
                // Console.WriteLine(line.ToString());
                content += sr.ReadLine();
            }

            return content;
        }

        /// <summary>
        /// Record Count  and  Token Verification
        /// </summary>
        public void IpStatitics_Token()
        {
            //Record Count  and  Token Verification
            string IpStatitics_StartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
            if (Request.Cookies["IpStatitics_StartDate"] == null)
            {
                Response.Cookies["IpStatitics_StartDate"].Value = IpStatitics_StartDate;
                ViewBag.IpStatitics_StartDate_Token = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);
            }
            else
            {
                ViewBag.IpStatitics_StartDate_Token = mvcCommeBase.SHA1_Hash(Request.Cookies["IpStatitics_StartDate"].Value);
            }
        }
        public string IPstatiticsAdd(string TableKeyID, string Title,string RecommUserId,string ShopID)
        { 
            this.IpStatitics_Token(); 
            string UserId = "";
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = User.Identity.GetUserId();
            }
            else
            {
                ViewBag.UserId = "NickName";  //Nick Visit
            }
            UserId = ViewBag.UserId;
            int Duration = 0;
            string SourceArea = string.Empty;
            string IP = mvcCommeBase.GetIP(); //Record IP
            ViewBag.SourceIP = IP;
            string OSVersion = Request.Browser.Browser; // Server： Environment.OSVersion.VersionString;
            string SourceUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
             
            DateTime CreatedDate = DateTime.Now;
            DateTime LastUpdateDate = CreatedDate;

            SourceStatistic sourceStatistic = new SourceStatistic { TableKeyID = TableKeyID, Title = Title, OSVersion = OSVersion, UserId = UserId, RecommUserId = RecommUserId, IP = IP, SourceArea = SourceArea, SourceUrl = SourceUrl, Duration = Duration, CreatedDate = CreatedDate, LastUpdateDate = LastUpdateDate, ShopID = ShopID, Status = SourceStatisticStatus.InValid };
            //query current article the same day record exist or not 
            var SourceStatistics = db.SourceStatistics.Where(c => c.TableKeyID == TableKeyID && c.IP == IP && c.CreatedDate.Day == DateTime.Now.Day && c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year).ToList();
            if (SourceStatistics.Count() == 0)
            {
                try
                {
                    db.SourceStatistics.Add(sourceStatistic);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    string operateLog = string.Format("IPstatiticsAdd >case :AddNew TableKeyID ={0}, Title = {1}, OSVersion = {2}, UserId = {3}, RecommUserId = {4}, IP = {5}, SourceArea = {6}, SourceUrl = {7}, Duration = {8}, CreatedDate = {9}, LastUpdateDate = {10}, ShopID = {11}, Status = {12} ,Message = {13}", sourceStatistic.TableKeyID, sourceStatistic.Title, sourceStatistic.OSVersion, sourceStatistic.UserId, sourceStatistic.RecommUserId, sourceStatistic.IP, sourceStatistic.SourceArea, sourceStatistic.SourceUrl, sourceStatistic.Duration, sourceStatistic.CreatedDate, sourceStatistic.LastUpdateDate, sourceStatistic.ShopID, SourceStatisticStatus.InValid,e.Message);
                    mvcCommeBase.OperateLoger(operateLog);
                }
               
                //UserFinanceItem
                if (!string.IsNullOrEmpty(RecommUserId))
                {
                    CreateUserFinanceItem(sourceStatistic.SourceStatisticsID.ToString(),0.5m, RecommUserId, ShopID);  //0.5m  : explicit type decimal
                }
                return sourceStatistic.SourceStatisticsID.ToString();
            }
            else
            { 
                try
                {
                    SourceStatistic SourceStatistic2 = SourceStatistics.FirstOrDefault();
                    SourceStatistic2.LastUpdateDate = DateTime.Now;
                    SourceStatistic2.Duration += 1;
                    DbEntityEntry<SourceStatistic> SourceStatisticEntry = db.Entry<SourceStatistic>(SourceStatistic2);
                    db.SourceStatistics.Attach(SourceStatistic2);
                    SourceStatisticEntry.Property(e => e.Duration).IsModified = true;
                    SourceStatisticEntry.Property(e => e.LastUpdateDate).IsModified = true;
                    db.SaveChanges();

                    string operateLog = string.Format("IPstatiticsAdd >case UPDATE [SourceStatistic] SUCCESS :LastUpdateDate ={0} ,SourceStatisticsID ={1};Title ={2}", DateTime.Now, SourceStatistic2.SourceStatisticsID, SourceStatistic2.Title);
                    mvcCommeBase.OperateLoger(operateLog);
                     
                    return SourceStatistic2.SourceStatisticsID.ToString();
                }
                catch(Exception e)
                {
                    string operateLog = string.Format("IPstatiticsAdd >case UPDATE FAIL:LastUpdateDate ={0} ,Message ={1}", DateTime.Now , e.Message);
                    mvcCommeBase.OperateLoger(operateLog);
                    return "0";
                }   
            }
        }
        /// <summary>
        /// update SourceStatistic: openid , UserId , VisitorIcon
        /// </summary>
        /// <param name="openid"></param>
        /// <param name=""></param>
        public void UpdIPstatitics(int SourceStatisticsID, string UserId, string NickName, string openid, string VisitorIcon, SourceStatisticStatus status)
        {
            string IP = mvcCommeBase.GetIP();
            SourceStatistic sourceStatistic = db.SourceStatistics.Find(SourceStatisticsID);
              
            if (sourceStatistic != null)
            {
                sourceStatistic.UserId = string.IsNullOrEmpty(UserId)? "NickName" : UserId;
                sourceStatistic.OpenID = string.IsNullOrEmpty(openid) ? "" : openid;
                sourceStatistic.VisitorIcon = string.IsNullOrEmpty(VisitorIcon) ? "" : VisitorIcon;
                sourceStatistic.WxNickName = string.IsNullOrEmpty(NickName) ? "" : NickName; 
                sourceStatistic.Status = status;
                     
                try
                {
                    db.SourceStatistics.Attach(sourceStatistic);
                    db.Entry(sourceStatistic).State = EntityState.Modified;
                    db.SaveChanges();

                    string operateLog = string.Format("UpdIPstatitics >case:: WEIXIN UPDATE SUCCESS VisitorIcon ={0}", VisitorIcon);
                    mvcCommeBase.OperateLoger(operateLog);
                }
                catch (Exception e)
                {
                    string operateLog = string.Format("UpdIPstatitics >case:: WEIXIN UPDATE FAIL:SourceStatisticsID ={0},Title ={1}, LastUpdateDate ={2} , Message ={3}", SourceStatisticsID, sourceStatistic.Title, DateTime.Now, e.Message);
                    mvcCommeBase.OperateLoger(operateLog); 
                }

            }
            else
            {
                string beginLog = string.Format("UpdIPstatitics >case::NOT EXIST RECORD:SourceStatisticsID ={0}, UserId ={1} ,NickName ={2},openid ={3},VisitorIcon ={4}", SourceStatisticsID, UserId, NickName, openid, VisitorIcon);
                mvcCommeBase.OperateLoger(beginLog);
            }
        }

        public UserTrace GetUserTrace(string infoId,string userId)
        {
            InfoDetail infoDetail = db.InfoDetails.Find(infoId); 
            UserTrace userTrace = db.UserTraces.Where(c => c.TableKeyID.Contains(infoId) && c.UserId.Contains(userId)).FirstOrDefault();
            if (userTrace == null)
            {
                string UserTraceId = infoDetail.ShopID + userId + infoDetail.InfoID;
                userTrace = new UserTrace
                {
                    UserTraceID = UserTraceId,
                    TableKeyID = infoDetail.InfoID,
                    ShopID = infoDetail.ShopID,
                    UserId = User.Identity.GetUserId(),
                    OperatedUserName = "SYSTEM",
                    OperatedDate = DateTime.Now
                };
                db.UserTraces.Add(userTrace);
                db.SaveChanges();
                return userTrace;
            }
            else
            {
                return userTrace;
            }
                
        }
        /// <summary>
        /// IP Statement IPstatitics  
        /// </summary>
        /// <param name="SourceStatisticsID"></param>
        /// <param name="IntervalMinutes"></param>
        /// <param name="IpStatitics_StartDate_Token"></param>
        /// <returns></returns>
        public ActionResult IPstatitics(string SourceStatisticsID, string IntervalMinutes, string IpStatitics_StartDate_Token)
        {
            //Set the start time for calculating the duration
            string IpStatitics_StartDate = "";
            string IpStatitics_StartDate_Token_CK = "";
            if (Request.Cookies["IpStatitics_StartDate"] != null)
            {
                IpStatitics_StartDate = Request.Cookies["IpStatitics_StartDate"].Value;
                IpStatitics_StartDate_Token_CK = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);
            }
            else
            {
                //if No time Verified cookie,otherwise not to count 
                return Json("{ result= 0 }");
            }
            //Insert or update statistics after verifying incoming data
            if (IpStatitics_StartDate_Token == IpStatitics_StartDate_Token_CK)
            {
                try
                {
                    SourceStatistic sourceStatistic = db.SourceStatistics.Find(int.Parse(SourceStatisticsID));
                    sourceStatistic.Duration += int.Parse(IntervalMinutes);
                    sourceStatistic.LastUpdateDate = DateTime.Now;
                    db.Entry(sourceStatistic).State = EntityState.Modified;
                    int Result = db.SaveChanges();

                    if (Result > 0)
                    {
                        Dictionary<string, int> result = new Dictionary<string, int> { { "result", 1 } };
                        return Json(result);
                    }
                    else
                    {
                        Dictionary<string, int> result = new Dictionary<string, int> { { "result", 0 } };
                        return Json(result);
                    }
                }catch(Exception ex)
                {
                    Common.CommonBase.OperateDateLoger("[EXCEPTION][FUNC::BaseController.IPstatitics()]["+ex.Message+"]");
                }
            }
            return Json("{ result= 0 }");
        }
        //openi nickname city country province headimgurl
        public JsonResult UpdateWechatInfo(string SourceStatisticsID, string openid, string nickname, string country,string province, string city, string headimgurl,string Token)
        {
            //Set the start time for calculating the duration 
            string IpStatitics_StartDate_Token_CK = "";
            if (Request.Cookies["IpStatitics_StartDate"] != null)
            { 
                IpStatitics_StartDate_Token_CK = mvcCommeBase.SHA1_Hash(Request.Cookies["IpStatitics_StartDate"].Value);
            }
            if(Token != IpStatitics_StartDate_Token_CK)
            {
                Dictionary<string, string> result = new Dictionary<string, string> { { "result", "Invalid Token" } };
                return Json(result);
            }

            
            ModalDialogView modalDialogView = new ModalDialogView();
            modalDialogView.MsgCode = "1";
            modalDialogView.Message = "OK";

            SourceStatistic sourceStatistic = db.SourceStatistics.Find(int.Parse(SourceStatisticsID));
            sourceStatistic.VisitorIcon = headimgurl;
            sourceStatistic.OpenID = openid;
            sourceStatistic.VisitorIcon = "";
            sourceStatistic.WxNickName = string.Format("{0}-{1}", nickname, city);
            
            db.Entry(sourceStatistic).State = EntityState.Modified;
            int Result = db.SaveChanges();

            if (Result > 0)
            {
                //insert UserProfile
                UserProfile userProfile = new UserProfile();
                userProfile.NickName = nickname;
                userProfile.Country = country;
                userProfile.State = province;
                userProfile.UserIcon = sourceStatistic.VisitorIcon;
                userProfile.OpenID = openid; 
                //avoid error
                userProfile.Birthday = DateTime.Now;
                userProfile.CreatedDate = DateTime.Now;
                userProfile.OperatedDate = DateTime.Now;
                userProfile.IsBlock = false;
                userProfile.IsMonopoly = false;
                userProfile.QuantizationScore = 0;
                try
                {
                    db.UserProfiles.Add(userProfile);
                    db.SaveChanges();
                    Dictionary<string, string> result = new Dictionary<string, string> { { "result", "1" } };
                    return Json(result);
                }
                catch(Exception ex)
                {
                    Dictionary<string, string> result = new Dictionary<string, string> { { "result", ex.Message } };
                    return Json(result);
                }
            }
            else
            {
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", 0 } };
                return Json(result);
            }
        }
        /// <summary>
        /// Check OpenID
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckOpenID(string openid)
        {
            var OpenIDExistList = db.UserProfiles.Where(s => s.OpenID == openid);
            if( OpenIDExistList.Count()>0)
            {
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", 1 } };

                return Json(result,JsonRequestBehavior.AllowGet);
            }else
            {
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", 0 } };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// check openID exit in table UserProfile
        /// </summary>
        public void CheckAuthorizeOpenId(string code, string ShopID, int SourceStatisticsID)
        {
             
            UserProfile userProfile = new UserProfile();
            WxUserInfo getWxUserInfo = new WxUserInfo();
            getWxUserInfo = weixin.getWxUserInfo(code); 
            string openid = getWxUserInfo.openid;
            string UserIcon = getUserIcon(getWxUserInfo.headimgurl, openid);
            getWxUserInfo.headimgurl = UserIcon;

            string UserId = "";
            if (Request.IsAuthenticated)
            {
                UserId = User.Identity.GetUserId();
            }
            string WxLog = "";
            if (!string.IsNullOrEmpty(openid))
            {
                var OpenIDExistList = db.UserProfiles.Where(s => s.OpenID == openid);

                string openidWxLog = string.Format("CheckAuthorizeOpenId >case : openid = not empty openid = {0}; OpenIDExistList.Count()={1}", openid,OpenIDExistList.Count());
                mvcCommeBase.OperateLoger(openidWxLog); 
                //获取并ADDNEW  
                if (OpenIDExistList.Count() == 0)
                {
                   
                    //insert  
                    userProfile.UserId = UserId;
                    userProfile.NickName = HttpUtility.UrlDecode(getWxUserInfo.nickname);
                    userProfile.Country = HttpUtility.UrlDecode(getWxUserInfo.country);
                    userProfile.State = HttpUtility.UrlDecode(getWxUserInfo.province);
                    userProfile.City = HttpUtility.UrlDecode(getWxUserInfo.city);
                    userProfile.UserIcon = UserIcon;
                    userProfile.OpenID = openid;
                    userProfile.Gender = weixin.GenderCase(getWxUserInfo.sex);
                    ////avoid error
                    userProfile.Birthday = DateTime.Now;
                    userProfile.CreatedDate = DateTime.Now;
                    userProfile.OperatedDate = DateTime.Now;
                    userProfile.IsBlock = false;
                    userProfile.IsMonopoly = false;
                    userProfile.QuantizationScore = 0;

                    db.UserProfiles.Add(userProfile);
                    db.SaveChanges();

                    WxLog = string.Format("CheckAuthorizeOpenId >case :After AddNew:: OpenIDExistList = 0 : code ={0} ,UserId ={1},NickName ={2} , UserIcon ={3}, ShopID = {4} , openid = {5},TableKeyID ={6}", code, UserId, userProfile.NickName, userProfile.UserIcon, ShopID, openid, SourceStatisticsID);
                    mvcCommeBase.OperateLoger(WxLog);

                    UpdIPstatitics(SourceStatisticsID, UserId, getWxUserInfo.nickname, openid, getWxUserInfo.headimgurl, SourceStatisticStatus.IsValid);
                    
                }
                else
                {
                    userProfile = OpenIDExistList.FirstOrDefault();
                    UpdIPstatitics(SourceStatisticsID, UserId, userProfile.NickName, openid, userProfile.UserIcon, SourceStatisticStatus.IsValid);
                    WxLog = string.Format("CheckAuthorizeOpenId >case : OpenIDExist = true  : code ={0} ,UserId ={1},NickName ={2} , UserIcon ={3}, ShopID = {4} , openid = {5},TableKeyID ={6}", code, UserId, userProfile.NickName, userProfile.UserIcon, ShopID, openid, SourceStatisticsID);
                    mvcCommeBase.OperateLoger(WxLog);
                }
            }
            else
            {
                WxLog = string.Format("CheckAuthorizeOpenId >case :else : OpenID = Empty ");
                mvcCommeBase.OperateLoger(WxLog);
            }
        }
        public WxUserInfo RetriveWeixin(int SourceStatisticsID)
        {
            SourceStatistic sourceStatistic = db.SourceStatistics.Find(SourceStatisticsID);
            string OpenId = sourceStatistic.OpenID;
            string ShopID = sourceStatistic.ShopID;
            WxUserInfo wxUserInfo = new WxUserInfo() { openid = "", nickname = "", sex = "", province = "", city = "", country = "", headimgurl = "", privilege = "", unionid = "" };
            if (OpenId.Length > 10)
            { 
                wxUserInfo = weixin.getWxUserInfoByOpenId(OpenId); 
                sourceStatistic.VisitorIcon = wxUserInfo.headimgurl;
                sourceStatistic.WxNickName = wxUserInfo.nickname;
                if(!string.IsNullOrEmpty(wxUserInfo.headimgurl) || !string.IsNullOrEmpty(wxUserInfo.nickname))
                {
                    try
                    {
                        db.SourceStatistics.Attach(sourceStatistic);
                        db.Entry(sourceStatistic).State = EntityState.Modified;
                        int result = db.SaveChanges();
                        wxUserInfo.privilege = result.ToString();
                        return wxUserInfo;
                    }
                    catch (Exception e)
                    {
                        string operateLog = string.Format("RetriveWeixin >case::LINK:: WEIXIN UPDATE FAIL:SourceStatisticsID ={0},WxNickName ={1}, VisitorIcon ={2} , OpenId ={3}, Message ={4}", SourceStatisticsID, wxUserInfo.nickname, wxUserInfo.headimgurl, OpenId, e.Message);
                        mvcCommeBase.OperateLoger(operateLog);
                        return wxUserInfo;
                    }
                }
                else
                {  
                    return wxUserInfo;
                } 
            }
            else
            {
                return wxUserInfo;
            } 
        }
        /// <summary>
        /// save to local
        /// </summary>
        /// <param name="IconUrl">web http url</param>
        /// <param name="FileName">target filename etc：abcd</param>
        /// <returns></returns>
        public string getUserIcon(string IconUrl,string FileName)
        {
            if(string.IsNullOrEmpty(IconUrl))
            {
                return IconUrl;
            }
            //string Dstr = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string NewFileName = "User" + FileName + ".jpg";
            string IconUrlPath = "";
            IconUrlPath = "/upload/user/" + NewFileName;
            if(!System.IO.File.Exists(IconUrlPath))
            {
                string FilePath = SaveUrlImage(IconUrl, NewFileName, "User");
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string dThumbnailFile;
                int flag = 100;
                System.Drawing.Image iSource = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(FilePath));
                //ImageFormat tFormat = iSource.RawFormat;
                Size tem_size = new Size(iSource.Width, iSource.Height);

                dThumbnailFile = FilePath + PictureSize.s60X60.ToString() + ".jpg";
                string sFilePath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                string dFile = System.Web.HttpContext.Current.Server.MapPath(dThumbnailFile);
                bool thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFilePath, dFile, 60, 60, flag);
                thumbnail_ok = mvcCommeBase.GetPicThumbnail(sFilePath, dFile, 100, 100, flag); 
            }

            return IconUrlPath;
        }
        /// <summary>
        ///  Initialize Important Parameter : RecommUserId , TableKeyID , UserId , ShopStaffID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserTrace ReturnUserTrace(string ID)
        {
            UserTrace UserTrace1 = db.UserTraces.Find(ID);
            Shop shop = db.Shops.Find(WebCookie.ShpID);
            if (UserTrace1 == null)
            {
                Product product = db.Products.Find(ID);
                InfoDetail infoDetail = db.InfoDetails.Find(ID);
                if (product != null || infoDetail != null)
                {
                    string UserTraceID = db.GetTableIdentityID("Tr", "UserTrace", 6);
                    UserTrace1 = new UserTrace()
                    {
                        UserTraceID = UserTraceID
                        ,
                        TableKeyID = ID
                        ,
                        UserId = shop.UserId
                        ,
                        ShopID = WebCookie.ShpID
                        ,
                        OperatedUserName = User.Identity.Name
                        ,
                        OperatedDate = DateTime.Now
                    };
                    db.UserTraces.Add(UserTrace1);
                    db.SaveChanges();
                }
            }
            string TableKeyID = UserTrace1.TableKeyID;
            ViewBag.UserId = UserTrace1.UserId;
            ViewBag.TableKeyID = UserTrace1.TableKeyID;  //ex: ViewBag.ProductId
            ViewBag.ShopStaffID = UserTrace1.UserId;
            // Required !important 
            // Set the RecommUserId 
            if (WebCookie.RecommUserId == string.Empty)   // Only Accept the First Recommender 
            {
                WebCookie.RecommUserId = UserTrace1.UserId;
            }
            return UserTrace1;
        }

        [HttpGet]
        public ActionResult IpSourceAreaQuery(int SourceStatisticsID, string queryIP)
        {
            SourceStatistic SourceStatistics = db.SourceStatistics.Find(SourceStatisticsID);
            if (SourceStatistics.SourceArea.Length < 1)
            {
                string SourceArea = AliyunIP.IpQuery(queryIP);
                SourceStatistics.SourceArea = SourceArea;
                DbEntityEntry<SourceStatistic> SourceStatisticEntry = db.Entry<SourceStatistic>(SourceStatistics);
                db.SourceStatistics.Attach(SourceStatistics);
                SourceStatisticEntry.Property(e => e.SourceArea).IsModified = true;
                db.SaveChanges();
                return Content(SourceArea);
            }
            else
            {
                return Content(SourceStatistics.SourceArea);
            }
        }

        /// <summary>
        /// Anonymous permissions are accessible: Page load time loadTime milliseconds
        /// </summary>
        /// <param name="SourceStatisticsID"></param>
        /// <param name="loadTime"></param>
        /// <returns></returns> 
        [HttpGet]
        public ActionResult PageLoadingTimesCounter(int SourceStatisticsID, int loadTime, string OSVersion)
        {
            SourceStatistic SourceStatistics = db.SourceStatistics.Find(SourceStatisticsID);
            if (SourceStatistics.SourceArea != null)
            {
                DbEntityEntry<SourceStatistic> SourceStatisticEntry = db.Entry<SourceStatistic>(SourceStatistics);
                SourceStatistics.LoadTime = loadTime;
                SourceStatistics.OSVersion = OSVersion;
                db.SourceStatistics.Attach(SourceStatistics);
                SourceStatisticEntry.Property(e => e.LoadTime).IsModified = true;
                SourceStatisticEntry.Property(e => e.OSVersion).IsModified = true;
                db.SaveChanges();
                return Content(loadTime.ToString() + " | " + OSVersion);
            }
            else
            {
                return Content("No SourceStatisticsID Exist");
            }
        }
        /// <summary>
        /// 分享链接的的跳转 Create UserTrace if No record  by Table Key Id
        /// </summary>
        /// <param name="ID">Talbe Key Id</param>
        /// <param name="Action"></param>
        /// <param name="ControlName"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult UserTrace(string TableKeyID, string Act, string Ctrl)
        {  
            string UserId = User.Identity.GetUserId();
            var userTrace = db.UserTraces.Where(c => c.TableKeyID.Contains(TableKeyID) && c.UserId == UserId).FirstOrDefault();

            if (userTrace == null)
            {
                string UserTraceID = db.GetTableIdentityID("Tr", "UserTrace", 6);
                UserTrace userTrace1 = new UserTrace()
                {
                    UserTraceID = UserTraceID,
                    TableKeyID = TableKeyID,
                    UserId = UserId,
                    ShopID = WebCookie.ShopID,
                    OperatedUserName = User.Identity.Name,
                    OperatedDate = DateTime.Now
                };
                db.UserTraces.Add(userTrace1);
                db.SaveChanges();
                return RedirectToAction(Act, Ctrl, new { Id = UserTraceID });
            }
            else
            {
                UserTrace userTrace1 = db.UserTraces.Where(c => c.TableKeyID.Contains(TableKeyID) && c.UserId == UserId).FirstOrDefault();
                return RedirectToAction(Act, Ctrl, new { Id = userTrace1.UserTraceID });
            }
        }
        public string CreateUserTrace(string TableKeyID, string UserId,string ShopID)
        {
            
            var userTrace = db.UserTraces.Where(c => c.TableKeyID.Contains(TableKeyID) && c.UserId == UserId).ToList();

            if (userTrace.Count() == 0)
            {
                string UserTraceID = db.GetTableIdentityID("Tr", "UserTrace", 6);
                UserTrace userTrace1 = new UserTrace()
                {
                     UserTraceID = UserTraceID
                    ,TableKeyID = TableKeyID
                    ,UserId = UserId
                    ,ShopID = ShopID
                    ,OperatedUserName = "System"
                    ,OperatedDate = DateTime.Now
                };
                db.UserTraces.Add(userTrace1);
                db.SaveChanges();
                return userTrace1.UserTraceID;
            }
            else
            {
                UserTrace userTrace1 = db.UserTraces.Where(c => c.TableKeyID.Contains(TableKeyID) && c.UserId == UserId).FirstOrDefault();
                return userTrace1.UserTraceID;
            }
        }
        public string SaveUrlImage(string UrlImage, string NewFileName, string SubPath)
        {
            if (string.IsNullOrEmpty(UrlImage))
            {
                return UrlImage;
            }
            string MediaRootPath = "Upload";
            string LocalPath = string.Format("/{0}/{1}", MediaRootPath, SubPath);
            if (!System.IO.Directory.Exists(LocalPath))
            {
                System.IO.Directory.CreateDirectory(LocalPath);
            }
            string FilePath = string.Format("/{0}/{1}/{2}", MediaRootPath, SubPath, NewFileName);
            string oFilePath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
            System.Drawing.Image Image1 = System.Drawing.Image.FromStream(WebRequest.Create(UrlImage).GetResponse().GetResponseStream());
            Image1.Save(oFilePath, GetFormat(oFilePath));
            return FilePath;
        }
        //Get the corresponding storage type based on the file extension name
        public static ImageFormat GetFormat(string filePath)
        {
            ImageFormat format = ImageFormat.MemoryBmp;
            String Ext = System.IO.Path.GetExtension(filePath).ToLower();

            if (Ext.Equals(".png")) format = ImageFormat.Png;
            else if (Ext.Equals(".jpg") || Ext.Equals(".jpeg")) format = ImageFormat.Jpeg;
            else if (Ext.Equals(".bmp")) format = ImageFormat.Bmp;
            else if (Ext.Equals(".gif")) format = ImageFormat.Gif;
            else if (Ext.Equals(".ico")) format = ImageFormat.Icon;
            else if (Ext.Equals(".emf")) format = ImageFormat.Emf;
            else if (Ext.Equals(".exif")) format = ImageFormat.Exif;
            else if (Ext.Equals(".tiff")) format = ImageFormat.Tiff;
            else if (Ext.Equals(".wmf")) format = ImageFormat.Wmf;
            else if (Ext.Equals(".memorybmp")) format = ImageFormat.MemoryBmp;

            return format;
        }
        public string GetDefaultRecommUserId(string RecommUserId)
        {
            if (!string.IsNullOrEmpty(RecommUserId))
            {
                return RecommUserId;
            }
            string ShpID = WebCookie.ShpID;
            RecommUserId = db.Shops.Find(ShpID).UserId;
            return RecommUserId;
        } 
        public void CreateUserFinanceItem(string TblKeyId, decimal ItemAmount ,string RecommUserId ,string ShopID)
        {
            string OperateLog = "";
            string UserFinanceItemID = db.GetTableIdentityID("FI", "UserFinanceItem", 12);
            RecommUserId = GetDefaultRecommUserId(RecommUserId);

            UserFinanceItem userFinanceItem = new UserFinanceItem
            {
                UserFinanceItemID = UserFinanceItemID
                ,
                UserFinanceID = string.Empty
                ,
                UserId = RecommUserId
                ,
                ItemAmount = ItemAmount
                ,
                ShopID = ShopID
                ,
                CreatedDate = DateTime.Now
                ,
                OperatedDate = DateTime.Now
                ,
                StatusId = "Created"
                ,
                promoteAndSalesChannel = 0
                ,
                TblKeyId = TblKeyId
            };
            try
            {
                db.UserFinanceItems.Add(userFinanceItem);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                OperateLog = string.Format("BaseCntroller.cs > CreateUserFinanceItem > case : SaveChanges : UserFinanceItemID={0} ,UserFinanceID={1},UserId={2} , ItemAmount={3}, ShopID = {4} ,CreatedDate = {5},OperatedDate = {6},StatusId = {7},TblKeyId = {8},EXCEPTION = {9}", UserFinanceItemID, userFinanceItem.UserFinanceID, userFinanceItem.UserId, userFinanceItem.ItemAmount, userFinanceItem.ShopID, userFinanceItem.CreatedDate, userFinanceItem.OperatedDate, userFinanceItem.StatusId, userFinanceItem.TblKeyId ,e.Message);
                mvcCommeBase.OperateLoger(OperateLog);
            }
            
        }
        public decimal CalcCurrentMonthFinanceTotalAmount(string UserId, int Month ,string StatusId)
        { 
            // Created > Submitted > Invalid / Invalid > Cancel
            decimal financeItemTotalAmount = 0;
            var statics1 = db.UserFinanceItems.Where(c => c.UserFinanceID == string.Empty && c.CreatedDate.Month == Month && c.UserId == UserId && c.StatusId == StatusId).ToList();

            if (statics1.Count() == 0)
            {
                return financeItemTotalAmount; 
            }
            financeItemTotalAmount = db.UserFinanceItems.Where(c => c.CreatedDate.Month == Month && c.UserId == UserId).Sum(c=>c.ItemAmount);
            return financeItemTotalAmount;
        }
        public void ReverseCalcFinanceItem(string UserFinanceItemID)
        {
            UserFinanceItem userFinanceItem = db.UserFinanceItems.Find(UserFinanceItemID);
            if (userFinanceItem.StatusId == "Created" && userFinanceItem.UserFinanceID == string.Empty)
            {
                db.UserFinanceItems.Remove(userFinanceItem); 
            }
            else if (userFinanceItem.UserFinanceID != string.Empty)
            {
                UserFinance userFinance = db.UserFinances.Find(userFinanceItem.UserFinanceID);
                if (userFinance.StatusId == "UnPaid")
                {
                    string UserFinanceID = userFinance.UserFinanceID;
                    userFinance.TotalAmount = userFinance.TotalAmount - userFinanceItem.ItemAmount;
                    db.UserFinances.Add(userFinance); 
                } 
            }
            userFinanceItem.StatusId = "Invalid";
            DbEntityEntry<UserFinanceItem> userFinanceItemEntry = db.Entry<UserFinanceItem>(userFinanceItem);
            db.UserFinanceItems.Attach(userFinanceItem);
            userFinanceItemEntry.Property(e => e.StatusId).IsModified = true;

            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    // Update the values of the entity that failed to save from the store
                    ex.Entries.Single().Reload();
                }
            } while (saveFailed);
        }

        public string GetTableStateStatusName(string TableName, string StatusId, string LanguageCode)
        {
            TableState tableState = db.TableStates.Where(c => c.TableName.Contains(TableName) && c.StatusId.Contains(StatusId) && c.LanguageCode.Contains(LanguageCode)).FirstOrDefault();
            if (tableState == null) // Create a new corresponding language code record
            {
                tableState = new TableState
                {
                    Id = db.GetTableIdentityID("TS", TableName, 3)
                   ,
                    TableName = TableName
                   ,
                    StatusId = StatusId
                   ,
                    StatusName = StatusId
                   ,
                    LanguageCode = LanguageCode
                };
                return StatusId + "-Undefined";
            }
            else
            {
                return tableState.StatusName;
            }
        } 
        public Shop GetShop(string ShopId)
        {
            Shop shop = db.Shops.Find(ShopId);
            return shop;
        }
       
        [HttpPost]
        public JsonResult GetLang(string KeyName)
        {
            string Result = LangUtilities.GetString(KeyName);
            Dictionary<string, string> result = new Dictionary<string, string> { { "result", Result } }; 
            return Json(result);
        }

        //初始化语言 
        public void InitializeLanguageCode()
        { 
            var wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
            var routeData = RouteTable.Routes.GetRouteData(wrapper); 
            if (routeData.Values["Language"] != null)
            {
                string route_parms_language = routeData.Values["Language"].ToString();
                _Language = LangUtilities.StandardLanguageCode(route_parms_language);
                LangUtilities.LanguageCode = _Language;
                WebCookie.Language = _Language;
            } 
            else
            {
                
                //var userLangs = Request.Headers["Accept-Language"].ToString();
                //var firstLang = userLangs.Split(',').FirstOrDefault();
                var firstLang = Request.UserLanguages[0];
                _Language = LangUtilities.StandardLanguageCode(firstLang); 
                LangUtilities.LanguageCode = _Language;
                WebCookie.Language = _Language;
            }
        }

        /// <summary>
        /// 此函數準備作廢 轉移到 ShopInitialize();
        /// </summary>
        public void InitLanguageStateViewBag()
        { 
            ViewBag.Language = Language;
            ViewBag.LanguageCode = Language;
             
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            InitializeLanguageCode();
        }
    }
}
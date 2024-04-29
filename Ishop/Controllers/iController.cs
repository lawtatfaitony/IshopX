using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using Ishop.Context;
using Ishop.Models;
using Ishop.Models.Info;
using Ishop.Models.ProductMgr;
using Ishop.Models.PubDataModal;
using Ishop.Utilities;
using Ishop.ViewModes.Info;
using Ishop.ViewModes.Public;
using LanguageResource;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Tencent;

namespace Ishop.Controllers
{
    [ValidateInput(false)]  
    public class iController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        private readonly string DomainName = ConfigurationManager.AppSettings["DomainName"].ToString();
        private readonly string WebSiteUrl = ConfigurationManager.AppSettings["WebSiteUrl"].ToString(); 
        // GET: i
        [ValidateInput(false)] 
        public ActionResult Wx(string Id)
        {
            ShopInitialize();
            //获取InfoID
            UserTrace userTrace = db.UserTraces.Find(Id);
            string InfoID = userTrace.TableKeyID ;
            ViewBag.UserId = userTrace.UserId;
            WebCookie.RecommUserId = userTrace.UserId;
            ViewBag.InfoID = InfoID;
            InfoDetail infoDetail = db.InfoDetails.Find(InfoID);
            if (infoDetail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //统计IP
            IpStatitics_Token();
            ViewBag.SourceIP = mvcCommeBase.GetIP();
            //记录IP 
            ViewBag.SourceStatisticsID =IPstatiticsAdd(InfoID, infoDetail.Title, userTrace.UserId, infoDetail.ShopID);

            infoDetail.Title = ChineseStringUtility.ToAutoTraditional(infoDetail.Title);
            infoDetail.SubTitle = ChineseStringUtility.ToAutoTraditional(infoDetail.SubTitle);
            infoDetail.Author = ChineseStringUtility.ToAutoTraditional(infoDetail.Author);
            infoDetail.InfoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.InfoDescription);
            infoDetail.SeoKeyword = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoKeyword);
            infoDetail.SeoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoDescription);

            ViewBag.Title = mvcCommeBase.Substr(infoDetail.Title , 40);
            ViewBag.KeyWords = infoDetail.SeoKeyword;
            ViewBag.Description = mvcCommeBase.Substr(Regex.Replace(infoDetail.SubTitle, @"[/n/r]", ""),30);
            ViewBag.KeyWordDescription = infoDetail.SeoDescription;
            ViewBag.IsOriginal = infoDetail.IsOriginal;
            ViewBag.Link = Request.Url.ToString();
            
            ViewBag.imgUrl = PictureSuffix.ReturnSizePicUrl(WebSiteUrl + infoDetail.TitleThumbNail, PictureSize.s310X310);
            //导读: 
            //ViewBag.Introduction = "<i class=\"glyphicon glyphicon-chevron-right\"></i> " + Lang.InfoList_InfoDetails_DefinitedTag_Introduction + "<br>" + infoDetail.SubTitle;  //<i class=\"fa fa-hand-o-right\">&nbsp;</i>
            ViewBag.Introduction = "<i class=\"glyphicon glyphicon-chevron-right\"></i> " + infoDetail.SubTitle;
            ViewBag.InfoDescription = infoDetail.InfoDescription;

            //编辑简介
            if (!string.IsNullOrEmpty(infoDetail.ShopStaffID))
            {
                ShopStaff shopStaff = db.ShopStaffs.Find(infoDetail.ShopStaffID);
                shopStaff.ChannelID = db.Channels.Find(shopStaff.ChannelID).ChannelName; //用于传入 分部视图的 ChannelName 名称获取

                ChineseStringUtility.ToAutoTraditional(shopStaff.StaffName);
                ChineseStringUtility.ToAutoTraditional(shopStaff.ContactTitle);
                ChineseStringUtility.ToAutoTraditional(shopStaff.Introduction);

                ViewBag.ShopStaffID = shopStaff;
                ViewBag.ShopQrcode = shopStaff.Qrcode;
                ViewBag.PublicNo = shopStaff.PublicNo ;  //所管理的公众号
            }
            var TopView = db.InfoDetails.Where(c => c.InfoID != infoDetail.InfoID && c.ShopID == infoDetail.ShopID).OrderByDescending(s => s.Views).Take(3).ToList();
            ViewBag.TopView = TopView.Where(c => c.InfoID != InfoID).ToList();

            //more
            ViewBag.myOriginTopViewListNew = GetMyOriginTopViews(infoDetail.ShopStaffID);

            //微信  
            ViewBag.appId = weixin.AppID;
            ViewBag.AppSecret = weixin.AppSecret;
            ViewBag.timestamp = weixin.timestamp;
            ViewBag.nonceStr = weixin.nonceStr;
            string RequestUrl = Request.Url.ToString();
            ViewBag.signature = weixin.signature(RequestUrl);

            //weixin authorize
            if (Request.QueryString["code"] == null)
            { 
                string redirect_uri = string.Format("{0}/i/wx/{1}", WebSiteUrl, Id);
                redirect_uri = Server.UrlEncode(redirect_uri);
                string AuthorUrl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}&connect_redirect=1#wechat_redirect", weixin.AppID, redirect_uri, Id);
                StreamWriter sw = new StreamWriter(Server.MapPath("/urlAuthorizeCode.txt"), false);
                sw.WriteLine("AppID={0};redirect_uri={1}", weixin.AppID, redirect_uri);
                sw.Close(); 
                Response.Redirect(AuthorUrl);
            }
            else
            {
                int SourceStatisticsID =  int.Parse(ViewBag.SourceStatisticsID);
                ViewBag.code = Request.QueryString["code"].ToString();
                CheckAuthorizeOpenId(ViewBag.code as string, infoDetail.ShopID, SourceStatisticsID);
            }
            return View(infoDetail);
        }
         
        [Route("Default")]
        [Authorize]
        public ActionResult InfoTraceUpd(string InfoID, string UserId)
        {
            List<UserTrace> UserTraces = db.UserTraces.Where(c => c.TableKeyID.Contains(InfoID) && c.UserId == UserId).ToList();
            UserTrace UserTrace1 = new UserTrace(); 
            if (UserTraces.Count() == 0)
            {
                string UserTraceID = db.GetTableIdentityID("Tr", "UserTrace", 6);

                UserTrace1 = new UserTrace() {
                    UserTraceID = UserTraceID
                    ,TableKeyID = InfoID
                    ,UserId = UserId
                    ,ShopID = WebCookie.ShopID
                    ,OperatedUserName = User.Identity.Name
                    ,OperatedDate = DateTime.Now
                };
                db.UserTraces.Add(UserTrace1);
                db.SaveChanges(); 
                return RedirectToAction("wx", new { Id = UserTraceID });  
            }
            else
            {
                UserTrace1 = db.UserTraces.Where(c => c.TableKeyID.Contains(InfoID) && c.UserId == UserId).FirstOrDefault();
                return RedirectToAction("wx", new { Id = UserTrace1.TableKeyID });
            }
            
        }
        /// <summary>
        /// Speech, product, knowledge base list and details
        /// </summary>
        /// <param name="SeoExtandID"></param>
        /// <returns></returns>
        [Authorize(Roles = "Supervisor,BusinessPromotion")]
        [HttpGet]
        public ActionResult SeoExt(string SeoExtandID , int? ExtandLevel)
        {
            ShopInitialize();
            // ExtandLevel  节点展开的层级 默认是 2级 
            ViewBag.intExtandLevel = (ExtandLevel ?? 2);

            SeoExtand SeoExtand1 =new SeoExtand() ;
              
            if (SeoExtandID != null)
            {
                SeoExtand1 = db.SeoExtands.Find(SeoExtandID);
                ViewBag.SeoExtandID = SeoExtandID;
                ViewBag.SeoHtmlContext = SeoExtand1.SeoHtmlContext;
            }
            else
            {
                SeoExtand1 = db.SeoExtands.FirstOrDefault();
                SeoExtandID = SeoExtand1.SeoExtandID;
                ViewBag.SeoExtandID = SeoExtand1.SeoExtandID;
                ViewBag.SeoHtmlContext = SeoExtand1.SeoHtmlContext;
            }
            ViewBag.Title = SeoExtand1.SeoKeyWord;

            //列出相关文件
            ViewBag.UploadItemList = db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(SeoExtandID)).Count() > 0 ? db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(SeoExtandID)).ToList() : null;
            return View(SeoExtand1);
        }

        /// <summary>
        /// Speech, product, knowledge base [update ranking]
        /// </summary>
        /// <param name="SeoExtandID"></param>
        /// <returns></returns>
        [Authorize(Roles = "BusinessPromotion")]
        [HttpPost]
        public ActionResult UpdTopRank50(string SeoExtandID,int TopRank50)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            
            SeoExtand SeoExtand1 = new SeoExtand();
           
            if (SeoExtandID != null)
            {
                SeoExtand1 = db.SeoExtands.Find(SeoExtandID);

                SeoExtand1.TopRank50 = TopRank50;
                DbEntityEntry<SeoExtand> SeoExtandEntry = db.Entry<SeoExtand>(SeoExtand1);
                db.SeoExtands.Attach(SeoExtand1);
                SeoExtandEntry.Property(e => e.TopRank50).IsModified = true;
                try
                {
                    // 写数据库
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "UPDATE SUCCESS" ;
                    return Json(ModalDialogView1);
                }
                
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "FAIL \n\n" + e.Message; ;
                    return Json(ModalDialogView1);
                }
            }
            else
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "ID NOT EXIST" ;
                return Json(ModalDialogView1);
            } 
        }
        
        [HttpGet]
        public ActionResult CompoundInterest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompoundInterest([Bind(Include = "P,F,n,i")]CompoundInterestView CompoundInterestView1)
        { 
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            double power1 = CompoundInterestView1.F / CompoundInterestView1.P;
            double N1 = 1 / CompoundInterestView1.n;
            double power2 =Math.Round( Math.Pow(power1,N1) , 6);  //开平方就用Math.Sqrt,   开n次方：Math.Pow(double,   1/n);

            double i =  double.Parse(power2.ToString()) - 1;

            ModalDialogView1.MsgCode = Math.Abs(Math.Round(i * 100, 4)).ToString();
            ModalDialogView1.Message = "Resule :: " + Math.Abs(Math.Round(i * 100,4)).ToString() + "%";
            return Json(ModalDialogView1);
             
        }
        [HttpGet]
        public string get_echostr(string token , string timestamp ,string nonce)
        { 
            string echostr = token + timestamp + nonce; 
            echostr = weixin.SHA1_Hash(echostr);
            return echostr;
        }
        [HttpGet]
        [Route(Name = "Default")]
        public ActionResult wxAuthorize(string signature ,string timestamp, string nonce, string echostr, string state ,string code)
        {
            string Redirect_Uri = "";
            //for wechat callback (this param:code is from wechat public perform redirect)
            if (!string.IsNullOrEmpty(code))
            { 
                Redirect_Uri = string.Format("/i/wx/{0}?code={1}", state, code);
                 
                string WxLog = string.Format("wxAuthorize > code={0} , id = {1} , Redirect_Uri = {2}", code, state, Redirect_Uri);
                mvcCommeBase.OperateLoger(WxLog);

                Response.Redirect(Redirect_Uri); 
            }
            ViewBag.Redirect_Uri = Redirect_Uri;
            if ( !string.IsNullOrEmpty(signature) && !string.IsNullOrEmpty(timestamp) && !string.IsNullOrEmpty(nonce) && !string.IsNullOrEmpty(echostr))
            {
                return Content(echostr); //test
                //============
                ////WeiXin weiXin = db.WeiXins.Where(c => c.ShopID == "sh0001").FirstOrDefault();
                ////StreamWriter sw = new StreamWriter(Server.MapPath("/urlAuthorize.txt"), false);
                ////sw.WriteLine("signature={0}&timestamp={1}&nonce={2}&echostr={3}", signature, timestamp, nonce, echostr);
                ////sw.Close();
                ////string sEchoStr = checkSignature(signature, timestamp, nonce, echostr, weiXin.AppID);

                ////StreamWriter sw2 = new StreamWriter(Server.MapPath("/urlAuthorize2.txt"), false);
                ////sw2.WriteLine("sEchoStr:{0}", sEchoStr);
                ////sw2.Close();

                ////return Content(sEchoStr);
            }
            return View();
        }
        public string checkSignature(string signature, string timestamp, string nonce,string echostr, string AppID)
        {
            string token = "TomIsController";
            string EncodingAESKey = "IamveryHappyIamveryHappyIamveryHappyIamvery";
             
            WXBizMsgCrypt wxMsgCrypt = new WXBizMsgCrypt(token, EncodingAESKey, AppID);    //微信提供的加解密类
            string sEchoStr = "";
             
            int code = wxMsgCrypt.VerifyURL(signature, timestamp, nonce, echostr, ref sEchoStr);
            if (code != 0)
            {
                sEchoStr = string.Format("Verrify Fail_{0}___", code) + DateTime.Now.ToString();
            }
            return sEchoStr; 
        }

        public List<MyOriginTopView> GetMyOriginTopViews(string UserId)
        {
           
            List<MyOriginTopView> myOriginTopViewListNew = new List<MyOriginTopView>();

            var myOriginTopViewList = db.InfoDetails.Where(c => c.ShopStaffID.Contains(UserId) && !string.IsNullOrEmpty(c.ShopStaffID)).OrderByDescending(c => c.Views).OrderByDescending(c => c.OperatedDate).ToList().Take(12);
            if(myOriginTopViewList.Count()>0)
            {
                foreach(var item in myOriginTopViewList)
                {
                    MyOriginTopView myOriginTopView = new MyOriginTopView();
                    myOriginTopView.UserTraceID = CreateUserTrace(item.InfoID, item.ShopStaffID,item.ShopID);
                    myOriginTopView.InfoID = item.InfoID;
                    myOriginTopView.UserId = item.ShopStaffID;
                    myOriginTopView.Title = item.Title;

                    myOriginTopViewListNew.Add(myOriginTopView);
                }
            }

            return myOriginTopViewListNew;
        }

        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult RetriveWeixinInfo(int ID)
        {
            WxUserInfo wxUserInfo = new WxUserInfo() { openid = "", nickname = "", sex = "", province = "", city = "", country = "", headimgurl = "", privilege = "", unionid = "" };
            wxUserInfo = RetriveWeixin(ID);
            return Content(string.Format("get WeiXinInfo Result ={0} openid = {1},nickname ={2},headimgurl ={3},SourceStatisticsID ={4}", wxUserInfo.privilege, wxUserInfo.openid, wxUserInfo.nickname, wxUserInfo.headimgurl, ID));
        }

        [Authorize]
        [HttpGet]
        public ActionResult RetriveToken()
        {
            return Content("hello world");
        }
         
        [HttpGet]
        public ActionResult EmailSubscribe()
        {
            DateTimeOffset df = new DateTimeOffset(DateTime.Now); 
            EmailSubscribe EmailSubscribe = new EmailSubscribe {
                Id = df.ToUnixTimeMilliseconds().ToString(),
                OperatedDate = DateTime.Now,
                ShopId = WebCookie.ShpID,
            }; 
            return View(EmailSubscribe);
        }

        [HttpPost]
        public ActionResult EmailSubscribe(string Email)
        {
            ResponseModalX responseModalX = new ResponseModalX();
            if (string.IsNullOrEmpty(Email))
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = Lang.EmailSubscribe_EmailInvalid
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
            if (mvcCommeBase.IsValidEmail(Email)==false)
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = Lang.EmailSubscribe_EmailInvalid
                };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }

            DateTimeOffset df = new DateTimeOffset(DateTime.Now);
            EmailSubscribe EmailSubscribe = new EmailSubscribe
            {
                Id = df.ToUnixTimeMilliseconds().ToString(),
                Email = Email,
                SubscriberName = string.Empty,
                Remarks = string.Empty,
                OperatedUserName = "SYSTEM",
                OperatedDate = DateTime.Now,
                ShopId = WebCookie.ShpID,
                EmailTaskId= "",
                Status = -1
            };
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            applicationDbContext.EmailSubscribe.Add(EmailSubscribe);
            bool result = applicationDbContext.SaveChanges()>0;
            if(result)
            {
                responseModalX.meta = new MetaModalX
                {
                    ErrorCode = (int)GeneralReturnCode.FAIL,
                    Success = false,
                    Message = Lang.GeneralUI_OK
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
    }
}
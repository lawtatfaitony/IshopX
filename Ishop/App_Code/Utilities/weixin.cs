using Ishop.Context;
using Ishop.Models.PubDataModal;
using Ishop.Models.User;
using Ishop.Utilities;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Ishop.AppCode.Utilities
{
    public class weixin
    {
        private static Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        //微信公众号开发
        public static string AppID = "wxed52e2ba2c783cea";
        public static string appID
        {

            get
            {
                return AppID;
            }
            set
            {
                AppID = value;
            }
        }

        public static string AppSecret = "5a20139e69b497660914a9d64e00de10";
        public static string appSecret
        {
            get
            {
                return AppSecret;
            }
            set
            {
                AppSecret = value;
            }
        }

        public static string ShopID = "sh0001";
        public static string shopID
        {
            get
            {
                return ShopID;
            }
            set
            {
                ShopID = value;
            }
        }

        //获取token : https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET 
        public static string GetAccessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={0}";
        ////分享的连接
        //public static string pathurl;

        ///返回时间戳、随机字符串、签名、appid
        public static string jsapiTicket = getJsApiTicket(GetToken(AppID, AppSecret));
        // 返回时间戳
        public static string timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
        // 返回创建随机字符串
        public static string nonceStr = createNonceStr();
        // 返回签名signature
        public static string rawstring(string pathurl)
        {
            string a1 = jsapiTicket;
            string aa = "jsapi_ticket=" + a1 + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + pathurl;
            return aa;
        }
        public static string signature(string pathurl)
        {
            string Rawstring = rawstring(pathurl);
            return SHA1_Hash(Rawstring);
        }
        // 返回的appid
        public static string appid = AppID;

        /// <summary>
        /// 【获取Token】前端调用后端 ,获取ticket 通过访问微信的API获取token，获取ticket之前要首先获取token，因为ticket获取要传一个token给微信。
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <returns></returns> 
        public static string GetToken(string appid, string secret)
        { 
            string getTokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, secret);
            try
            {
                TokenJson tokenJson = JsonConvert.DeserializeObject<TokenJson>(httpGet(getTokenUrl));
                string access_token = tokenJson.access_token;
                return access_token;
            }
            catch(JsonReaderException e)
            {
                TokenFail tokenFail = JsonConvert.DeserializeObject<TokenFail>(httpGet(getTokenUrl));
                string access_token = tokenFail.errmsg;

                string WxLog = string.Format("class:weixin > GetToken > errcode={0} , errmsg = {1},error = {2}", tokenFail.errcode, tokenFail.errmsg ,e.Message);
                mvcCommeBase.OperateLoger(WxLog);

                return access_token;
                
            }
            
        }

        /// <summary>
        ///  获取ticket 通过上面的返回的token获取ticket
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string getJsApiTicket(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + access_token + "";
             
            try
            {
                Jsapi api = JsonConvert.DeserializeObject<Jsapi>(httpGet(url));
                string ticket = api.ticket;
                return ticket;
            }
            catch (Exception e)
            { 
                TicketFail ticketFail = JsonConvert.DeserializeObject<TicketFail>(httpGet(url));
                string WxLog = string.Format("class:weixin > getJsApiTicket > errcode={0} , errmsg = {1},error = {2}", ticketFail.errcode, ticketFail.errmsg, e.Message);
                mvcCommeBase.OperateLoger(WxLog);
                return string.Empty; 
            }
        }
        
        //获取ticket
        public static string getJsApiTicket(string appid, string appSecret)
        { 
            ////这里开始从微信API获取ticket
            string token = GetToken(appid, appSecret);
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + token + "";
            Jsapi api = JsonConvert.DeserializeObject<Jsapi>(httpGet(url));
            string ticket = api.ticket;
            return ticket;
        } 
        public static OpenIdObject getOpenIDObject(string code)
        {
            //if openid is valid,then update access_token
            string getOpenIdUrl = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppID, AppSecret, code);//通过appid,appaseret,code
            OpenIdObject openIdObject = JsonConvert.DeserializeObject<OpenIdObject>(httpGet(getOpenIdUrl));
              
            return openIdObject;
        } 
        public static WxUserInfo getWxUserInfo(string code)
        {
            WxUserInfo wxUserInfo = new WxUserInfo();
            OpenIdObject openIdObject = getOpenIDObject(code);
            
            string url_userinfo = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", openIdObject.access_token, openIdObject.openid); //https://api.weixin.qq.com/sns/userinfo?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_userinfo);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonstr = "";
            using (Stream resStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(resStream,Encoding.UTF8); //String json = newString(Json.getBytes("ISO-8859-1"), "UTF-8");
                jsonstr = reader.ReadToEnd();
                resStream.Close();
            }

            var ser = new DataContractJsonSerializer(typeof(WxUserInfo));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonstr));
             
            string WxLog;
            try
            {
                wxUserInfo = (WxUserInfo)ser.ReadObject(ms);

                WxLog = string.Format("getWxUserInfo >SUCCESS country={0} ,province={1},city={2}, nickname = {3}", wxUserInfo.country, wxUserInfo.province, wxUserInfo.city, wxUserInfo.nickname);
                mvcCommeBase.OperateLoger(WxLog);

                return wxUserInfo;
            }
            catch (JsonReaderException e)
            { 
                WxLog = string.Format("class : weixin__getWxUserInfo > getResult={0} ,message={1}", jsonstr, e.Message);
                mvcCommeBase.OperateLoger(WxLog);
                return wxUserInfo;
            } 
        }
        public static WxUserInfo getWxUserInfoByOpenId(string openid)
        {
            WxUserInfo wxUserInfo = new WxUserInfo();
            string token_access = GetToken(AppID, AppSecret);
            string url_userinfo = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", token_access, openid); //https://api.weixin.qq.com/sns/userinfo?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_userinfo);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonstr = "";
            using (Stream resStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(resStream, Encoding.UTF8); //String json = newString(Json.getBytes("ISO-8859-1"), "UTF-8");
                jsonstr = reader.ReadToEnd();
                resStream.Close();
            }

            var ser = new DataContractJsonSerializer(typeof(WxUserInfo));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonstr));

            string WxLog;
            
            wxUserInfo = (WxUserInfo)ser.ReadObject(ms);

            WxLog = string.Format("getWxUserInfo >SUCCESS country={0} ,province={1},city={2}, nickname = {3}", wxUserInfo.country, wxUserInfo.province, wxUserInfo.city, wxUserInfo.nickname);
            mvcCommeBase.OperateLoger(WxLog);
            //when FAILURE :if return wxUserInfo = empty
            if (string.IsNullOrEmpty(wxUserInfo.headimgurl) && string.IsNullOrEmpty(wxUserInfo.headimgurl))
            {
                WxLog = string.Format("class : weixin > getWxUserInfo > getResult={0} ,message={1}", jsonstr);
                mvcCommeBase.OperateLoger(WxLog);
                return wxUserInfo;
            }

            return wxUserInfo;
            
        }
        #region  public method
        //公共方法，request网络获取
        public static string RequestUrl(string url, string method)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = method;
            request.ContentType = "text/html";
            request.Headers.Add("charset", "utf-8");

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        } 
        //公共方法，获取Json
        public static string GetJsonValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值
                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }

                    result = jsonStr.Substring(index, end - index);
                    result = result.Trim(new char[] { '"', ' ', '\'' }); //过滤引号或空格
                }
            }
            return result;
        }

        //公共方法，发起一个http请球，返回值  
        private static string httpGet(string url)
        {
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
                Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据  
                string pageHtml = System.Text.Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句              

                return pageHtml;
            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message.ToString());
                return null;
            }
        }

        //创建随机字符串  
        public static string createNonceStr()
        {
            int length = 16;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string str = "";
            Random rad = new Random();
            for (int i = 0; i < length; i++)
            {
                str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
            }
            return str;
        }

        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }
        /// <summary>  
        /// DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time"> DateTime时间格式</param>  
        /// <returns>Unix时间戳格式</returns>  
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        public string DoPost(string url, string data)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            byte[] postData = Encoding.UTF8.GetBytes(data);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }
        public static HttpWebRequest GetWebRequest(string url, string method)
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
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static Genders GenderCase(string sex)
        {
            switch(sex)
            {
                case "1":
                    return Genders.Male;
                case "2":
                    return Genders.Female;
                default:
                    return Genders.Unkown; 
            } 
        }

        public static Encoding GetEncoding(Stream stream)
        { 
            Encoding encoding1 = Encoding.Default;
            
                try
                {
                     using (StreamReader reader1 = new StreamReader(stream, true))
                            {
                                char[] chArray1 = new char[1];
                                reader1.Read(chArray1, 0, 1);
                                encoding1 = reader1.CurrentEncoding;
                                reader1.BaseStream.Position = 0;
                                if (encoding1 == Encoding.UTF8)
                                {
                                    byte[] buffer1 = encoding1.GetPreamble();
                                    if (stream.Length >= buffer1.Length)
                                    {
                                        byte[] buffer2 = new byte[buffer1.Length];
                                        stream.Read(buffer2, 0, buffer2.Length);
                                        for (int num1 = 0; num1 < buffer2.Length; num1++)
                                        {
                                            if (buffer2[num1] != buffer1[num1])
                                            {
                                                encoding1 = Encoding.Default;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        encoding1 = Encoding.Default;
                                    }
                                }
                            }
                         
                }
                catch (Exception ex)
                {
                    string WxLog = string.Format("class : weixin > GetEncoding > GetEncoding={0} ", ex.Message);
                    mvcCommeBase.OperateLoger(WxLog); 
                    throw;
                }
                if (encoding1 == null)
                {
                    encoding1 = Encoding.UTF8;
                }
             
            return encoding1;
        }
        #endregion
        /// <summary>
        /// 更新令牌、或者返回令牌 
        /// </summary>
       
    }
    
    public class Jsapi
    {
        public string errcode;
        public string errmsg;
        public string ticket;
        public string expires_in;
    }
    public class TokenAndTicket
    {
        public string Token;
        public string Ticket;
    }
    public class WxUserInfo
    {
        public string openid = "";
        public string nickname = "";
        public string sex = "";
        public string province = "";
        public string city = "";
        public string country = "";
        public string headimgurl = "";
        public string privilege = "";
        public string unionid = "";
    }
    public class OpenIdObject
    {
        public string access_token = "";
        public string expires_in = "";
        public string refresh_token = "";
        public string openid = "";
        public string scope = "";
    }
    public class TokenJson
    {
        public string access_token = "";
        public string expires_in = "";
    }

    public class TokenFail
    {
        //{"errcode":40013,"errmsg":"invalid appid"}
        public string errcode;
        public string errmsg; 
    }

    public class TicketFail
    {
        //{"errcode":42001,"errmsg":"access_token expired hint: [axr1DA07251187!]"}
        public string errcode;
        public string errmsg; 
    }
    public class UserInfoFail
    {
        //{"errcode":42001,"errmsg":"access_token expired hint: [axr1DA07251187!]"}
        public string errcode;
        public string errmsg;
    }
    public class NewWeiXin
    {
        public string AppID = "";
        public string AppSecret = "";
         
        public string nonceStr = "";
        public string timestamp = "";
        public string signature = "";
        public string token = "";
        public string jsapiTicket = "";
    }
    public class WeiXinApp
    {
        private static Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        public NewWeiXin CreateNewWeixin(string ShopID,string RqUrl)
        {
            NewWeiXin newWeiXin = new NewWeiXin();
            
            TokenAndTicket TokenAndTicket1 = new Utilities.TokenAndTicket();

            WeiXin weiXin = new WeiXin();
            weiXin = db.WeiXins.Where(c => c.ShopID == ShopID).FirstOrDefault();

            if (weiXin.lastupdate <= DateTime.Now)
            {
                //获取Token 
                TokenAndTicket1.Token = GetToken(weiXin.AppID, weiXin.secret);
                //获取ticket 
                TokenAndTicket1.Ticket = getJsApiTicket(TokenAndTicket1.Token);

                //更新到数据库
                weiXin.access_token = TokenAndTicket1.Token;
                weiXin.ticket = TokenAndTicket1.Ticket;
                weiXin.lastupdate = DateTime.Now.AddSeconds(7200);
                weiXin.ticket_expires_in = 7200;
                weiXin.expires_in = 7200;

                DbEntityEntry<WeiXin> WeiXinsEntry = db.Entry<WeiXin>(weiXin);
                db.WeiXins.Attach(weiXin);
                db.Entry(weiXin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                //===========
                newWeiXin.AppID = weiXin.AppID;
                newWeiXin.AppSecret = weiXin.secret;
                newWeiXin.nonceStr = createNonceStr();
                newWeiXin.signature = signature(RqUrl, weiXin.ticket);
                newWeiXin.token = weiXin.access_token;
                newWeiXin.timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
                newWeiXin.jsapiTicket = weiXin.ticket;
                return newWeiXin;
            }
            else
            {
                newWeiXin.AppID = weiXin.AppID;
                newWeiXin.AppSecret = weiXin.secret;
                newWeiXin.nonceStr = createNonceStr();
                newWeiXin.signature = signature(RqUrl, weiXin.ticket);
                newWeiXin.token = weiXin.access_token;
                newWeiXin.timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
                newWeiXin.jsapiTicket = weiXin.ticket;

                return newWeiXin;
            }
        }
        public string signature(string pathurl, string ticket)
        {
            string nonceStr = createNonceStr();
            string timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
            string Rawstring = rawstring(pathurl, ticket,  nonceStr,  timestamp);
            return SHA1_Hash(Rawstring);
        }
        public string createNonceStr()
        {
            int length = 16;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string str = "";
            Random rad = new Random();
            for (int i = 0; i < length; i++)
            {
                str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
            }
            return str;
        }

        public string rawstring(string pathurl, string ticket , string nonceStr, string timestamp)
        {
            string a1 = ticket;
            string aa = "jsapi_ticket=" + a1 + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + pathurl;
            return aa;
        }
        public string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }
        public  int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        private string httpGet(string url)
        {
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
                Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据  
                string pageHtml = System.Text.Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句              

                return pageHtml;
            }


            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message.ToString());
                return null;
            }
        }
        public Genders GenderCase(string sex)
        {
            switch (sex)
            {
                case "1":
                    return Genders.Male;
                case "2":
                    return Genders.Female;
                default:
                    return Genders.Unkown;
            }
        }
        public string RequestUrl(string url, string method)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = method;
            request.ContentType = "text/html";
            request.Headers.Add("charset", "utf-8");

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        }
        public string GetToken(string appid, string secret)
        {
            string getTokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, secret);
            TokenJson tokenJson = JsonConvert.DeserializeObject<TokenJson>(httpGet(getTokenUrl));
            string access_token = tokenJson.access_token;
            return access_token;
        }

        public string getJsApiTicket(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + access_token + "";
            Jsapi api = JsonConvert.DeserializeObject<Jsapi>(httpGet(url));
            string ticket = api.ticket;
            return ticket;
        }

        public string getOpenID(string code, string AppID, string AppSecret,string ShopID)
        { 
            string getOpenIdUrl = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppID, AppSecret, code);//通过appid,appaseret,code
            OpenIdObject openIdObject = JsonConvert.DeserializeObject<OpenIdObject>(httpGet(getOpenIdUrl));
            string openid = openIdObject.openid;
            if (openid.Length > 0)
            {
                WeiXin weiXin1 = db.WeiXins.Where(c => c.ShopID == ShopID).FirstOrDefault();
                weiXin1.access_token = openIdObject.access_token;
                weiXin1.lastupdate = DateTime.Now.AddSeconds(7200);
                DbEntityEntry<WeiXin> entry = db.Entry<WeiXin>(weiXin1);
                db.WeiXins.Attach(weiXin1);
                db.Entry<WeiXin>(weiXin1).State = EntityState.Modified;
                db.SaveChanges();
            }
            return openIdObject.openid;
        }
    }

}


 
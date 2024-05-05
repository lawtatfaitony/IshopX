using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Globalization; 
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;
using System.Web.Caching;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;
using System.Management;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using Newtonsoft.Json;
using Ishop.Context;
using Ishop.Models.UploadItem;
using LanguageResource;
using Ishop.Models.ProductMgr;
using System.IO;
using System.Linq;

namespace Ishop.Utilities
{
    //尺寸规格
    public enum PictureSize
    {
        IsNotPict = 0, s48X48 = 1, s60X60 = 2, s100X100 = 3, s160X160 = 4, s230X230 = 5, s250X250 = 6, s310X310 = 7, s350X350 = 8, s600X600 = 9
    }
    /// <summary>
    /// Thumbnail file name suffix
    /// </summary>
    public class PictureSuffix
    { 
        public static string ReturnSizePicUrl(string PicUrl , PictureSize pictureSize)
        {
            if (string.IsNullOrEmpty(PicUrl))
            {
                return "defultUserIcon" + pictureSize + ".jpg";
            }
            if (PicUrl.ToLower().IndexOf("gif") != -1)
            {
                return PicUrl + pictureSize + ".gif";
            }
            if (PicUrl.ToLower().IndexOf("png") != -1)
            {
                return PicUrl + pictureSize + ".png";
            }
            if (PicUrl.ToLower().IndexOf("jpeg") != -1)
            {
                return PicUrl + pictureSize + ".jpeg";
            }
            return PicUrl + pictureSize + ".jpg";
            
        }
    }
    public static class mvcCommeBase
    {
        private static readonly string WebSiteUrl = ConfigurationManager.AppSettings["WebSiteUrl"].ToString();
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["WebSiteUrl"];

        private static Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        public static bool SaveDataJson(string FileContent, string PathFile)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(PathFile, false, System.Text.Encoding.GetEncoding("UTF-8"));
                writer.Write(FileContent);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

            return true;
        }
        public static void ChkShpID()
        {
            HttpContext CurrentHttp = HttpContext.Current;
            string ShpID;
            if (string.IsNullOrEmpty(WebCookie.ShpID)) //no ShpId cookie State
            {
                if (CurrentHttp.Request.Params["shpid"] != null)
                {
                    ShpID = CurrentHttp.Request.Params["shpid"].ToString().ToLower(); //1.get the  Url Param
                    WebCookie.ShpID = ShpID;
                }
                else
                {
                    ShpID = ConfigurationManager.AppSettings["DefaultShopID"].ToLower(); //2.get the config ShpId
                    WebCookie.ShpID = ShpID;
                }
            } 
        }
        public static string CreateDynamicToken(string Scret)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now);
            long ts1 = dateTimeOffset.ToUnixTimeSeconds();
            long oddL1 = ts1 % 10;
            ts1 = ts1 - oddL1;
            string tokenScret = HMACSHA1Encode(ts1.ToString(), Scret);
            return tokenScret;
        }
        public static string HMACSHA1Encode(string input, string strkey)
        {
            byte[] keyX = Encoding.ASCII.GetBytes(strkey);
            HMACSHA1 myhmacsha1 = new HMACSHA1(keyX);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
        public static string ReadDataFromHtml(string pathFileName)
        { 
            if (File.Exists(pathFileName))
            {
                string content = File.ReadAllText(pathFileName, Encoding.UTF8);
                return content;
            }
            else
            {
                return string.Empty;
            }
        }
        public static void CheckInitialize()
        {
            //Language Initialize
            if (WebCookie.Language == string.Empty)
            {
                WebCookie.Language = LangUtilities.LanguageCode;
            }
            if (WebCookie.ShpID == string.Empty)
            {
                mvcCommeBase.ChkShpID();
            }
        }
        public static Shop ReturnClient_Shop()
        {
            string ShpID = WebCookie.ShpID;
            Shop Client_Shop = db.Shops.Find(ShpID);
            return Client_Shop;
        }
        //public static void ChkCerPassword()
        //{
        //    if (HttpContext.Current.Session["CerPassword"] == null)
        //    {
        //        if (HttpContext.Current.Request.Params["AccountMgrID"] != null)
        //        {
        //            HttpContext.Current.Response.Redirect("/Mgr/AccountMgr/CerPassword?ReturnCerPassUrl=/Mgr/AccountMgr/AccountMgrAddOrUpd%3fAccountMgrID=" + HttpContext.Current.Request.Params["AccountMgrID"].ToString());
        //        }
        //        else
        //        {
        //            HttpContext.Current.Response.Redirect("/Mgr/AccountMgr/CerPassword?ReturnCerPassUrl=/Mgr/AccountMgr/AccountMgrAddOrUpd");
        //        }

        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        public static bool ChkCerPassword()
        {
            if (System.Web.HttpContext.Current.Session["CerPassword"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            //str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out;
        }
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        public static void SetCache(string cacheKey, object objObject)
        {
            if (objObject == null)
                return;
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject);
        }
        public static bool IsChinaArea()
        {
            if (LangUtilities.LanguageCode == "zh-CN")
            {
                return true;
            }else
            {
                return false;
            }
        } 
        public static string RplforOdd(string s) 
        {
            //把奇数 以*号标识
            s = s.Replace("1","*");
            s = s.Replace("3", "*");
            s = s.Replace("5", "*");
            s = s.Replace("7", "*");
            s = s.Replace("9", "*");
            return s;
        }
        public static string PhoneNumberRplforArisk(string s)
        {
            //把中间的3位以*号标识.长度不够4位不替换 
            //Regex.Replace(s, @"(?im)(\d{3})(\d{4})(\d{4})", "$1***$3");//134****0555
            Regex re = new Regex("", RegexOptions.None);
            int sLength = s.Length;
            switch (sLength)
            {
                case 5:
                    re = new Regex("(\\d{3})(\\d{2})", RegexOptions.None);
                    s = re.Replace(s, "$1****");
                    break;
                case 6:
                    re = new Regex("(\\d{3})(\\d{3})", RegexOptions.None);
                    s = re.Replace(s, "$1****");
                    break;
                case 7:
                    re = new Regex("(\\d{3})(\\d{4})", RegexOptions.None);
                    s = re.Replace(s, "$1****");
                    break;
                case 8:
                    re = new Regex("(\\d{3})(\\d{4})(\\d{1})", RegexOptions.None);
                    s = re.Replace(s, "$1****$3");
                    break;
                case 9:
                    re = new Regex("(\\d{3})(\\d{4})(\\d{2})", RegexOptions.None);
                    s = re.Replace(s, "$1****$3");
                    break;
                case 10:
                    re = new Regex("(\\d{3})(\\d{4})(\\d{3})", RegexOptions.None);
                    s = re.Replace(s, "$1****$3");
                    break;
                case 11:
                    s = Regex.Replace(s, @"(?im)(\d{3})(\d{4})(\d{4})", "$1***$3");
                    break;
                case 12:
                    re = new Regex("(\\d{3})(\\d{4})(\\d{5})", RegexOptions.None);
                    s = re.Replace(s, "$1****$3");
                    break;
                default:
                    re = new Regex("(\\d{3})(\\d{4})(\\d{13})", RegexOptions.None);
                    s = re.Replace(s, "$1****$3");
                    break;
            }
            return s;

        }
        public static string SplitHtml(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring))
            {
                return Htmlstring;
            }
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<[^>]*>", "");
            return Htmlstring;
        }
        public static string EncodeTextToHtml(string SourceText)
        {
            SourceText = SourceText.Replace("\n", "<br>");
            SourceText = SourceText.Replace(" ", "&nbsp;");
            SourceText = SourceText.Replace("[", "<");
            SourceText = SourceText.Replace("]", ">");
            return SourceText;
        }
        public static string DecodeHtmlToText(string SourceHtml)
        {
            SourceHtml = SourceHtml.Replace("<br>", "\n");
            SourceHtml = SourceHtml.Replace("&nbsp;", " ");
            SourceHtml = SourceHtml.Replace("[", "<");
            SourceHtml = SourceHtml.Replace("]", ">");
            return SourceHtml;
        }
        private static string[] PhoneNumberStarts = "136,137,138,139,159,130,131,132,133,188,189".Split(',');  //"134,135,136,137,138,139,150,151,152,157,158,159,130,131,132,155,156,133,153,180,181,182,183,185,186,176,187,188,189,177,178"
        private static string[] PhoneNumberHKStarts = "90,91,92,93,96,97,98,61,62,63,66,68".Split(',');  //排除 99 ,900 與不吉利号码 ,香港  51-56、59、6、90-98开头的号码为移动电话号码

        /// <summary>
                /// 随机生成电话号码
                /// </summary>
                /// <returns></returns>
        public static string RandomCNphoneNumber()
        {
            Random ran = new Random();
            int n = ran.Next(10, 1000);
            int index = ran.Next(0, PhoneNumberStarts.Length - 1);
            string first = PhoneNumberStarts[index];
            string second = (ran.Next(100, 888) + 10000).ToString().Substring(1);
            string thrid = (ran.Next(1, 9100) + 10000).ToString().Substring(1).Replace("4", "8"); ;
            return first + second + thrid;
        }
        public static string RandomHKphoneNumber()
        {
            Random ran = new Random();
            int n = ran.Next(1000, 9000);
            int index = ran.Next(0, PhoneNumberHKStarts.Length - 1);
            string first = PhoneNumberHKStarts[index];
            string second = (ran.Next(100, 888) + n).ToString().Substring(1);
            string thrid = (ran.Next(100, 999) + 1000).ToString().Substring(1).Replace("7", "8");
            return (first + second + thrid).Replace("4","8");
        }
        public static bool IsNumber(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return false;
            }
            char[] chArray = new char[str.Length];
            chArray = str.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if ((chArray[i] < '0') || (chArray[i] > '9'))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsValidEmail(string strIn)
        {
            if (string.IsNullOrEmpty(strIn))
            {
                return false;
            } 
            // Return true if strIn is in valid e-mail format. ref : https://msdn.microsoft.com/zh-tw/library/01escwtf(v=vs.100).aspx
            return Regex.IsMatch(strIn,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        private static readonly char[] constant =
          {
               '0','1','2','3','5','6','7','8','9', 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
          }; 
        //生产随机数字和字母
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(35)]);
            }
            return newRandom.ToString();
        }
        private static readonly char[] constantNumber =
          {
               '0','1','2','3','4','5','6','7','8','9'
              };
        //生产随机数字 例如 手机验证码
        public static string GenerateNumberRandom(int Length)
        {
            
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constantNumber[rd.Next(10)]);
            }
            return newRandom.ToString();
        }
        public static string GetHash(string strValue)
        {
            SHA384Managed sha384 = new SHA384Managed();
            UnicodeEncoding uEncode = new UnicodeEncoding();
            Byte[] bytValue;
            Byte[] bytTemp;

            bytValue = uEncode.GetBytes(strValue);
            bytTemp = sha384.ComputeHash(bytValue);
            return Convert.ToBase64String(bytTemp);
        }//unsymmetrical Encryption
         
        public static string CreateRandomCode(int codeCount)
        {
            string[] strArray = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z".Split(new char[] { ',' });
            string str2 = "";
            int num = -1;
            Random random = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (num != -1)
                {
                    random = new Random((i * num) * ((int)DateTime.Now.Ticks));
                }
                int index = random.Next(0x23);
                if (num == index)
                {
                    return CreateRandomCode(codeCount);
                }
                num = index;
                str2 = str2 + strArray[index];
            }
            return str2;
        }
         
        #region GetPicThumbnail 
        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片</param>
        /// <param name="dFile">压缩后保存位置</param>
        /// <param name="dHeight">高度</param>
        /// <param name="dWidth">宽度</param>
        /// <param name="flag">压缩质量 1-100</param>
        /// <returns></returns>

        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile); 
            ImageFormat tFormat = iSource.RawFormat; 
            int sW = 0, sH = 0;
            Bitmap ob ;
            //按比例缩放 
            Size tem_size = new Size(iSource.Width, iSource.Height);  
            if (tem_size.Width > dHeight || tem_size.Height > dWidth) //将**改成c#中的或者操作符号
            {
                if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
                {
                    sW = dWidth; 
                    sH = ( dWidth * tem_size.Height ) / tem_size.Width;
                    ob = new Bitmap(sW, sH);
                } 
                else
                {
                    sH = dHeight; 
                    sW = ( dHeight * tem_size.Width ) / tem_size.Height;
                    ob = new Bitmap(sW, sH);
                } 
            } 
            else
            { 
                sW = tem_size.Width; 
                sH = tem_size.Height;
                ob = new Bitmap(sW, sH);
            }
              
            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.White); //g.Clear(Color.Transparent); 透明
            g.CompositingQuality = CompositingQuality.HighQuality; 
            g.SmoothingMode = SmoothingMode.HighQuality; 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic; 
            g.DrawImage(iSource, new Rectangle(0, 0, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel); 
            g.Dispose(); 
            //以下代码为保存图片时，设置压缩质量 
            EncoderParameters ep = new EncoderParameters(); 
            long[] qy = new long[1]; 
            qy[0] = flag;//设置压缩的比例1-100 
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy); 
            ep.Param[0] = eParam; 
            try
            { 
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders(); 
                ImageCodecInfo jpegICIinfo = null; 
                for (int x = 0; x < arrayICI.Length; x++)
                { 
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    { 
                        jpegICIinfo = arrayICI[x]; 
                        break; 
                    } 
                } 
                if (jpegICIinfo != null)
                { 
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径 
                } 
                else
                { 
                    ob.Save(dFile, tFormat); 
                } 
                return true; 
            } 
            catch
            { 
                return false; 
            } 
            finally
            { 
                iSource.Dispose(); 
                ob.Dispose();

            } 
        }
        #endregion 
        /// <summary>
        /// The replace. 用正则表达式 去掉 特殊字符串
        /// </summary>
        /// <param name="regex">
        /// The regex.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Replace(Regex regex, string input)
        {
            string inputReplaced = null;

            inputReplaced = regex.Replace(input, " ");

            return inputReplaced;
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringToBase64(string str)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str));
        }

        /// <summary>
        /// Base64 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64ToString(string str)
        {
            return System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(str));
        }
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetIP()
        {
            string userHostAddress = string.Empty;
            //如果客户端使用了代理服务器，则利用HTTP_X_FORWARDED_FOR找到客户端IP地址
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]!=null)
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            } 
            //否则直接读取REMOTE_ADDR获取客户端IP地址
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            //前两者均失败，则利用Request.UserHostAddress属性获取IP地址，但此时无法确定该IP是客户端IP还是代理IP
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }
            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        ///<summary>
        ///替换html中的特殊字符
        ///</summary>
        ///<paramname="theString">需要进行替换的文本。</param>
        ///<returns>替换完的文本。</returns>
        public static string HtmlEncode(string theString)
        {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace(" ", "&nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("\'", "&#39;");
            theString = theString.Replace("\n", "<br/>");
            return theString;
        }
        ///<summary>
        ///恢复html中的特殊字符
        ///</summary>
        ///<paramname="theString">需要恢复的文本。</param>
        ///<returns>恢复好的文本。</returns>
        public static string HtmlDecode(string theString)
        { 
            theString = theString.Replace("&gt;", ">");
            theString = theString.Replace("&lt;", "<");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace("&quot;", "\"");
            theString = theString.Replace("&#39;", "\'");
            theString = theString.Replace("<br/>", "\n");
            return theString;
        }
        //判断中文字符(双字节字符)
        public static bool IsChinaString(string CString)
        {
            bool BoolValue = false;
            for (int i = 0; i < CString.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToChar(CString.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                {
                    BoolValue = false;
                }
                else
                {

                    return BoolValue = true;
                }
            }

            return BoolValue;

        } 
        /// <summary>
        /// Domain Name and https/http
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            // 是否为SSL认证站点
            string secure = HttpContext.Current.Request.ServerVariables["HTTPS"];
            string httpProtocol = (secure == "on" ? "https://" : "http://");
            // 服务器名称
            string serverName = HttpContext.Current.Request.ServerVariables["Server_Name"];
            string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            // 应用服务名称
            string applicationName = HttpContext.Current.Request.ApplicationPath;

            string PathRoot = "";
            if(port !="80")
            {
                PathRoot = httpProtocol + serverName  + applicationName;
            }
            else
            {
                PathRoot = httpProtocol + serverName + (port.Length > 0 ? ":" + port : string.Empty) + applicationName;
            }
            return PathRoot;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImgUrl">RootPath+ImgUrl</param>
        /// <param name="maxwidth">etc : max-width:100px;</param>
        /// <returns></returns>
        public static string RenderImg(string ImgUrl,string maxwidth)
        {
            string RootPath = GetRootPath();
            
            if (!string.IsNullOrEmpty(ImgUrl))
            {
                ImgUrl = RootPath + ImgUrl;
                return string.Format("<a href=\"{0}\" target=\"_blank\"><img src=\"{0}\" style=\"max-width:{1}; \" alt=\"\" /></a>", ImgUrl , maxwidth);
            }else
            {
                return string.Empty;
            }
        }

        
        /// 记录文本文件日志方法
        /// </summary>
        /// <param name="FileContent">需要记录的文件内容</param>
        /// <param name="TxtFileName">保存的文件名</param>
        /// <param name="ErrMsg">错误信息</param>
        /// <returns></returns>
        public static bool OperateLoger(string FileContent)
        { 
            StreamWriter writer = null;
            string sCurDate = System.DateTime.Now.ToString("yyyy-MM-dd");
            string sFile =Path.Combine( AppDomain.CurrentDomain.BaseDirectory + "Operatebugrecord.log");
            try
            {
                if (File.Exists(sFile))
                    writer = new StreamWriter(sFile, true, System.Text.Encoding.GetEncoding("UTF-8"));
                else
                {
                    // when 15th per month to clear all data.
                    bool IsAppend = DateTime.Now.Day == 15 ? true : false;
                    writer = new StreamWriter(sFile, false, System.Text.Encoding.GetEncoding("UTF-8"));
                } 
                
                string sDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                writer.WriteLine("<" + sDateTime + "> " + " " + FileContent);
            }
            catch  //(IOException e)
            { 
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            return true;
        }

        public static string Substr(string str,int Lenght)
        {
            if(string.IsNullOrEmpty(str))
            {
                return str;
            }
            str = str.Replace("\"","");
            str = str.Replace("'", "");
            if (str.Length > Lenght)
            {
                return str.Substring(0, Lenght);
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// 移除電話前面的國家代碼 以適應WhatsApp的格式
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static string removePhoneAreaCode(string phoneNumber)
        {
            string[] keywords = { "+852", "+852", "+86", "+65", "+886", "+81" };
            string[] specialChar = { "+", "-", " " };

            foreach (string item in keywords)
            {
                if (phoneNumber.Contains(item))
                    phoneNumber = phoneNumber.TrimStart(item.ToArray());
            }
            foreach (string item in specialChar)
            {
                if (phoneNumber.Contains(item))
                    phoneNumber = phoneNumber.TrimStart(item.ToArray());
            } 
           
            phoneNumber = phoneNumber.Trim();

            return phoneNumber;
        }

        /// <summary>
        /// 解析店鋪價格表達格式
        /// </summary>
        /// <param name="ShopCurrency">zh-CN|zh-HK|en-US</param>
        /// <returns></returns>
        public static string GetShopPriceByShopCurrency(string price ,string ShopCurrency)
        {
             if(!string.IsNullOrEmpty(ShopCurrency))
            { 
                if (string.IsNullOrEmpty(price) )
                {
                    return "HK$0.0";
                }
                else
                {
                    if (price.StartsWith("HK$") || price.StartsWith("CN¥") || price.StartsWith("US$"))
                    {
                        return price;
                    }
                    switch(ShopCurrency)
                    {
                        case "zh-HK":
                            return $"HK${price}";
                        case "zh-CN":
                            return $"CN¥{price}";
                        case "en-US":
                            return $"US${price}";
                        default:
                            return $"HK${price}";
                    } 
                }
            }
            else
            {
                return price;
            }
        }
    }
}

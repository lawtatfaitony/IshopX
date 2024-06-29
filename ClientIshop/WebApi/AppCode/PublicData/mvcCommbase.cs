using System;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Globalization; 
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D; 
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using WebApi.AppCode.PublicData;

namespace WebApi.Utilities
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
                return PicUrl;
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
        
        public static string SHA1_Hash(string str_sha1_in)
        {
            if(string.IsNullOrEmpty(str_sha1_in))
            {
                return str_sha1_in;
            }
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out;
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
            string oPath = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = string.Format("{0}\\{1}", oPath, "Operatebugrecord.log"); // Path.Combine( AppDomain.CurrentDomain.BaseDirectory + "Operatebugrecord.log");
             
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
        /// <summary>
        /// getinfolist
        /// </summary>
        /// <param name="FileContent"></param>
        /// <returns></returns>
        public static bool SaveJson(string oPath, string FileName, string FileContent)
        {
            StreamWriter writer = null; 
           
            string targetPathFile = string.Format("{0}\\{1}", oPath, FileName);

            mvcCommeBase.OperateLoger("mvcCommeBase>OperateLoger> SaveJson=>App Catalog::>" + targetPathFile + " || " + DateTime.Now.ToString());
            try
            {
                if (!Directory.Exists(oPath))
                {
                    Directory.CreateDirectory(oPath);
                }
                bool IsAppend = false;
                writer = new StreamWriter(targetPathFile, IsAppend, System.Text.Encoding.GetEncoding("UTF-8")); 
                writer.Write(FileContent); //writer.WriteLine(FileContent);
                writer.Close();
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
        //remain
        public static object SaveJsonReturnObject(string jsonData,IHostingEnvironment hostingEnvironment,string SubJsonDataPath, string FileName,DateTime dataUpdDateTime)
        {
            StreamWriter writer = null;
            string oPath   = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}", hostingEnvironment.WebRootPath, "ClientApp","jsonData", SubJsonDataPath);
            string sFile  = string.Format("{0}\\{1}", oPath, FileName); 
            bool IsAppend = false; //rewrite the file
            object m = new object();
            try
            {
                //rewrite or not
                if (File.Exists(sFile))
                { 
                    DateTime lastAccessTime = File.GetLastWriteTime(sFile);
                    if(dataUpdDateTime> lastAccessTime)  //case: rewrite the  file
                    { 
                        writer = new StreamWriter(sFile, IsAppend, System.Text.Encoding.GetEncoding("UTF-8"));
                        writer.Write(jsonData);  
                        writer.Flush();
                        writer.Close();
                    }
                }else
                {
                    if (!Directory.Exists(oPath))
                    {
                        Directory.CreateDirectory(oPath);
                    }
                    writer = new StreamWriter(sFile, IsAppend, System.Text.Encoding.GetEncoding("UTF-8"));
                    writer.Write(jsonData);  
                    writer.Flush();
                    writer.Close();
                }
                 
                using (FileStream fs = new FileStream(sFile, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("UTF-8")))
                    {
                        string JsonFileText = sr.ReadToEnd().ToString(); 
                        m = JsonConvert.DeserializeObject<object>(JsonFileText, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });  
                    }
                }
                return m;
            }
            catch(Exception ex)
            { 
                mvcCommeBase.OperateLoger(string.Format("mvcCommeBase>SaveJsonReturnObject> {0}=>catch::{1} > || {2}" , "infoIDs", ex.Message, DateTime.Now)); 
                return m;
            } 
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
    }
}

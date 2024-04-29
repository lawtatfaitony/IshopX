using System; 
using System.Collections.Generic; 
using System.Drawing; 
using System.IO;
using System.Linq;
using System.Net;
using System.Text;   
using System.Configuration; 
using System.Text.RegularExpressions;

namespace Common
{
    public partial class CommonBase
    {
        /// <summary>
        /// 判断空字符串以及截断过长字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringNullRet(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            if (str.Length > 50)
                str = str.Substring(0,49);
            return str;
        }
        public static string Substr(string str, int Lenght)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            str = str.Replace("\"", "");
            str = str.Replace("'", "");
            if (str.Length > Lenght)
            {
                return string.Format("{0}…", str.Substring(0, Lenght));
            }
            else
            {
                return str;
            }
        }
        public static string Substr2(string str,int StartIndex ,int Lenght)
        {
            if (string.IsNullOrEmpty(str) || str.Length < StartIndex)
            {
                return str;
            }
            str = str.Replace("\"", "");
            str = str.Replace("'", "");
            if (str.Length - StartIndex >= Lenght)
            {
                return string.Format("{0}…", str.Substring(StartIndex, Lenght));
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// this("ABC123456",0,3)="123456.." 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="StartIndex"></param>
        /// <param name="RemoveLenght"></param>
        /// <returns></returns>
        public static string Substr3(string str, int StartIndex,int RemoveLenght)
        {
            if (string.IsNullOrEmpty(str) || str.Length < StartIndex)
            {
                return str;
            }
            str = str.Replace("\"", "");
            str = str.Replace("'", "");
            if (str.Length > StartIndex + RemoveLenght)
            {
                return string.Format("{0}…", str.Remove(StartIndex, RemoveLenght));
            }
            else
            {
                return str;
            }
        }
        public static string SubstrX(string str, int StartIndex, int RemoveLenght)
        {
            if (string.IsNullOrEmpty(str) || str.Length < StartIndex)
            {
                return str;
            }
            str = str.Replace("\"", "");
            str = str.Replace("'", "");
            string str1=""; 
            string str2 = "";
            string strx = str;
            if (str.Length > StartIndex)
            {
                str1 = str.Substring(0, StartIndex);
                strx = string.Format("{0}…{1}", str1, str2);
            }
            if (str.Length > StartIndex + RemoveLenght)
            {
                str2 = str.Remove(0,StartIndex + RemoveLenght);
                strx = string.Format("{0}…{1}", str1, str2);
            }
              
            return strx;
        }
        /// <summary>
        /// this("ABC123456",0,3)="..123456" 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="StartIndex"></param>
        /// <param name="RemoveLenght"></param>
        /// <returns></returns>
        public static string SubstrPrefix(string str, int StartIndex, int RemoveLenght)
        {
            if (string.IsNullOrEmpty(str) || str.Length < StartIndex)
            {
                return str;
            }
            str = str.Replace("\"", "");
            str = str.Replace("'", "");
            if (str.Length > StartIndex + RemoveLenght)
            {
                return string.Format("…{0}", str.Remove(StartIndex, RemoveLenght));
            }
            else
            {
                return str;
            }
        }
        private static readonly char[] constantNumber =
        {
               '0','1','2','3','4','5','6','7','8','9'
        };
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
        public static string TransHtmlBr(string theString,string toStr)
        { 
            theString = theString.Replace("<br>", toStr);
            return theString;
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringToBase64(string value)
        {
            //return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str));

            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes); 
        }

        /// <summary>
        /// Base64 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64ToString(string value)
        {
            //if (string.IsNullOrEmpty(str))
            //    return string.Empty;

            //return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(str));

            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes); 
        }

        /// <summary>
        /// 去掉字符串中的数字
        /// </summary>
        public static string RemoveNumber(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }

        /// <summary>
        /// 去掉字符串中的非数字
        /// </summary>
        public static string RemoveNotNumber(string key)
        {
            return Regex.Replace(key, @"[^\d]*", "");
        }
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
         
        public static bool IsNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
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
        /// <summary>
        /// 判断输入的字符串是否全是英文字母
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsLetter(string input)
        {
            string pattern = @"^[A-Za-z]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        } 
        public static bool IsDigitAndLetter(string strMessage, int iMinLong, int iMaxLong)
        {
            bool bResult = false;
            string pattern = @"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9a-zA-Z]+$"; 
            if (strMessage.Length >= iMinLong && strMessage.Length <= iMaxLong)//判断字符串长度
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(strMessage, pattern))
                {
                    bResult = true;
                }
                else
                {
                    bResult = false;
                }
            }

            return bResult;
        }
        public static bool IsDigitOrLetter(string strMessage, int iMinLong, int iMaxLong)
        {
            bool bResult = false;

            //开头匹配一个字母或数字+匹配两个十进制数字+匹配一个字母或数字+匹配两个相同格式的的（-加数字）+已字母或数字结尾
            //如：1111-111-1119
            //string pattern = @"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$";

            //string pattern = @"^[a-zA-Z0-9]\d{2}$"; //开头以字母或数字，然后后面加两个数字字符

            string pattern = @"^[a-zA-Z0-9]*$"; //匹配所有字符都在字母和数字之间

            //string pattern = @"^[a-z0-9]*$"; //匹配所有字符都在小写字母和数字之间

            //string pattern = @"^[A-Z][0-9]*$"; //以大写字母开头，后面的都是数字

            //string pattern = @"^\d{3}-\d{2}$";//匹配 333-22 格式,三个数字加-加两个数字

            if (strMessage.Length >= iMinLong && strMessage.Length <= iMaxLong)//判断字符串长度
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(strMessage, pattern))
                {
                    bResult = true;
                }
                else
                {
                    bResult = false;
                }
            }

            return bResult;
        }

        /// <summary>
        /// 中文名字输出优先 限定最少2个汉字 英文限定10个字母 输出二选一 中或英
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static void SplitChineseAndEng(string text, out string name)
        {
            char[] chi = new char[3];
            char[] eng = new char[10];
            int j = 0;
            int k = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Regex.IsMatch(text[i].ToString(), @"[\u4e00-\u9fbb]"))
                {
                    if (j <= 2) //限定三个汉字
                    {
                        chi.SetValue(text[i], j);
                    }

                    j++;
                }
                else
                {
                    if (k <= 9) //限定10个英文字符
                    {
                        eng.SetValue(text[i], k);
                    }
                    k++;
                }
            }

            if (j >= 2)
            {
                name = string.Join("", chi);
            }
            else
            {
                name = string.Join("", eng);
            }
        }

        /// <summary>
        /// 中文名字优先 限定3个汉字 英文限定10个字母 输出二选一 中或英
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static void SplitChineseAndEng(string text, int maxChinese, int maxEnglish, out string name)
        {
            char[] chi = new char[maxChinese];
            char[] eng = new char[maxEnglish];
            int j = 0;
            int k = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Regex.IsMatch(text[i].ToString(), @"[\u4e00-\u9fbb]"))
                {
                    if (j <= maxChinese - 1) //限定三个汉字
                    {
                        chi.SetValue(text[i], j);
                    }

                    j++;
                }
                else
                {
                    if (k <= maxEnglish - 1) //限定10个英文字符
                    {
                        eng.SetValue(text[i], k);
                    }
                    k++;
                }
            }

            if (j >= 2)
            {
                name = string.Join("", chi);
            }
            else
            {
                name = string.Join("", eng);
            }
        }
    }
    
}

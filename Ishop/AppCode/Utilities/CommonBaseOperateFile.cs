﻿using System; 
using System.Collections.Generic; 
using System.Drawing; 
using System.IO;
using System.Linq;
using System.Net;
using System.Text;   
using System.Configuration;

using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Ishop.Appcode.Utilities;

namespace Common
{
    public partial class CommonBase
    { 

        public enum LoggerMode
        {
            DEBUG=-1,
            INFO = 0,
            WARNNING = 1,
            ERROR = 2,
            FATAL = 3
        }
        public static bool SaveImage(string Path1, string FileName, string PhotoBase64)
        {
            string PathFileName = Path.Combine(Path1, FileName);
            byte[] bt = Convert.FromBase64String(PhotoBase64);

            if (System.IO.Directory.Exists(Path1) == false)
            {
                System.IO.Directory.CreateDirectory(Path1);
            }
            try
            {
                File.WriteAllBytes(PathFileName, bt);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static string ReadConfigJson(string  PathFileName)
        {
            if(File.Exists(PathFileName))
            {
                string content = File.ReadAllText(PathFileName, Encoding.UTF8);
                return content;
            }else
            {
                return string.Empty;
            }
           
        }
        public static bool SaveDataJson(string FileContent,string PathFile)
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
        public static bool SaveDataJson(string fileContent, string path, string targetFileName)
        {
            StreamWriter writer = null;
            try
            {
                if (System.IO.Directory.Exists(path) == false)
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                string PathFile = Path.Combine(path, targetFileName);
                writer = new StreamWriter(PathFile, false, System.Text.Encoding.GetEncoding("UTF-8"));
                writer.Write(fileContent);
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

        public static string ReadDataFromJson( string path, string targetFileName)
        {
            string PathFileName = Path.Combine(path, targetFileName);
            if (File.Exists(PathFileName))
            {
                string content = File.ReadAllText(PathFileName, Encoding.UTF8);
                return content;
            }
            else
            {
                return string.Empty;
            }  
        }
        public static string ReadDataFromJson(string PathFileName)
        { 
            if (File.Exists(PathFileName))
            {
                string content = File.ReadAllText(PathFileName, Encoding.UTF8);
                return content;
            }
            else
            {
                return string.Empty;
            }
        }
        public static bool CopyToFolder(string TargetPath, string TargetFileName, string SourcePathFileName)
        {
            string TargetPathFileName = Path.Combine(TargetPath, TargetFileName);
             
            if (!System.IO.Directory.Exists(TargetPath) )
            {
                System.IO.Directory.CreateDirectory(TargetPath);
            }
            try
            {
                File.Copy(SourcePathFileName, TargetPathFileName, true);
                return true;
            }
            catch
            {
                return false;
            } 
        }

        #region 
        public static bool WriteLogNtimes(string LineContent, LoggerMode loggerMode)
        {
            string dateTimeLineLog = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] {1}", DateTime.Now, LineContent);
            Logger logger = new Logger { LoggerLine = dateTimeLineLog, loggerMode = loggerMode }; 
            LoggerQueueHelper.instance.AddData(logger); 
            bool AnalysisStatus = LoggerQueueHelper.instance.AnalysisStatus; 
            if (!AnalysisStatus)
            { 
                if (LoggerQueueHelper.instance.Getcount() > 0)
                { 
                    LoggerQueueHelper.instance.PostAnalysis();
                }
            }
            return true;
        }
        public static bool OperateLoger(string LineContent)
        {
            bool result = WriteLogNtimes(LineContent, LoggerMode.INFO);  //修改为强行加入LoggerMode.INFO
            return result;
        } 
         
        #endregion

        #region  Date Loger
        public static bool OperateDateLoger(string LineContent)
        {
            bool result = WriteLogNtimes(LineContent, LoggerMode.INFO);  //修改为强行加入LoggerMode.INFO
            return result;
        }
        public static bool OperateDateLoger(string LineContent,LoggerMode loggerMode)
        {
            bool result = WriteLogNtimes(LineContent, loggerMode);  //修改为强行加入LoggerMode.INFO
            return result;
        }
        public static bool EntryImageLoger(string LineEntryImage)
        {
            bool result = WriteLogNtimes(LineEntryImage, LoggerMode.INFO);
            return result;
        }
        #endregion
        public static string GetSystemDriveLogPath()
        {
            string path;
            string Systemdrive = Environment.GetEnvironmentVariable("systemdrive");
            Systemdrive = string.Format("{0}\\", Systemdrive);
            path = Path.Combine(Systemdrive, "log");
             
            if (System.IO.Directory.Exists(path) == false)
            {
                System.IO.Directory.CreateDirectory(path);
            }
            return path;
        }

        public static bool IsConsoleOrWinformPath()
        {
            string EnvPath = System.Environment.CurrentDirectory.TrimEnd('\\');
            string BaseDirPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); 
            return EnvPath == BaseDirPath;
        }

        #region 把字符串转换成 byte 的二进制流。
        /// <summary>
        /// 把字符串转换成 byte 的二进制流。
        /// </summary>
        /// <param name="strmemo"></param>
        /// <param name="enc">字节流的编码方式，例如 Encoding.UTF7，Encoding.UTF8; Encoding.Unicode;</param>
        /// <returns></returns>
        public static MemoryStream GetMemoryStream(string strmemo, Encoding enc)
        {
            if (strmemo == string.Empty)
            {
                return null;
            }
            Byte[] btMemo = enc.GetBytes(strmemo);
            MemoryStream ms = new MemoryStream(btMemo);
            return ms;
        }
        public static MemoryStream GetMemoryStream(string strmemo)
        {
            return GetMemoryStream(strmemo, Encoding.UTF8);
        }
        #endregion
    }


}

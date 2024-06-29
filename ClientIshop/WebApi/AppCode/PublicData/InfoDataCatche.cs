using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.ModelView;
using WebApi.Utilities;

namespace WebApi.AppCode.PublicData
{
    public static class JsonDataDir
    {
        public static string userInfoList = "userInfoList";
        public static string UserTrace = "UserTrace";
    }
    public class InfoDataCatche
    {
        private readonly static ApplicationDbContext db = new ApplicationDbContext();
        private readonly static IHttpContextAccessor httpContextAccessor;
        //private readonly static IHostingEnvironment hostingEnvironment;
        public static IEnumerable<InfoDetail> SaveJsonReturnInfoRalateList(IHostingEnvironment hostingEnvironment, UserTraceInfoIDset userTraceInfoIDset, DateTime dataUpdDateTime,int row)
        {
            string FileName = userTraceInfoIDset.ShopId + "_" + userTraceInfoIDset.UserId + ".json";
            StreamWriter writer = null;
            string oPath = string.Format("{0}\\{1}\\{2}", hostingEnvironment.WebRootPath,  "jsonData", JsonDataDir.userInfoList);
            string sFile = Path.Combine(oPath + "\\" + FileName);
            sFile = string.Format("{0}\\{1}", oPath, FileName);
            bool IsAppend = false; //rewrite the file
            IEnumerable<InfoDetail> m ;
            string jsonData;
            try
            { 
                //rewrite or not
                if (File.Exists(sFile))
                {
                    DateTime lastAccessTime = File.GetLastWriteTime(sFile);
                    if (dataUpdDateTime > lastAccessTime)  //case: rewrite the  file
                    {
                        m = getShopUserTraceRalateList(userTraceInfoIDset, row);
                        jsonData = JsonConvert.SerializeObject(m);
                        writer = new StreamWriter(sFile, IsAppend, System.Text.Encoding.GetEncoding("UTF-8"));
                        writer.Write(jsonData);
                        writer.Flush();
                        writer.Close();
                        mvcCommeBase.OperateLoger(string.Format("SaveJsonReturnInfoRalateList> {0}=>catch::{1} > || {2}", userTraceInfoIDset, sFile, DateTime.Now));
                    }
                }
                else
                {
                    if (!Directory.Exists(oPath))
                    {
                        Directory.CreateDirectory(oPath);
                    }

                    m = getShopUserTraceRalateList(userTraceInfoIDset, row);
                    jsonData = JsonConvert.SerializeObject(m);

                    writer = new StreamWriter(sFile, IsAppend, System.Text.Encoding.GetEncoding("UTF-8"));
                    writer.Write(jsonData);
                    writer.Flush();
                    writer.Close();
                    mvcCommeBase.OperateLoger(string.Format("SaveJsonReturnInfoRalateList> {0}=>catch::{1} > || {2}", userTraceInfoIDset, sFile, DateTime.Now));
                }

                using (FileStream fs = new FileStream(sFile, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("UTF-8")))
                    {
                        string JsonFileText = sr.ReadToEnd().ToString();
                        m = JsonConvert.DeserializeObject<IEnumerable<InfoDetail>>(JsonFileText, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });
                    }
                }
                return m;
            }
            catch (Exception ex)
            {
                mvcCommeBase.OperateLoger(string.Format("mvcCommeBase>SaveJsonReturnObject> {0}=>catch::{1} > || {2}", "infoIDs", ex.Message, DateTime.Now));
                return null;
            }
        }
        public static IEnumerable<InfoDetail> getShopUserTraceRalateList(UserTraceInfoIDset userTraceInfoIDset,int row)
        {
            var TopView = db.InfoDetail.Where(c => c.InfoId != userTraceInfoIDset.InfoId && c.ShopId == userTraceInfoIDset.ShopId).OrderByDescending(s => s.Views).Take(row).ToList();
            InfoPublic infoPublic = new InfoPublic();
            List<InfoDetail> infoDetailsList = new List<InfoDetail>();
            foreach (var item in TopView)
            {
                item.UserTraceId = InfoPublic.CreateUserTrace(item.InfoId, userTraceInfoIDset.UserId, item.ShopId);
                item.InfoDescription = string.Empty;
                infoDetailsList.Add(item);
            }
            return infoDetailsList;
        }
        /// <summary>
        /// SaveJsonRtnUserTraceInfoIDset
        /// UserTraceId = ShopId +UserId + InfoId    : example: sh0006620002Inf000000089 
        /// and then Sha the string by Leter Order plus
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="UserTraceId"></param>
        /// <returns></returns>
        public static UserTraceInfoIDset SaveJsonRtnUserTraceInfoIDset(IHostingEnvironment hostingEnvironment, string UserTraceId)
        {
            string FileName = UserTraceId + ".json";
            StreamWriter writer = null;
            string oPath = string.Format("{0}\\{1}\\{2}", hostingEnvironment.WebRootPath, "jsonData", JsonDataDir.UserTrace);
            string sFile = string.Format("{0}\\{1}", oPath, FileName);
            bool IsAppend = false; //rewrite the file
            UserTraceInfoIDset userTraceInfoIDset = new UserTraceInfoIDset() ;
            try
            {
                //rewrite or not
                if (!File.Exists(sFile))
                {
                    UserTrace userTrace = db.UserTrace.Find(UserTraceId);
                    userTraceInfoIDset.InfoId = userTrace.TableKeyId.Trim();
                    userTraceInfoIDset.ShopId = userTrace.ShopId.Trim();
                    userTraceInfoIDset.UserTraceId = userTrace.UserTraceId.Trim();
                    userTraceInfoIDset.UserId = userTrace.UserId.Trim();
                    userTraceInfoIDset.CreatedDate = userTrace.OperatedDate;
                    string HashStr = userTraceInfoIDset.InfoId + userTraceInfoIDset.ShopId + userTraceInfoIDset.UserTraceId + userTraceInfoIDset.UserId + userTraceInfoIDset.CreatedDate.ToString("yyyyMMddHHmmssffff");
                    userTraceInfoIDset.VerifiedSHA = mvcCommeBase.GetHash(HashStr);

                    string jsonData = JsonConvert.SerializeObject(userTraceInfoIDset);

                    if (!Directory.Exists(oPath))
                    {
                        Directory.CreateDirectory(oPath);
                    }
                    writer = new StreamWriter(sFile, IsAppend, System.Text.Encoding.GetEncoding("UTF-8"));
                    writer.Write(jsonData);
                    writer.Flush();
                    writer.Close();
                }

                using (FileStream fs = new FileStream(sFile, FileMode.Open, System.IO.FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("UTF-8")))
                    {
                        string JsonFileText = sr.ReadToEnd().ToString();
                        userTraceInfoIDset = JsonConvert.DeserializeObject<UserTraceInfoIDset>(JsonFileText, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });
                    }
                }
                return userTraceInfoIDset;
            }
            catch (Exception ex)
            {
                mvcCommeBase.OperateLoger(string.Format("SaveJsonRtnUserTraceInfoIDset :: =>catch::{0} > || ,UserTraceId::{1}", ex.Message, DateTime.Now));
                return null;
            }
        }

        public static IEnumerable<InfoDetail> GetInfolistCache(string cloudHost, string oPath,string FileName,string ShpId, string RecommUserId, int pageX, int pageSize)
        {
            Console.WriteLine("oPath: {0}", oPath);

            int pageNumber = pageX == 1 ? 1 : pageX;
            var ShopInfolist = db.InfoDetail.Where(c => c.ShopId == ShpId).OrderByDescending(s => s.Views).ToList();
            IEnumerable<InfoDetail> result = ShopInfolist.ToPagedList(pageSize, pageNumber);
            List<InfoDetail> list = new List<InfoDetail>();
            foreach (var item in result)
            {
                item.UserTraceId = InfoPublic.CreateUserTrace(item.InfoId, RecommUserId, ShpId);
                if (!item.TitleThumbNail.Contains(cloudHost))
                {
                    item.TitleThumbNail = $"{cloudHost}{PictureSuffix.ReturnSizePicUrl(item.TitleThumbNail, PictureSize.s250X250)}";
                }
                   
                item.InfoDescription = string.Empty;
                list.Add(item);
            }
            //save json
            string json = JsonConvert.SerializeObject(list.ToList());
            mvcCommeBase.SaveJson(oPath, FileName, json); 
            return list.ToList();
        }
   
        /// <summary>
        /// 轉換為雲端 IMG URL
        /// </summary>
        /// <param name="cloudHost"></param>
        /// <returns></returns>
        public static string TransCloudHostUrlImg(string cloudHost, string relativeImgPath)
        { 
            if (!relativeImgPath.Contains(cloudHost))
            {
                relativeImgPath = $"{cloudHost}{relativeImgPath}";
            }
            return relativeImgPath;
        }  
    }
}

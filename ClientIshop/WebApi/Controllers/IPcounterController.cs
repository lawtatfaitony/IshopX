using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.AppCode.Utilities;
using WebApi.Models;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public enum SourceStatisticStatus
    {
        InValid = 0,
        IsValid = 1
    }
   
    [ApiController]
    public class IPcounterController : ControllerBase
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public string UserName = "NickName";

        private readonly IHttpContextAccessor httpContextAccessor;
        public IPcounterController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("[controller]/[action]/{RecommUserId}/{ShopID}/{TableKeyID}/{Title}")]
        public string IPstatiticsAdd(string RecommUserId, string ShopID,string TableKeyID, string Title)
        {
            //this.IpStatitics_Token();
            string UserId = "";
            string Ip = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            
            int Duration = 0;
            //Ip =  // httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault(); 
            string SourceArea = string.Empty;
            string OSVersion = string.Empty;
            string SourceUrl = "";

            DateTime CreatedDate = DateTime.Now;
            DateTime LastUpdateDate = CreatedDate;

            SourceStatistic sourceStatistic = new SourceStatistic { TableKeyId = TableKeyID, Title = Title, Osversion = OSVersion, UserId = UserId, RecommUserId = RecommUserId, Ip = Ip, SourceArea = SourceArea, SourceUrl = SourceUrl, Duration = Duration, CreatedDate = CreatedDate, LastUpdateDate = LastUpdateDate, ShopId = ShopID, Status = 0 };
            //query current article the same day record exist or not 
            var SourceStatistics = db.SourceStatistic.Where(c => c.TableKeyId == TableKeyID && c.Ip == Ip && c.CreatedDate.Day == DateTime.Now.Day && c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year).ToList();
            if (SourceStatistics.Count() == 0)
            {
                try
                {
                    db.SourceStatistic.Add(sourceStatistic);
                    db.SaveChanges(); 
                }
                catch (Exception e)
                {
                    string operateLog = string.Format("IpStatistc>IPstatiticsAdd >case :AddNew TableKeyID ={0}, Title = {1}, OSVersion = {2}, UserId = {3}, RecommUserId = {4}, IP = {5}, SourceArea = {6}, SourceUrl = {7}, Duration = {8}, CreatedDate = {9}, LastUpdateDate = {10}, ShopID = {11}, Status = {12} ,Message = {13}", sourceStatistic.TableKeyId, sourceStatistic.Title, sourceStatistic.Osversion, sourceStatistic.UserId, sourceStatistic.RecommUserId, sourceStatistic.Ip, sourceStatistic.SourceArea, sourceStatistic.SourceUrl, sourceStatistic.Duration, sourceStatistic.CreatedDate, sourceStatistic.LastUpdateDate, sourceStatistic.ShopId, SourceStatisticStatus.InValid, e.Message);
                    mvcCommeBase.OperateLoger(operateLog);
                }

                //UserFinanceItem
                if (!string.IsNullOrEmpty(RecommUserId))
                {
                    CreateUserFinanceItem(sourceStatistic.SourceStatisticsId.ToString(), 0.5m, RecommUserId, ShopID);  //0.5m  : explicit type decimal
                }
                return sourceStatistic.SourceStatisticsId.ToString();
            }
            else
            {
                try
                {
                    SourceStatistic SourceStatistic2 = SourceStatistics.FirstOrDefault();
                    SourceStatistic2.LastUpdateDate = DateTime.Now;
                    SourceStatistic2.Duration += 1;
                    db.SourceStatistic.Attach(SourceStatistic2);
                    db.SaveChanges();

                    return SourceStatistic2.SourceStatisticsId.ToString();
                }
                catch (Exception e)
                {
                    string operateLog = string.Format("IPstatiticsAdd >case UPDATE FAIL:LastUpdateDate ={0} ,Message ={1}", DateTime.Now, e.Message);
                    mvcCommeBase.OperateLoger(operateLog);
                    return "0";
                }
            }
        }
        /// <summary>
        /// Record Count  and  Token Verification
        /// </summary>
         
        private bool IpStatitics_VirifyToken(string IpStatitics_StartDate_Token)
        {
            ////Temp Test
            //return true;

            ////Record Count  and  Token Verification
            string IpStatitics_StartDate = "";

            if (this.httpContextAccessor.HttpContext.Request.Cookies["IpStatitics_StartDate"] != null)
            {
                this.httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("IpStatitics_StartDate", out IpStatitics_StartDate);
                IpStatitics_StartDate = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);

                if (IpStatitics_StartDate == IpStatitics_StartDate_Token)
                {
                    // verified to pass 
                    return true;
                }
                else
                {
                    //nothing to do  : verified = false
                    return false;
                }
            }
            else
            {
                //nothing to do  : verified = false
                return false;
            }

        }
        
        /// <summary>
        /// IP Statement IPstatitics  params order by leter dictionary 
        /// </summary>
        /// <param name="SourceStatisticsID"></param>
        /// <param name="IntervalMinutes"></param> 
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]/[action]/{IntervalMinutes}/{IpStatitics_StartDate_Token}/{SourceStatisticsID}")]
        public IActionResult IPstatitics( string IntervalMinutes, string IpStatitics_StartDate_Token, string SourceStatisticsID)
        {
            if (this.IpStatitics_VirifyToken(IpStatitics_StartDate_Token))
            {
                //Insert or update statistics after verifying incoming data 
                SourceStatistic sourceStatistic = db.SourceStatistic.Find(int.Parse(SourceStatisticsID));
                sourceStatistic.Duration += decimal.Round(decimal.Parse(IntervalMinutes), 1);
                sourceStatistic.Duration = decimal.Round(sourceStatistic.Duration, 1);
                sourceStatistic.LastUpdateDate = DateTime.Now;
                db.Entry(sourceStatistic).State = EntityState.Modified;
                int Result = db.SaveChanges();

                if (Result > 0)
                { 
                    Dictionary<string, int> result = new Dictionary<string, int> { { "result", 1 } };
                    return Ok(result);
                }
                else
                {
                    Dictionary<string, int> result = new Dictionary<string, int> { { "result", 0 } };
                    return Ok(result);
                }
            }
            else
            {
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", -1 } };
                return Ok(result);
            }

        }
        //https://localhost:44363/api/IPcounter/PageLoadingTimesCounter/32615/57536/Windows/jttp:sdfsfsdf.com/201903300119366054
        
        [HttpGet] 
        [Route("[controller]/[action]/{SourceStatisticsID}/{loadTime}/{OSVersion}/{SourceUrl}/{IpStatitics_StartDate_Token}")]
        public IActionResult PageLoadingTimesCounter(int SourceStatisticsID, int loadTime, string Osversion,string SourceUrl,string IpStatitics_StartDate_Token)
        { 
            SourceStatistic SourceStatistics = db.SourceStatistic.Find(SourceStatisticsID);
            
            bool bSourceUrl = string.IsNullOrEmpty(SourceStatistics.SourceUrl);
            bool bOsversion = string.IsNullOrEmpty(SourceStatistics.Osversion);
            bool bSourceArea = string.IsNullOrEmpty(SourceStatistics.SourceArea);

            if (SourceStatistics != null)
            {
               
                EntityEntry<SourceStatistic> SourceStatisticEntry = db.Entry<SourceStatistic>(SourceStatistics);
                SourceStatistics.LoadTime = loadTime;
                SourceStatistics.SourceUrl = SourceUrl;
                SourceStatistics.Osversion = Osversion;

                if(string.IsNullOrEmpty(SourceStatistics.SourceArea)|| SourceStatistics.SourceArea.Contains("::1"))
                {
                    string SourceArea = AliyunIP.IpQuery(SourceStatistics.Ip); 
                    SourceStatistics.SourceArea = SourceArea;
                } 

                db.SourceStatistic.Attach(SourceStatistics); 
                SourceStatisticEntry.Property(e => e.LoadTime).IsModified = true;
                SourceStatisticEntry.Property(e => e.SourceUrl).IsModified = bSourceUrl;
                SourceStatisticEntry.Property(e => e.Osversion).IsModified = bOsversion;
                SourceStatisticEntry.Property(e => e.SourceArea).IsModified = bSourceArea;

                db.SaveChanges();

                Dictionary<string, int> result = new Dictionary<string, int> { { "result", SourceStatistics.SourceStatisticsId } };
                return Ok(result);
            }
            else
            {
                Dictionary<string, int> result = new Dictionary<string, int> { { "result", 0 } };
                return Ok(result);

            } 
        }
         
        private void CreateUserFinanceItem(string TblKeyId, decimal ItemAmount, string RecommUserId, string ShopId)
        {
            string OperateLog = "";
            string UserFinanceItemID = db.GetTableIdentityID("FI", "UserFinanceItem", 12);
            RecommUserId = GetDefaultRecommUserId(RecommUserId, ShopId);

            UserFinanceItem userFinanceItem = new UserFinanceItem
            {
                UserFinanceItemId = UserFinanceItemID
                ,
                UserFinanceId = string.Empty
                ,
                UserId = RecommUserId
                ,
                ItemAmount = ItemAmount
                ,
                ShopId = ShopId
                ,
                CreatedDate = DateTime.Now
                ,
                OperatedDate = DateTime.Now
                ,
                StatusId = "Created"
                ,
                PromoteAndSalesChannel = 0
                ,
                TblKeyId = TblKeyId
            };
            try
            {
                db.UserFinanceItem.Add(userFinanceItem);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                OperateLog = string.Format("BaseCntroller.cs > CreateUserFinanceItem > case : SaveChanges : UserFinanceItemID={0} ,UserFinanceID={1},UserId={2} , ItemAmount={3}, ShopID = {4} ,CreatedDate = {5},OperatedDate = {6},StatusId = {7},TblKeyId = {8},EXCEPTION = {9}", UserFinanceItemID, userFinanceItem.UserFinanceId, userFinanceItem.UserId, userFinanceItem.ItemAmount, userFinanceItem.ShopId, userFinanceItem.CreatedDate, userFinanceItem.OperatedDate, userFinanceItem.StatusId, userFinanceItem.TblKeyId, e.Message);
                mvcCommeBase.OperateLoger(OperateLog);
            }

        }
        private string GetDefaultRecommUserId(string RecommUserId, string ShopId)
        {
            if (!string.IsNullOrEmpty(RecommUserId))
            {
                return RecommUserId;
            }
            RecommUserId = db.Shop.Find(ShopId).UserId;
            return RecommUserId;
        }
          
    }
     
}

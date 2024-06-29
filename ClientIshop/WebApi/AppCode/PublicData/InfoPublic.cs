using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AppCode.PublicData
{
    public class InfoPublic
    {
        private static readonly ApplicationDbContext db = new ApplicationDbContext();
        public static string CreateUserTrace(string TableKeyID, string UserId, string ShopID)
        {
            // new rule :
            string UserTraceID = ShopID + UserId + TableKeyID;
            //UserTrace userTrace = db.UserTrace.Where(c => c.TableKeyId.Contains(TableKeyID) && c.UserId == UserId).FirstOrDefault();
            UserTrace userTrace = db.UserTrace.Find(UserTraceID);

            if (userTrace == null)
            {
                //string UserTraceID = db.GetTableIdentityID("Tr", "UserTrace", 6);
                
                UserTrace userTrace1 = new UserTrace()
                {
                    UserTraceId = UserTraceID
                    ,
                    TableKeyId = TableKeyID
                    ,
                    UserId = UserId
                    ,
                    ShopId = ShopID
                    ,
                    OperatedUserName = "System"
                    ,
                    OperatedDate = DateTime.Now
                };
                db.UserTrace.Add(userTrace1);
                db.SaveChanges();
                return userTrace1.UserTraceId;
            }
            else
            {
                return userTrace.UserTraceId;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ishop.Context;
using Ishop.Models.UploadItem;
using System.Data.Entity;

namespace Ishop.AppCode.Utilities
{
    public  class AdditionalForUpload
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        /// <summary>
        /// case:insert,数据插入成功后,把临时的GUID更新为新的表格主键ID 
        /// </summary>
        /// <param name="TempID">临时的GUID</param>
        /// <param name="TargetTalbeKeyID">表格的主键ID,例如 ProductID=123</param>
        /// <returns></returns>
        public  bool AlterTempTargetTalbeKeyID(string TempID, string TargetTalbeKeyID)
        {
            try
            {
                var uploadItems = from s in db.UploadItems
                                  select s;
                uploadItems = uploadItems.Where(c => c.TargetTalbeKeyID == TempID); 
                  
                foreach (var  item in uploadItems)
                {
                    item.TargetTalbeKeyID = TargetTalbeKeyID;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                 
                return true;
            }
            catch 
            { 
                return false;
            }


        }
    }
}
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AttDataCore.Context;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace WebApi.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public string GetTableIdentityID(string prefix, string tableName, int lenght)
        {
            using (ApplicationDbContext dataBaseContext = new ApplicationDbContext())
            {
                if (dataBaseContext.Database.CanConnect())
                {
                    TableIdentity T = dataBaseContext.TableIdentity.Find(tableName);

                    if (T == null)
                    {
                        TableIdentity tableIdentity = new TableIdentity { TableIdentityId = 2000, TableName = tableName, OperatedDate = DateTime.Now };
                        dataBaseContext.TableIdentity.Add(tableIdentity);
                        bool retsult = dataBaseContext.SaveChanges() > 0;
                        if (retsult)
                        {
                            T = tableIdentity;
                        }
                    }
                    else
                    {
                        T.TableIdentityId += 1;
                        T.OperatedDate = DateTime.Now;
                        dataBaseContext.Update(T);
                        dataBaseContext.SaveChanges();
                    }
                    string NewID = prefix + T.TableIdentityId.ToString().PadLeft(lenght, '0');
                    return NewID;
                }
                else
                {
                    return DateTime.Now.ToLongTimeString();
                }
            }
        }
        //public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime? EndDate, string MainComId)
        //{
        //    string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
        //    string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
        //    string tohash = strStartDate + strEndDate; 
        //    string a = RemoveNumber(SHA1encode(tohash)).Substring(0, 3).ToUpper();
        //    string NewID = string.Format("{0}{3}{1}{2}", strStartDate, strEndDate, MainComId, a);

        //    return NewID;
        //}
        //public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime? EndDate, string MainComId, string ShiftAbbrId)
        //{
        //    string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
        //    string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
           
        //    string a = RemoveNumber(Guid.NewGuid().ToString("N")).Substring(0, 3).ToUpper();
        //    string NewID = string.Format("{0}{3}{1}{2}", strStartDate, strEndDate, MainComId, a);

        //    return NewID;
        //}
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Configuration.GetConnectionString("DevConnection"))
                string CONNECTION_STRING = AppSetting.GetConfig("ConnectionStrings:DefaultConnection");
                 
                //optionsBuilder.UseSqlServer("Data Source=SERVER1\\DATAGUARDSRV;Initial Catalog=DataGuardXcore;User ID=admin;Password=13711222146@mcessol;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;");
                optionsBuilder.UseSqlServer(CONNECTION_STRING, options =>
                        options.EnableRetryOnFailure());
            }
        }
    }
}

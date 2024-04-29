namespace Ishop.Migrations
{
    using System;
    using System.Text;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using System.Security.Claims;
    using Microsoft.Owin;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ishop.Utilities;
    using Ishop.Identity.Models;
    using Ishop.Models;
    using Ishop.Models.ProductMgr;
    using Ishop.Models.CampaignMgr;
    internal sealed class Configuration : DbMigrationsConfiguration<Ishop.Context.ApplicationDbContext>
    { 
        public Configuration()
        { 
            AutomaticMigrationsEnabled = true;//默认为false 此处需要修改 
            AutomaticMigrationDataLossAllowed = true;
        }
         
    }
}
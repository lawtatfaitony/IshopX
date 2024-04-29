
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Net;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using Ishop.Models;
using Ishop.Identity.Models;
using Ishop.Models.ProductMgr;
using Ishop.Models.PubDataModal;
using Ishop.Models.CampaignMgr;
using Ishop.Models.UploadItem;
using Ishop.Models.Info;
using System.Web;
using Ishop.Models.User;

namespace Ishop.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<ApplicationRole> AspNetRoles { get; set; }
        public virtual DbSet<ApplicationUserRole> UserRoles { get; set; }

        public DbSet<ProdPropertiesValue> ProdPropertiesValues { get; set; }
        public DbSet<BlockList> BlockLists { get; set; } 
        public DbSet<TableIdentity> tableIdentity { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Prodcate> Prodcates { get; set; }
        public DbSet<ProdPropertiesName> ProdPropertiesNames { get; set; } 
        public DbSet<SaleStatus> saleStatus { get; set; } 
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<CampaignProduct> CampaignProducts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<UploadItem> UploadItems { get; set; }
        public DbSet<ShopStaff> ShopStaffs { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<UserCoupon> UserCoupons { get; set; } 
        public DbSet<AccountMgr> AccountMgrs { get; set; }
        public DbSet<AccountWebSite> AccountWebSites { get; set; }
        public DbSet<InfoDetail> InfoDetails { get; set; }
        public DbSet<InfoCate> InfoCates { get; set; } 
        public DbSet<Language> Languages { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<VipLevel> VipLevels { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<AccountDownLog> AccountDownLogs { get; set; }
        
        public DbSet<SeoExtand> SeoExtands { get; set; }
        public DbSet<InfoItemTemplate> InfoItemTemplates { get; set; }
        public DbSet<SourceStatistic> SourceStatistics { get; set; }
        public DbSet<UserTrace> UserTraces { get; set; }
        public DbSet<WeiXin> WeiXins { get; set; } 
        public DbSet<QuantFactor> QuantFactors { get; set; }
        public DbSet<UserQuantFactor> UserQuantFactors { get; set; }
        public DbSet<DispatchNote> DispatchNotes { get; set; }
        public DbSet<TableState> TableStates { get; set; }
        public DbSet<ProductSku> ProductSkus { get; set; } 
        public DbSet<EmailSms> EmailSmss { get; set; }
        public DbSet<Cart> Carts { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<UserFinance> UserFinances { get; set; }
        public DbSet<UserFinanceItem> UserFinanceItems { get; set; }
        public DbSet<TemplateNotePosition> TemplateNotePositions { get; set; }
        public DbSet<DefiniteTemplateNote> DefiniteTemplateNotes { get; set; }

        public DbSet<EmailSubscribe> EmailSubscribe { get; set; }
        public DbSet<EmailTask> EmailTask { get; set; }
        public DbSet<SendMailInfo> SendMailInfo { get; set; }

        public string GetTableIdentityID(string Prefix,string TableName,int Lenght)
        { 
            ApplicationDbContext context = ApplicationDbContext.Create();
            TableIdentity T = new TableIdentity();
             
            if (context.tableIdentity.Find(TableName)==null)
            {
                T.TableIdentityID = 1;
                T.TableName = TableName;
                T.OperatedDate = DateTime.Now;
                context.tableIdentity.Add(T);
                context.SaveChanges();
                  
            }else
            {
                T = context.tableIdentity.Find(TableName);
                T.TableIdentityID += 1;                           
                T.OperatedDate = DateTime.Now;

                context.Entry(T).State = EntityState.Modified;
                context.SaveChanges(); 
            } 
            string NewID = Prefix + T.TableIdentityID.ToString().PadLeft(Lenght,'0');
            return NewID ;  
        }
        
        public ApplicationDbContext()
            : base("IShopDBContext", throwIfV1Schema: false)
        { 
        }  
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("ModelBuilder is NULL");
            }
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//指定单数形式的表名

            base.OnModelCreating(modelBuilder);

            //Define the keys and relations
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<ApplicationRole>().HasKey<string>(r => r.Id).ToTable("AspNetRoles"); 
            modelBuilder.Entity<ApplicationUser>().HasMany<ApplicationUserRole>((ApplicationUser u) => u.UserRoles);
            modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");
             
            //模型数据字段配置 
            modelBuilder.Configurations.Add(new AccountDownLogConfiguration());
            modelBuilder.Configurations.Add(new AccountWebSiteConfiguration());
            modelBuilder.Configurations.Add(new AccountMgrConfiguration());

            modelBuilder.Configurations.Add(new BlockListConfiguration());

           
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CampaignConfiguration());
            modelBuilder.Configurations.Add(new CampaignProductConfiguration());
            modelBuilder.Configurations.Add(new CartConfiguration());

            modelBuilder.Configurations.Add(new LanguageConfiguration());

            
            modelBuilder.Configurations.Add(new ProdPropertiesValueConfiguration());
            modelBuilder.Configurations.Add(new ProdPropertiesNameConfiguration());
            
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProdcateConfiguration());

            modelBuilder.Configurations.Add(new SourceStatisticConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new ShopConfiguration());
            modelBuilder.Configurations.Add(new SaleStatusConfiguration());

            modelBuilder.Configurations.Add(new UserTraceConfiguration());
            
            modelBuilder.Configurations.Add(new InfoDetailConfiguration());
            modelBuilder.Configurations.Add(new ShopStaffConfiguration());

            modelBuilder.Configurations.Add(new UserAddressConfiguration());
            modelBuilder.Configurations.Add(new UserTagConfiguration());
        } 

        public bool RoleExists(ApplicationRoleManager roleManager, string name)
        {
            return roleManager.RoleExists(name);
        } 
        public bool CreateRole(ApplicationRoleManager _roleManager, string name, string description = "")
        {
            var idResult = _roleManager.Create<ApplicationRole, string>(new ApplicationRole(name, description));
            return idResult.Succeeded;
        } 
        public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        } 
        public void ClearUserRoles(ApplicationUserManager userManager, string userId)
        {
            var user = userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.UserRoles);
            foreach (ApplicationUserRole role in currentRoles)
            {
                userManager.RemoveFromRole(userId, role.Role.Name);
            }
        } 
        public void RemoveFromRole(ApplicationUserManager userManager, string userId, string roleName)
        {
            userManager.RemoveFromRole(userId, roleName);
        } 
        public void DeleteRole(ApplicationDbContext context, ApplicationUserManager userManager, string roleId)
        {
            var roleUsers = context.Users.Where(u => u.UserRoles.Any(r => r.RoleId == roleId));
            var role = context.AspNetRoles.Find(roleId);

            foreach (var user in roleUsers)
            {
                this.RemoveFromRole(userManager, user.Id, role.Name);
            }
            context.AspNetRoles.Remove(role);
            context.SaveChanges();
        } 
    }
}
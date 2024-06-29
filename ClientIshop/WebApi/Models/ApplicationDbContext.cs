using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDownLog> AccountDownLog { get; set; }
        public virtual DbSet<AccountMgr> AccountMgr { get; set; }
        public virtual DbSet<AccountMgr0> AccountMgr0 { get; set; }
        public virtual DbSet<AccountWebSite> AccountWebSite { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BlockList> BlockList { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignProduct> CampaignProduct { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<DefiniteTemplateNote> DefiniteTemplateNote { get; set; }
        public virtual DbSet<DispatchNote> DispatchNote { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<EmailSms> EmailSms { get; set; }
        public virtual DbSet<EmailSubscribe> EmailSubscribe { get; set; }
        public virtual DbSet<EmailTask> EmailTask { get; set; }
        public virtual DbSet<InfoCate> InfoCate { get; set; }
        public virtual DbSet<InfoDetail> InfoDetail { get; set; }
        public virtual DbSet<InfoItemTemplate> InfoItemTemplate { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<ProdPropertiesName> ProdPropertiesName { get; set; }
        public virtual DbSet<ProdPropertiesValue> ProdPropertiesValue { get; set; }
        public virtual DbSet<Prodcate> Prodcate { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductSku> ProductSku { get; set; }
        public virtual DbSet<QuantFactor> QuantFactor { get; set; }
        public virtual DbSet<SaleStatus> SaleStatus { get; set; }
        public virtual DbSet<SendMailInfo> SendMailInfo { get; set; }
        public virtual DbSet<SeoExtand> SeoExtand { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopStaff> ShopStaff { get; set; }
        public virtual DbSet<SourceStatistic> SourceStatistic { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TableIdentity> TableIdentity { get; set; }
        public virtual DbSet<TableState> TableState { get; set; }
        public virtual DbSet<TemplateNotePosition> TemplateNotePosition { get; set; }
        public virtual DbSet<UploadItem> UploadItem { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserChannel> UserChannel { get; set; }
        public virtual DbSet<UserCoupon> UserCoupon { get; set; }
        public virtual DbSet<UserFinance> UserFinance { get; set; }
        public virtual DbSet<UserFinanceItem> UserFinanceItem { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserQuantFactor> UserQuantFactor { get; set; }
        public virtual DbSet<UserTag> UserTag { get; set; }
        public virtual DbSet<UserTrace> UserTrace { get; set; }
        public virtual DbSet<VipLevel> VipLevel { get; set; }
        public virtual DbSet<WeiXin> WeiXin { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=CLOUDSERVER\\DATAGUARD;Initial Catalog=IshopX559;User ID=sa;Password=admin123;Connect Timeout=2400;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDownLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountMgrId)
                    .HasColumnName("AccountMgrID")
                    .HasMaxLength(18);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.ResourceFile).HasMaxLength(512);

                entity.Property(e => e.TagName).HasMaxLength(512);

                entity.Property(e => e.UserTagId)
                    .HasColumnName("UserTagID")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AccountMgr>(entity =>
            {
                entity.Property(e => e.AccountMgrId)
                    .HasColumnName("AccountMgrID")
                    .HasMaxLength(18);

                entity.Property(e => e.AssignedToUserId)
                    .HasColumnName("AssignedToUserID")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedByUserId)
                    .HasColumnName("CreatedByUserID")
                    .HasMaxLength(128);

                entity.Property(e => e.LoginEmail).HasMaxLength(512);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .HasMaxLength(1024);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.Password).HasMaxLength(1024);

                entity.Property(e => e.Password2).HasMaxLength(1024);

                entity.Property(e => e.PrivacyAnswer).HasMaxLength(1024);

                entity.Property(e => e.PrivacyQuestion).HasMaxLength(1024);

                entity.Property(e => e.Remarks).HasMaxLength(2000);

                entity.Property(e => e.ScurityEmail).HasMaxLength(512);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.WebSite)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountMgr0>(entity =>
            {
                entity.HasKey(e => e.AccountMgrId)
                    .HasName("PK_dbo.AccountMgr0");

                entity.Property(e => e.AccountMgrId)
                    .HasColumnName("AccountMgrID")
                    .HasMaxLength(18);

                entity.Property(e => e.AssignedToUserId)
                    .HasColumnName("AssignedToUserID")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedByUserId)
                    .HasColumnName("CreatedByUserID")
                    .HasMaxLength(128);

                entity.Property(e => e.LoginEmail).HasMaxLength(512);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .HasMaxLength(1024);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.Password).HasMaxLength(1024);

                entity.Property(e => e.Password2).HasMaxLength(1024);

                entity.Property(e => e.PrivacyAnswer).HasMaxLength(1024);

                entity.Property(e => e.PrivacyQuestion).HasMaxLength(1024);

                entity.Property(e => e.Remarks).HasMaxLength(2000);

                entity.Property(e => e.ScurityEmail).HasMaxLength(512);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.WebSite)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountWebSite>(entity =>
            {
                entity.HasKey(e => e.WebSiteId)
                    .HasName("PK_dbo.AccountWebSite");

                entity.Property(e => e.WebSiteId)
                    .HasColumnName("WebSiteID")
                    .HasMaxLength(10);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUser_Id");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.RoleId1)
                    .HasName("IX_Role_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.ApplicationUserId)
                    .HasColumnName("ApplicationUser_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.RoleId1)
                    .HasColumnName("Role_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.AspNetUserRolesApplicationUser)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_ApplicationUser_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRolesRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.RoleId1Navigation)
                    .WithMany(p => p.AspNetUserRolesRoleId1Navigation)
                    .HasForeignKey(d => d.RoleId1)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_Role_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRolesUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BlockList>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(512);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.CampaignId)
                    .HasColumnName("CampaignID")
                    .HasMaxLength(20);

                entity.Property(e => e.CampaignDesc).HasColumnType("ntext");

                entity.Property(e => e.CampaignLabel).HasMaxLength(6);

                entity.Property(e => e.CampaignName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CampaignProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CampaignId })
                    .HasName("PK_dbo.CampaignProduct");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(20);

                entity.Property(e => e.CampaignId)
                    .HasColumnName("CampaignID")
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.TradePrice).HasColumnType("money");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName).HasMaxLength(60);

                entity.Property(e => e.ProductSkuId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PropertyDesc).HasMaxLength(60);

                entity.Property(e => e.RetailPrice).HasColumnType("money");

                entity.Property(e => e.SkuImageUrl).HasMaxLength(256);

                entity.Property(e => e.TradePrice).HasColumnType("money");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryDesc).HasColumnType("ntext");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(128);

                entity.Property(e => e.ParentsCategoryId)
                    .HasColumnName("ParentsCategoryID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.ChannelId)
                    .HasColumnName("ChannelID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.CouponId)
                    .HasColumnName("CouponID")
                    .HasMaxLength(20);

                entity.Property(e => e.Conditions).HasColumnType("money");

                entity.Property(e => e.CouponName)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FaceValue).HasColumnType("money");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DefiniteTemplateNote>(entity =>
            {
                entity.Property(e => e.DefiniteTemplateNoteId).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.SenderUserAddressId).HasColumnName("SenderUserAddressID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<DispatchNote>(entity =>
            {
                entity.Property(e => e.DispatchNoteId).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasMaxLength(128);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.ParentId).HasColumnName("Parent_id");
            });

            modelBuilder.Entity<EmailSms>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.CredentialUserName).HasColumnName("credentialUserName");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.Pwd).HasColumnName("pwd");

                entity.Property(e => e.SentFrom).HasColumnName("sentFrom");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<EmailSubscribe>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(30);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmailTaskId).HasMaxLength(30);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.SubscriberName).HasMaxLength(100);
            });

            modelBuilder.Entity<EmailTask>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(30);

                entity.Property(e => e.CallBackUrl).HasMaxLength(512);

                entity.Property(e => e.EmailTemplate)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.SenderAccountArr)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Subject).HasMaxLength(20);
            });

            modelBuilder.Entity<InfoCate>(entity =>
            {
                entity.Property(e => e.InfoCateId)
                    .HasColumnName("InfoCateID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.PrarentsId).HasColumnName("PrarentsID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<InfoDetail>(entity =>
            {
                entity.HasKey(e => e.InfoId)
                    .HasName("PK_dbo.InfoDetail");

                entity.Property(e => e.InfoId)
                    .HasColumnName("InfoID")
                    .HasMaxLength(20);

                entity.Property(e => e.Author).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InfoCateId)
                    .HasColumnName("InfoCateID")
                    .HasMaxLength(128);

                entity.Property(e => e.InfoDescription).HasColumnType("ntext");

                entity.Property(e => e.InfoItemTemplateIds)
                    .HasColumnName("InfoItemTemplateIDs")
                    .HasMaxLength(256);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.SeoDescription).HasMaxLength(256);

                entity.Property(e => e.SeoKeyword).HasMaxLength(256);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.ShopStaffId)
                    .HasColumnName("ShopStaffID")
                    .HasMaxLength(128);

                entity.Property(e => e.SubTitle).HasMaxLength(512);

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.TitleThumbNail).HasMaxLength(256);

                entity.Property(e => e.UserTraceId)
                    .HasColumnName("UserTraceID")
                    .HasMaxLength(128);

                entity.Property(e => e.VideoUrl).HasMaxLength(512);
            });

            modelBuilder.Entity<InfoItemTemplate>(entity =>
            {
                entity.Property(e => e.InfoItemTemplateId)
                    .HasColumnName("InfoItemTemplateID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.KeyName)
                    .HasName("PK_dbo.Language");

                entity.Property(e => e.KeyName).HasMaxLength(256);

                entity.Property(e => e.Ar)
                    .HasColumnName("ar")
                    .HasMaxLength(4000);

                entity.Property(e => e.De)
                    .HasColumnName("de")
                    .HasMaxLength(4000);

                entity.Property(e => e.En)
                    .HasColumnName("en")
                    .HasMaxLength(4000);

                entity.Property(e => e.Es)
                    .HasColumnName("es")
                    .HasMaxLength(4000);

                entity.Property(e => e.Fr)
                    .HasColumnName("fr")
                    .HasMaxLength(4000);

                entity.Property(e => e.Ja)
                    .HasColumnName("ja")
                    .HasMaxLength(4000);

                entity.Property(e => e.KeyType).HasMaxLength(256);

                entity.Property(e => e.Ko)
                    .HasColumnName("ko")
                    .HasMaxLength(4000);

                entity.Property(e => e.Remarks).HasMaxLength(512);

                entity.Property(e => e.Ru)
                    .HasColumnName("ru")
                    .HasMaxLength(4000);

                entity.Property(e => e.Zh)
                    .HasColumnName("zh")
                    .HasMaxLength(4000);

                entity.Property(e => e.ZhCn)
                    .HasColumnName("zh_CN")
                    .HasMaxLength(4000);

                entity.Property(e => e.ZhHk)
                    .HasColumnName("zh_HK")
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.MenuItemId)
                    .HasColumnName("MenuItemID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentsMenuItemId).HasColumnName("ParentsMenuItemID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.AdjustFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FaceValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Payment).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.TotalCommision).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalRetailPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.Property(e => e.OrderItemId).HasMaxLength(128);

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Commision).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CommisionRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductSkuId).IsRequired();

                entity.Property(e => e.RetailPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TradePrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderItem_dbo.Order_OrderId");
            });

            modelBuilder.Entity<ProdPropertiesName>(entity =>
            {
                entity.HasKey(e => e.PropertiesNameId)
                    .HasName("PK_dbo.ProdPropertiesName");

                entity.Property(e => e.PropertiesNameId)
                    .HasColumnName("PropertiesNameID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProdCateId)
                    .HasColumnName("ProdCateID")
                    .HasMaxLength(4000);

                entity.Property(e => e.ProdCateName).HasMaxLength(4000);

                entity.Property(e => e.PropertiesName).HasMaxLength(4000);
            });

            modelBuilder.Entity<ProdPropertiesValue>(entity =>
            {
                entity.HasKey(e => e.PropertiesValueId)
                    .HasName("PK_dbo.ProdPropertiesValue");

                entity.Property(e => e.PropertiesValueId)
                    .HasColumnName("PropertiesValueID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProdCateId).HasColumnName("ProdCateID");

                entity.Property(e => e.PropertiesNameId).HasColumnName("PropertiesNameID");
            });

            modelBuilder.Entity<Prodcate>(entity =>
            {
                entity.Property(e => e.ProdCateId)
                    .HasColumnName("ProdCateID")
                    .HasMaxLength(128);

                entity.Property(e => e.ParentsProdCateId).HasColumnName("ParentsProdCateID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProdCateId)
                    .HasName("IX_ProdCateID");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(128);

                entity.Property(e => e.CategoryIds).HasColumnName("CategoryIDs");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProdCateId)
                    .HasColumnName("ProdCateID")
                    .HasMaxLength(128);

                entity.Property(e => e.RetailPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleStatusId).HasColumnName("SaleStatusID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TradePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ViewsIp).HasColumnName("ViewsIP");

                entity.HasOne(d => d.ProdCate)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProdCateId)
                    .HasConstraintName("FK_dbo.Product_dbo.Prodcate_ProdCateID");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId })
                    .HasName("PK_dbo.ProductCategory");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProductSku>(entity =>
            {
                entity.Property(e => e.ProductSkuId).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(20);

                entity.Property(e => e.PropValueIds).HasColumnName("PropValueIDs");

                entity.Property(e => e.TradePrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<QuantFactor>(entity =>
            {
                entity.Property(e => e.QuantFactorId)
                    .HasColumnName("QuantFactorID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentsId).HasColumnName("ParentsID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<SaleStatus>(entity =>
            {
                entity.Property(e => e.SaleStatusId)
                    .HasColumnName("SaleStatusID")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SendMailInfo>(entity =>
            {
                entity.Property(e => e.SendMailInfoId).HasMaxLength(128);

                entity.Property(e => e.EnableSsl).HasColumnName("EnableSSL");

                entity.Property(e => e.EnableTsl).HasColumnName("EnableTSL");

                entity.Property(e => e.SenderOfCompany).IsRequired();

                entity.Property(e => e.SenderServerHost).IsRequired();

                entity.Property(e => e.SenderUserPassword).IsRequired();

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SeoExtand>(entity =>
            {
                entity.Property(e => e.SeoExtandId)
                    .HasColumnName("SeoExtandID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentsSeoExtandId).HasColumnName("ParentsSeoExtandID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CerPath)
                    .HasColumnName("cerPath")
                    .HasMaxLength(256);

                entity.Property(e => e.FbQrcode)
                    .HasColumnName("fbQRcode")
                    .HasMaxLength(256);

                entity.Property(e => e.FooterTemplate).HasMaxLength(256);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ShopCurrency)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ShopLogo)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ToutiaoQrcode)
                    .HasColumnName("ToutiaoQRcode")
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.WeiboQrcode)
                    .HasColumnName("WeiboQRcode")
                    .HasMaxLength(256);

                entity.Property(e => e.WeixinQrcode)
                    .HasColumnName("WeixinQRcode")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ShopStaff>(entity =>
            {
                entity.Property(e => e.ShopStaffId)
                    .HasColumnName("ShopStaffID")
                    .HasMaxLength(128);

                entity.Property(e => e.ChannelId)
                    .HasColumnName("ChannelID")
                    .HasMaxLength(256);

                entity.Property(e => e.ContactTitle).HasMaxLength(100);

                entity.Property(e => e.IconPortrait).HasMaxLength(256);

                entity.Property(e => e.Introduction).HasColumnType("ntext");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.OtherChannelName).HasMaxLength(256);

                entity.Property(e => e.OtherQrcode).HasMaxLength(256);

                entity.Property(e => e.PublicNo).HasMaxLength(300);

                entity.Property(e => e.Qrcode).HasMaxLength(256);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.StaffName).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.UserName).HasMaxLength(128);
            });

            modelBuilder.Entity<SourceStatistic>(entity =>
            {
                entity.HasKey(e => e.SourceStatisticsId)
                    .HasName("PK_dbo.SourceStatistic");

                entity.Property(e => e.SourceStatisticsId).HasColumnName("SourceStatisticsID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(128);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LoadTime).HasColumnName("loadTime");

                entity.Property(e => e.OpenId)
                    .HasColumnName("OpenID")
                    .HasMaxLength(256);

                entity.Property(e => e.Osversion)
                    .HasColumnName("OSVersion")
                    .HasMaxLength(128);

                entity.Property(e => e.RecommUserId).HasMaxLength(128);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.SourceArea).HasMaxLength(256);

                entity.Property(e => e.TableKeyId)
                    .IsRequired()
                    .HasColumnName("TableKeyID")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.VisitorIcon).HasMaxLength(256);

                entity.Property(e => e.WxNickName).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<TableIdentity>(entity =>
            {
                entity.HasKey(e => e.TableName)
                    .HasName("PK_dbo.TableIdentity");

                entity.Property(e => e.TableName).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.TableIdentityId).HasColumnName("TableIdentityID");
            });

            modelBuilder.Entity<TableState>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.LanguageCode).IsRequired();

                entity.Property(e => e.StatusId).HasMaxLength(50);

                entity.Property(e => e.StatusName).HasMaxLength(50);

                entity.Property(e => e.TableName).HasMaxLength(128);
            });

            modelBuilder.Entity<TemplateNotePosition>(entity =>
            {
                entity.Property(e => e.TemplateNotePositionId).HasMaxLength(128);

                entity.Property(e => e.DataField).HasMaxLength(50);

                entity.Property(e => e.FontSize).HasMaxLength(50);

                entity.Property(e => e.MaxWidth)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'2.5cm')");

                entity.Property(e => e.TableName).HasMaxLength(50);
            });

            modelBuilder.Entity<UploadItem>(entity =>
            {
                entity.Property(e => e.UploadItemId).HasMaxLength(100);

                entity.Property(e => e.FileExt).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.RawName).HasMaxLength(100);

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.SubPath).HasMaxLength(256);

                entity.Property(e => e.TargetTalbeKeyId)
                    .HasColumnName("TargetTalbeKeyID")
                    .HasMaxLength(256);

                entity.Property(e => e.Url).HasMaxLength(256);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.Property(e => e.UserAddressId)
                    .HasColumnName("UserAddressID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UserChannel>(entity =>
            {
                entity.Property(e => e.UserChannelId)
                    .HasColumnName("UserChannelID")
                    .HasMaxLength(128);

                entity.Property(e => e.ChannelId).HasColumnName("ChannelID");

                entity.Property(e => e.ChannelQrcode).HasColumnName("ChannelQRcode");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<UserCoupon>(entity =>
            {
                entity.Property(e => e.UserCouponId)
                    .HasColumnName("UserCouponID")
                    .HasMaxLength(20);

                entity.Property(e => e.CouponId)
                    .IsRequired()
                    .HasColumnName("CouponID")
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UserFinance>(entity =>
            {
                entity.Property(e => e.UserFinanceId)
                    .HasColumnName("UserFinanceID")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UserFinanceItem>(entity =>
            {
                entity.Property(e => e.UserFinanceItemId)
                    .HasColumnName("UserFinanceItemID")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.PromoteAndSalesChannel).HasColumnName("promoteAndSalesChannel");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.UserFinanceId).HasColumnName("UserFinanceID");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");

                entity.Property(e => e.AsignAccountMgrIds).HasColumnName("AsignAccountMgrIDs");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OpenId).HasColumnName("OpenID");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.UserTagId).HasColumnName("UserTagID");

                entity.Property(e => e.VipLevelId).HasColumnName("VipLevelID");

                entity.Property(e => e.WechatId).HasColumnName("WechatID");
            });

            modelBuilder.Entity<UserQuantFactor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.QuantFactorId).HasColumnName("QuantFactorID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfileID");
            });

            modelBuilder.Entity<UserTag>(entity =>
            {
                entity.Property(e => e.UserTagId)
                    .HasColumnName("UserTagID")
                    .HasMaxLength(128);

                entity.Property(e => e.TagName).HasMaxLength(128);
            });

            modelBuilder.Entity<UserTrace>(entity =>
            {
                entity.Property(e => e.UserTraceId)
                    .HasColumnName("UserTraceID")
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasMaxLength(20);

                entity.Property(e => e.TableKeyId)
                    .HasColumnName("TableKeyID")
                    .HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<VipLevel>(entity =>
            {
                entity.Property(e => e.VipLevelId).HasColumnName("VipLevelID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<WeiXin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessToken).HasColumnName("access_token");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasColumnName("AppID")
                    .HasMaxLength(256);

                entity.Property(e => e.ExpiresIn).HasColumnName("expires_in");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("lastupdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Secret).HasColumnName("secret");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.Ticket).HasColumnName("ticket");

                entity.Property(e => e.TicketExpiresIn).HasColumnName("ticket_expires_in");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

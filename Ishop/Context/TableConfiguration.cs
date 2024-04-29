using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishop.Models.ProductMgr;
using Ishop.Models.CampaignMgr;
using Ishop.Models.PubDataModal;
using Ishop.Models.Info;
using Ishop.Models.User;
using Ishop.Models;

namespace Ishop.Context
{
   
    public class AccountDownLogConfiguration : EntityTypeConfiguration<AccountDownLog>
    {
        public AccountDownLogConfiguration()
        { 
            HasKey(t => t.ID);
            Property(t => t.AccountMgrID).HasColumnType("nvarchar").HasMaxLength(18);
            Property(t => t.UserTagID).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.TagName).HasColumnType("nvarchar").HasMaxLength(512);
            Property(t => t.ResourceFile).HasColumnType("nvarchar").HasMaxLength(512);
            Property(t => t.Rank).HasColumnType("int");
            Property(t => t.OperatedUserName).HasColumnType("nvarchar").HasMaxLength(256);
        }
    } 
    public class AccountWebSiteConfiguration : EntityTypeConfiguration<AccountWebSite>
    { 
        public AccountWebSiteConfiguration()
        {
            HasKey(t => t.WebSiteID); 
            Property(t => t.WebSite).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.SiteName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
    public class AccountMgrConfiguration : EntityTypeConfiguration<AccountMgr>
    {   
        public AccountMgrConfiguration()
        {
            HasKey(t => t.AccountMgrID);
            Property(t => t.ShopID).HasColumnType("varchar").HasMaxLength(20);
            Property(t => t.WebSite).HasColumnType("varchar").HasMaxLength(256);
            Property(t => t.SiteName).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.LoginID).HasColumnType("nvarchar").HasMaxLength(1024);
            Property(t => t.Password).HasColumnType("nvarchar").HasMaxLength(1024);
            Property(t => t.Password2).HasColumnType("nvarchar").HasMaxLength(1024);
            Property(t => t.IsCer).HasColumnType("bit");
            Property(t => t.LoginEmail).HasColumnType("nvarchar").HasMaxLength(512);
            Property(t => t.ScurityEmail).HasColumnType("nvarchar").HasMaxLength(512);
            Property(t => t.Mobile).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.NickName).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.PrivacyQuestion).HasColumnType("nvarchar").HasMaxLength(1024);
            Property(t => t.PrivacyAnswer).HasColumnType("nvarchar").HasMaxLength(1024);
            Property(t => t.CreatedByUserID).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.AssignedToUserID).HasColumnType("nvarchar").HasMaxLength(200);
            Property(t => t.Remarks).HasColumnType("nvarchar").HasMaxLength(2000);
            Property(t => t.OperatedUserName).HasColumnType("nvarchar").HasMaxLength(256);
        }
    }
    public class BlockListConfiguration : EntityTypeConfiguration<BlockList>
    {
        public BlockListConfiguration()
        {
            HasKey(t => t.BlockListId);
            Property(t => t.ShopID).HasColumnType("nvarchar").HasMaxLength(20);
            Property(t => t.Name).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.PhoneNumber).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.Email).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.Remarks).HasColumnType("nvarchar").HasMaxLength(512);
            Property(t => t.OperatedUserName).HasColumnType("nvarchar").HasMaxLength(256);
        }
    } 
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(t => t.CategoryID);
            Property(t => t.ParentsCategoryID).IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(t => t.CategoryID).IsUnicode(false).HasColumnType("varchar").HasMaxLength(128);
            Property(t => t.ShopID).IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(t => t.CategoryDesc).HasColumnType("ntext");
            Property(t => t.CategoryName).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.OperatedUserName).HasColumnType("nvarchar").HasMaxLength(128);
        }
    }
    public class CartConfiguration : EntityTypeConfiguration<Cart>
    {
        public CartConfiguration()
        {
            HasKey(t => t.Id);
            Property(t => t.CartId).IsUnicode(false).HasColumnType("varchar").HasMaxLength(128);
            Property(t => t.ProductSkuId).IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.SkuImageUrl).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.ProductName).HasColumnType("nvarchar").HasMaxLength(60);
            Property(t => t.PropertyDesc).HasColumnType("nvarchar").HasMaxLength(60);
            Property(t => t.TradePrice).HasColumnType("money");
            Property(t => t.RetailPrice).HasColumnType("money");
            Property(t => t.Quantity).HasColumnType("int"); 
        }
    } 
    public class InfoDetailConfiguration : EntityTypeConfiguration<InfoDetail>
    {
        public InfoDetailConfiguration()
        {
            HasKey(t => t.InfoID).Property(t => t.InfoID).HasMaxLength(20);  
            Property(t => t.UserTraceID).HasMaxLength(128).HasMaxLength(128);
            Property(t => t.InfoCateID).HasMaxLength(6);
            Property(t => t.Title).HasMaxLength(256);
            Property(t => t.SubTitle).HasMaxLength(512);
            Property(t => t.TitleThumbNail).HasMaxLength(256);
            Property(t => t.SeoKeyword).HasMaxLength(256);
            Property(t => t.SeoDescription).HasMaxLength(256);
            Property(t => t.VideoUrl).HasMaxLength(512);
            Property(t => t.Author).HasMaxLength(256);
            Property(t => t.ShopID).HasMaxLength(20);
            Property(t => t.OperatedUserName).HasMaxLength(256);
            Property(t => t.InfoItemTemplateIDs).HasMaxLength(256);
            Property(t => t.ShopStaffID).HasMaxLength(128);
            Property(t => t.InfoDescription).HasColumnType("ntext");
        }
    } 
    public class LanguageConfiguration : EntityTypeConfiguration<Language>
    { 
        public LanguageConfiguration()
        {

            HasKey(t => t.KeyName);
            Property(t => t.KeyName).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.KeyType).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.zh_CN).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.zh_HK).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.en).HasColumnType("nvarchar").HasMaxLength(4000);

            Property(t => t.ja).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.zh).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.ko).HasColumnType("nvarchar").HasMaxLength(4000);
           
            Property(t => t.fr).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.de).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.ru).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.ar).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.es).HasColumnType("nvarchar").HasMaxLength(4000);
            Property(t => t.Remarks).HasColumnType("nvarchar").HasMaxLength(512); 
        }
    }
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(t => t.ProductID);  
            Property(t => t.ProductID).IsUnicode(false).HasColumnType("varchar");
            Property(t => t.ProdDesc).IsUnicode(true).HasColumnType("ntext");
            Property(t => t.TradePrice).HasColumnType("money");
            Property(t => t.RetailPrice).HasColumnType("money)"); 
        }
    }
    
    public class ProdPropertiesNameConfiguration : EntityTypeConfiguration<ProdPropertiesName>
    {
        public ProdPropertiesNameConfiguration()
        {
            Property(t => t.PropertiesNameID).IsUnicode(true).HasColumnType("nchar");
            Property(t => t.ProdCateID).IsUnicode(true).HasColumnType("nvarchar");
            Property(t => t.ProdCateName).IsUnicode(true).HasColumnType("nvarchar");
            Property(t => t.PropertiesName).IsUnicode(true).HasColumnType("nvarchar");
            Property(t => t.IsForTrading).HasColumnType("int");
        }
    }
    public class ProdPropertiesValueConfiguration : EntityTypeConfiguration<ProdPropertiesValue>
    {
        public ProdPropertiesValueConfiguration()
        {
            Property(t => t.PropertiesValueID).IsUnicode(true).HasColumnType("nchar");
        }
    }
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        { 
            HasKey(t => new { t.ProductID, t.CategoryID });  //也可以通过方法创建双键做主键 modelBuilder.Entity<Product>().HasKey(t => new { t.KeyID, t.CandidateID });
            Property(t => t.CategoryID).IsUnicode(false).HasColumnType("varchar");
            Property(t => t.ProductID).IsUnicode(false).HasColumnType("varchar");
        }
    }
    public class ProdcateConfiguration : EntityTypeConfiguration<Prodcate>
    {
        public ProdcateConfiguration()
        {
            HasKey(t => t.ProdCateID);
            Property(t => t.ProdCateID).IsRequired().IsUnicode(true).HasColumnType("nvarchar");
        }
    } 

    public class ShopConfiguration : EntityTypeConfiguration<Shop>
    {
        public ShopConfiguration()
        {
            HasKey(t => t.ShopID);
            Property(t => t.ShopID).IsRequired().IsUnicode(true).HasColumnType("varchar").HasMaxLength(20);
            Property(t => t.ShopName).IsRequired().IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(50);
            Property(t => t.ShopLogo).IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.WeixinQRcode).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.WeiboQRcode).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.ToutiaoQRcode).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.fbQRcode).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.FooterTemplate).IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.cerPath).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.UserId).IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.UserName).IsRequired().IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.ShopCurrency).IsRequired().IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(20);
            Property(t => t.PhoneNumber).IsRequired().IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.OperatedUserName).IsUnicode(true).HasColumnType("nvarchar").HasMaxLength(256); 
        }
    }
    public class SaleStatusConfiguration : EntityTypeConfiguration<SaleStatus>
    {
        public SaleStatusConfiguration()
        {
            HasKey(t => t.SaleStatusID);
            Property(t => t.SaleStatusID).IsUnicode(false);
        }
    } 

    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            Property(t => t.SupplierID).IsUnicode(false).HasColumnType("varchar");
        }
    }
    public class TableIdentityConfiguration : EntityTypeConfiguration<TableIdentity>
    {
        public TableIdentityConfiguration()
        {
            HasKey(t => t.TableName);
            Property(t => t.TableName).IsUnicode(false).HasColumnType("varchar").HasMaxLength(128);
        }
    }
    public class UserAddressConfiguration : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressConfiguration()
        {
            Property(t => t.UserAddressID).HasColumnType("varchar");
        }
    }
    public class CampaignConfiguration : EntityTypeConfiguration<Campaign>
    {
        public CampaignConfiguration()
        {   
            Property(t => t.CampaignDesc).IsUnicode(true).HasColumnType("ntext");
        }
    } 
    public class CampaignProductConfiguration : EntityTypeConfiguration<CampaignProduct>
    {
        public CampaignProductConfiguration()
        {
            HasKey(t => new { t.ProductID, t.CampaignID });
            Property(t => t.TradePrice).HasColumnType("money"); 
        }
    }
    public class ShopStaffConfiguration : EntityTypeConfiguration<ShopStaff>
    {
        public ShopStaffConfiguration()
        {
            HasKey(t => t.ShopStaffID).Property(t => t.ShopStaffID).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.ShopID).HasColumnType("nvarchar").HasMaxLength(20);
            Property(t => t.UserId).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.UserName).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.IconPortrait).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.StaffName).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.Introduction).HasColumnType("ntext");
            Property(t => t.IsConfirmed).HasColumnType("bit");
            Property(t => t.PublicNo).HasColumnType("nvarchar").HasMaxLength(300);
            Property(t => t.ContactTitle).HasColumnType("nvarchar").HasMaxLength(100);
            Property(t => t.ChannelID).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.Qrcode).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.OtherChannelName).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.OtherQrcode).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.OperatedUserName).HasColumnType("nvarchar").HasMaxLength(256);
        }
    } 
    public class SourceStatisticConfiguration : EntityTypeConfiguration<SourceStatistic>
    {
        public SourceStatisticConfiguration()
        {
            HasKey(t => new { t.SourceStatisticsID });
            Property(t => t.UserId).HasColumnType("nvarchar").HasMaxLength(128); 
            Property(t => t.TableKeyID).HasColumnType("nvarchar").HasMaxLength(128); 
            Property(t => t.OSVersion).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.Title).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.RecommUserId).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.IP).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.SourceArea).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.Duration).HasColumnType("decimal");  //三位整數 max : 24*60mins = 1440mins
            Property(t => t.LoadTime).HasColumnType("int");
            Property(t => t.OpenID).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.VisitorIcon).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.VisitorIcon).HasColumnType("nvarchar").HasMaxLength(256);
            Property(t => t.ShopID).HasColumnType("nvarchar").HasMaxLength(20); 
            Property(t => t.WxNickName).HasColumnType("nvarchar").HasMaxLength(50); 
        }
    }

    public class UserTagConfiguration : EntityTypeConfiguration<UserTag>
    {
        public UserTagConfiguration()
        {
            HasKey(t => new { t.UserTagID });
            Property(t => t.TagName).HasColumnType("nvarchar").HasMaxLength(128);
        }
    }
    public class UserTraceConfiguration : EntityTypeConfiguration<UserTrace>
    {
        public UserTraceConfiguration()
        {
            HasKey(t => new { t.UserTraceID });
            Property(t => t.UserTraceID).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.TableKeyID).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.UserId).HasColumnType("nvarchar").HasMaxLength(128);
            Property(t => t.ShopID).HasColumnType("nvarchar").HasMaxLength(20);
            Property(t => t.OperatedUserName).HasColumnType("nvarchar").HasMaxLength(256);
        }
    }
}
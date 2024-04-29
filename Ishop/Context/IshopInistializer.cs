using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ishop.Models.ProductMgr;
using Ishop.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Ishop.Models;
using Ishop.Models.CampaignMgr;
using Ishop.Models.PubDataModal;
using Ishop.Models.Info;
using System.Configuration;

namespace Ishop.Context
{
    /// <summary>
    ///Set the initialization database and the seed data. The current global.ascx is set to null. Replace this sentence with the past.  //System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(new IshopInitializer()); 
    /// </summary>

    public class IshopInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    { 
        protected override void Seed(ApplicationDbContext context)
        {
            //超级用户的UserId = d0e87019-dd9d-4f8f-a649-6c64217d602e 改为 620000
            string ShopId = ConfigurationManager.AppSettings["DefaultShopID"].Trim();
            string UserId = "620000";
            ////角色初始化 网站全局常量数据
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole{Id="80000852-1268-1388-6668-132475536968",Name="Supervisor",Description="Supervisor"},
                new ApplicationRole{Id="20000852-1268-1388-6668-132475536962",Name="Admins",Description="Admins（Global）"},
                new ApplicationRole{Id="00000852-1268-1388-6668-132475536968",Name="AdminAnalyst",Description="AdminAnalyst"},
                new ApplicationRole{Id="90000852-1268-0758-6668-132475536969",Name="BusinessPromotion",Description="Business Promotion"},
                new ApplicationRole{Id="30000852-1268-1388-6668-132475536963",Name="CustomerService",Description="StoreCustomersService"},
                new ApplicationRole{Id="11110852-1368-1398-1616-132475536964",Name="GlobalUser",Description="GlobalUser"},
                new ApplicationRole{Id="11111852-1368-0758-1616-132475536967",Name="StoreAdmin",Description="Store Admin"},
                new ApplicationRole{Id="11111852-1368-0758-2626-132475536964",Name="StoreProductAdmin",Description="Store Product Admin"},
                new ApplicationRole{Id="11111852-1368-0758-3636-132475536965",Name="StorePreSales",Description="Store PreSales"},
                new ApplicationRole{Id="61111852-1368-0758-6868-132475536961",Name="StroeShippingClerk",Description="Stroe Shipping Clerk"},
                new ApplicationRole{Id="11110852-1368-0758-1616-132475536962",Name="StoreCustomersService",Description="Store Customers Service"},
                new ApplicationRole{Id="61111852-1368-0758-6262-132475536966",Name="StoreBusinessPromotion",Description="Store Business Promotion"} 
            };
            roles.ForEach(s => context.AspNetRoles.Add(s));
            context.SaveChanges();

            //添加用户 Id = 620000 
            ApplicationUser users = new ApplicationUser
            {
                Id = UserId,
                Email = "Admin@xyz.com",
                EmailConfirmed = true,
                PasswordHash = "AI1RkoKGCy8uhjlAQgrMwTn3ljFXXOed+H+1s2LDR98cRzcEwegtDTdbTgEA11/QiA==",
                SecurityStamp = "16b7ca85-5f66-4c1d-bb7a-1b7b73635d1a",
                PhoneNumber = "13800000000",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = "Admin@xyz.com"
            };
            context.Users.Add(users);
            context.SaveChanges();

            //初始化种子ID 
            var TableIdentitys = new List<TableIdentity>
            {
                new TableIdentity{ TableName ="AccountMgr" , TableIdentityID = 41 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="AspNetUsers" , TableIdentityID = 1 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="Campaign" , TableIdentityID = 1 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="Coupon" , TableIdentityID = 1 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="InfoDetail" , TableIdentityID = 77 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="MenuItem" , TableIdentityID = 72 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="Prodcate" , TableIdentityID = 2012 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="ProdPropertiesName" , TableIdentityID = 139 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="ProdPropertiesValue" , TableIdentityID = 119 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="Supplier" , TableIdentityID = 1 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="Shop" , TableIdentityID = 1 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="UserAddresses" , TableIdentityID =1 , OperatedDate = DateTime.Now },
                new TableIdentity{ TableName ="Changel" , TableIdentityID =7 , OperatedDate = DateTime.Now }
            };
            TableIdentitys.ForEach(a => context.tableIdentity.Add(a));
            context.SaveChanges();
            //Add user role (administrator  UserId=620000	Supervisor RoleId=00000852-1268-1388-6668-132475536968) 
            var UserRoles = new List<ApplicationUserRole>
            {
                new ApplicationUserRole{UserId=UserId,RoleId="80000852-1268-1388-6668-132475536968"} 
            }; 
            UserRoles.ForEach(s => context.UserRoles.Add(s));
            context.SaveChanges();

            ////Category initialization
            var prodcates = new List<Prodcate>
            {
                new Prodcate{ProdCateID="PC000001",Levels=0,ParentsProdCateID="0",ProdCateName="服装",IsLock=1},
                new Prodcate{ProdCateID="PC000011",Levels=1,ParentsProdCateID="PC000001",ProdCateName="男装",IsLock=1},
                new Prodcate{ProdCateID="PC000021",Levels=2,ParentsProdCateID="PC000011",ProdCateName="男装牛仔裤",IsLock=1},
                new Prodcate{ProdCateID="PC000012",Levels=1,ParentsProdCateID="PC000001",ProdCateName="女装",IsLock=1},
                new Prodcate{ProdCateID="PC000022",Levels=2,ParentsProdCateID="PC000012",ProdCateName="连衣裙",IsLock=1},
                new Prodcate{ProdCateID="PC000005",Levels=0,ParentsProdCateID="0",ProdCateName="工艺品",IsLock=1},
                new Prodcate{ProdCateID="PC000006",Levels=0,ParentsProdCateID="0",ProdCateName="厨具",IsLock=1},
                new Prodcate{ProdCateID="PC000007",Levels=0,ParentsProdCateID="0",ProdCateName="日用品",IsLock=1},
                new Prodcate{ProdCateID="PC000008",Levels=0,ParentsProdCateID="0",ProdCateName="美容",IsLock=1}
            };
            prodcates.ForEach(s => context.Prodcates.Add(s));
            context.SaveChanges();

            //属性初始化
            var ProdPropertiesNames = new List<ProdPropertiesName>
            {
                new ProdPropertiesName{ProdCateID="PC000021",ProdCateName="男装牛仔裤",PropertiesNameID="PN00000001",PropertiesName="腰型",IsForTrading=0},
                new ProdPropertiesName{ProdCateID="PC000021",ProdCateName="男装牛仔裤",PropertiesNameID="PN00000002",PropertiesName="尺寸",IsForTrading=1},
                new ProdPropertiesName{ProdCateID="PC000021",ProdCateName="男装牛仔裤",PropertiesNameID="PN00000003",PropertiesName="裤型",IsForTrading=0},
                new ProdPropertiesName{ProdCateID="PC000021",ProdCateName="男装牛仔裤",PropertiesNameID="PN00000004",PropertiesName="颜色",IsForTrading=1}
            };
            ProdPropertiesNames.ForEach(s => context.ProdPropertiesNames.Add(s));
            context.SaveChanges();

            //属性值初始化 ProdPropertiesValue 
            var ProdPropertiesValues = new List<ProdPropertiesValue>
            {
               new ProdPropertiesValue{ ProdCateID = "PC000021", ProdCateName = "男装牛仔裤" ,  PropertiesNameID = "PN00000002" , PropertiesName = "尺寸", PropertiesValueID = "PV00000001" , PropertiesValueName = "27寸" ,  OperatedUserName = "Admin" ,  OperatedDate = DateTime.Now },
               new ProdPropertiesValue{ ProdCateID = "PC000021", ProdCateName = "男装牛仔裤" ,  PropertiesNameID = "PN00000002" , PropertiesName = "尺寸", PropertiesValueID = "PV00000002" , PropertiesValueName = "28寸" ,  OperatedUserName = "Admin" ,  OperatedDate = DateTime.Now },
               new ProdPropertiesValue{ ProdCateID = "PC000021", ProdCateName = "男装牛仔裤" ,  PropertiesNameID = "PN00000002" , PropertiesName = "尺寸", PropertiesValueID = "PV00000003" , PropertiesValueName = "29寸" ,  OperatedUserName = "Admin" ,  OperatedDate = DateTime.Now }
            };
            ProdPropertiesValues.ForEach(a => context.ProdPropertiesValues.Add(a));
            context.SaveChanges();

            //商品销售状态  // Online="在售",Offline="下架" , InStudio="设计拍摄中", OutStock="售罄" 
            var saleStatus = new List<SaleStatus>
            {
                new SaleStatus{SaleStatusID="Online" ,SaleStatusDesc="在售"},
                new SaleStatus{SaleStatusID="Offline" ,SaleStatusDesc="下架"},
                new SaleStatus{SaleStatusID="InStudio" ,SaleStatusDesc="设计拍摄中"},
                new SaleStatus{SaleStatusID="OutStock" ,SaleStatusDesc="售罄"}
            };
            saleStatus.ForEach(c => context.saleStatus.Add(c));
            context.SaveChanges();

            //供应商初始化
            var Suppliers = new List<Supplier>
            {
                 new Supplier{SupplierID = "Supp0001",SupplierName = "iShop", ContactNick = "Tony", ContactName ="Ugege", PhoneNumber = "13712345888" ,CompanyName = "Ishop Supplier",CompanyAddress = "ZhongShan Road No 118",ShopID= ShopId,Remarks="New Arrival",OperatedUserName ="Admin", OperatedDate = DateTime.Now }

            };
            Suppliers.ForEach(a => context.Suppliers.Add(a));
            context.SaveChanges();
             
            var Shops = new List<Shop>
            {
                new Shop{ShopID =ShopId ,ShopName ="iShop",ShopLogo ="sh0001_60X60.jpg",FooterTemplate = "" , UserId=UserId,UserName ="Supervisor@xyz.com",ShopCurrency = "zh-CN" , PhoneNumber="13247553696",OperatedUserName ="Supervisor@xyz.com",OperatedDate =DateTime.Now }

            };
            Shops.ForEach(a => context.Shops.Add(a));
            context.SaveChanges();
             
            var Campaigns = new List<Campaign>
            {
                new Campaign{ CampaignID ="Camp000001" , CampaignName ="周年纪念活动", CampaignLabel ="周年纪念惠", ShopID = ShopId ,  StartDate=DateTime.Now, EndDate =DateTime.Now.AddDays(90), CampaignDesc = "周年纪念惠 满5件送一件" , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Parse("2016-12-1 16:56:59")}

            };
            Campaigns.ForEach(a => context.Campaigns.Add(a));
            context.SaveChanges();
             
            var Coupons = new List<Coupon>
            {
                new Coupon{ CouponID ="C000001" , ShopID =ShopId, CouponName ="满199元减10元现金劵", Conditions = 199 ,FaceValue =10  , StartDate=DateTime.Now, EndDate =DateTime.Now.AddDays(90), IssueQuantity = 500 ,Mode = IssueMode.BuyerGet , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now }
            };
            Coupons.ForEach(a => context.Coupons.Add(a));
            context.SaveChanges();
             
            var UserAddresses = new List<UserAddress>
            {
                new UserAddress{UserAddressID="UA00000000001" ,UserId=UserId,Country="香港",State="北京",District="时代区",Address="阿皆街",PostCode="1000000",PhoneNumber="138001380000",TelePhoneNumber="+85266668888",OperatedUserName ="Admin",OperatedDate = DateTime.Now }
            };
            UserAddresses.ForEach(a => context.UserAddresses.Add(a));
            context.SaveChanges();

            
            var AccountWebSites = new List<AccountWebSite>
            {
                 new AccountWebSite{ WebSiteID ="163com" , WebSite ="http://www.163.com", SiteName ="网易"  }
                ,new AccountWebSite{ WebSiteID ="alipay" , WebSite ="http://www.alipay.com", SiteName ="支付宝"  }
                ,new AccountWebSite{ WebSiteID ="baidu" , WebSite ="http://www.baidu.com", SiteName ="百度"  }
                ,new AccountWebSite{ WebSiteID ="douban" , WebSite ="http://www.douban.com", SiteName ="豆瓣"  }
                ,new AccountWebSite{ WebSiteID ="google" , WebSite ="http://www.google.HK", SiteName ="谷歌"  }
                ,new AccountWebSite{ WebSiteID ="QQ" , WebSite ="http://www.QQ.com", SiteName ="QQ平台"  }
                ,new AccountWebSite{ WebSiteID ="sina" , WebSite ="http://www.sina.com.cn", SiteName ="新浪"  }
                ,new AccountWebSite{ WebSiteID ="sohu" , WebSite ="http://www.sohu.com", SiteName ="搜狐"  }
                ,new AccountWebSite{ WebSiteID ="taobao" , WebSite ="http://www.taobao.com", SiteName ="淘宝"  }
                ,new AccountWebSite{ WebSiteID ="weibo" , WebSite ="http://www.weibo.com", SiteName ="微博"  }
                ,new AccountWebSite{ WebSiteID ="weixin" , WebSite ="http://www.weixin.com", SiteName ="微信"  }
                ,new AccountWebSite{ WebSiteID ="zhubajie" , WebSite ="http://www.zhubajie.com", SiteName ="猪八戒"  }
                ,new AccountWebSite{ WebSiteID ="FB" , WebSite ="http://www.facebook.com", SiteName ="脸谱"  }
                ,new AccountWebSite{ WebSiteID ="Other" , WebSite ="http://www.Other.com", SiteName ="其他"  }
            };
            AccountWebSites.ForEach(a => context.AccountWebSites.Add(a));
            context.SaveChanges();
             
            var InfoCates = new List<InfoCate>
            {
                  new InfoCate{ InfoCateID ="IC0001" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="About", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "zh-CN"},
                  new InfoCate{ InfoCateID ="IC0001" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="About", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now  ,LanguageCode = "zh-HK"},
                  new InfoCate{ InfoCateID ="IC0001" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="About", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now  ,LanguageCode = "en-US"},
                  new InfoCate{ InfoCateID ="IC0002" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="分类2", Levels = 0  , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now,LanguageCode = "zh-CN" },
                  new InfoCate{ InfoCateID ="IC0003" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="分类3", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "zh-CN" },
                  new InfoCate{ InfoCateID ="IC0004" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="分类4", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "zh-CN" },
                  new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="专业知识", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "zh-CN" }
                 ,new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="專業知識", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "zh-HK" }
                 ,new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="Professional knowledge", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "en-US" }
                 ,new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="Professionelles Wissen", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "de" }
                 ,new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="Connaissances professionnelles", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "fr" }
                 ,new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="专业知识", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "ar" }
                 ,new InfoCate{ InfoCateID ="IC0005" , ShopID = ShopId ,PrarentsID= "0", InfoCateName ="Conhecimento profissional", Levels = 0 , OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now ,LanguageCode = "es" }
            };
            InfoCates.ForEach(a => context.InfoCates.Add(a));
            context.SaveChanges();
             
            var InfoItemTemplates = new List<InfoItemTemplate>
            {
                 new InfoItemTemplate{ InfoItemTemplateID ="InfoTemp00001" , InfoItemTemplateName = "Jumptron橫屏模板" ,Path= "~/Views/InfoList/_InfoDetailJumbotronUnit.cshtml", ShopID = ShopId, OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now },
                 new InfoItemTemplate{ InfoItemTemplateID ="InfoTemp00002" , InfoItemTemplateName = "列表项模板" ,Path= "~/Views/Shared/Info/InfoListUnit.cshtml", ShopID = ShopId, OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now }
            };
            InfoCates.ForEach(a => context.InfoCates.Add(a));
            context.SaveChanges();
             
            var Channels = new List<Channel>
            {
                 new Channel{ ChannelID ="CH00000000" , ChannelName = "微信" ,ChannelUrl= "http://www.weixin.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now },
                 new Channel{ ChannelID ="CH00000001" , ChannelName = "微信公众号" ,ChannelUrl= "http://www.weixin.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now },
                 new Channel{ ChannelID ="CH00000002" , ChannelName = "微信小程序" ,ChannelUrl= "http://mp.weixin.qq.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now },
                 new Channel{ ChannelID ="CH00000003" , ChannelName = "新浪博客" ,ChannelUrl= "http://blog.sina.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now },
                 new Channel{ ChannelID ="CH00000004" , ChannelName = "微博" ,ChannelUrl= "http://www.weibo.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now  },
                 new Channel{ ChannelID ="CH00000005" , ChannelName = "头条新闻" ,ChannelUrl= "http://www.toutiao.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now  },
                 new Channel{ ChannelID ="CH00000006" , ChannelName = "facebook" ,ChannelUrl= "http://www.facebook.com", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now  },
                 new Channel{ ChannelID ="CH00000007" , ChannelName = "google" ,ChannelUrl= "http://www.google.com.hk", OperatedUserName ="Supervisor@xyz.com",OperatedDate = DateTime.Now  }
            };
            Channels.ForEach(a => context.Channels.Add(a));
            context.SaveChanges();
              
            var tableState = new List<TableState>
            {
                new TableState{Id="TS001" ,TableName = "DispatchNote" ,StatusId="Unpaid",StatusName = "未支付" ,LanguageCode = "zh-CN"},
                new TableState{Id="TS002" ,TableName = "DispatchNote" ,StatusId="Unpaid",StatusName = "Unpaid" ,LanguageCode = "zh-HK"},
                new TableState{Id="TS003" ,TableName = "DispatchNote" ,StatusId="Unpaid",StatusName = "未支付" ,LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS004" ,TableName = "DispatchNote" ,StatusId="Unpaid",StatusName = "Unpaid" ,LanguageCode = "en-US"},

                new TableState{Id="TS005" ,TableName = "DispatchNote" ,StatusId="Receipted",StatusName = "已收款",LanguageCode = "zh-CN"},
                new TableState{Id="TS006" ,TableName = "DispatchNote" ,StatusId="Receipted",StatusName = "Receipted",LanguageCode = "zh-HK"},
                new TableState{Id="TS007" ,TableName = "DispatchNote" ,StatusId="Receipted",StatusName = "已收款",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS008" ,TableName = "DispatchNote" ,StatusId="Receipted",StatusName = "Receipted",LanguageCode = "en-US"},

                new TableState{Id="TS009" ,TableName = "DispatchNote" ,StatusId="OutOfStock",StatusName = "缺货",LanguageCode = "zh-CN"},
                new TableState{Id="TS010" ,TableName = "DispatchNote" ,StatusId="OutOfStock",StatusName = "OutOfStock",LanguageCode = "zh-HK"},
                new TableState{Id="TS011" ,TableName = "DispatchNote" ,StatusId="OutOfStock",StatusName = "缺貨",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS012" ,TableName = "DispatchNote" ,StatusId="OutOfStock",StatusName = "OutOfStock",LanguageCode = "en-US"},

                new TableState{Id="TS013" ,TableName = "DispatchNote" ,StatusId="PickingUp",StatusName = "捡货",LanguageCode = "zh-CN"},
                new TableState{Id="TS014" ,TableName = "DispatchNote" ,StatusId="PickingUp",StatusName = "PickingUp",LanguageCode = "zh-HK"},
                new TableState{Id="TS015" ,TableName = "DispatchNote" ,StatusId="PickingUp",StatusName = "撿貨",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS016" ,TableName = "DispatchNote" ,StatusId="PickingUp",StatusName = "PickingUp",LanguageCode = "en-US"},

                new TableState{Id="TS017" ,TableName = "DispatchNote" ,StatusId="HasSent",StatusName = "已发货",LanguageCode = "zh-CN"},
                new TableState{Id="TS018" ,TableName = "DispatchNote" ,StatusId="HasSent",StatusName = "HasSent",LanguageCode = "zh-HK"},
                new TableState{Id="TS019" ,TableName = "DispatchNote" ,StatusId="HasSent",StatusName = "已发貨",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS020" ,TableName = "DispatchNote" ,StatusId="HasSent",StatusName = "HasSent",LanguageCode = "en-US"},

                new TableState{Id="TS021" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "有效的",LanguageCode = "zh-CN"},
                new TableState{Id="TS022" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "Invalid",LanguageCode = "zh-HK"},
                new TableState{Id="TS023" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "有效的",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS024" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "Invalid",LanguageCode = "en-US"},

                new TableState{Id="TS025" ,TableName = "UserFinanceItem" ,StatusId="Unvalid",StatusName = "无效的",LanguageCode = "zh-CN"},
                new TableState{Id="TS026" ,TableName = "UserFinanceItem" ,StatusId="Unvalid",StatusName = "Unvalid",LanguageCode = "zh-HK"},
                new TableState{Id="TS027" ,TableName = "UserFinanceItem" ,StatusId="Unvalid",StatusName = "無效的",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS028" ,TableName = "UserFinanceItem" ,StatusId="Unvalid",StatusName = "Unvalid",LanguageCode = "en-US"},

                new TableState{Id="TS029" ,TableName = "UserFinanceItem" ,StatusId="Cancel",StatusName = "取消",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS030" ,TableName = "UserFinanceItem" ,StatusId="Cancel",StatusName = "Cancel",LanguageCode = "zh-HK"},
                new TableState{Id="TS031" ,TableName = "UserFinanceItem" ,StatusId="Cancel",StatusName = "取消",LanguageCode = "zh-CN"},
                new TableState{Id="TS032" ,TableName = "UserFinanceItem" ,StatusId="Cancel",StatusName = "Cancel",LanguageCode = "en-US"},
                
                new TableState{Id="TS033" ,TableName = "UserFinance" ,StatusId="Paid",StatusName = "已支付",LanguageCode = "zh-CN"},
                new TableState{Id="TS034" ,TableName = "UserFinance" ,StatusId="Paid",StatusName = "已支付",LanguageCode = "zh-HK"},
                new TableState{Id="TS035" ,TableName = "UserFinance" ,StatusId="Paid",StatusName = "未兌現",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS036" ,TableName = "UserFinance" ,StatusId="Paid",StatusName = "Paid",LanguageCode = "en-US"},

                new TableState{Id="TS037" ,TableName = "UserFinance" ,StatusId="Unpaid",StatusName = "未支付",LanguageCode = "zh-CN"},
                new TableState{Id="TS038" ,TableName = "UserFinance" ,StatusId="Unpaid",StatusName = "Unpaid",LanguageCode = "en-US"},
                new TableState{Id="TS039" ,TableName = "UserFinance" ,StatusId="UnPaid",StatusName = "未兌現",LanguageCode = "zh-HK"},
                new TableState{Id="TS040" ,TableName = "UserFinance" ,StatusId="UnPaid",StatusName = "未兌現",LanguageCode = "zh-hants-HK"},

                new TableState{Id="TS040" ,TableName = "UserFinance" ,StatusId="Submited",StatusName = "提交",LanguageCode = "zh-CN"},
                new TableState{Id="TS040" ,TableName = "UserFinance" ,StatusId="Submited",StatusName = "提交",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS040" ,TableName = "UserFinance" ,StatusId="Submited",StatusName = "提交",LanguageCode = "zh-HK"},
                new TableState{Id="TS040" ,TableName = "UserFinance" ,StatusId="Submited",StatusName = "Submited",LanguageCode = "en-US"},

                new TableState{Id="TS041" ,TableName = "UserFinanceItem" ,StatusId="Created",StatusName = "创建",LanguageCode = "zh-CN"},
                new TableState{Id="TS042" ,TableName = "UserFinanceItem" ,StatusId="Created",StatusName = "Created",LanguageCode = "zh-HK"},
                new TableState{Id="TS043" ,TableName = "UserFinanceItem" ,StatusId="Created",StatusName = "創建",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS044" ,TableName = "UserFinanceItem" ,StatusId="Created",StatusName = "Created",LanguageCode = "en-US"},

                new TableState{Id="TS045" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "无效",LanguageCode = "zh-CN"},
                new TableState{Id="TS046" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "無效",LanguageCode = "zh-HK"},
                new TableState{Id="TS047" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "無效",LanguageCode = "zh-hants-HK"},
                new TableState{Id="TS048" ,TableName = "UserFinanceItem" ,StatusId="Invalid",StatusName = "Invalid",LanguageCode = "en-US"} 
            };
            tableState.ForEach(c => context.TableStates.Add(c));
            context.SaveChanges();
             
            var infoDetail = new List<InfoDetail>
            {  
             new InfoDetail{ InfoID="about",InfoCateID ="IC0001" ,Title="",TitleThumbNail="",ShowTitleThumbNail=true,SubTitle="",SeoKeyword="",SeoDescription="",InfoDescription="",VideoUrl="",Author="",Views=1,ShopID=ConfigurationManager.AppSettings["DefaultShopID"],OperatedUserName="Supervisor@xyz.com",CreatedDate= DateTime.Now ,OperatedDate = DateTime.Now ,ShopStaffID= UserId ,InfoItemTemplateIDs="",IsOriginal=true}  
            ,new InfoDetail { InfoID = "about2", InfoCateID = "IC0001", Title = "", TitleThumbNail = "", ShowTitleThumbNail = true, SubTitle = "", SeoKeyword = "", SeoDescription = "", InfoDescription = "", VideoUrl = "", Author = "", Views = 1, ShopID = ConfigurationManager.AppSettings["DefaultShopID"], OperatedUserName = "Supervisor@xyz.com", CreatedDate = DateTime.Now, OperatedDate = DateTime.Now, ShopStaffID = UserId , InfoItemTemplateIDs = "", IsOriginal = true }
            ,new InfoDetail { InfoID = "about3", InfoCateID = "IC0001", Title = "", TitleThumbNail = "", ShowTitleThumbNail = true, SubTitle = "", SeoKeyword = "", SeoDescription = "", InfoDescription = "", VideoUrl = "", Author = "", Views = 1, ShopID = ConfigurationManager.AppSettings["DefaultShopID"], OperatedUserName = "Supervisor@xyz.com", CreatedDate = DateTime.Now, OperatedDate = DateTime.Now, ShopStaffID = UserId , InfoItemTemplateIDs = "", IsOriginal = true }
            ,new InfoDetail { InfoID = "promotion", InfoCateID = "IC0001", Title = "", TitleThumbNail = "", ShowTitleThumbNail = true, SubTitle = "how to promotion", SeoKeyword = "how to promotion", SeoDescription = "how to promotion", InfoDescription = "how to promotion", VideoUrl = "", Author = "", Views = 1, ShopID = ShopId, OperatedUserName = "Supervisor@xyz.com", CreatedDate = DateTime.Now, OperatedDate = DateTime.Now, ShopStaffID = UserId , InfoItemTemplateIDs = "", IsOriginal = true }
             };
            infoDetail.ForEach(c => context.InfoDetails.Add(c));
            context.SaveChanges();
        }
    }
}
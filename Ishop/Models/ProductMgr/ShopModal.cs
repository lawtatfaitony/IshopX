using DataAnnotationsExtensions;
using Ishop.Utilities;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace Ishop.Models.ProductMgr
{
    /// <summary>
    /// 销售状态ID :  OnLine在售,OffLine下架 , InStudio制作设计中, OutStock 售罄, defaut保留值
    /// </summary>
    public enum SaleStatusID
    {
        // Online="在售",Offline="下架" , InStudio="设计拍摄中", OutOfStock="售罄" 
        Online = 1, Offline = 2, InStudio = 3, OutOfStock = 4
    }
    /// <summary>
    /// 商品表
    /// </summary>
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(20)]
        [LocalizedDisplayName("商品ID", KeyName = "Product_ProductID", KeyType = KeyType.Modal)]
        public string ProductID { get; set; }

        [LocalizedDisplayName("类目ID", KeyName = "Product_ProdCateID", KeyType = KeyType.Modal)]
        [StringLength(8, ErrorMessage = "类目ID长度规定为8位")]
        [Column(TypeName = "nvarchar")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProdCateID { get; set; }

        [StringLength(30, MinimumLength = 2, ErrorMessage = "商品名称最少2字，最大30字")]
        [LocalizedDisplayName("商品名称", KeyName = "Product_ProductName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")] //空商品名称显示为：-
        public string ProductName { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "商品优化标题最少2字，最大60字")]
        [LocalizedDisplayName("商品标题", KeyName = "Product_Title", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")] //空商品优化标题显示为：-
        public string Title { get; set; }

        [StringLength(256, MinimumLength = 6, ErrorMessage = "必需选择商品主图")]
        [LocalizedDisplayName("商品主图", KeyName = "Product_ProductImg", KeyType = KeyType.Modal)]
        public string ProductImg { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "填入A-Z,a-z,0-9组成的货号")]
        [LocalizedDisplayName("货号", KeyName = "Product_StyleNo", KeyType = KeyType.Modal)]
        public string StyleNo { get; set; }

        [LocalizedDisplayName("商品描述", KeyName = "Product_ProdDesc", KeyType = KeyType.Modal)]
        public string ProdDesc { get; set; }

        [LocalizedDisplayName("视频连接", KeyName = "Product_VideoUrl", KeyType = KeyType.Modal)]
        [Column("VideoUrl", TypeName = "nvarchar")]
        //[Url] //[RegularExpression(@"^(http://|https://)?((?:[A-Za-z0-9]+-[A-Za-z0-9]+|[A-Za-z0-9]+)\.)+([A-Za-z]+)[/\?\:]?.*$", ErrorMessage = "连接格式错误")]
        [DefaultValue("#")]
        [StringLength(512)]
        public string VideoUrl { get; set; }

        [StringLength(300)]
        [LocalizedDisplayName("店内分类ID", KeyName = "Product_CategoryIDs", KeyType = KeyType.Modal)]
        public string CategoryIDs { get; set; }  //可多选,英文逗号隔开

        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "Product_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "名称格式例如:Shop001,Shop为前缀")]
        public string ShopID { get; set; }

        [StringLength(20)]
        [LocalizedDisplayName("供应商ID", KeyName = "Product_SupplierID", KeyType = KeyType.Modal)]
        public string SupplierID { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "0")]
        [DefaultValue(0)]
        [LocalizedDisplayName("成交价格", KeyName = "Product_TradePrice", KeyType = KeyType.Modal)]  // 通过活动系统设定计算

        public decimal TradePrice { get; set; }

        [Required]
        [LocalizedDisplayName("零售价格", KeyName = "Product_RetailPrice", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        [Display(Name = "零售价格")] //用户填入
        public decimal RetailPrice { get; set; }

        [LocalizedDisplayName("佣金率", KeyName = "Product_CommisionRate", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        [Digits]
        public int CommisionRate { get; set; }

        [Required]
        [DefaultValue(0)]
        [LocalizedDisplayName("浏览IP数", KeyName = "Product_ViewsIP", KeyType = KeyType.Modal)]
        public int ViewsIP { get; set; }

        [StringLength(20)]
        [LocalizedDisplayName("推荐者展示", KeyName = "Product_StaffID", KeyType = KeyType.Modal)]
        public string StaffID { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "Product_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "Product_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "Product_CreatedDate", KeyType = KeyType.Modal)]
        public DateTime CreatedDate { get; set; }

        [LocalizedDisplayName("销售状态", KeyName = "Product_SaleStatusID", KeyType = KeyType.Modal)]
        public string SaleStatusID { get; set; }
    }
    /// <summary>
    /// 商品销售状态
    /// </summary>
    public class SaleStatus
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("销售状态ID", KeyName = "SaleStatus_SaleStatusID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 3)]
        public string SaleStatusID { get; set; }
         
        [LocalizedDisplayName("销售状态描述", KeyName = "SaleStatus_SaleStatusDesc", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 2)]
        public string SaleStatusDesc { get; set; }
    }
    /// <summary>
    /// 店铺内分类
    /// </summary>
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(20, ErrorMessage = "系统缺少分配类目ID")]
        [LocalizedDisplayName("店内分类ID", KeyName = "Category_CategoryID", KeyType = KeyType.Modal)]
        public string CategoryID { get; set; }

        [Required(ErrorMessage = "<br/><i class=\"fa fa - exclamation - triangle\">必需选择店铺主类ID,默认为0</i>")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "<br/><i class=\"fa fa - exclamation - triangle\">必需选择店铺主类ID,父类ID默认为0</i>")]
        [Display(Name = "父类ID")]
        [LocalizedDisplayName("父类ID", KeyName = "Category_ParentsCategoryID", KeyType = KeyType.Modal)]
        public string ParentsCategoryID { get; set; }
         
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "没有存在有效店铺")]
        [LocalizedDisplayName("店铺ID", KeyName = "Category_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [Required(ErrorMessage = "<i class=\"fa fa-exclamation-triangle\">店内自定义分类名称是必需的</i>")]
        [LocalizedDisplayName("店内分类名称", KeyName = "Category_CategoryName", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "<i class=\"fa fa-exclamation-triangle\">店内自定义分类名称太长,50字内</i>")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        [LocalizedDisplayName("店内分类描述", KeyName = "Category_CategoryDesc", KeyType = KeyType.Modal)]
        public string CategoryDesc { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "Category_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [Display(Name = "操作日期")]
        [DisplayFormat(NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }

    }
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [LocalizedDisplayName("店内分类ID", KeyName = "ProductCategory_CategoryID", KeyType = KeyType.Modal)]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(20)]
        [LocalizedDisplayName("商品ID", KeyName = "ProductCategory_ProductID", KeyType = KeyType.Modal)]
        public string ProductID { get; set; }

    }
    /// <summary>
    /// 商品类目表
    /// </summary>
    public class Prodcate
    {
        public Prodcate()
        {
            ParentsProdCateID = "0";  //设置默认值
        }  
        [LocalizedDisplayName("类目ID", KeyName = "Prodcate_ProdCateID", KeyType = KeyType.Modal)]
        [StringLength(128, MinimumLength = 1)]
        [MaxLength(128)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "nvarchar")]
        public string ProdCateID { get; set; }
         
        [LocalizedDisplayName("类目层级", KeyName = "Prodcate_Levels", KeyType = KeyType.Modal)]
        public int Levels { get; set; }

        [LocalizedDisplayName("父类ID", KeyName = "Prodcate_ParentsProdCateID", KeyType = KeyType.Modal)]
        
        public string ParentsProdCateID { get; set; }

        [Required]
        [LocalizedDisplayName("类目名称", KeyName = "Prodcate_ProdCateName", KeyType = KeyType.Modal)]
        [MaxLength(200)]
        public string ProdCateName { get; set; }
        //是否显示
        [Range(0, 1)]
        [Display(Name = "显示")]
        [LocalizedDisplayName("显示", KeyName = "Prodcate_IsLock", KeyType = KeyType.Modal)]
        public int IsLock { get; set; }

        //类目下的产品集合
        public virtual ICollection<Product> Products { get; set; }
    }

    /// <summary>
    /// 商品属性名称
    /// </summary>
    public class ProdPropertiesName
    { 
        [Required]
        [LocalizedDisplayName("类目ID", KeyName = "ProdPropertiesName_ProdCateID", KeyType = KeyType.Modal)]
        [MaxLength(8)]
        public string ProdCateID { get; set; }
         
        [Required]
        [LocalizedDisplayName("类目名称", KeyName = "ProdPropertiesName_ProdCateName", KeyType = KeyType.Modal)]
        [MaxLength(200)]
        public string ProdCateName { get; set; }
         
        [Key]
        [Required]
        [DisplayName("Prop NameID")]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PropertiesNameID { get; set; }
         
        [Required]
        [LocalizedDisplayName("属性名称", KeyName = "ProdPropertiesName_PropertiesName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string PropertiesName { get; set; }

        //IsForTrading
        //是否显示
        //[Range(0, 1)]
        [Required]
        [LocalizedDisplayName("是否为交易属性", KeyName = "ProdPropertiesName_IsForTrading", KeyType = KeyType.Modal)]

        public int IsForTrading { get; set; }

        
        [LocalizedDisplayName("展示图片", KeyName = "ProdPropertiesName_ShowPicture", KeyType = KeyType.Modal)]

        [DefaultValue(0)]
        public int ShowPicture { get; set; }
    }
    /// <summary>
    /// 属性值表
    /// </summary>
    public class ProdPropertiesValue
    { 
        [Required]
        [LocalizedDisplayName("类目ID", KeyName = "ProdPropertiesValue_ProdCateID", KeyType = KeyType.Modal)]
        [StringLength(8, MinimumLength = 1)]
        public string ProdCateID { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        [LocalizedDisplayName("类目名称", KeyName = "ProdPropertiesValue_ProdCateName", KeyType = KeyType.Modal)]
        public string ProdCateName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        [LocalizedDisplayName("属性ID", KeyName = "ProdPropertiesValue_PropertiesNameID", KeyType = KeyType.Modal)]
        public string PropertiesNameID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [LocalizedDisplayName("属性名称", KeyName = "ProdPropertiesValue_PropertiesName", KeyType = KeyType.Modal)]
        public string PropertiesName { get; set; }
        
        [Key]
        [StringLength(10)]
        //[LocalizedDisplayName("属性值ID", KeyName = "ProdPropertiesValue_PropertiesValueID", KeyType = KeyType.Modal)]
        [Display(Name = "PropValId")]
        public string PropertiesValueID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [LocalizedDisplayName("属性值", KeyName = "ProdPropertiesValue_PropertiesValueName", KeyType = KeyType.Modal)]
        public string PropertiesValueName { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "ProdPropertiesValue_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作时间", KeyName = "ProdPropertiesValue_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("店铺ID", KeyName = "Shop_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }

        [Required]
        [LocalizedDisplayName("店铺名称", KeyName = "Shop_ShopName", KeyType = KeyType.Modal)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "必需填入店铺名称")]
        public string ShopName { get; set; }

        [Required]
        [LocalizedDisplayName("店铺logo", KeyName = "Shop_ShopLogo", KeyType = KeyType.Modal)]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "必需填入店铺名称")]
        public string ShopLogo { get; set; }

        [LocalizedDisplayName("微信二维码", KeyName = "Shop_WeixinQRcode", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string WeixinQRcode { get; set; }

        [LocalizedDisplayName("微博二维码", KeyName = "Shop_WeiboQRcode", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string WeiboQRcode { get; set; }

        [LocalizedDisplayName("头条二维码", KeyName = "Shop_ToutiaoQRcode", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string ToutiaoQRcode { get; set; }

        [LocalizedDisplayName("fb二维码", KeyName = "Shop_fbQRcode", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string fbQRcode { get; set; }

        [LocalizedDisplayName("页脚模板", KeyName = "Shop_FooterTemplate", KeyType = KeyType.Modal)]
        [MaxLength(512)]
        [StringLength(512)]
        public string FooterTemplate { get; set; }

        [LocalizedDisplayName("证书", KeyName = "Shop_cerPath", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        [StringLength(256)]
        public string cerPath { get; set; }
         
        //用户信息 UserId,UserName,PhoneNumber
        [Required]
        [Display(Name = "UserId")]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [LocalizedDisplayName("店长", KeyName = "Shop_UserName", KeyType = KeyType.Modal)]
        [StringLength(256, ErrorMessage = "必需填入用户名")]
        public string UserName { get; set; }

        [Required]
        [LocalizedDisplayName("展示货币", KeyName = "Shop_ShopCurrency", KeyType = KeyType.Modal)]
        [StringLength(20, ErrorMessage = "交易显示的货比,比不一定是支付接口货币")]
        public string ShopCurrency { get; set; }

        [Required]
        [LocalizedDisplayName("服务电话", KeyName = "Shop_PhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(128, ErrorMessage = "必需填入服务手机或电话")] 
        public string PhoneNumber { get; set; }

        [Required]
        [LocalizedDisplayName("域名", KeyName = "Shop_HostName", KeyType = KeyType.Modal)] 
        public string HostName { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "Shop_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "Shop_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }
         
        public DateTime CreatedDate { get; set; }

        [LocalizedDisplayName("资讯模式", KeyName = "Shop_IsInfoMode", KeyType = KeyType.Modal)]
        [DefaultValue(1)]
        public int IsInfoMode { get; set; }

        
    }
    public class ShopStaff
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [LocalizedDisplayName("员工编号", KeyName = "ShopStaff_ShopStaffID", KeyType = KeyType.Modal)] 
        [StringLength(128, MinimumLength = 6)]
        public string ShopStaffID { get; set; }

        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "ShopStaff_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 1)]
        public string ShopID { get; set; }

        [Required]
        [Display(Name = "UserId")]
        [LocalizedDisplayName("UserId", KeyName = "ShopStaff_UserId", KeyType = KeyType.Modal)]
        [StringLength(128,MinimumLength =1)]
        public string UserId { get; set; }

        [Required]
        [LocalizedDisplayName("UserName", KeyName = "ShopStaff_UserName", KeyType = KeyType.Modal)]
        [StringLength(128,MinimumLength = 1)]
        public string UserName { get; set; }

        [LocalizedDisplayName("形象照", KeyName = "ShopStaff_IconPortrait", KeyType = KeyType.Modal)]
        [StringLength(256, MinimumLength = 1)]
        public string IconPortrait { get; set; }

        [Required]
        [LocalizedDisplayName("成员姓名/昵称", KeyName = "ShopStaff_StaffName", KeyType = KeyType.Modal)]
        [StringLength(256, MinimumLength = 1)]
        public string StaffName { get; set; }

        [LocalizedDisplayName("会员确认", KeyName = "ShopStaff_IsConfirmed", KeyType = KeyType.Modal)]  //如果系统自动确认.=true,不需要会员确认
        public bool IsConfirmed { get; set; }

        [LocalizedDisplayName("公众号", KeyName = "ShopStaff_PublicNo", KeyType = KeyType.Modal)]
        [StringLength(300)]
        public string PublicNo { get; set; }

        [LocalizedDisplayName("头衔", KeyName = "ShopStaff_ContactTitle", KeyType = KeyType.Modal)]
        [StringLength(100)]
        public string ContactTitle { get; set; }

        [LocalizedDisplayName("简介", KeyName = "ShopStaff_Introduction", KeyType = KeyType.Modal)]
        public string Introduction { get; set; }

        [LocalizedDisplayName("渠道名称", KeyName = "ShopStaff_ChannelID", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string ChannelID { get; set; }

        [LocalizedDisplayName("二维码", KeyName = "ShopStaff_Qrcode", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string Qrcode { get; set; }

        [LocalizedDisplayName("其它渠道名称", KeyName = "ShopStaff_OtherChannelName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OtherChannelName { get; set; }

        [LocalizedDisplayName("其他二维码", KeyName = "ShopStaff_OtherQrcode", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OtherQrcode { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "ShopStaff_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "ShopStaff_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }
    }
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "供应商ID")]
        [LocalizedDisplayName("供应商ID", KeyName = "Supplier_SupplierID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "名称格式例如:Su001,Su为前缀,4-20位字符")]
        public string SupplierID { get; set; }

        [Required]
        [LocalizedDisplayName("供应商名称", KeyName = "Supplier_SupplierID", KeyType = KeyType.Modal)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "必需填入供应商名称")]
        public string SupplierName { get; set; }

        //供应商匿名 用于隐藏真实信息,提供内部员工沟通使用 
        [Required]
        [Display(Name = "供应商匿名")]
        [LocalizedDisplayName("供应商匿名", KeyName = "Supplier_ContactNick", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string ContactNick { get; set; }
         
        [LocalizedDisplayName("联系人", KeyName = "Supplier_ContactName", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string ContactName { get; set; }
         
        [LocalizedDisplayName("联系人手机", KeyName = "Supplier_PhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "公司名称")]
        [LocalizedDisplayName("公司名称", KeyName = "Supplier_CompanyName", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Display(Name = "公司地址")]
        [LocalizedDisplayName("公司地址", KeyName = "Supplier_CompanyAddress", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string CompanyAddress { get; set; }

        [Required]
        [Display(Name = "店铺ID")]
        [LocalizedDisplayName("店铺ID", KeyName = "Supplier_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "名称格式例如:Shop001,Shop为前缀")]
        public string ShopID { get; set; }
         
        [LocalizedDisplayName("备注", KeyName = "Supplier_Remarks", KeyType = KeyType.Modal)]
        public string Remarks { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "Supplier_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "Supplier_OperatedDate", KeyType = KeyType.Modal)]

        public DateTime OperatedDate { get; set; }
    }
    //用于发货或退货的地址
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "UserAddressID")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "名称格式例如:UA00000000001,UA为前缀,4-20位字符")]
        public string UserAddressID { get; set; }

        [Required]
        [Display(Name = "UserId")]
        [StringLength(128, ErrorMessage = "必需填入UserId")]
        public string UserId { get; set; }

        [LocalizedDisplayName("所在国家", KeyName = "UserAddress_Country", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "所在国家")]
        public string Country { get; set; }

        [LocalizedDisplayName("所在州省", KeyName = "UserAddress_Country", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "所在州省")]
        public string State { get; set; }

        [LocalizedDisplayName("所在县区", KeyName = "UserAddress_Country", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "所在县区")]
        public string District { get; set; }

        [LocalizedDisplayName("详细地址", KeyName = "UserAddress_Address", KeyType = KeyType.Modal)]
        [StringLength(200, ErrorMessage = "详细地址")]
        public string Address { get; set; }

        [LocalizedDisplayName("邮政编号", KeyName = "UserAddress_PostCode", KeyType = KeyType.Modal)]
        [StringLength(20, ErrorMessage = "邮政编号")]
        public string PostCode { get; set; }

        [LocalizedDisplayName("手机号码", KeyName = "UserAddress_PhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "手机号码")]
        public string PhoneNumber { get; set; }

        [LocalizedDisplayName("电话号码", KeyName = "UserAddress_TelePhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "电话号码")]
        public string TelePhoneNumber { get; set; }

        [LocalizedDisplayName("ShopID", KeyName = "UserAddress_ShopID", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string ShopID { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "UserAddress_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "UserAddress_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }
    }
    //发货單
    public class DispatchNote
    {
        [Key]
        [Display(Name = "Dispatch No")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "发货单格式例如:DP00000000001,DP为前缀,4-20位字符")]
        public string DispatchNoteId { get; set; }
         
        [Display(Name = "OrderID")]
        [StringLength(128, ErrorMessage = "必需填入OrderID")]
        public string OrderID { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "需要填入货号")]
        [Display(Name = "货号")]
        [LocalizedDisplayName("货号", KeyName = "DispatchNote_StyleNo", KeyType = KeyType.Modal)]
        public string StyleNo { get; set; }
         
        [LocalizedDisplayName("货号", KeyName = "DispatchNote_payment_no", KeyType = KeyType.Modal)]
        [StringLength(128, ErrorMessage = "GateWay payment_no")]
        public string PaymentNo { get; set; }
          
        [LocalizedDisplayName("数量", KeyName = "DispatchNote_Quantity", KeyType = KeyType.Modal)]
        [DefaultValue(1)]
        public int Quantity { get; set; }
          
        [LocalizedDisplayName("RecommUserId", KeyName = "DispatchNote_RecommUserId", KeyType = KeyType.Modal)]
        [StringLength(128, ErrorMessage = "必需填入推广者的UserId")]
        public string RecommUserId { get; set; }
         
        [LocalizedDisplayName("收件人", KeyName = "DispatchNote_Recipient", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "收件人")]
        public string Recipient { get; set; }
         
        [LocalizedDisplayName("所在国家", KeyName = "DispatchNote_Country", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "所在国家")]
        [DefaultValue("CHINA SAR")]
        public string Country { get; set; }
         
        [LocalizedDisplayName("所在州省", KeyName = "DispatchNote_State", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "所在州省")]
        public string State { get; set; }
         
        [LocalizedDisplayName("所在县区", KeyName = "DispatchNote_District", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "所在县区")]
        public string District { get; set; }
         
        [LocalizedDisplayName("详细地址", KeyName = "DispatchNote_Address", KeyType = KeyType.Modal)]
        [StringLength(200, ErrorMessage = "详细地址")]
        public string Address { get; set; }
         
        [LocalizedDisplayName("邮政编号", KeyName = "DispatchNote_PostCode", KeyType = KeyType.Modal)]
        [StringLength(20, ErrorMessage = "邮政编号")]
        public string PostCode { get; set; }
         
        [LocalizedDisplayName("手机号码", KeyName = "DispatchNote_PhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "手机号码")]
        public string PhoneNumber { get; set; }
         
        [LocalizedDisplayName("电话号码", KeyName = "DispatchNote_TelePhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(50, ErrorMessage = "电话号码")]
        public string TelePhoneNumber { get; set; }
         
        [LocalizedDisplayName("创建日期", KeyName = "DispatchNote_CreatedDate", KeyType = KeyType.Modal)]
        public DateTime CreatedDate { get; set; }
         
        [LocalizedDisplayName("备 注", KeyName = "DispatchNote_Remarks", KeyType = KeyType.Modal)]
        [StringLength(1000, ErrorMessage = "备注字数太多哦，来个简短的吧！")]
        public string Remarks { get; set; }
          
        
        [StringLength(20, MinimumLength = 6, ErrorMessage = "店铺ID")] 
        public string ShopID { get; set; }
         
        [LocalizedDisplayName("发货状态", KeyName = "DispatchNote_ShopID", KeyType = KeyType.Modal)]
        [DefaultValue(DispatchNoteStatus.Unpaid)]
        public DispatchNoteStatus DispatchNoteStatus { get; set; }
         
        [LocalizedDisplayName("状态", KeyName = "DispatchNote_StatusName", KeyType = KeyType.Modal)]
        [DefaultValue("OK")]
        public string StatusName { get; set; }
    }
 
    public class ProductSku
    {
        [Key]
        [LocalizedDisplayName("ProductSkuId", KeyName = "ProductSku_ProductSkuId", KeyType = KeyType.Modal)]
        [StringLength(20)]
        public string ProductSkuId { get; set; }

        [LocalizedDisplayName("属性值集合", KeyName = "ProductSku_PropValueIDs", KeyType = KeyType.Modal)]
        [DefaultValue("0")]
        public string PropValueIDs { get; set; }
         
        [Required]
        [StringLength(20)]
        [DisplayName("ProductID")]
        [Column("ProductID")]
        public string ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [LocalizedDisplayName("货号", KeyName = "ProductSku_StyleNo", KeyType = KeyType.Modal)] 
        [Column("StyleNo")] 
        public string StyleNo { get; set; }

        [LocalizedDisplayName("产品名称", KeyName = "ProductSku_ProductName", KeyType = KeyType.Modal)]
        public string ProductName { get; set; }

        [LocalizedDisplayName("SKU图", KeyName = "ProductSku_SkuImage", KeyType = KeyType.Modal)]
        public string SkuImage { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "0")]
        [DefaultValue(0)]
        [LocalizedDisplayName("成交价", KeyName = "ProductSku_TradePrice", KeyType = KeyType.Modal)] 
        public decimal TradePrice { get; set; } 

        [LocalizedDisplayName("库存数量", KeyName = "ProductSku_Quantity", KeyType = KeyType.Modal)]
        public int Quantity { get; set; }

        [LocalizedDisplayName("属性描述", KeyName = "ProductSku_PropertyDesc", KeyType = KeyType.Modal)]
        [StringLength(300)]
        public string PropertyDesc { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "ProductSku_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "ProductSku_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "ProductSku_CreatedDate", KeyType = KeyType.Modal)]
        public DateTime CreatedDate { get; set; }
    }

    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] 
        public int Id { get; set; }

        [Display(Name = "CartId")] [LocalizedDisplayName("操作用户", KeyName = "ProductSku_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(200)]
        public string CartId { get; set; }

        [Required]
        [Display(Name = "ProductSkuId")] 
        public string ProductSkuId { get; set; }
         
        [LocalizedDisplayName("Sku规格图", KeyName = "Cart_SkuImageUrl", KeyType = KeyType.Modal)]
        public string SkuImageUrl { get; set; }
         
        [LocalizedDisplayName("产品名称", KeyName = "Cart_ProductName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        public string ProductName { get; set; }
          
        [LocalizedDisplayName("属性描述", KeyName = "Cart_PropertyDesc", KeyType = KeyType.Modal)]
        [StringLength(300)]
        public string PropertyDesc { get; set; }

        [DefaultValue(0)]
        [DisplayFormat(DataFormatString = "{0:c0}")]
        [LocalizedDisplayName("成交价", KeyName = "Cart_TradePrice", KeyType = KeyType.Modal)]
        public decimal TradePrice { get; set; }
  
        [DefaultValue(0)]
        [LocalizedDisplayName("零售价", KeyName = "Cart_RetailPrice", KeyType = KeyType.Modal)]
        public decimal RetailPrice { get; set; }

        [DefaultValue(0)]
        [LocalizedDisplayName("数量", KeyName = "Cart_Quantity", KeyType = KeyType.Modal)]
        public int Quantity { get; set; }
          
        [LocalizedDisplayName("更新日期", KeyName = "Cart_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }
         
        [LocalizedDisplayName("创建日期", KeyName = "Cart_CreatedDate", KeyType = KeyType.Modal)]
        public DateTime CreatedDate { get; set; }
    } 

    /// <summary>
    /// 订单头  OrderHeader 
    /// </summary>
    public class Order
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [DisplayName("Order Id")]
        public int OrderId { get; set; }

        [DisplayName("User Id")]
        [StringLength(128)] 
        public string UserId { get; set; }

        [LocalizedDisplayName("用户名", KeyName = "Order_UserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string UserName { get; set; }

        [LocalizedDisplayName("调整金额", KeyName = "Order_AdjustFee", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public decimal AdjustFee { get; set; }
         
        [LocalizedDisplayName("优惠金额", KeyName = "Order_DiscountFee", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public decimal DiscountFee { get; set; }
         
        [LocalizedDisplayName("付款金额", KeyName = "Order_Payment", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public decimal Payment { get; set; }  //ItemAmount =TradePrice X Quantity - FaceValue

        
        [LocalizedDisplayName("价格合计", KeyName = "Order_TotalRetailPrice", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public decimal TotalRetailPrice { get; set; }
         
        [LocalizedDisplayName("活动ID", KeyName = "Order_CampaignID", KeyType = KeyType.Modal)]  //如有
        [StringLength(20)]
        public string CampaignID { get; set; }
         
        [LocalizedDisplayName("活动名称", KeyName = "Order_CampaignName", KeyType = KeyType.Modal)]  //如有
        [StringLength(30)]
        public string CampaignName { get; set; }
         
        [LocalizedDisplayName("优惠劵ID", KeyName = "Order_CouponID", KeyType = KeyType.Modal)]  //如有
        [StringLength(20)]
        public string CouponID { get; set; }
         
        [LocalizedDisplayName("优惠劵面值", KeyName = "Order_FaceValue", KeyType = KeyType.Modal)]  //如有
        [DefaultValue(0)]
        public decimal FaceValue { get; set; }
         
        [LocalizedDisplayName("支付流水号", KeyName = "Order_PaymentNo", KeyType = KeyType.Modal)]  //如有  
        [DefaultValue("0")]
        public string PaymentNo { get; set; }
         
        [LocalizedDisplayName("支付网关", KeyName = "Order_PayGateName", KeyType = KeyType.Modal)]  //如有  
        [DefaultValue("0")]
        [StringLength(50)]
        public string PayGateName { get; set; }

        [LocalizedDisplayName("推薦者", KeyName = "Order_RecommUserId", KeyType = KeyType.Modal)]
        [StringLength(128)]
        public string RecommUserId { get; set; }

        [DefaultValue(0)]
        [LocalizedDisplayName("订单佣金", KeyName = "Order_TotalCommision", KeyType = KeyType.Modal)]
        public decimal TotalCommision { get; set; }

        //订单明细项   
        public virtual ICollection<OrderItem> OrderItems { get; set; }
          
        [LocalizedDisplayName("订单日期", KeyName = "Order_CreatedDate", KeyType = KeyType.Modal)]
        public DateTime CreatedDate { get; set; }
         
        [LocalizedDisplayName("店铺ID", KeyName = "Order_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("订单状态", KeyName = "Order_StatusId", KeyType = KeyType.Modal)]
        [StringLength(50)]
        [DefaultValue("UnPaid")]
        public string StatusId { get; set; }
        
    }

    /// <summary>
    /// 订单明细项  OrderItem 
    /// </summary>
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [DisplayName("OrderItemId")]  //格式 OrderId + 序号
        public string OrderItemId { get; set; }
         
        [Required]
        [DisplayName("OrderId")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "CartId")]
        [StringLength(200)]
        public string CartId { get; set; }

        [Required]
        [Display(Name = "ProductSkuId")]
        public string ProductSkuId { get; set; }
         
        [LocalizedDisplayName("Sku规格图", KeyName = "OrderItem_SkuImageUrl", KeyType = KeyType.Modal)]
        public string SkuImageUrl { get; set; }
         
        [LocalizedDisplayName("产品名称", KeyName = "OrderItem_ProductName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        public string ProductName { get; set; }

        [LocalizedDisplayName("属性描述", KeyName = "OrderItem_PropertyDesc", KeyType = KeyType.Modal)]
        [StringLength(300)]
        public string PropertyDesc { get; set; }
         
        [DefaultValue(0)]
        [DisplayFormat(DataFormatString = "{0:c0}")] 
        [LocalizedDisplayName("成交价", KeyName = "OrderItem_TradePrice", KeyType = KeyType.Modal)]
        public decimal TradePrice { get; set; }
         
        [DefaultValue(0)] 
        [LocalizedDisplayName("数量", KeyName = "OrderItem_Quantity", KeyType = KeyType.Modal)]
        public int Quantity { get; set; }

        [DefaultValue(0)] 
        [LocalizedDisplayName("零售价", KeyName = "OrderItem_RetailPrice", KeyType = KeyType.Modal)]
        public decimal RetailPrice { get; set; }

        [DefaultValue(0)] 
        [LocalizedDisplayName("金额", KeyName = "OrderItem_ItemAmount", KeyType = KeyType.Modal)]
        public decimal ItemAmount { get; set; } //ItemAmount =TradePrice X Quantity 

        [DefaultValue(0)]
        [LocalizedDisplayName("佣金率", KeyName = "OrderItem_CommisionRate", KeyType = KeyType.Modal)]
        public decimal CommisionRate { get; set; }

        [DefaultValue(0)]
        [LocalizedDisplayName("佣金", KeyName = "OrderItem_Commision", KeyType = KeyType.Modal)]
        public decimal Commision { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "OrderItem_CreatedDate", KeyType = KeyType.Modal)]
        public DateTime CreatedDate { get; set; } 
    }
 }

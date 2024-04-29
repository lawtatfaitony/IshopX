using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ishop.Models.CampaignMgr
{
    public class Campaign
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "必需输入最少长度为10位ID,例如：Camp001")]
        [Display(Name = "活动ID")]
        public string CampaignID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "商品名称最少2字，最大30字")]
        [Display(Name = "活动名称")]
        [DisplayFormat(NullDisplayText = "-")] //空活动名称显示为：-
        public string CampaignName { get; set; }

        [StringLength(6, ErrorMessage = "促销标签，最大6字,默认显示：优惠价")]
        [Display(Name = "促销标签")]
        [DisplayFormat(NullDisplayText = "优惠价")] //空促销标签显示为：-
        public string CampaignLabel { get; set; }

        [Required]
        [Display(Name = "店铺ID")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "名称格式例如:Shop001,Shop为前缀")]
        public string ShopID { get; set; }

        [Display(Name = "开始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", NullDisplayText = "2000-01-01")]
        public DateTime StartDate { get; set; }

        [Display(Name = "结束日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", NullDisplayText = "2000-01-01")]
        public DateTime EndDate { get; set; }

        [Display(Name = "活动描述")]
        [DisplayFormat(NullDisplayText = "-")] //空活动内容显示为：- 数据类型:ntext
        public string CampaignDesc { get; set; }

        [StringLength(256)]
        [Display(Name = "操作用户")]
        public string OperatedUserName { get; set; }

        [Display(Name = "操作日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }
    public class CampaignProduct
    { 
        [StringLength(20, MinimumLength = 6, ErrorMessage = "必需输入最少长度为10位ID,例如：Camp001")]
        [Display(Name = "活动ID")]
        public string CampaignID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "商品ID")]
        public string ProductID { get; set; }

        [Required]
        [Display(Name = "折扣")]
        [Range(1, 10)]  //1-9.9折
        public int Discount { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "0.0")]
        [Display(Name = "成交价格")]
        [DefaultValue(999999)]
        public decimal TradePrice { get; set; }

        [Required]
        [Display(Name = "起卖数量")]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [StringLength(256)]
        [Display(Name = "操作用户")]
        public string OperatedUserName { get; set; }

        [Display(Name = "操作日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]

        public DateTime OperatedDate { get; set; }

        public IList<string> FaceValues = new List<string>() { "1", "2", "3", "4" };
    }

    //优惠劵模式
    public enum IssueMode { SellerSend, BuyerGet }

    //店铺优惠劵 /Coupon
    public class Coupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "必需输入最少长度为6位ID")]
        [Display(Name = "优惠劵ID")]
        public string CouponID { get; set; }

        [Required(ErrorMessage = "缺少店铺ShopID")]
        [Display(Name = "店铺ID")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "名称格式例如:Shop001,Shp为前缀")]
        public string ShopID { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "必需输入最少长度为4位的优惠劵名称")]
        [Display(Name = "优惠劵名称")]
        public string CouponName { get; set; }

        [Required(ErrorMessage = "输入0：无条件使用。")]
        [Display(Name = "使用条件")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "0.0")]
        public decimal Conditions { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "输入优惠劵面值。")]
        [Display(Name = "优惠劵面值")]
        public decimal FaceValue { get; set; }

        [Display(Name = "开始日期")] 
        public DateTime StartDate { get; set; }

        [Display(Name = "结束日期")] 
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "输入发行优惠劵数量。")]
        [Display(Name = "发行数量")]
        [Range(1, 99999)]
        public int IssueQuantity { get; set; }

        [Required(ErrorMessage = "优惠劵模式,SellerSend=卖家派发,BuyerGet=买家获取。")]
        [Display(Name = "优惠劵模式")]
        public IssueMode Mode { get; set; }

        [StringLength(256)]
        [Display(Name = "操作用户")]
        public string OperatedUserName { get; set; }

        [Display(Name = "操作日期")] 
        public DateTime OperatedDate { get; set; }
    }
    public class UserCoupon 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [Display(Name = "UserCouponID")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "UserCouponID Is Pkey")]
        public string UserCouponID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "必需输入优惠券ID")]
        [Display(Name = "优惠劵ID")]
        public string CouponID { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "必需必需输入用户登陆名称(UserName)")]
        [Display(Name = "优惠劵ID")]
        public string UserName { get; set; }

        [Display(Name = "操作日期")] 
        public DateTime OperatedDate { get; set; }
    }
}
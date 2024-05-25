using Ishop.Utilities;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq; 
using System.Web;
using System.Collections;
using Ishop.Models.ProductMgr;
using Ishop.Models.CampaignMgr;
using Ishop.Models;

namespace Ishop.ViewModes.Order
{ 
    /// <summary>
    /// 订单头 以及 发货 明細
    /// </summary>
    public class OrderDetailView
    {
        [Required]
        [DisplayName("OrderId")]
        public int OrderId { get; set; }
         
        [LocalizedDisplayName("优惠劵ID", KeyName = "OrderDetailView_CouponID", KeyType = KeyType.ModalView)]
        [StringLength(20)]
        public string CouponID { get; set; }

        [Required]
        [LocalizedDisplayName("支付金额", KeyName = "OrderDetailView_Payment", KeyType = KeyType.ModalView)]
        [DefaultValue(0)]
        public decimal Payment { get; set; }

        public virtual ICollection Coupons { get; set; }
        public virtual ICollection OrderItems { get; set; }

        [Required]
        [LocalizedDisplayName("收件人", KeyName = "OrderDetailView_Recipient", KeyType = KeyType.ModalView)]
        [StringLength(50, ErrorMessage = "收件人")]
        public string Recipient { get; set; }
         
        [LocalizedDisplayName("所在国家", KeyName = "OrderDetailView_Recipient", KeyType = KeyType.ModalView)]
        [StringLength(50, ErrorMessage = "所在国家")]
        public string Country { get; set; }

        [Required]
        [LocalizedDisplayName("所在国家", KeyName = "OrderDetailView_State", KeyType = KeyType.ModalView)]
        [StringLength(50, ErrorMessage = "所在州省")]
        public string State { get; set; }

        [Required]
        [LocalizedDisplayName("所在县区", KeyName = "OrderDetailView_District", KeyType = KeyType.ModalView)]
        [StringLength(50, ErrorMessage = "所在县区")]
        public string District { get; set; }

        [Required]
        [LocalizedDisplayName("详细地址", KeyName = "OrderDetailView_Address", KeyType = KeyType.ModalView)]
        [StringLength(200)]
        public string Address { get; set; }
         
        [LocalizedDisplayName("邮政编号", KeyName = "OrderDetailView_PostCode", KeyType = KeyType.ModalView)]
        [StringLength(8)]
        public string PostCode { get; set; }

        [Required]
        [LocalizedDisplayName("手机号码", KeyName = "OrderDetailView_PhoneNumber", KeyType = KeyType.ModalView)]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "电话号码")]
        [StringLength(50, ErrorMessage = "电话号码")]
        public string TelePhoneNumber { get; set; }

        [Display(Name = "支付狀態")] 
        public string StatusId { get; set; }

        [Display(Name = "訂單創建日期")]
        public DateTime CreatedDate { get; set; }
    }

    /// <summary>
    /// For OrderMgtController.OrderDetails
    /// </summary>
    public class OrderDetails
    {
        public Shop Shop { get; set; }
        public Models.ProductMgr.Order OrderHeader { get; set; }
        public int Quantity { get; set; } 
        public DispatchNote DispatchNote { get; set; } 
        public Coupon Coupon { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
    public class ProductSkuPropName1
    {
        public string ProductID;
        public string SkuImage;
        public string PropName1;
        public string PropValue1;
    }
    public class ReturnToListDataProp1
    {
        public string PropName1;
        public List<ProductSkuPropName1> listdata;
    }
    public class ProductSkuPropName2
    {
        public string ProductID;
        public string SkuImage;
        public string PropName2;
        public string PropValue2;
    }
    public class ReturnToListDataProp2
    {
        public string PropName2;
        public List<ProductSkuPropName2> listdata; 
    }
    public class GetProductAllInfo
    {
        public Product product;
        public List<ProductSku> productSkulist;
    }
}

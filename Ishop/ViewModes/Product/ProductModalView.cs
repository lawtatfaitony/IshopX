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
    public enum DispatchNoteStatus
    {
        Unpaid= 0, Receipted = 1, OutOfStock = 2, PickingUp = 3, HasSent = 4
    } 
    public class DispatchNoteModalView
    { 
        public string DispatchNoteId { get; set; }
        [DefaultValue(DispatchNoteStatus.Unpaid)]
        public DispatchNoteStatus DispatchNoteStatus { get; set; }  
    }
    //加入购物车时的颜色尺寸值，用于查询SKU  for  AddToShoppingCart
    public class ProductSkuQry
    {
        public string txtQuantity { get; set; }
        public string txtProdPropertiesValue1 { get; set; }

        public string txtProdPropertiesValue2 { get; set; }
    }

    public class ProductSkuAdd
    {
        public string txtQuantity { get; set; }
        public string txtProductSkuTradePrice { get; set; } 
        public string txtProductSkuId { get; set; }
        public string txtSkuImage { get; set; }
        public string txtPropValueIDs { get; set; }
        
    }
    /// <summary>
    /// for AddToCart
    /// </summary>
    public class ProductSkuQuantity
    {
        public string txtQuantity { get; set; }
        public string txtProductSkuId { get; set; }
         
    }
    /// <summary>
    ///  product head Images  include Product.ProductImg
    /// </summary>
    public class ProductImageView
    {
        public string ProductID { get; set; }
        public string UploadItemId { get; set; }
        public string ProductImg { get; set; } 
        public string ProductUploadItemImg { get; set; } 
        public string s60X60 { get; set; }
        public string s100X100 { get; set; }
        public string s160X160 { get; set; }
        public string s250X250 { get; set; }
        public string s310X310 { get; set; }
        public string s350X350 { get; set; } 
        public string s600X600 { get; set; } 
    }
    public class ProductUnit
    { 
        public string ProductID { get; set; }
        public string ProdCateID { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string ProductImg { get; set; }
        public string StyleNo { get; set; }
        public string VideoUrl { get; set; }
        public string CategoryIDs { get; set; }
        public string ShopID { get; set; }
        public string SupplierID { get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public int CommisionRate { get; set; }
        public int ViewsIP { get; set; }
        public string StaffID { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string SaleStatusID { get; set; }
    }
}
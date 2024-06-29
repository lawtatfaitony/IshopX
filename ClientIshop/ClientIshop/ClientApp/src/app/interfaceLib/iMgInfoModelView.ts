

//interface iMgInfoModelView {

//  infodetail: iInfoDetail;

//  shopStaff: iShopStaff;

//  shop: iShop;

//  infoDetailRalateList: iInfoDetail[];
//}


export class InfoDetail {
  public UserTraceId: string;
  public InfoID: string;
  public InfoCateID: string;
  public Title: string
  public InfoItemTemplateIDs: string
  public TitleThumbNail: string;
  public ShowTitleThumbNail: boolean;
  public SubTitle: string;
  public SeoKeyword: string;
  public SeoDescription: string;
  public InfoDescription: string;
  public VideoUrl: string;
  public Author: string;
  public IsOriginal: boolean;
  public ShopStaffID: string;
  public Views: number;
  public ShopID: string;
  public OperatedUserName: string;
  public CreatedDate: Date;
  public OperatedDate: Date;
}


export class InfoPane {
  public UserTraceId: string;
  public InfoID: string; 
  public Title: string
  public InfoItemTemplateIDs: string
  public TitleThumbNail: string; 
  public SubTitle: string; 
  public ShopID: string;
   
}



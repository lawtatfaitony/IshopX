// /app/ts.interface.lib/iMgInfoModelView.ts
//<reference path="/app/ts.interface.lib/iMgInfoModelView.ts" />

import { InfoPane } from './../interfaceLib/iMgInfoModelView';
import { Injectable, Inject } from '@angular/core'; 
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { apiUrls,apiHostName } from '../shared/models/model.url'; 
import { Observable } from 'rxjs';
import { map,tap, catchError } from 'rxjs/operators'; 
import { error } from 'protractor';


export interface iInfoIDs {
  UserTraceId: string;
  UserId: string;
  InfoId: string;
  InfoCateId: string;
  ShopStaffId: string;
  ShopId: string;
   
  Title: string
  InfoItemTemplateIDs: string
  TitleThumbNail: string;
  ShowTitleThumbNail: boolean;
  SubTitle: string;
  SeoKeyword: string;
  SeoDescription: string;
  InfoDescription: string;
  VideoUrl: string;
  Author: string;
  IsOriginal: boolean; 
  Views: number; 
  OperatedUserName: string;
  CreatedDate: Date;
  OperatedDate: Date;
}
 
export interface iInfoDetail {
  UserTraceId: string;
  InfoID: string;
  InfoCateID: string;
  Title: string
  InfoItemTemplateIDs: string
  TitleThumbNail: string;
  ShowTitleThumbNail: boolean;
  SubTitle: string;
  SeoKeyword: string;
  SeoDescription: string;
  InfoDescription: string;
  VideoUrl: string;
  Author: string;
  IsOriginal: boolean;
  ShopStaffID: string;
  Views: number;
  ShopID: string;
  OperatedUserName: string;
  CreatedDate: Date;
  OperatedDate: Date;
}

export interface iShop {

  ShopID: string;
  ShopName: string;
  ShopLogo: string;
  WeixinQRcode: string;
  WeiboQRcode: string;
  ToutiaoQRcode: string;
  fbQRcode: string;
  FooterTemplate: string;
  cerPath: string;
  UserId: string;
  UserName: string;
  ShopCurrency: string;
  PhoneNumber: string;
  OperatedUserName: string;
  OperatedDate: Date;
}

export interface iShopStaff {
  ShopStaffID: string;
  ShopID: string;
  UserId: string;
  UserName: string;
  IconPortrait: string;
  StaffName: string;
  IsConfirmed: string;
  PublicNo: string;
  ContactTitle: string;
  Introduction: string;
  ChannelID: string;
  Qrcode: string;
  OtherChannelName: string;
  OtherQrcode: string;
  OperatedUserName: string;
  OperatedDate: Date;
}

@Injectable()

export class InfoService{

  public readonly s60x60: string = "s60x60";
  public readonly s100X100: string = "s100X100";
  public readonly s160X160: string = "s160X160";
  public readonly s250X250: string = "s250X250";
  public readonly s310X310: string = "s310X310";
  public readonly s350X350: string = "s350X350";
  public readonly s600X600: string = "s600X600";

  public BaseUrl: string;  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.BaseUrl = baseUrl; 
    console.log("this.BaseUrl  :" + this.BaseUrl ); 
  }

  getObjectValue(Object: any, PropertyValue: string) {
    if (Reflect.has(Object, PropertyValue)) {
      //console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
      return Reflect.get(Object, PropertyValue);
    }
    else {
      console.log("getObjectValue : no no no {0}:::::", PropertyValue);
      return null;
    }
  }

  //把本地圖片格式轉換為cloud對應格式
  getImgOnlineApiUrl(Object: any, PropertyValue: string) {
    if (Reflect.has(Object, PropertyValue)) {
      debugger; 
      
      let imgOnlineApiUrl  = apiHostName.onlineImgHost + Reflect.get(Object, PropertyValue);
      alert(imgOnlineApiUrl);
      console.log("getObjeimgOnlineApiUrl  :" + imgOnlineApiUrl );

       return imgOnlineApiUrl;
    }
    else {
      console.log("getObjectValue : no no no {0}:::::", PropertyValue);
      return null;
    }
  }

  getiInfoIDsExtend(id: string): Observable<iInfoIDs> {

    const uri_getinfoids = apiUrls.getinfoids + id;

    return this.http.get<iInfoIDs>(uri_getinfoids)
      .pipe(
      tap(_ => console.log('fetched iInfoIDs'))
    ); 
  }

  getShopStaffDetails(ShopStaffId: string): Observable<iShopStaff[]>{

    const StaffDetails_uri = apiUrls.shopstaffdetails + ShopStaffId;
    
    return this.http.get<iShopStaff[]>(StaffDetails_uri)
      .pipe(
      tap(_ => console.log('fetched StaffDetails'))
      );
  }

  getShopDetails(ShopId: string): Observable<iShop[]> {

    const ShopDetails_uri = apiUrls.shopdetails + ShopId; 
    //return this.http.get<iShop[]>(ShopDetails_uri);
    return this.http.get<iShop[]>(ShopDetails_uri)
      .pipe(
      tap(_ => console.log('fetched ShopDetails_uri'))
      );
  }
  
  infoDetailRalateList(id: string): Observable<iInfoDetail[]> {
    const InfoDetailRalateList_uri = apiUrls.InfoDetailRalateList + id;
    return this.http.get<iInfoDetail[]>(InfoDetailRalateList_uri)
      .pipe(
      tap(_ => console.log('fetched infoDetailRalateList'))
      );
  }
 
  //home page list
  GetInfolist(ShpId: string, RecommUserId: string, pageindex: string, pagesize: string): Observable<iInfoDetail[]> {
    
    const uri_getinfolist = apiUrls.getInfolist + ShpId + "/" + RecommUserId + "/" + pageindex + "/" + pagesize;   
    console.log({"uri_getinfolist":uri_getinfolist});
    return this.http.get<iInfoDetail[]>(uri_getinfolist)
      .pipe(
        tap(_ => {
        console.log("GetInfolist::" + Date());
      }),
      //catchError(this.handleError)
      );
  }
  //for test
  GetInfolist2(ShpId: string, RecommUserId: string, pageindex: string, pagesize: string): Observable<iInfoDetail[]> {
     
    const uri_getinfolist = apiUrls.getInfolist + ShpId + "/" + RecommUserId + "/" + pageindex + "/" + pagesize;    
    return this.http.get<iInfoDetail[]>(uri_getinfolist);
  }
  //remain to use
   //getInfoIDs(id: string) {

  //  const a = this.BaseUrl + apiUrls.getinfoids + id ;
  //  return this.http.get(a);
  //}

  getInfoIDsResponse(id: string): Observable<HttpResponse<iInfoIDs>> {
    var b = apiUrls.getinfoids + id;
    return this.http.get<iInfoIDs>(
      b, { observe: 'response' });
  }
  getInfoPaneAdSetX(InfoPaneUrl: string): Observable<InfoPane> {
    return this.http.get<InfoPane>(InfoPaneUrl)
      .pipe(
        tap(_ => console.log('fetched getInfoPaneAdSet'))
      );
  }

  ReturnSizePicUrl(PicUrl: string, PictureSize: string) {
    if (PicUrl.toLowerCase().indexOf("gif") != -1) {
      return PicUrl + PictureSize + ".gif";
    }
    if (PicUrl.toLowerCase().indexOf("png") != -1) {
      return PicUrl + PictureSize + ".png";
    }
    if (PicUrl.toLowerCase().indexOf("jpeg") != -1) {
      return PicUrl + PictureSize + ".jpeg";
    }
    return PicUrl + PictureSize + ".jpg"; 
  }
  
  
  //// sample method from angular doc
  //private handleError(error: HttpErrorResponse) {
  //  // TODO: seems we cannot use messageService from here...
  //  let errMsg = (error.message) ? error.message : 'Server error';
  //  console.error(errMsg);
  //  if (error.status === 401) {
  //    window.location.href = '/';
  //  }
  //  return Observable.throw(errMsg);
  //}
  
}

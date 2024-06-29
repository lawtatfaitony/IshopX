 
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map,tap,catchError } from 'rxjs/operators';

import { PublicService } from '../public.service';
import { InfovideopaneComponent } from '../infovideopane/infovideopane.component';
import { InfopaneComponent } from '../infopane/infopane.component';
import { AdItem } from './ad-item';
import { iInfoIDs, iInfoDetail, InfoService } from '../info/info.service';
import { apiUrls } from '../shared/models/model.url';
import { InfoPane, InfoDetail} from './../interfaceLib/iMgInfoModelView';
import { filter } from 'rxjs/operators';
@Injectable()
export class AdService {  
  RecommUserId: string;
  take: number = 3;
  ShpId: string;
  public InfoItemTemplateIds_InfoPane: string = "InfoTemp00001";
  public infoPane: InfoPane;
  public infodetail: iInfoDetail;
  public InfoPaneAdSetData: iInfoDetail[];
  public InfoPaneAdSetData1: iInfoDetail;
  public InfoIdAdSetData2: iInfoDetail;
  public InfoIdAdSetData3: iInfoDetail;

  public InfoPane_userTraceId:string;
  public InfoPane_title: string;
  public InfoPane_subTitle: string;
  public InfoPane_titleThumbNail: string;

  arrDataInfo: Array<any>;
  arrAdItem: Array<AdItem>;
  getAds() {
     
    const InfoPaneUrl:string = `${apiUrls.getInfoPaneAdSet}${this.ShpId}/${this.RecommUserId}/${this.InfoItemTemplateIds_InfoPane}`;

    //this.getInfoPaneAd(InfoPaneUrl).subscribe(data => {
    //  this.InfoPaneAdSetData1 = data;
    //  console.log("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
    //  console.log(data);
    //});
    this.getInfoPaneAdSetX(InfoPaneUrl).subscribe(data => {

      console.log("InfoPaneUrl =" + InfoPaneUrl);
      console.log(data);
 
      // debugger;
      // this.infoPane.UserTraceId = this.infoService.getObjectValue(data, "userTraceId"); 
      // this.infoPane.InfoID = this.infoService.getObjectValue(data, "infoId");
      // this.infoPane.Title = this.infoService.getObjectValue(data, "title");
      // this.infoPane.SubTitle = this.infoService.getObjectValue(data, "subTitle");
      // this.infoPane.TitleThumbNail = this.infoService.getObjectValue(data, "titleThumbNail");

    }); 
  
    return [
      new AdItem(InfopaneComponent, {  userTraceId: "sh0006620002Inf000000081", title: "Ha.Ha!!! this.infoPane.Title", subTitle: "this.infoPane.SubTitle", titleThumbNail: "http://81.71.74.135:8081/Upload/Info/Inf20180826131028997.jpg"  }),
      new AdItem(InfopaneComponent, {  userTraceId: "sh0006620002Inf000000081", title: "Ha.Ha!!! this.infoPane.Title", subTitle: "this.infoPane.SubTitle", titleThumbNail: "http://81.71.74.135:8081/Upload/Info/Infsh000620240523122531358.jpg"  }),
      new AdItem(InfovideopaneComponent, { headline: 'video Openings in all departments', body: 'Apply today' }),
    ];

    //return [
    //  new AdItem(InfopaneComponent, { userTraceId: this.infoPane.UserTraceId, title: this.infoPane.Title + "哈哈哈哈", subTitle: this.infoPane.SubTitle, titleThumbNail: this.infoPane.TitleThumbNail }),
    //  new AdItem(InfovideopaneComponent, { headline: 'video Openings in all departments', body: 'Apply today' }),
    //];

  } //getAds 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject('ShpId') shpId: string, private infoService: InfoService, private publicService: PublicService) {
     
    this.RecommUserId = this.publicService.getRecommUserId();
    this.ShpId = shpId;
    //this.getInfoIdAdSet(shpId, this.RecommUserId, "InfoTemp00001", 3); 

    ///InfoData/getInfoPaneAdSet/sh0006/620002/InfoTemp00001
    const InfoPaneUrl:string = `${apiUrls.getInfoPaneAdSet}${this.ShpId}/${this.RecommUserId}/${this.InfoItemTemplateIds_InfoPane}`;
      
    //這段有問題
    // let obj:object =  this.getInfoPaneAd(InfoPaneUrl);
    // console.log(obj);
    // debugger;
    // this.infoPane.InfoID = this.getObjectValue(obj, "infoId");
    // this.infoPane.UserTraceId = this.getObjectValue(obj, "userTraceId");
    // this.infoPane.Title = this.getObjectValue(obj, "title");  
    // this.infoPane.SubTitle = this.getObjectValue(obj, "subTitle");
    // this.infoPane.TitleThumbNail = this.getObjectValue(obj, "titleThumbNail");
  }
  getInfoPaneAdSetX(InfoPaneUrl: string): Observable<InfoPane> { 

    console.log("InfoPaneUrl = " +  InfoPaneUrl);

    return this.http.get<InfoPane>(InfoPaneUrl)
      .pipe(
      tap(_ => console.log('fetched getInfoPaneAdSet'))
      );
  }
  
  getInfoPaneAd(InfoPaneUrl: string): Observable<iInfoDetail> {
  
    return this.http.get<iInfoDetail>(InfoPaneUrl)
      .pipe(
        tap(_ => console.log('fetched getInfoPaneAdSet'))
      );
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
  
  // async getInfoIdAdSet(shpId: string, RecommUserId: string, InfoItemTemplateID:string, take: number) {
  //  const promise = new Promise((resolve, reject) => {
  //    this.infoService.getInfoIdAdSet(shpId, RecommUserId, InfoItemTemplateID, take)
  //      .toPromise()
  //      .then(
  //      data => { // Success
          
  //        this.InfoIdAdSetData = data;
  //        this.arrDataInfo = this.InfoIdAdSetData.map<iInfoDetail>(function (item, index, array) {
  //          console.log("map::" + index);
  //          console.log(item);
  //          //this.arrDataInfo[index] = item;
  //          return item;
  //        });
  //        console.log(this.arrDataInfo);
  //        this.InfoIdAdSetData = data;
  //          resolve(data);
  //        },
  //        err => {
  //          console.error(err);
  //          reject(err);
  //        }
  //      );
  //  });
  //  await promise;
  // }
}

 
import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, NavigationEnd, NavigationStart, Params } from "@angular/router";
import { iInfoIDs, iInfoDetail, iShop, iShopStaff, InfoService } from './info.service'; 
 

import { iResult,IpCounterService } from '../ipcounter.service';
import { apiHostName } from '../shared/models/model.url';
import { apiUrls } from '../shared/models/model.url';
import { window, filter, map } from 'rxjs/operators';


@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
}) 
export class InfoComponent implements OnInit{
   
  public iiInfoIDs: iInfoIDs;
  public id: string;
  public userId: string;
  public ShopId: string;
  public ShopStaffId: string;
  public SourceStatisticsId: string;
  public IpStatitics_StartDate_Token: string;
  public showTitleThumbNail: boolean;
  public title: string;
  public isOriginal: boolean ;
  public operatedDate: Date;
  public titleThumbNail: string;
  public author: string;
  public infoDescription: string;
  public infodetails: iInfoDetail[];
  //public shop: iShop[];
  public infoDetailRalateList: iInfoDetail[]; 
  public shopstaff: iShopStaff[]; 
 
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerInfo: ActivatedRoute, private router: Router,
    private infoService: InfoService, private ipCounterService: IpCounterService) {
    
    this.routerInfo.params.subscribe(data => {this.id = data.id;});

    this.getiInfoIDsExtend(this.id);
     
  };
  
  async getiInfoIDsExtend(Id: string) {
    const promise = new Promise((resolve, reject) => {
      this.infoService.getiInfoIDsExtend(Id)
        .toPromise()
        .then(
        dataiInfoIDs =>{ // Success 
          this.iiInfoIDs = dataiInfoIDs; 
          this.title = this.infoService.getObjectValue(dataiInfoIDs, "title");
          //document.title = this.title;
          this.ShopId = this.infoService.getObjectValue(dataiInfoIDs, "shopId");
          this.ShopStaffId = this.infoService.getObjectValue(dataiInfoIDs, "shopStaffId");
          this.userId = this.infoService.getObjectValue(dataiInfoIDs, "userId");
          this.SourceStatisticsId = this.infoService.getObjectValue(dataiInfoIDs, "sourceStatisticsId");
          this.IpStatitics_StartDate_Token = this.infoService.getObjectValue(dataiInfoIDs, "ipStatitics_StartDate_Token");
          this.showTitleThumbNail = this.infoService.getObjectValue(dataiInfoIDs, "showTitleThumbNail"); 
          this.isOriginal = this.infoService.getObjectValue(dataiInfoIDs, "isOriginal");
          this.operatedDate = this.infoService.getObjectValue(dataiInfoIDs, "operatedDate");
          this.titleThumbNail =apiHostName.onlineImgHost +  this.infoService.getObjectValue(dataiInfoIDs, "titleThumbNail");
          this.author = this.infoService.getObjectValue(dataiInfoIDs, "author");
          this.infoDescription = this.infoService.getObjectValue(dataiInfoIDs, "infoDescription");
          
          console.log("getStaffDetails");
          this.getStaffDetails(this.ShopStaffId);

          console.log("infodetaildalatedist");
          this.getInfodetaildalatedist(this.id);

          //console.log("getShopDetails");
          //this.getShopDetails(this.ShopId);

          //dataiInfoIDs
          console.log("dataiInfoIDs");
          console.log({"dataiInfoIDs":dataiInfoIDs});
          console.log({"dataiInfoIDs":dataiInfoIDs});

          //ip counter
          this.ipCounterService.IPstatitics(this.SourceStatisticsId, this.IpStatitics_StartDate_Token);
          console.log("IPstatitics:::" + this.SourceStatisticsId);
          this.ipCounterService.PageLoadingTimesCounter(this.SourceStatisticsId, this.IpStatitics_StartDate_Token);
          console.log("PageLoadingTimesCounter:::" + this.SourceStatisticsId); 
          resolve(dataiInfoIDs);

         

        }, 
        err => {
          console.error(err);
          reject(err);
        }
        );
    });
    await promise;
  }
  async getStaffDetails(ShopStaffId:string) { 
    const promise = new Promise((resolve, reject) => {
      this.infoService.getShopStaffDetails(ShopStaffId) 
        .toPromise() 
        .then(
          res => { // Success 
            this.shopstaff = res;
            resolve(res);  //加入參數才能用這個 日期  
          }, 
          err => { 
            console.error("getStaffDetails>error:::\n\r" + err);  
            reject(err); 
          } 
        ); 
    }); 
    await promise; 
  }
   
  async getInfodetaildalatedist(Id: string) {
    const promise = new Promise((resolve, reject) => {
      this.infoService.infoDetailRalateList(Id)
        .toPromise()
        .then(
          res => { // Success 
            this.infoDetailRalateList = res;
            resolve(res);  //需要傳入data 
          },
          err => {
            console.error("error:::\n\r" + err);
            reject(err);
          }
        );
    });
    await promise;
  }
  //圖片loading
  loadImageAsync(url)
  {
    return new Promise(function (resolve, reject) {
      const image = new Image();

        image.onload = function () {
          resolve(image);
        };

        image.onerror = function () {
          reject(new Error('Could not load image at ' + url));
        };

        image.src = url;
      });
  };

  gotoTop() {
    document.querySelector("body").scrollTop = 0;
  }
  ngOnInit() { 
    this.routerInfo.params.subscribe(data => {
      this.id = data.id;
      this.getiInfoIDsExtend(this.id);
      console.log(data); 
    });  
  }; 
}


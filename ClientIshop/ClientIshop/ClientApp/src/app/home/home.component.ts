import { Component, Inject, OnInit } from '@angular/core';

import { Location} from '@angular/common'; 
import { HttpClient } from '@angular/common/http'; 
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { LazyLoadImageModule, intersectionObserverPreset } from 'ng-lazyload-image';
import { CookieService } from 'ngx-cookie-service';
import { PublicService } from '../public.service';

import { iInfoDetail, InfoService } from '../info/info.service';
import { iResult, IpCounterService } from '../ipcounter.service';
import { apiUrls,apiHostName } from '../shared/models/model.url';

import { AdService } from '../ad/ad.service';
import { AdItem } from '../ad/ad-item'; 

import { Observable, BehaviorSubject, fromEvent, merge } from 'rxjs';
  
import { distinct, filter, map, debounceTime, tap, flatMap, window } from 'rxjs/operators'; 
import * as _ from 'lodash';
import { forEach } from '@angular/router/src/utils/collection';
  

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent {

  ApiHostName : object;
  catche: iInfoDetail[];
  http: HttpClient;
  ShpId: string;  
  infolists: iInfoDetail[];
  BaseUrl: string;
  HostUrl: string;
  offset: number = 100;
  defaultImage: string = "/assets/Rolling1s60pxblueblack.gif";
  RecommUserId: string;
    
  private pagesize: number = 150;
  private uri_getinfolist: string;
  private loading: boolean = false; 
  location: Location;
  public ads: AdItem[];

  constructor(http: HttpClient, @Inject('ShpId') shpId: string, @Inject('BASE_URL') baseUrl: string, private infoService: InfoService,
    private cookieService: CookieService, xlocation: Location, private publicService: PublicService, private adService: AdService) {
   
    this.ApiHostName = apiHostName;
    this.http = http;
    this.ShpId = shpId;
    this.BaseUrl = baseUrl; 
      
    this.location = xlocation; 
    var _platformStrategy = this.infoService.getObjectValue(this.location, "_platformStrategy"); 
    console.log(_platformStrategy);
    var _platformLocation = this.infoService.getObjectValue(_platformStrategy, "_platformLocation")
    console.log(_platformLocation);

    var _Location = this.infoService.getObjectValue(_platformLocation, "location")
    console.log(_Location); 
    this.HostUrl = _Location;

    this.RecommUserId = this.publicService.getRecommUserId();
    if (this.RecommUserId.length < 3) {  // 獲取失敗，待測試
      this.RecommUserId = "620000";
    }
    this.GetInfolist(this.ShpId);

    
    this.ads = this.adService.getAds(); 
  }

  async GetInfolist(ShpId: string) {
    const promise = new Promise((resolve, reject) => {
      this.infoService.GetInfolist(ShpId, this.RecommUserId, "1", this.pagesize.toString())
        .toPromise()
        .then(
          res => { // Success 
            
            this.infolists = res; 
            
            this.loading = true;
            resolve(res);
          },
        err => {
            console.error(err);
            reject(err);
          }
        );
    });
    await promise;
  }
  //getRecommUserId():string
  //  {
  //      const cookieRecommUserIdExists: boolean = this.cookieService.check('RecommUserId');
  //      if (cookieRecommUserIdExists) {
  //        return this.cookieService.get('RecommUserId');
  //      }
  //      else
  //      {
  //        return this.cookieService.get('DefaultShopUserId');
  //      }
  //  };
  OnInit()
  {
    //this.GetInfolist(this.ShpId);
    console.log("OnInit ：" + Date);

    //this.ads = this.adService.getAds();
    //console.log("加載組件 OnIniit");
    //console.log(this.ads);
  }
  ngAfterViewInit() {
    // 获取所有cdkScrollable
    var i = 0;
    if (!this.loading)
      setInterval(() => { 
        console.log("ngAfterViewInit :: minutes timer..." + i);
        i += 1;
      }, 60000); 
    }

 
}

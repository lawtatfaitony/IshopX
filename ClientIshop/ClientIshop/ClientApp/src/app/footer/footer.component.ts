import { Component, Input, Inject, HostListener } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { iShop, InfoService } from '../info/info.service'; 
import { apiUrls } from '../shared/models/model.url'; 
import { distinct, filter, map, debounceTime, tap, flatMap } from 'rxjs/operators';
import { Observable, BehaviorSubject, fromEvent, merge } from 'rxjs';
import { PublicService } from "../public.service";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent{
  ShpId: string;
  shop: iShop[];
  shopName: string;

  @Input()
  set myModelshopName(value) {
    this.shopName = value;
  }
  show: string = "bg-black-active";
  footerShow: boolean = false;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject('ShpId') shpId: string, private infoService: InfoService,private publicService: PublicService)
  {
    this.ShpId = shpId;
    //this.getShopDetails(this.ShpId);
  }
  //async getShopDetails(ShopId: string) {
  //  const promise = new Promise((resolve, reject) => {
  //    this.infoService.getShopDetails(ShopId)
  //      .toPromise()
  //      .then(
  //        res => { // Success 
  //          this.shop = res;
  //          this.shopName = this.infoService.getObjectValue(res, "shopName");
  //          resolve();
  //        },
  //        err => {
  //          console.error("getShopDetails>error:::\n\r" + err);
  //          reject(err);
  //        }
  //      );
  //  });
  //  await promise;
  //}

  @HostListener('window:scroll', [])
  onWindowScroll() {

    const number = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;  //  let scrollTop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop；

    //console.log("getScrollTop() + getWindowHeight() == getScrollHeight() 已经到最底部了！!" );
    //console.log("getScrollTop:: " + this.getScrollTop() + " \n\r getScrollHeight:: " + this.getScrollHeight() + "\n\rgetWindowHeight::" + this.getWindowHeight() +  "\n\r pageYOffset::" + number);

    var bottomArea = Math.abs((this.publicService.getScrollTop() + this.publicService.getWindowHeight()) - this.publicService.getScrollHeight());
     
    if (bottomArea >= 0 && bottomArea < 50) {
      this.footerShow = true;
    }
    else { 
      this.footerShow = false;
    }
  }
  
  //window.onscroll = function () {
  //  if (getScrollTop() + getWindowHeight() == getScrollHeight()) {
  //    alert("已经到最底部了！!");
  //  }
  //};

  

}

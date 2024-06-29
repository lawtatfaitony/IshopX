
//<app-staff [ShopStaffId]="infodetails.shopStaffId" *ngIf="infodetails.shopStaffId"></app-staff>

import { Component, Inject, OnInit,Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Params } from "@angular/router";
import { iInfoIDs, iShopStaff ,InfoService } from '../info/info.service';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnChanges, OnInit {
   
  private _ShopStaffId: string;
  http: HttpClient;
 
  @Input()
  set ShopStaffId(ShopStaffId: string) { // 输入属性1
    this._ShopStaffId = ShopStaffId;

    console.log('屬性::::::' + this._ShopStaffId);
    // dosomething
  };
  get ShopStaffId() {
    return this._ShopStaffId;
  };

  public shopstaff: iShopStaff[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

        //// get shopstaff
        //console.log('this.ShopStaffId::::::' + this._ShopStaffId);
        console.log("Staff detail:::::::::::::::" + baseUrl + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId);
        //http.get<iShopStaff>(baseUrl + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId).subscribe(resultshopstaff => {

        //  console.log("形象 shopstaff :\n\r");
        //  console.log(resultshopstaff);
        //  this.shopstaff = resultshopstaff;

        //});
  }
  ngOnChanges(changes: SimpleChanges): void {
    console.group('child ngOnChanges called.');
    console.log(changes); 
    console.groupEnd();
    let changedProp = changes["ShopStaffId"];

    this._ShopStaffId = changedProp["currentValue"];
    console.log('ngOnChanges :this._ShopStaffId::::::' + this._ShopStaffId);
    //var baseUrl2 = "https://localhost:44363/";
    //console.log("Staff detail:::::::::::::::" + baseUrl2 + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId);
    this.http.get<iShopStaff[]>( '/api/InfoData/ShopStaffDetails/' + this.ShopStaffId).subscribe(resultshopstaff => {

          console.log("形象 shopstaff :\n\r");
          console.log(resultshopstaff);
          this.shopstaff = resultshopstaff;

        });
  }
   
  //ngOnChanges(changes: { [propKey: string]: SimpleChanges }) {
  //  for (let propName in changes) { // 遍历changes
  //    let changedProp = changes[propName]; // propName是输入属性的变量名称
  //    let to = JSON.stringify(changedProp.currentValue); // 获取输入属性当前值
  //    if (changedProp.isFirstChange()) { // 判断输入属性是否首次变化
  //      console.log(`Initial value of ${propName} set to ${to}`);
  //    } else {
  //      let from = JSON.stringify(changedProp.previousValue); // 获取输入属性先前值
  //      console.log(`${propName} changed from ${from} to ${to}`);
  //    }
  //  }
  //}
  ngOnInit() {
        // get shopstaff
        //console.log('this.ShopStaffId::::::' + this._ShopStaffId);
        //console.log("Staff detail:::::::::::::::" + baseUrl + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId);
        //http.get<iShopStaff[]>(baseUrl + 'api/InfoData/ShopStaffDetails/' + this.ShopStaffId).subscribe(resultshopstaff => {

        //  console.log("形象 shopstaff :\n\r");
        //  console.log(resultshopstaff);
        //  this.shopstaff = resultshopstaff;

        //});
  }
}

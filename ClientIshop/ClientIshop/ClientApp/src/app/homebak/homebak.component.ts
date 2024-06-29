import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { iInfoDetail, InfoService } from '../info/info.service';
import { iResult, IpCounterService } from '../ipcounter.service';
import { apiUrls } from '../shared/models/model.url';


import { Observable, BehaviorSubject, fromEvent, merge } from 'rxjs';

import { distinct, filter, map, debounceTime, tap, flatMap } from 'rxjs/operators';
import * as _ from 'lodash';

@Component({
  selector: 'app-homebak',
  templateUrl: './homebak.component.html',
  styleUrls: ['./homebak.component.css']
})

export class HomebakComponent {
  http: HttpClient;
  ShpId: string;
  title = 'welcome to our  ClientApp';
  subtitle = "這是一個副標題。subtitle!";
  datatime = Date.now();
  BaseUrl: string;
  RecommUserId: string = this.getRecommUserId();



  private cache = [];
  private pageByManual$ = new BehaviorSubject(1);
  private itemHeight = 120;
  private itemSize = 12;
  loading = false;
  uri_getinfolist: string;

  private pageByScroll$ = fromEvent(window, "scroll")
    .pipe(
      map(() => window.scrollY),
      filter(current => current >= document.body.clientHeight - window.innerHeight),
      debounceTime(200), 
      distinct(),
    map(y => Math.ceil((y + window.innerHeight) / (this.itemHeight * this.itemSize))),
    );

  private pageByResize$ = fromEvent(window, "resize")
    .pipe(
      debounceTime(200),
      map(_ => Math.ceil(
        (window.innerHeight + document.body.scrollTop) /
        (this.itemHeight * this.itemSize)
      ))
    )

  private pageToLoad$ = merge(this.pageByManual$, this.pageByScroll$, this.pageByResize$)
    .pipe(
      distinct(),
      filter(page => this.cache[page - 1] === undefined)
    );

  infolists = this.pageToLoad$
    .pipe(
      tap(_ => this.loading = true),
      flatMap((page: number) => {

        return this.http.get(this.uri_getinfolist + `/${page}/` + this.itemSize)
          .pipe(
            map((resp) => resp),
            tap(resp => {
              console.log("page \n\r:::::" + page);
              this.cache[page - 1] = resp;
              if ((this.itemHeight * this.itemSize * page) < window.innerHeight) {
                this.pageByManual$.next(page + 1);
              }
            })
          )
      }),
      map(() => _.flatMap(this.cache))
    );

  constructor(http: HttpClient, @Inject('ShpId') shpId: string, @Inject('BASE_URL') baseUrl: string, private infoService: InfoService, private cookieService: CookieService) {
    this.http = http;
    this.ShpId = shpId;
    this.BaseUrl = baseUrl;
    this.uri_getinfolist = apiUrls.getInfolist + this.ShpId + "/" + this.RecommUserId;
    //console.log("uri_getinfolist::::\n\r" + this.uri_getinfolist); 
    //this.GetInfolist(this.ShpId);

    //when frequence scroll & multi operation ,use the follow to reduce :
    //this.subscribeScoll = Observable.fromEvent(window, 'scroll')
    //  .debounceTime(50)
    //  .throttle(ev => Observable.interval(50))
    //  .subscribe((event) => {
    //    this.pageByScroll$();
    //  });
  }

  //async GetInfolist(ShpId: string) {
  //  const promise = new Promise((resolve, reject) => {
  //    this.infoService.GetInfolist(ShpId, "1", "50")
  //      .toPromise()
  //      .then(
  //        res => { // Success 
  //          this.infolists = res;
  //          this.loading = true;
  //          resolve();
  //        },
  //        err => {
  //          console.error("GetInfolist > error:::\n\r" + err);
  //          reject(err);
  //        }
  //      );
  //  });
  //  await promise;
  //}

  //drop(event: CdkDragDrop<string[]>) {
  //  moveItemInArray(this.infolists, event.previousIndex, event.currentIndex);
  //}

  getRecommUserId(): string {
    const cookieRecommUserIdExists: boolean = this.cookieService.check('RecommUserId');
    if (cookieRecommUserIdExists) {
      return this.cookieService.get('RecommUserId');
    }
    else {
      return this.cookieService.get('DefaultShopUserId');
    }
  };

  ngAfterViewInit() {
    //// 获取所有cdkScrollable
    //if (this.loading)
    //  setInterval(() => {
    //    console.log("loading... \n\r");
    //  }, 1000);

  }
}

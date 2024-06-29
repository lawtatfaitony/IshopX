import { Injectable, Inject } from '@angular/core';
import { Location } from '@angular/common'; 
import { HttpClient } from '@angular/common/http'; 
import { apiUrls } from './shared/models/model.url';
import { CookieService } from 'ngx-cookie-service'; 
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router'; 
import { Title } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class PublicService {  
  ShpId: string; 
  BaseUrl: string;
  HostUrl: string; 
  defaultLazyImage: string = "/assets/Rolling1s60pxblueblack.gif";
  RecommUserId: string = this.getRecommUserId();
  location: Location;
  config:any;
  constructor(public http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    @Inject('ShpId') shpId: string, private route: ActivatedRoute,
    private titleService: Title,
    private cookieService: CookieService,
    xlocation: Location) {
     
    this.BaseUrl = baseUrl;
    this.ShpId = shpId; 
    //_Location ============= 
    this.location = xlocation;
    var _platformStrategy = this.getObjectValue(this.location, "_platformStrategy");
    console.log(_platformStrategy);
    var _platformLocation = this.getObjectValue(_platformStrategy, "_platformLocation")
    console.log(_platformLocation);
    var _Location = this.getObjectValue(_platformLocation, "location")
    console.log("public service" + _Location);
    this.HostUrl = _Location;

    //=======================
     
  }
  public getObjectValue(Object: any, PropertyValue: string) {
    if (Reflect.has(Object, PropertyValue)) {
      //console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
      return Reflect.get(Object, PropertyValue);
    }
    else {
      console.log("getObjectValue : no no no {0}:::::", PropertyValue);
      return null;
    }
  }

  public getRecommUserId(): string {
    const cookieRecommUserIdExists: boolean = this.cookieService.check('RecommUserId');
    const cookieDefaultShopUserIdExists: boolean = this.cookieService.check('DefaultShopUserId');
    if (cookieRecommUserIdExists) {
      return this.cookieService.get('RecommUserId');
    }
    else if (cookieDefaultShopUserIdExists) {
      return this.cookieService.get('DefaultShopUserId');
    } else {
      return "620000";
    }
  }
  public setTitle(title: string) { 
    // Get the config information from the app routing data
    this.config = this.route.snapshot.data;
    console.log( "route.snapshop.data \n\r" + this.config);
    // Sets the page title
    this.titleService.setTitle(title); 
  }
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
  }


  public getScrollTop(): number {
    var scrollTop = 0, bodyScrollTop = 0, documentScrollTop = 0;
    if (document.body) {
      bodyScrollTop = document.body.scrollTop;
    }
    if (document.documentElement) {
      documentScrollTop = document.documentElement.scrollTop;
    }
    scrollTop = (bodyScrollTop - documentScrollTop > 0) ? bodyScrollTop : documentScrollTop;
    return scrollTop;
  }
  public getScrollHeight(): number {
    var scrollHeight = 0, bodyScrollHeight = 0, documentScrollHeight = 0;
    if (document.body) {
      bodyScrollHeight = document.body.scrollHeight;
    }
    if (document.documentElement) {
      documentScrollHeight = document.documentElement.scrollHeight;
    }
    scrollHeight = (bodyScrollHeight - documentScrollHeight > 0) ? bodyScrollHeight : documentScrollHeight;
    return scrollHeight;
  }
  public getWindowHeight(): number {
    var windowHeight = 0;
    if (document.compatMode == "CSS1Compat") {
      windowHeight = document.documentElement.clientHeight;
    } else {
      windowHeight = document.body.clientHeight;
    }
    return windowHeight;
  }
   
 
 // /**
 //* Handle Http operation that failed.
 //* Let the app continue.
 //* @param operation - name of the operation that failed
 //* @param result - optional value to return as the observable result
 //*/
 // private handleError<T>(operation = 'operation', result?: T) {
 //   return (error: any): Observable<T> => {

 //     // TODO: send the error to remote logging infrastructure
 //     console.error(error); // log to console instead

 //     // TODO: better job of transforming error for user consumption
 //     this.log(`${operation} failed: ${error.message}`);

 //     // Let the app keep running by returning an empty result.
 //     return of(result as T);
 //   };
 // } 
}

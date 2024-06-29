   
import { Injectable, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { apiUrls } from './shared/models/model.url';
import { CookieService } from 'ngx-cookie-service';

export interface iResult {

  result: string; 
  statuscode: number;   
}
export interface iresult { 
  status: number;
}
@Injectable()
export class IpCounterService {
  IpIntervalId:any; 
  public BaseUrl: string; 
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private cookieService: CookieService)
  {
    this.BaseUrl = baseUrl; 
      
  }

  getObjectValue(Object: any, PropertyValue: string) {
    if (Reflect.has(Object, PropertyValue)) {
      console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
      return Reflect.get(Object, PropertyValue);
    }
    else {
      console.log("no no no {0}:::::", PropertyValue);
      return null;
    }
  }
  
  ngOnInit() {  
    //加载页面耗时计算  loadTime
    var loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart; 
    //浏览次数统计
    setTimeout("console.log(loadTime);", 3000);

    //initialize the IpIntervalId:
    clearInterval(this.IpIntervalId);
  };

  public getIpIntervalId(IpIntervalId?: string):number {
    const cookieIpIntervalIdExists: boolean = this.cookieService.check('IpIntervalId');
    if (cookieIpIntervalIdExists) { 
      let ck = Number(this.cookieService.get('IpIntervalId'))
      if (IpIntervalId != null || ck != Number(IpIntervalId) )
      {
        console.log("getIpIntervalId:: IpIntervalId !=null::" + ck );
        this.cookieService.set('IpIntervalId', IpIntervalId);
      }
      return ck;
    }
    else {
      if (IpIntervalId != "undefined") {
        this.cookieService.set('IpIntervalId', IpIntervalId);
        return Number(IpIntervalId);
      } else {
        console.log("error :: IpIntervalId = undefined;return null (ipcounter.service)");
        return null;
      }
      
    }
  };
  public getPage() {

    var hidden, state, visibilityChange;
    if (typeof document["hidden"] !== "undefined") { hidden = "hidden"; visibilityChange = "visibilitychange"; state = "visibilityState"; }
    else if (typeof document["mozHidden"] !== "undefined") { hidden = "mozHidden"; visibilityChange = "mozvisibilitychange"; state = "mozVisibilityState"; }
    else if (typeof document["msHidden"] !== "undefined") { hidden = "msHidden"; visibilityChange = "msvisibilitychange"; state = "msVisibilityState"; }
    else if (typeof document["webkitHidden"] !== "undefined") { hidden = "webkitHidden"; visibilityChange = "webkitvisibilitychange"; state = "webkitVisibilityState"; }
    return { 'hidden': hidden, 'visibilityChange': visibilityChange, 'state': state };
  }

  //IP SourceStatistics 
  SourceStatistics(SourceStatisticsID: string, IntervalMinutes: number, IpStatitics_StartDate_Token: string) {
    var SourceStatistics_Url =  apiUrls.ipstatitic ;  //"IPstatitics/{IntervalMinutes}/{SourceStatisticsID}"
    
    SourceStatistics_Url = SourceStatistics_Url + IntervalMinutes + "/" + IpStatitics_StartDate_Token + "/" + SourceStatisticsID ;
    console.log(SourceStatistics_Url);
    
    ///IP Statitics
    var Page = this.getPage();
    if (document[Page['state']] == 'hidden') {
      console.log("h5切换到后台");

    } else {

      this.http.get(SourceStatistics_Url).subscribe(dataIpCouter => {
        console.log(dataIpCouter);
        console.log("h5获得焦点\n\r" + SourceStatistics_Url);
      });
    };
         
  }
    
  IPstatitics(SourceStatisticsID: string, IpStatitics_StartDate_Token:string)
  {
    this.IpIntervalId = setInterval(() => {
      this.SourceStatistics(SourceStatisticsID, 0.5, IpStatitics_StartDate_Token);  //if IntervalMinutes is equal to 1 minutes ,then variant of intervals set to 60000. 
    }, 30000); 
    console.log("start::IpIntervalId::" + this.IpIntervalId);  //window.clearInterval(t1); 
  }

  PageLoadingTimesCounter(SourceStatisticsID: string, IpStatitics_StartDate_Token:string)
  {
    var loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart;
    var Osversion = this.getOSAndBrowser();
    var SourceUrl = encodeURIComponent(document.referrer); //encodeURIComponent(document.referrer).replace("/", "\/");
    if (SourceUrl.length < 1) { SourceUrl = "-"}
    console.log("SourceUrl ::\n\r" + SourceUrl);

    var PageLoading_Url =  apiUrls.pageLoadingTimesCounter;   
    PageLoading_Url = PageLoading_Url + SourceStatisticsID + "/" + loadTime + "/" + Osversion + "/" + SourceUrl + "/" + IpStatitics_StartDate_Token;

    //loadTime
    console.log("loadTime::" + loadTime);
    setTimeout(() => {
      console.log('PageLoadingTimesCounter::\n\r' + PageLoading_Url)
      this.http.get<iresult>(PageLoading_Url)
        .pipe(
        tap(_ => console.log('PageLoadingTimesCounter::\n\r' + PageLoading_Url))
        );
      //this.http.get(PageLoading_Url).subscribe(dataPageLoading => {
      //  console.log(dataPageLoading);
      //  console.log("loadTime | Osversion | Token...\n\r" + PageLoading_Url);
      //}); //has essor  not be clone
    }, 10000); 
  }
   
  //JS Get current operating system and browser name
  getOSAndBrowser() {
    var os = navigator.platform;
    var userAgent = navigator.userAgent;
    var info_OS_Browser = "";
    if (/(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)) {
      info_OS_Browser = "iPhone";
    } else if (/(Android)/i.test(navigator.userAgent)) {
      info_OS_Browser = "Android";
    } else {
      info_OS_Browser = "Windows";
    }
    console.log("getOSAndBrowser:" + info_OS_Browser);
    return info_OS_Browser;
}

  ngOnDestroy() {
    clearInterval(this.IpIntervalId);
  }
}

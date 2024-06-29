(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/ad-banner/ad-banner.component.css":
/*!***************************************************!*\
  !*** ./src/app/ad-banner/ad-banner.component.css ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FkLWJhbm5lci9hZC1iYW5uZXIuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./src/app/ad-banner/ad-banner.component.html":
/*!****************************************************!*\
  !*** ./src/app/ad-banner/ad-banner.component.html ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"ad-banner-example\">\r\n  <ng-template ad-host></ng-template>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/ad-banner/ad-banner.component.ts":
/*!**************************************************!*\
  !*** ./src/app/ad-banner/ad-banner.component.ts ***!
  \**************************************************/
/*! exports provided: AdBannerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdBannerComponent", function() { return AdBannerComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _ad_ad_directive__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../ad/ad.directive */ "./src/app/ad/ad.directive.ts");



var AdBannerComponent = /** @class */ (function () {
    function AdBannerComponent(componentFactoryResolver) {
        this.componentFactoryResolver = componentFactoryResolver;
        this.currentAdIndex = -1;
    }
    AdBannerComponent.prototype.ngOnInit = function () {
        this.loadComponent();
        this.getAds();
    };
    AdBannerComponent.prototype.ngOnDestroy = function () {
        clearInterval(this.interval);
    };
    AdBannerComponent.prototype.loadComponent = function () {
        this.currentAdIndex = (this.currentAdIndex + 1) % this.ads.length;
        var adItem = this.ads[this.currentAdIndex];
        var componentFactory = this.componentFactoryResolver.resolveComponentFactory(adItem.component);
        var viewContainerRef = this.adHost.viewContainerRef;
        viewContainerRef.clear();
        var componentRef = viewContainerRef.createComponent(componentFactory);
        componentRef.instance.data = adItem.data;
    };
    AdBannerComponent.prototype.getAds = function () {
        var _this = this;
        this.interval = setInterval(function () {
            _this.loadComponent();
        }, 6000);
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Array)
    ], AdBannerComponent.prototype, "ads", void 0);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewChild"])(_ad_ad_directive__WEBPACK_IMPORTED_MODULE_2__["AdDirective"]),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", _ad_ad_directive__WEBPACK_IMPORTED_MODULE_2__["AdDirective"])
    ], AdBannerComponent.prototype, "adHost", void 0);
    AdBannerComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-ad-banner',
            template: __webpack_require__(/*! ./ad-banner.component.html */ "./src/app/ad-banner/ad-banner.component.html"),
            styles: [__webpack_require__(/*! ./ad-banner.component.css */ "./src/app/ad-banner/ad-banner.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ComponentFactoryResolver"]])
    ], AdBannerComponent);
    return AdBannerComponent;
}());



/***/ }),

/***/ "./src/app/ad/ad-item.ts":
/*!*******************************!*\
  !*** ./src/app/ad/ad-item.ts ***!
  \*******************************/
/*! exports provided: AdItem */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdItem", function() { return AdItem; });
var AdItem = /** @class */ (function () {
    function AdItem(component, data) {
        this.component = component;
        this.data = data;
    }
    return AdItem;
}());



/***/ }),

/***/ "./src/app/ad/ad.directive.ts":
/*!************************************!*\
  !*** ./src/app/ad/ad.directive.ts ***!
  \************************************/
/*! exports provided: AdDirective */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdDirective", function() { return AdDirective; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var AdDirective = /** @class */ (function () {
    function AdDirective(viewContainerRef) {
        this.viewContainerRef = viewContainerRef;
    }
    AdDirective = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Directive"])({
            selector: '[ad-host]',
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewContainerRef"]])
    ], AdDirective);
    return AdDirective;
}());



/***/ }),

/***/ "./src/app/ad/ad.service.ts":
/*!**********************************!*\
  !*** ./src/app/ad/ad.service.ts ***!
  \**********************************/
/*! exports provided: AdService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdService", function() { return AdService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _public_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../public.service */ "./src/app/public.service.ts");
/* harmony import */ var _infovideopane_infovideopane_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../infovideopane/infovideopane.component */ "./src/app/infovideopane/infovideopane.component.ts");
/* harmony import */ var _infopane_infopane_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../infopane/infopane.component */ "./src/app/infopane/infopane.component.ts");
/* harmony import */ var _ad_item__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./ad-item */ "./src/app/ad/ad-item.ts");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../info/info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../shared/models/model.url */ "./src/app/shared/models/model.url.ts");










var AdService = /** @class */ (function () {
    function AdService(http, baseUrl, shpId, infoService, publicService) {
        this.http = http;
        this.infoService = infoService;
        this.publicService = publicService;
        this.take = 3;
        this.InfoItemTemplateIds_InfoPane = "InfoTemp00001";
        this.RecommUserId = this.publicService.getRecommUserId();
        this.ShpId = shpId;
        //this.getInfoIdAdSet(shpId, this.RecommUserId, "InfoTemp00001", 3); 
        ///InfoData/getInfoPaneAdSet/sh0006/620002/InfoTemp00001
        var InfoPaneUrl = "" + _shared_models_model_url__WEBPACK_IMPORTED_MODULE_9__["apiUrls"].getInfoPaneAdSet + this.ShpId + "/" + this.RecommUserId + "/" + this.InfoItemTemplateIds_InfoPane;
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
    AdService.prototype.getAds = function () {
        var InfoPaneUrl = "" + _shared_models_model_url__WEBPACK_IMPORTED_MODULE_9__["apiUrls"].getInfoPaneAdSet + this.ShpId + "/" + this.RecommUserId + "/" + this.InfoItemTemplateIds_InfoPane;
        //this.getInfoPaneAd(InfoPaneUrl).subscribe(data => {
        //  this.InfoPaneAdSetData1 = data;
        //  console.log("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //  console.log(data);
        //});
        this.getInfoPaneAdSetX(InfoPaneUrl).subscribe(function (data) {
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
            new _ad_item__WEBPACK_IMPORTED_MODULE_7__["AdItem"](_infopane_infopane_component__WEBPACK_IMPORTED_MODULE_6__["InfopaneComponent"], { userTraceId: "sh0006620002Inf000000081", title: "Ha.Ha!!! this.infoPane.Title", subTitle: "this.infoPane.SubTitle", titleThumbNail: "http://81.71.74.135:8081/Upload/Info/Inf20180826131028997.jpg" }),
            new _ad_item__WEBPACK_IMPORTED_MODULE_7__["AdItem"](_infopane_infopane_component__WEBPACK_IMPORTED_MODULE_6__["InfopaneComponent"], { userTraceId: "sh0006620002Inf000000081", title: "Ha.Ha!!! this.infoPane.Title", subTitle: "this.infoPane.SubTitle", titleThumbNail: "http://81.71.74.135:8081/Upload/Info/Infsh000620240523122531358.jpg" }),
            new _ad_item__WEBPACK_IMPORTED_MODULE_7__["AdItem"](_infovideopane_infovideopane_component__WEBPACK_IMPORTED_MODULE_5__["InfovideopaneComponent"], { headline: 'video Openings in all departments', body: 'Apply today' }),
        ];
        //return [
        //  new AdItem(InfopaneComponent, { userTraceId: this.infoPane.UserTraceId, title: this.infoPane.Title + "哈哈哈哈", subTitle: this.infoPane.SubTitle, titleThumbNail: this.infoPane.TitleThumbNail }),
        //  new AdItem(InfovideopaneComponent, { headline: 'video Openings in all departments', body: 'Apply today' }),
        //];
    }; //getAds 
    AdService.prototype.getInfoPaneAdSetX = function (InfoPaneUrl) {
        console.log("InfoPaneUrl = " + InfoPaneUrl);
        return this.http.get(InfoPaneUrl)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["tap"])(function (_) { return console.log('fetched getInfoPaneAdSet'); }));
    };
    AdService.prototype.getInfoPaneAd = function (InfoPaneUrl) {
        return this.http.get(InfoPaneUrl)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["tap"])(function (_) { return console.log('fetched getInfoPaneAdSet'); }));
    };
    AdService.prototype.getObjectValue = function (Object, PropertyValue) {
        if (Reflect.has(Object, PropertyValue)) {
            //console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
            return Reflect.get(Object, PropertyValue);
        }
        else {
            console.log("getObjectValue : no no no {0}:::::", PropertyValue);
            return null;
        }
    };
    AdService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](2, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String, String, _info_info_service__WEBPACK_IMPORTED_MODULE_8__["InfoService"], _public_service__WEBPACK_IMPORTED_MODULE_4__["PublicService"]])
    ], AdService);
    return AdService;
}());



/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _home_home_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./home/home.component */ "./src/app/home/home.component.ts");
/* harmony import */ var _counter_counter_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./counter/counter.component */ "./src/app/counter/counter.component.ts");
/* harmony import */ var _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./fetch-data/fetch-data.component */ "./src/app/fetch-data/fetch-data.component.ts");
/* harmony import */ var _info_info_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./info/info.component */ "./src/app/info/info.component.ts");
/* harmony import */ var _footer_footer_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./footer/footer.component */ "./src/app/footer/footer.component.ts");
/* harmony import */ var _homebak_homebak_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./homebak/homebak.component */ "./src/app/homebak/homebak.component.ts");
/* harmony import */ var _bootstraptest_bootstraptest_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./bootstraptest/bootstraptest.component */ "./src/app/bootstraptest/bootstraptest.component.ts");
/* harmony import */ var _test_test_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./test/test.component */ "./src/app/test/test.component.ts");











var routes = [
    { path: '', component: _home_home_component__WEBPACK_IMPORTED_MODULE_3__["HomeComponent"], pathMatch: 'full' },
    { path: 'home/index', component: _home_home_component__WEBPACK_IMPORTED_MODULE_3__["HomeComponent"], pathMatch: 'full' },
    { path: 'counter', component: _counter_counter_component__WEBPACK_IMPORTED_MODULE_4__["CounterComponent"] },
    { path: 'fetch-data', component: _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_5__["FetchDataComponent"] },
    { path: 'info/:id', component: _info_info_component__WEBPACK_IMPORTED_MODULE_6__["InfoComponent"] },
    { path: 'Bootstraptest', component: _bootstraptest_bootstraptest_component__WEBPACK_IMPORTED_MODULE_9__["BootstraptestComponent"] },
    { path: 'footer', component: _footer_footer_component__WEBPACK_IMPORTED_MODULE_7__["FooterComponent"] },
    { path: 'test', component: _test_test_component__WEBPACK_IMPORTED_MODULE_10__["TestComponent"] },
    { path: 'homebak', component: _homebak_homebak_component__WEBPACK_IMPORTED_MODULE_8__["HomebakComponent"] }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "@media (max-width: 767px) {\r\n  /* On small screens, the nav menu spans the full width of the screen. Leave a space for it. */\r\n  .body-content {\r\n    padding-top: 50px;\r\n  }\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvYXBwLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSw2RkFBNkY7RUFDN0Y7SUFDRSxpQkFBaUI7RUFDbkI7QUFDRiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiQG1lZGlhIChtYXgtd2lkdGg6IDc2N3B4KSB7XHJcbiAgLyogT24gc21hbGwgc2NyZWVucywgdGhlIG5hdiBtZW51IHNwYW5zIHRoZSBmdWxsIHdpZHRoIG9mIHRoZSBzY3JlZW4uIExlYXZlIGEgc3BhY2UgZm9yIGl0LiAqL1xyXG4gIC5ib2R5LWNvbnRlbnQge1xyXG4gICAgcGFkZGluZy10b3A6IDUwcHg7XHJcbiAgfVxyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<!--The content below is only a placeholder and can be replaced.-->\r\n<div class='container' style=\"min-height:100%\">\r\n  <div class='row'>\r\n    <app-nav-menu [myModelshopName]=\"shopName\"  [myModelshopLogo]=\"shopLogo\"></app-nav-menu> \r\n  </div>\r\n  <div class='row' style=\"padding-top:50px;min-height:100%\"> \r\n    <router-outlet>\r\n    </router-outlet> \r\n  </div>\r\n  <div class='row'>\r\n    <app-footer [myModelshopName]=\"shopName\"></app-footer>\r\n  </div>\r\n</div>\r\n \r\n"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./info/info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-cookie-service */ "./node_modules/ngx-cookie-service/index.js");




var AppComponent = /** @class */ (function () {
    function AppComponent(baseUrl, shpId, infoService, cookieService) {
        this.infoService = infoService;
        this.cookieService = cookieService;
        this.title = 'ClientApp';
        this.ShpId = shpId;
        this.getShopDetails(this.ShpId);
    }
    AppComponent.prototype.getShopDetails = function (ShopId) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var promise;
            var _this = this;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        promise = new Promise(function (resolve, reject) {
                            _this.infoService.getShopDetails(ShopId)
                                .toPromise()
                                .then(function (res) {
                                _this.shop = res;
                                _this.shopLogo = _this.infoService.getObjectValue(res, "shopLogo");
                                _this.shopName = _this.infoService.getObjectValue(res, "shopName");
                                _this.shopUserId = _this.infoService.getObjectValue(res, "userId");
                                _this.defaultShopUserIdCookied(_this.shopUserId);
                                document.title = _this.shopName;
                                resolve();
                            }, function (err) {
                                console.error("getShopDetails>error:::\n\r" + err);
                                reject(err);
                            });
                        });
                        return [4 /*yield*/, promise];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    AppComponent.prototype.defaultShopUserIdCookied = function (DefaultShopUserId) {
        var defaultShopUserIdCookieExists = this.cookieService.check('DefaultShopUserId');
        //if not then set a cookie
        if (!defaultShopUserIdCookieExists) {
            this.cookieService.set('DefaultShopUserId', DefaultShopUserId);
        }
        console.log("AppComponent >> DefaultShopUserId::" + this.cookieService.get("DefaultShopUserId"));
    };
    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [String, String, _info_info_service__WEBPACK_IMPORTED_MODULE_2__["InfoService"], ngx_cookie_service__WEBPACK_IMPORTED_MODULE_3__["CookieService"]])
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var ng_lazyload_image__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ng-lazyload-image */ "./node_modules/ng-lazyload-image/fesm5/ng-lazyload-image.js");
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ngx-cookie-service */ "./node_modules/ngx-cookie-service/index.js");
/* harmony import */ var _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./nav-menu/nav-menu.component */ "./src/app/nav-menu/nav-menu.component.ts");
/* harmony import */ var _home_home_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./home/home.component */ "./src/app/home/home.component.ts");
/* harmony import */ var _counter_counter_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./counter/counter.component */ "./src/app/counter/counter.component.ts");
/* harmony import */ var _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./fetch-data/fetch-data.component */ "./src/app/fetch-data/fetch-data.component.ts");
/* harmony import */ var _info_info_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./info/info.component */ "./src/app/info/info.component.ts");
/* harmony import */ var _footer_footer_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./footer/footer.component */ "./src/app/footer/footer.component.ts");
/* harmony import */ var _staff_staff_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./staff/staff.component */ "./src/app/staff/staff.component.ts");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./info/info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var _ipcounter_service__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./ipcounter.service */ "./src/app/ipcounter.service.ts");
/* harmony import */ var _highlight_directive__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./highlight.directive */ "./src/app/highlight.directive.ts");
/* harmony import */ var _nav_menu_nav_manu_toggle_directive__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./nav-menu/nav-manu-toggle.directive */ "./src/app/nav-menu/nav-manu-toggle.directive.ts");
/* harmony import */ var _bootstraptest_bootstraptest_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./bootstraptest/bootstraptest.component */ "./src/app/bootstraptest/bootstraptest.component.ts");
/* harmony import */ var _angular_cdk_scrolling__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/cdk/scrolling */ "./node_modules/@angular/cdk/esm5/scrolling.es5.js");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "./node_modules/@angular/cdk/esm5/drag-drop.es5.js");
/* harmony import */ var _homebak_homebak_component__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./homebak/homebak.component */ "./src/app/homebak/homebak.component.ts");
/* harmony import */ var _test_test_component__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./test/test.component */ "./src/app/test/test.component.ts");
/* harmony import */ var _ad_ad_directive__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./ad/ad.directive */ "./src/app/ad/ad.directive.ts");
/* harmony import */ var _ad_ad_service__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./ad/ad.service */ "./src/app/ad/ad.service.ts");
/* harmony import */ var _ad_banner_ad_banner_component__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./ad-banner/ad-banner.component */ "./src/app/ad-banner/ad-banner.component.ts");
/* harmony import */ var _infopane_infopane_component__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./infopane/infopane.component */ "./src/app/infopane/infopane.component.ts");
/* harmony import */ var _infovideopane_infovideopane_component__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./infovideopane/infovideopane.component */ "./src/app/infovideopane/infovideopane.component.ts");






























var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_6__["AppComponent"],
                _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_9__["NavMenuComponent"],
                _home_home_component__WEBPACK_IMPORTED_MODULE_10__["HomeComponent"],
                _counter_counter_component__WEBPACK_IMPORTED_MODULE_11__["CounterComponent"],
                _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_12__["FetchDataComponent"],
                _info_info_component__WEBPACK_IMPORTED_MODULE_13__["InfoComponent"],
                _footer_footer_component__WEBPACK_IMPORTED_MODULE_14__["FooterComponent"],
                _staff_staff_component__WEBPACK_IMPORTED_MODULE_15__["StaffComponent"],
                _highlight_directive__WEBPACK_IMPORTED_MODULE_18__["HighlightDirective"],
                _nav_menu_nav_manu_toggle_directive__WEBPACK_IMPORTED_MODULE_19__["NavManuToggleDirective"],
                _bootstraptest_bootstraptest_component__WEBPACK_IMPORTED_MODULE_20__["BootstraptestComponent"],
                _homebak_homebak_component__WEBPACK_IMPORTED_MODULE_23__["HomebakComponent"],
                _test_test_component__WEBPACK_IMPORTED_MODULE_24__["TestComponent"],
                _ad_banner_ad_banner_component__WEBPACK_IMPORTED_MODULE_27__["AdBannerComponent"],
                _ad_ad_directive__WEBPACK_IMPORTED_MODULE_25__["AdDirective"],
                _infopane_infopane_component__WEBPACK_IMPORTED_MODULE_28__["InfopaneComponent"],
                _infovideopane_infovideopane_component__WEBPACK_IMPORTED_MODULE_29__["InfovideopaneComponent"]
            ],
            imports: [
                _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClientModule"],
                ng_lazyload_image__WEBPACK_IMPORTED_MODULE_7__["LazyLoadImageModule"].forRoot({
                    preset: ng_lazyload_image__WEBPACK_IMPORTED_MODULE_7__["intersectionObserverPreset"]
                }),
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
                _app_routing_module__WEBPACK_IMPORTED_MODULE_5__["AppRoutingModule"],
                _angular_cdk_scrolling__WEBPACK_IMPORTED_MODULE_21__["ScrollingModule"],
                _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_22__["DragDropModule"]
            ],
            entryComponents: [_infopane_infopane_component__WEBPACK_IMPORTED_MODULE_28__["InfopaneComponent"], _infovideopane_infovideopane_component__WEBPACK_IMPORTED_MODULE_29__["InfovideopaneComponent"]],
            providers: [_info_info_service__WEBPACK_IMPORTED_MODULE_16__["InfoService"], _ipcounter_service__WEBPACK_IMPORTED_MODULE_17__["IpCounterService"], ngx_cookie_service__WEBPACK_IMPORTED_MODULE_8__["CookieService"], _ad_ad_service__WEBPACK_IMPORTED_MODULE_26__["AdService"]],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_6__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/bootstraptest/bootstraptest.component.css":
/*!***********************************************************!*\
  !*** ./src/app/bootstraptest/bootstraptest.component.css ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2Jvb3RzdHJhcHRlc3QvYm9vdHN0cmFwdGVzdC5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/bootstraptest/bootstraptest.component.html":
/*!************************************************************!*\
  !*** ./src/app/bootstraptest/bootstraptest.component.html ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\r\n  bootstraptest works!\r\n</p>\r\n<div class=\"container\">\r\n  <div class=\"row\">\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n    <div class=\"col-md-1\">.col-md-1</div>\r\n  </div>\r\n  <div class=\"row\">\r\n    <div class=\"col-md-8\">.col-md-8</div>\r\n    <div class=\"col-md-4\">.col-md-4</div>\r\n  </div>\r\n  <div class=\"row\">\r\n    <div class=\"col-md-4\">.col-md-4</div>\r\n    <div class=\"col-md-4\">.col-md-4</div>\r\n    <div class=\"col-md-4\">.col-md-4</div>\r\n  </div>\r\n  <div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n      .col-md-6\r\n      <var>y</var> = <var>m</var><var>x</var> + <var>b</var>\r\n    </div>\r\n    <div class=\"col-md-6\">.col-md-6</div>\r\n  </div>\r\n</div>\r\n\r\n\r\n<div class=\"container\">\r\n  <div class=\"table-responsive\">\r\n    <table class=\"table  table-hover\">\r\n      <tr>\r\n        <td class=\"active\">.sfsdfsdf..</td>\r\n        <td class=\"success\">.asdf..</td>\r\n        <td class=\"warning\">.sfasfsaf..</td>\r\n        <td class=\"danger\">..fghdf.</td>\r\n        <td class=\"info\">...sdf</td>\r\n      </tr>\r\n\r\n      <tr>\r\n        <td class=\"active\">..dfgh.</td>\r\n        <td class=\"success\">...</td>\r\n        <td class=\"warning\">fghfg..</td>\r\n        <td class=\"danger\">..dfgh.</td>\r\n        <td class=\"info\">...</td>\r\n      </tr>\r\n\r\n      <tr>\r\n        <td class=\"active\">..555555.</td>\r\n        <td class=\"success\">fgh..</td>\r\n        <td class=\"warning\">45...</td>\r\n        <td class=\"danger\">...</td>\r\n        <td class=\"info\">..456.</td>\r\n      </tr>\r\n\r\n      <tr>\r\n        <td class=\"active\">..dfsdfgsdfgsdfgsdfgsdfgsfdgsgdfgsdfgsdg.</td>\r\n        <td class=\"success\">..sgfdgsdfgsfgsdfgdsfgsdfgsdfg.sdfgsdfgsdfgsd</td>\r\n        <td class=\"warning\">..55sdfgsdfgsdfg5.sgsdfgsdfgsdfgsdfgsdfgsdfgsdfgsdfgsfdgsgsdfgsdfg dfgsdfg  dfgsdfg sdf gsfgsfdgsdfg  sdfgs </td>\r\n        <td class=\"danger\">.sdsdfgdsfgdsfgsdgf.sdfgsdfgsdfgsdfgsdfg.</td>\r\n        <td class=\"info\">.sdfsdfgsdfgsfdgsdf..</td>\r\n      </tr>\r\n    </table>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/bootstraptest/bootstraptest.component.ts":
/*!**********************************************************!*\
  !*** ./src/app/bootstraptest/bootstraptest.component.ts ***!
  \**********************************************************/
/*! exports provided: BootstraptestComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BootstraptestComponent", function() { return BootstraptestComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var BootstraptestComponent = /** @class */ (function () {
    function BootstraptestComponent() {
    }
    BootstraptestComponent.prototype.ngOnInit = function () {
    };
    BootstraptestComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-bootstraptest',
            template: __webpack_require__(/*! ./bootstraptest.component.html */ "./src/app/bootstraptest/bootstraptest.component.html"),
            styles: [__webpack_require__(/*! ./bootstraptest.component.css */ "./src/app/bootstraptest/bootstraptest.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], BootstraptestComponent);
    return BootstraptestComponent;
}());



/***/ }),

/***/ "./src/app/counter/counter.component.html":
/*!************************************************!*\
  !*** ./src/app/counter/counter.component.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Counter</h1>\r\n\r\n<p>This is a simple example of an Angular component.</p>\r\n\r\n<p>Current count: <strong>{{ currentCount }}</strong></p>\r\n\r\n<button (click)=\"incrementCounter()\">Increment</button>\r\n"

/***/ }),

/***/ "./src/app/counter/counter.component.ts":
/*!**********************************************!*\
  !*** ./src/app/counter/counter.component.ts ***!
  \**********************************************/
/*! exports provided: CounterComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CounterComponent", function() { return CounterComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var CounterComponent = /** @class */ (function () {
    function CounterComponent() {
        this.currentCount = 0;
    }
    CounterComponent.prototype.incrementCounter = function () {
        this.currentCount++;
    };
    CounterComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-counter-component',
            template: __webpack_require__(/*! ./counter.component.html */ "./src/app/counter/counter.component.html")
        })
    ], CounterComponent);
    return CounterComponent;
}());



/***/ }),

/***/ "./src/app/fetch-data/fetch-data.component.html":
/*!******************************************************!*\
  !*** ./src/app/fetch-data/fetch-data.component.html ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Weather forecast</h1>\r\n\r\n<p>This component demonstrates fetching data from the server.</p>\r\n\r\n<p *ngIf=\"!forecasts\"><em>Loading...</em></p>\r\n\r\n<table class='table' *ngIf=\"forecasts\">\r\n  <thead>\r\n    <tr>\r\n      <th>Date</th>\r\n      <th>Temp. (C)</th>\r\n      <th>Temp. (F)</th>\r\n      <th>Summary</th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr *ngFor=\"let forecast of forecasts\">\r\n      <td>{{ forecast.dateFormatted }}</td>\r\n      <td>{{ forecast.temperatureC }}</td>\r\n      <td>{{ forecast.temperatureF }}</td>\r\n      <td>{{ forecast.summary }}</td>\r\n    </tr>\r\n  </tbody>\r\n</table>\r\n"

/***/ }),

/***/ "./src/app/fetch-data/fetch-data.component.ts":
/*!****************************************************!*\
  !*** ./src/app/fetch-data/fetch-data.component.ts ***!
  \****************************************************/
/*! exports provided: FetchDataComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FetchDataComponent", function() { return FetchDataComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../shared/models/model.url */ "./src/app/shared/models/model.url.ts");




var FetchDataComponent = /** @class */ (function () {
    function FetchDataComponent(http, baseUrl) {
        var _this = this;
        http.get(_shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].weatherforecasts).subscribe(function (result) {
            _this.forecasts = result;
        }, function (error) { return console.error(error); });
    }
    FetchDataComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-fetch-data',
            template: __webpack_require__(/*! ./fetch-data.component.html */ "./src/app/fetch-data/fetch-data.component.html")
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String])
    ], FetchDataComponent);
    return FetchDataComponent;
}());



/***/ }),

/***/ "./src/app/footer/footer.component.css":
/*!*********************************************!*\
  !*** ./src/app/footer/footer.component.css ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".bordertop3px {\r\n  border-top-style: solid;\r\n  border: 3px,0,0,0;\r\n  border-top-color: #e2e2e2; \r\n}\r\n\r\n.gradient {\r\n  background: linear-gradient(to bottom, #e7e0e0 0%,#ffffff 100%);\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvZm9vdGVyL2Zvb3Rlci5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsdUJBQXVCO0VBQ3ZCLGlCQUFpQjtFQUNqQix5QkFBeUI7QUFDM0I7O0FBRUE7RUFNRSwrREFBK0Q7QUFDakUiLCJmaWxlIjoic3JjL2FwcC9mb290ZXIvZm9vdGVyLmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuYm9yZGVydG9wM3B4IHtcclxuICBib3JkZXItdG9wLXN0eWxlOiBzb2xpZDtcclxuICBib3JkZXI6IDNweCwwLDAsMDtcclxuICBib3JkZXItdG9wLWNvbG9yOiAjZTJlMmUyOyBcclxufVxyXG5cclxuLmdyYWRpZW50IHtcclxuICBiYWNrZ3JvdW5kOiAtbW96LWxpbmVhci1ncmFkaWVudCh0b3AsICNlN2UwZTAgMCUsICNmZmZmZmYgMTAwJSk7XHJcbiAgYmFja2dyb3VuZDogLXdlYmtpdC1ncmFkaWVudChsaW5lYXIsIGxlZnQgdG9wLCBsZWZ0IGJvdHRvbSwgY29sb3Itc3RvcCgwJSwjZTdlMGUwKSwgY29sb3Itc3RvcCgxMDAlLCNmZmZmZmYpKTtcclxuICBiYWNrZ3JvdW5kOiAtd2Via2l0LWxpbmVhci1ncmFkaWVudCh0b3AsICNlN2UwZTAgMCUsI2ZmZmZmZiAxMDAlKTtcclxuICBiYWNrZ3JvdW5kOiAtby1saW5lYXItZ3JhZGllbnQodG9wLCAjZTdlMGUwIDAlLCNmZmZmZmYgMTAwJSk7XHJcbiAgYmFja2dyb3VuZDogLW1zLWxpbmVhci1ncmFkaWVudCh0b3AsICNlN2UwZTAgMCUsI2ZmZmZmZiAxMDAlKTtcclxuICBiYWNrZ3JvdW5kOiBsaW5lYXItZ3JhZGllbnQodG8gYm90dG9tLCAjZTdlMGUwIDAlLCNmZmZmZmYgMTAwJSk7XHJcbn1cclxuIl19 */"

/***/ }),

/***/ "./src/app/footer/footer.component.html":
/*!**********************************************!*\
  !*** ./src/app/footer/footer.component.html ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"this.footerShow\" class=\"container bordertop3px gradient \" [ngClass]=\"show\"> \r\n    <div class=\"container\">\r\n      <ul class=\"list-unstyled footer\">\r\n        <li class=\"copyright\">\r\n          &copy; {{shopName}}\r\n        </li>\r\n      </ul>\r\n    </div>\r\n</div>\r\n  <script>\r\n    var _hmt = _hmt || [];\r\n    (function () {\r\n      var hm = document.createElement(\"script\");\r\n      hm.src = \"https://hm.baidu.com/hm.js?6de35c7ba67bf67be24fdbe4b5cadfb6\";\r\n      var s = document.getElementsByTagName(\"script\")[0];\r\n      s.parentNode.insertBefore(hm, s);\r\n    })();\r\n  </script>\r\n"

/***/ }),

/***/ "./src/app/footer/footer.component.ts":
/*!********************************************!*\
  !*** ./src/app/footer/footer.component.ts ***!
  \********************************************/
/*! exports provided: FooterComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FooterComponent", function() { return FooterComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../info/info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var _public_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../public.service */ "./src/app/public.service.ts");





var FooterComponent = /** @class */ (function () {
    function FooterComponent(http, baseUrl, shpId, infoService, publicService) {
        this.infoService = infoService;
        this.publicService = publicService;
        this.show = "bg-black-active";
        this.footerShow = false;
        this.ShpId = shpId;
        //this.getShopDetails(this.ShpId);
    }
    Object.defineProperty(FooterComponent.prototype, "myModelshopName", {
        set: function (value) {
            this.shopName = value;
        },
        enumerable: true,
        configurable: true
    });
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
    FooterComponent.prototype.onWindowScroll = function () {
        var number = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0; //  let scrollTop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop；
        //console.log("getScrollTop() + getWindowHeight() == getScrollHeight() 已经到最底部了！!" );
        //console.log("getScrollTop:: " + this.getScrollTop() + " \n\r getScrollHeight:: " + this.getScrollHeight() + "\n\rgetWindowHeight::" + this.getWindowHeight() +  "\n\r pageYOffset::" + number);
        var bottomArea = Math.abs((this.publicService.getScrollTop() + this.publicService.getWindowHeight()) - this.publicService.getScrollHeight());
        if (bottomArea >= 0 && bottomArea < 50) {
            this.footerShow = true;
        }
        else {
            this.footerShow = false;
        }
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [Object])
    ], FooterComponent.prototype, "myModelshopName", null);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('window:scroll', []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], FooterComponent.prototype, "onWindowScroll", null);
    FooterComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-footer',
            template: __webpack_require__(/*! ./footer.component.html */ "./src/app/footer/footer.component.html"),
            styles: [__webpack_require__(/*! ./footer.component.css */ "./src/app/footer/footer.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](2, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String, String, _info_info_service__WEBPACK_IMPORTED_MODULE_3__["InfoService"], _public_service__WEBPACK_IMPORTED_MODULE_4__["PublicService"]])
    ], FooterComponent);
    return FooterComponent;
}());



/***/ }),

/***/ "./src/app/highlight.directive.ts":
/*!****************************************!*\
  !*** ./src/app/highlight.directive.ts ***!
  \****************************************/
/*! exports provided: HighlightDirective */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HighlightDirective", function() { return HighlightDirective; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var HighlightDirective = /** @class */ (function () {
    function HighlightDirective(el) {
        this.el = el;
    }
    HighlightDirective.prototype.onMouseEnter = function () {
        this.highlight(this.highlightColor || this.defaultColor || '#fce49e');
    };
    HighlightDirective.prototype.onMouseLeave = function () {
        this.highlight(null);
    };
    HighlightDirective.prototype.highlight = function (color) {
        this.el.nativeElement.style.backgroundColor = color;
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", String)
    ], HighlightDirective.prototype, "defaultColor", void 0);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])('appHighlight'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", String)
    ], HighlightDirective.prototype, "highlightColor", void 0);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('mouseenter'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], HighlightDirective.prototype, "onMouseEnter", null);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('mouseleave'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], HighlightDirective.prototype, "onMouseLeave", null);
    HighlightDirective = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Directive"])({
            selector: '[appHighlight]'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ElementRef"]])
    ], HighlightDirective);
    return HighlightDirective;
}());



/***/ }),

/***/ "./src/app/home/home.component.html":
/*!******************************************!*\
  !*** ./src/app/home/home.component.html ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"!infolists\" style=\"padding-top:100px;\"> \r\n  <div class='loader'>\r\n    <div class='loader_overlay'></div>\r\n    <div class='loader_cogs'>\r\n      <div class='loader_cogs__top'>\r\n        <div class='top_part'></div>\r\n        <div class='top_part'></div>\r\n        <div class='top_part'></div>\r\n        <div class='top_hole'></div>\r\n      </div>\r\n      <div class='loader_cogs__left'>\r\n        <div class='left_part'></div>\r\n        <div class='left_part'></div>\r\n        <div class='left_part'></div>\r\n        <div class='left_hole'></div>\r\n      </div>\r\n      <div class='loader_cogs__bottom'>\r\n        <div class='bottom_part'></div>\r\n        <div class='bottom_part'></div>\r\n        <div class='bottom_part'></div>\r\n        <div class='bottom_hole'><!-- lol --></div>\r\n      </div>\r\n      <p>loading</p>\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n<div>\r\n  <app-ad-banner [ads]=\"ads\"></app-ad-banner>\r\n</div>\r\n\r\n<cdk-virtual-scroll-viewport class=\"no-margin no-padding\" style=\"width:100%;height: 800px;\" itemSize=\"1\" minBufferPx=\"30\" maxBufferPx=\"200\">\r\n  <ng-container *cdkVirtualFor=\"let infodetail of infolists\" class=\"no-margin no-padding\">\r\n    <div class=\"row margin-bottom-10 padding-top5 padding-left5 padding-right5\" style=\"border-bottom:solid;border-bottom-color:#f3eeee;border-bottom-width:1px; background-color:#f2eeee;\">\r\n      <div class=\"col-xs-8 no-padding-top\">\r\n        <div class=\"margin-left15 padding-left5 padding-bottom5 no-padding-top h4\">\r\n          <div class=\"row\">\r\n            <a [routerLink]='[\"/info/\"+ infodetail.userTraceId]' class=\"repeat-title no-padding-top\">\r\n              <span class=\"repeat-title\">{{infodetail.title}}</span>\r\n            </a>\r\n          </div>\r\n          <div class=\"row\">\r\n            <div class=\"hidden-sm hidden-md hidden-xs lead\">{{infodetail.subTitle}}</div>\r\n          </div>\r\n        </div>\r\n      </div> \r\n      <div class=\"col-xs-4 padding-bottom5\">\r\n        <a [routerLink]='[\"/info/\"+ infodetail.userTraceId]' class=\"no-margin no-padding\">\r\n          <img  [defaultImage]=\"this.defaultImage\" [lazyLoad]=\"infodetail.titleThumbNail\" [offset]=\"offset\" class=\"img-responsive\">\r\n        </a>\r\n      </div>\r\n    </div>\r\n  </ng-container>\r\n</cdk-virtual-scroll-viewport>\r\n\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/home/home.component.ts":
/*!****************************************!*\
  !*** ./src/app/home/home.component.ts ***!
  \****************************************/
/*! exports provided: HomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeComponent", function() { return HomeComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-cookie-service */ "./node_modules/ngx-cookie-service/index.js");
/* harmony import */ var _public_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../public.service */ "./src/app/public.service.ts");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../info/info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../shared/models/model.url */ "./src/app/shared/models/model.url.ts");
/* harmony import */ var _ad_ad_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../ad/ad.service */ "./src/app/ad/ad.service.ts");









var HomeComponent = /** @class */ (function () {
    function HomeComponent(http, shpId, baseUrl, infoService, cookieService, xlocation, publicService, adService) {
        this.infoService = infoService;
        this.cookieService = cookieService;
        this.publicService = publicService;
        this.adService = adService;
        this.offset = 100;
        this.defaultImage = "/assets/Rolling1s60pxblueblack.gif";
        this.pagesize = 150;
        this.loading = false;
        this.ApiHostName = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_7__["apiHostName"];
        this.http = http;
        this.ShpId = shpId;
        this.BaseUrl = baseUrl;
        this.location = xlocation;
        var _platformStrategy = this.infoService.getObjectValue(this.location, "_platformStrategy");
        console.log(_platformStrategy);
        var _platformLocation = this.infoService.getObjectValue(_platformStrategy, "_platformLocation");
        console.log(_platformLocation);
        var _Location = this.infoService.getObjectValue(_platformLocation, "location");
        console.log(_Location);
        this.HostUrl = _Location;
        this.RecommUserId = this.publicService.getRecommUserId();
        if (this.RecommUserId.length < 3) { // 獲取失敗，待測試
            this.RecommUserId = "620000";
        }
        this.GetInfolist(this.ShpId);
        this.ads = this.adService.getAds();
    }
    HomeComponent.prototype.GetInfolist = function (ShpId) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var promise;
            var _this = this;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        promise = new Promise(function (resolve, reject) {
                            _this.infoService.GetInfolist(ShpId, _this.RecommUserId, "1", _this.pagesize.toString())
                                .toPromise()
                                .then(function (res) {
                                _this.infolists = res;
                                _this.loading = true;
                                resolve(res);
                            }, function (err) {
                                console.error(err);
                                reject(err);
                            });
                        });
                        return [4 /*yield*/, promise];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
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
    HomeComponent.prototype.OnInit = function () {
        //this.GetInfolist(this.ShpId);
        console.log("OnInit ：" + Date);
        //this.ads = this.adService.getAds();
        //console.log("加載組件 OnIniit");
        //console.log(this.ads);
    };
    HomeComponent.prototype.ngAfterViewInit = function () {
        // 获取所有cdkScrollable
        var i = 0;
        if (!this.loading)
            setInterval(function () {
                console.log("ngAfterViewInit :: minutes timer..." + i);
                i += 1;
            }, 60000);
    };
    HomeComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-home',
            template: __webpack_require__(/*! ./home.component.html */ "./src/app/home/home.component.html"),
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](2, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClient"], String, String, _info_info_service__WEBPACK_IMPORTED_MODULE_6__["InfoService"],
            ngx_cookie_service__WEBPACK_IMPORTED_MODULE_4__["CookieService"], _angular_common__WEBPACK_IMPORTED_MODULE_2__["Location"], _public_service__WEBPACK_IMPORTED_MODULE_5__["PublicService"], _ad_ad_service__WEBPACK_IMPORTED_MODULE_8__["AdService"]])
    ], HomeComponent);
    return HomeComponent;
}());



/***/ }),

/***/ "./src/app/homebak/homebak.component.css":
/*!***********************************************!*\
  !*** ./src/app/homebak/homebak.component.css ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "ul {\r\n  max-width: 800px;\r\n  color: #cc4871;\r\n  margin: 20px auto;\r\n  padding: 2px;\r\n}\r\n\r\n.list li {\r\n  padding: 20px;\r\n  background: #f8d8f2;\r\n  border-radius: 12px;\r\n  margin-bottom: 12px;\r\n  text-align: center;\r\n  font-size: 12px;\r\n}\r\n\r\n.divClasslist {\r\n  width: 300px;\r\n  border: solid 1px #234365;\r\n  min-height: 60px;\r\n  display: block;\r\n  background: #cc4871;\r\n  border-radius: 5px;\r\n  margin-bottom: 12px;\r\n  overflow: hidden;\r\n}\r\n\r\n.divClass {\r\n  padding: 20px 10px;\r\n  border-bottom: solid 1px #ccc;\r\n  color: rgba(0, 0, 0, 0.87);\r\n  display: flex;\r\n  flex-direction: row;\r\n  align-items: center;\r\n  justify-content: space-between;\r\n  box-sizing: border-box;\r\n  cursor: move;\r\n  background: #f8d8f2;\r\n  font-size: 14px;\r\n}\r\n\r\n.divClass:active {\r\n    background-color: #cc4871;\r\n  }\r\n\r\n.transparentsUnit {\r\n  opacity: 0.7;\r\n  filter: alpha(opacity=70);\r\n}\r\n\r\n.padding-right-10 {\r\n  padding-right: -20px;\r\n}\r\n\r\n.padding-top0 {\r\n  padding-top: 0;\r\n}\r\n\r\n.bottomgreyline {\r\n  border-width: 3px;\r\n  border-bottom: solid;\r\n  border-bottom-width: 1px;\r\n  border-bottom-color: #8d8d8d;\r\n  background-color: #f7f2ea; /*f7f2ea*/\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaG9tZWJhay9ob21lYmFrLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxnQkFBZ0I7RUFDaEIsY0FBYztFQUNkLGlCQUFpQjtFQUNqQixZQUFZO0FBQ2Q7O0FBRUE7RUFDRSxhQUFhO0VBQ2IsbUJBQW1CO0VBQ25CLG1CQUFtQjtFQUNuQixtQkFBbUI7RUFDbkIsa0JBQWtCO0VBQ2xCLGVBQWU7QUFDakI7O0FBRUE7RUFDRSxZQUFZO0VBQ1oseUJBQXlCO0VBQ3pCLGdCQUFnQjtFQUNoQixjQUFjO0VBQ2QsbUJBQW1CO0VBQ25CLGtCQUFrQjtFQUNsQixtQkFBbUI7RUFDbkIsZ0JBQWdCO0FBQ2xCOztBQUVBO0VBQ0Usa0JBQWtCO0VBQ2xCLDZCQUE2QjtFQUM3QiwwQkFBMEI7RUFDMUIsYUFBYTtFQUNiLG1CQUFtQjtFQUNuQixtQkFBbUI7RUFDbkIsOEJBQThCO0VBQzlCLHNCQUFzQjtFQUN0QixZQUFZO0VBQ1osbUJBQW1CO0VBQ25CLGVBQWU7QUFDakI7O0FBRUU7SUFDRSx5QkFBeUI7RUFDM0I7O0FBR0Y7RUFDRSxZQUFZO0VBQ1oseUJBQXlCO0FBQzNCOztBQUVBO0VBQ0Usb0JBQW9CO0FBQ3RCOztBQUVBO0VBQ0UsY0FBYztBQUNoQjs7QUFFQTtFQUNFLGlCQUFpQjtFQUNqQixvQkFBb0I7RUFDcEIsd0JBQXdCO0VBQ3hCLDRCQUE0QjtFQUM1Qix5QkFBeUIsRUFBRSxTQUFTO0FBQ3RDIiwiZmlsZSI6InNyYy9hcHAvaG9tZWJhay9ob21lYmFrLmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyJ1bCB7XHJcbiAgbWF4LXdpZHRoOiA4MDBweDtcclxuICBjb2xvcjogI2NjNDg3MTtcclxuICBtYXJnaW46IDIwcHggYXV0bztcclxuICBwYWRkaW5nOiAycHg7XHJcbn1cclxuXHJcbi5saXN0IGxpIHtcclxuICBwYWRkaW5nOiAyMHB4O1xyXG4gIGJhY2tncm91bmQ6ICNmOGQ4ZjI7XHJcbiAgYm9yZGVyLXJhZGl1czogMTJweDtcclxuICBtYXJnaW4tYm90dG9tOiAxMnB4O1xyXG4gIHRleHQtYWxpZ246IGNlbnRlcjtcclxuICBmb250LXNpemU6IDEycHg7XHJcbn1cclxuXHJcbi5kaXZDbGFzc2xpc3Qge1xyXG4gIHdpZHRoOiAzMDBweDtcclxuICBib3JkZXI6IHNvbGlkIDFweCAjMjM0MzY1O1xyXG4gIG1pbi1oZWlnaHQ6IDYwcHg7XHJcbiAgZGlzcGxheTogYmxvY2s7XHJcbiAgYmFja2dyb3VuZDogI2NjNDg3MTtcclxuICBib3JkZXItcmFkaXVzOiA1cHg7XHJcbiAgbWFyZ2luLWJvdHRvbTogMTJweDtcclxuICBvdmVyZmxvdzogaGlkZGVuO1xyXG59XHJcblxyXG4uZGl2Q2xhc3Mge1xyXG4gIHBhZGRpbmc6IDIwcHggMTBweDtcclxuICBib3JkZXItYm90dG9tOiBzb2xpZCAxcHggI2NjYztcclxuICBjb2xvcjogcmdiYSgwLCAwLCAwLCAwLjg3KTtcclxuICBkaXNwbGF5OiBmbGV4O1xyXG4gIGZsZXgtZGlyZWN0aW9uOiByb3c7XHJcbiAgYWxpZ24taXRlbXM6IGNlbnRlcjtcclxuICBqdXN0aWZ5LWNvbnRlbnQ6IHNwYWNlLWJldHdlZW47XHJcbiAgYm94LXNpemluZzogYm9yZGVyLWJveDtcclxuICBjdXJzb3I6IG1vdmU7XHJcbiAgYmFja2dyb3VuZDogI2Y4ZDhmMjtcclxuICBmb250LXNpemU6IDE0cHg7XHJcbn1cclxuXHJcbiAgLmRpdkNsYXNzOmFjdGl2ZSB7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAjY2M0ODcxO1xyXG4gIH1cclxuXHJcblxyXG4udHJhbnNwYXJlbnRzVW5pdCB7XHJcbiAgb3BhY2l0eTogMC43O1xyXG4gIGZpbHRlcjogYWxwaGEob3BhY2l0eT03MCk7XHJcbn1cclxuXHJcbi5wYWRkaW5nLXJpZ2h0LTEwIHtcclxuICBwYWRkaW5nLXJpZ2h0OiAtMjBweDtcclxufVxyXG5cclxuLnBhZGRpbmctdG9wMCB7XHJcbiAgcGFkZGluZy10b3A6IDA7XHJcbn1cclxuXHJcbi5ib3R0b21ncmV5bGluZSB7XHJcbiAgYm9yZGVyLXdpZHRoOiAzcHg7XHJcbiAgYm9yZGVyLWJvdHRvbTogc29saWQ7XHJcbiAgYm9yZGVyLWJvdHRvbS13aWR0aDogMXB4O1xyXG4gIGJvcmRlci1ib3R0b20tY29sb3I6ICM4ZDhkOGQ7XHJcbiAgYmFja2dyb3VuZC1jb2xvcjogI2Y3ZjJlYTsgLypmN2YyZWEqL1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/homebak/homebak.component.html":
/*!************************************************!*\
  !*** ./src/app/homebak/homebak.component.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"!infolists\">\r\n  <i class=\"fa fa-spinner\"></i><em>Loading...</em>\r\n  <div class='loader'>\r\n    <div class='loader_overlay'></div>\r\n    <div class='loader_cogs'>\r\n      <div class='loader_cogs__top'>\r\n        <div class='top_part'></div>\r\n        <div class='top_part'></div>\r\n        <div class='top_part'></div>\r\n        <div class='top_hole'></div>\r\n      </div>\r\n      <div class='loader_cogs__left'>\r\n        <div class='left_part'></div>\r\n        <div class='left_part'></div>\r\n        <div class='left_part'></div>\r\n        <div class='left_hole'></div>\r\n      </div>\r\n      <div class='loader_cogs__bottom'>\r\n        <div class='bottom_part'></div>\r\n        <div class='bottom_part'></div>\r\n        <div class='bottom_part'></div>\r\n        <div class='bottom_hole'><!-- lol --></div>\r\n      </div>\r\n      <p>loading</p>\r\n    </div>\r\n    <h1>Welcome!</h1>\r\n    <h2>wait...</h2>\r\n  </div>\r\n</div>\r\n\r\n<cdk-virtual-scroll-viewport class=\"no-margin no-padding\" style=\"width:100%;height: 800px;\" itemSize=\"50\" minBufferPx=\"30\" maxBufferPx=\"200\">\r\n  <ng-container *cdkVirtualFor=\"let infodetail of infolists\" class=\"no-margin no-padding\">\r\n    <div class=\"row margin-bottom-10 padding-top5 padding-left5 padding-right5\" style=\"border-bottom:solid;border-bottom-color:#f3eeee;border-bottom-width:1px; background-color:#f2eeee;\">\r\n      <div class=\"col-xs-8\">\r\n        <div class=\"margin-left15 padding-left5 padding-bottom5 h4\">\r\n          <div class=\"row\">\r\n            <a [routerLink]='[\"/info/\"+ infodetail.userTraceId]'>\r\n              {{infodetail.title}}\r\n            </a>\r\n          </div>\r\n          <div class=\"row\">\r\n            <div class=\"hidden-sm hidden-md hidden-xs lead\">{{infodetail.subTitle}}</div>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-xs-4 padding-bottom5\">\r\n        <a [routerLink]='[\"/info/\"+ infodetail.userTraceId]' class=\"no-margin no-padding\">\r\n          <img [src]=\"infodetail.titleThumbNail\" class=\"img-responsive\" />\r\n        </a>\r\n      </div>\r\n    </div>\r\n\r\n  </ng-container>\r\n</cdk-virtual-scroll-viewport>\r\n\r\n\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/homebak/homebak.component.ts":
/*!**********************************************!*\
  !*** ./src/app/homebak/homebak.component.ts ***!
  \**********************************************/
/*! exports provided: HomebakComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomebakComponent", function() { return HomebakComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-cookie-service */ "./node_modules/ngx-cookie-service/index.js");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../info/info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/models/model.url */ "./src/app/shared/models/model.url.ts");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! lodash */ "./node_modules/lodash/lodash.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_8___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_8__);









var HomebakComponent = /** @class */ (function () {
    function HomebakComponent(http, shpId, baseUrl, infoService, cookieService) {
        var _this = this;
        this.infoService = infoService;
        this.cookieService = cookieService;
        this.title = 'welcome to our  ClientApp';
        this.subtitle = "這是一個副標題。subtitle!";
        this.datatime = Date.now();
        this.RecommUserId = this.getRecommUserId();
        this.cache = [];
        this.pageByManual$ = new rxjs__WEBPACK_IMPORTED_MODULE_6__["BehaviorSubject"](1);
        this.itemHeight = 120;
        this.itemSize = 12;
        this.loading = false;
        this.pageByScroll$ = Object(rxjs__WEBPACK_IMPORTED_MODULE_6__["fromEvent"])(window, "scroll")
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["map"])(function () { return window.scrollY; }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["filter"])(function (current) { return current >= document.body.clientHeight - window.innerHeight; }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["debounceTime"])(200), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["distinct"])(), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["map"])(function (y) { return Math.ceil((y + window.innerHeight) / (_this.itemHeight * _this.itemSize)); }));
        this.pageByResize$ = Object(rxjs__WEBPACK_IMPORTED_MODULE_6__["fromEvent"])(window, "resize")
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["debounceTime"])(200), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["map"])(function (_) { return Math.ceil((window.innerHeight + document.body.scrollTop) /
            (_this.itemHeight * _this.itemSize)); }));
        this.pageToLoad$ = Object(rxjs__WEBPACK_IMPORTED_MODULE_6__["merge"])(this.pageByManual$, this.pageByScroll$, this.pageByResize$)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["distinct"])(), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["filter"])(function (page) { return _this.cache[page - 1] === undefined; }));
        this.infolists = this.pageToLoad$
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["tap"])(function (_) { return _this.loading = true; }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["flatMap"])(function (page) {
            return _this.http.get(_this.uri_getinfolist + ("/" + page + "/") + _this.itemSize)
                .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["map"])(function (resp) { return resp; }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["tap"])(function (resp) {
                console.log("page \n\r:::::" + page);
                _this.cache[page - 1] = resp;
                if ((_this.itemHeight * _this.itemSize * page) < window.innerHeight) {
                    _this.pageByManual$.next(page + 1);
                }
            }));
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_7__["map"])(function () { return lodash__WEBPACK_IMPORTED_MODULE_8__["flatMap"](_this.cache); }));
        this.http = http;
        this.ShpId = shpId;
        this.BaseUrl = baseUrl;
        this.uri_getinfolist = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_5__["apiUrls"].getInfolist + this.ShpId + "/" + this.RecommUserId;
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
    HomebakComponent.prototype.getRecommUserId = function () {
        var cookieRecommUserIdExists = this.cookieService.check('RecommUserId');
        if (cookieRecommUserIdExists) {
            return this.cookieService.get('RecommUserId');
        }
        else {
            return this.cookieService.get('DefaultShopUserId');
        }
    };
    ;
    HomebakComponent.prototype.ngAfterViewInit = function () {
        //// 获取所有cdkScrollable
        //if (this.loading)
        //  setInterval(() => {
        //    console.log("loading... \n\r");
        //  }, 1000);
    };
    HomebakComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-homebak',
            template: __webpack_require__(/*! ./homebak.component.html */ "./src/app/homebak/homebak.component.html"),
            styles: [__webpack_require__(/*! ./homebak.component.css */ "./src/app/homebak/homebak.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](2, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String, String, _info_info_service__WEBPACK_IMPORTED_MODULE_4__["InfoService"], ngx_cookie_service__WEBPACK_IMPORTED_MODULE_3__["CookieService"]])
    ], HomebakComponent);
    return HomebakComponent;
}());



/***/ }),

/***/ "./src/app/info/info.component.css":
/*!*****************************************!*\
  !*** ./src/app/info/info.component.css ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n#div_TitleThumbNail {\r\n  position: relative;\r\n}\r\n.infobody {\r\n  margin-left: 5px;\r\n  margin-top: 0;\r\n  margin-right: 5px;\r\n  padding-left:3px;\r\n  padding-right:3px;\r\n  background-color: #f7f2ea;\r\n}\r\n.originalandauthor {\r\n  font-size: 12px;\r\n  padding-left: 3px; \r\n  color: darkgray;\r\n  border-radius: 5px;\r\n  background-color: #e9e4dd;\r\n  padding-top: 1px;\r\n  display: block;\r\n}\r\nInfoDescription1 #div_TitleThumbNail img {\r\n  position: relative;\r\n}\r\n#InfoDescription1 p {\r\n  font-family: 'Microsoft YaHei ,Microsoft JhengHei UI';\r\n  font-size: 1.2em;\r\n  line-height: 1.6em;\r\n}\r\n#InfoDescription1 p > span {\r\n    font-family: 'Microsoft YaHei ,Microsoft JhengHei UI';\r\n    font-size: 1.2em;\r\n    line-height: 1.6em;\r\n  }\r\n#InfoDescription1 div span {\r\n  font-family: 'Microsoft YaHei ,Microsoft JhengHei UI';\r\n  font-size: 1.2em;\r\n  line-height: 1.6em;\r\n}\r\n#InfoDescription1 div > font span {\r\n  font-family: 'Microsoft YaHei ,Microsoft JhengHei UI';\r\n  font-size: 1.2em;\r\n  line-height: 1.6em;\r\n}\r\n#InfoDescription1 div > p span {\r\n  font-family: 'Microsoft YaHei ,Microsoft JhengHei UI';\r\n  font-size: 1.2em;\r\n  line-height: 1.6em;\r\n}\r\n#InfoDescription1 font {\r\n  font-family: 'Microsoft YaHei ,Microsoft JhengHei UI';\r\n  font-size: 1.2em;\r\n  line-height: 1.6em;\r\n}\r\n#InfoDescription1 img {\r\n  display: block;\r\n  margin: auto;\r\n  position: center;\r\n}\r\n.center_infodetail {\r\n  padding-top: 5px;\r\n  padding-bottom: 5px;\r\n  position: center;\r\n}\r\nimg {\r\n  position: center;\r\n  display: block;\r\n  margin: auto;\r\n}\r\np > img {\r\n  position: center;\r\n  display: block;\r\n  margin: auto;\r\n}\r\n \r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaW5mby9pbmZvLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IjtBQUNBO0VBQ0Usa0JBQWtCO0FBQ3BCO0FBQ0E7RUFDRSxnQkFBZ0I7RUFDaEIsYUFBYTtFQUNiLGlCQUFpQjtFQUNqQixnQkFBZ0I7RUFDaEIsaUJBQWlCO0VBQ2pCLHlCQUF5QjtBQUMzQjtBQUVBO0VBQ0UsZUFBZTtFQUNmLGlCQUFpQjtFQUNqQixlQUFlO0VBQ2Ysa0JBQWtCO0VBQ2xCLHlCQUF5QjtFQUN6QixnQkFBZ0I7RUFDaEIsY0FBYztBQUNoQjtBQUNBO0VBQ0Usa0JBQWtCO0FBQ3BCO0FBRUE7RUFDRSxxREFBcUQ7RUFDckQsZ0JBQWdCO0VBQ2hCLGtCQUFrQjtBQUNwQjtBQUVFO0lBQ0UscURBQXFEO0lBQ3JELGdCQUFnQjtJQUNoQixrQkFBa0I7RUFDcEI7QUFFRjtFQUNFLHFEQUFxRDtFQUNyRCxnQkFBZ0I7RUFDaEIsa0JBQWtCO0FBQ3BCO0FBRUE7RUFDRSxxREFBcUQ7RUFDckQsZ0JBQWdCO0VBQ2hCLGtCQUFrQjtBQUNwQjtBQUVBO0VBQ0UscURBQXFEO0VBQ3JELGdCQUFnQjtFQUNoQixrQkFBa0I7QUFDcEI7QUFFQTtFQUNFLHFEQUFxRDtFQUNyRCxnQkFBZ0I7RUFDaEIsa0JBQWtCO0FBQ3BCO0FBQ0E7RUFDRSxjQUFjO0VBQ2QsWUFBWTtFQUNaLGdCQUFnQjtBQUNsQjtBQUNBO0VBQ0UsZ0JBQWdCO0VBQ2hCLG1CQUFtQjtFQUNuQixnQkFBZ0I7QUFDbEI7QUFDQTtFQUNFLGdCQUFnQjtFQUNoQixjQUFjO0VBQ2QsWUFBWTtBQUNkO0FBQ0M7RUFDQyxnQkFBZ0I7RUFDaEIsY0FBYztFQUNkLFlBQVk7QUFDZCIsImZpbGUiOiJzcmMvYXBwL2luZm8vaW5mby5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiXHJcbiNkaXZfVGl0bGVUaHVtYk5haWwge1xyXG4gIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxufVxyXG4uaW5mb2JvZHkge1xyXG4gIG1hcmdpbi1sZWZ0OiA1cHg7XHJcbiAgbWFyZ2luLXRvcDogMDtcclxuICBtYXJnaW4tcmlnaHQ6IDVweDtcclxuICBwYWRkaW5nLWxlZnQ6M3B4O1xyXG4gIHBhZGRpbmctcmlnaHQ6M3B4O1xyXG4gIGJhY2tncm91bmQtY29sb3I6ICNmN2YyZWE7XHJcbn1cclxuXHJcbi5vcmlnaW5hbGFuZGF1dGhvciB7XHJcbiAgZm9udC1zaXplOiAxMnB4O1xyXG4gIHBhZGRpbmctbGVmdDogM3B4OyBcclxuICBjb2xvcjogZGFya2dyYXk7XHJcbiAgYm9yZGVyLXJhZGl1czogNXB4O1xyXG4gIGJhY2tncm91bmQtY29sb3I6ICNlOWU0ZGQ7XHJcbiAgcGFkZGluZy10b3A6IDFweDtcclxuICBkaXNwbGF5OiBibG9jaztcclxufVxyXG5JbmZvRGVzY3JpcHRpb24xICNkaXZfVGl0bGVUaHVtYk5haWwgaW1nIHtcclxuICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcbn1cclxuXHJcbiNJbmZvRGVzY3JpcHRpb24xIHAge1xyXG4gIGZvbnQtZmFtaWx5OiAnTWljcm9zb2Z0IFlhSGVpICxNaWNyb3NvZnQgSmhlbmdIZWkgVUknO1xyXG4gIGZvbnQtc2l6ZTogMS4yZW07XHJcbiAgbGluZS1oZWlnaHQ6IDEuNmVtO1xyXG59XHJcblxyXG4gICNJbmZvRGVzY3JpcHRpb24xIHAgPiBzcGFuIHtcclxuICAgIGZvbnQtZmFtaWx5OiAnTWljcm9zb2Z0IFlhSGVpICxNaWNyb3NvZnQgSmhlbmdIZWkgVUknO1xyXG4gICAgZm9udC1zaXplOiAxLjJlbTtcclxuICAgIGxpbmUtaGVpZ2h0OiAxLjZlbTtcclxuICB9XHJcblxyXG4jSW5mb0Rlc2NyaXB0aW9uMSBkaXYgc3BhbiB7XHJcbiAgZm9udC1mYW1pbHk6ICdNaWNyb3NvZnQgWWFIZWkgLE1pY3Jvc29mdCBKaGVuZ0hlaSBVSSc7XHJcbiAgZm9udC1zaXplOiAxLjJlbTtcclxuICBsaW5lLWhlaWdodDogMS42ZW07XHJcbn1cclxuXHJcbiNJbmZvRGVzY3JpcHRpb24xIGRpdiA+IGZvbnQgc3BhbiB7XHJcbiAgZm9udC1mYW1pbHk6ICdNaWNyb3NvZnQgWWFIZWkgLE1pY3Jvc29mdCBKaGVuZ0hlaSBVSSc7XHJcbiAgZm9udC1zaXplOiAxLjJlbTtcclxuICBsaW5lLWhlaWdodDogMS42ZW07XHJcbn1cclxuXHJcbiNJbmZvRGVzY3JpcHRpb24xIGRpdiA+IHAgc3BhbiB7XHJcbiAgZm9udC1mYW1pbHk6ICdNaWNyb3NvZnQgWWFIZWkgLE1pY3Jvc29mdCBKaGVuZ0hlaSBVSSc7XHJcbiAgZm9udC1zaXplOiAxLjJlbTtcclxuICBsaW5lLWhlaWdodDogMS42ZW07XHJcbn1cclxuXHJcbiNJbmZvRGVzY3JpcHRpb24xIGZvbnQge1xyXG4gIGZvbnQtZmFtaWx5OiAnTWljcm9zb2Z0IFlhSGVpICxNaWNyb3NvZnQgSmhlbmdIZWkgVUknO1xyXG4gIGZvbnQtc2l6ZTogMS4yZW07XHJcbiAgbGluZS1oZWlnaHQ6IDEuNmVtO1xyXG59XHJcbiNJbmZvRGVzY3JpcHRpb24xIGltZyB7XHJcbiAgZGlzcGxheTogYmxvY2s7XHJcbiAgbWFyZ2luOiBhdXRvO1xyXG4gIHBvc2l0aW9uOiBjZW50ZXI7XHJcbn1cclxuLmNlbnRlcl9pbmZvZGV0YWlsIHtcclxuICBwYWRkaW5nLXRvcDogNXB4O1xyXG4gIHBhZGRpbmctYm90dG9tOiA1cHg7XHJcbiAgcG9zaXRpb246IGNlbnRlcjtcclxufVxyXG5pbWcge1xyXG4gIHBvc2l0aW9uOiBjZW50ZXI7XHJcbiAgZGlzcGxheTogYmxvY2s7XHJcbiAgbWFyZ2luOiBhdXRvO1xyXG59XHJcbiBwID4gaW1nIHtcclxuICBwb3NpdGlvbjogY2VudGVyO1xyXG4gIGRpc3BsYXk6IGJsb2NrO1xyXG4gIG1hcmdpbjogYXV0bztcclxufVxyXG4gXHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/info/info.component.html":
/*!******************************************!*\
  !*** ./src/app/info/info.component.html ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = " <div *ngIf=\"!iiInfoIDs\" style=\"padding-top:100px;\">\r\n    <div class='loader'>\r\n      <div class='loader_overlay'></div>\r\n      <div class='loader_cogs'>\r\n        <div class='loader_cogs__top'>\r\n          <div class='top_part'></div>\r\n          <div class='top_part'></div>\r\n          <div class='top_part'></div>\r\n          <div class='top_hole'></div>\r\n        </div>\r\n        <div class='loader_cogs__left'>\r\n          <div class='left_part'></div>\r\n          <div class='left_part'></div>\r\n          <div class='left_part'></div>\r\n          <div class='left_hole'></div>\r\n        </div>\r\n        <div class='loader_cogs__bottom'>\r\n          <div class='bottom_part'></div>\r\n          <div class='bottom_part'></div>\r\n          <div class='bottom_part'></div>\r\n          <div class='bottom_hole'><!-- lol --></div>\r\n        </div>\r\n        <p>loading</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n\r\n \r\n<div *ngIf=\"iiInfoIDs\" class=\"infobody\">\r\n  <div> <span>{{titleThumbNail}}</span></div>\r\n  <div class=\"padding-right5 padding-top5\" [appHighlight]=\"color\">\r\n    <h4><strong>{{iiInfoIDs.title}}</strong></h4> \r\n  </div> \r\n  <div id=\"InfoDescription1\" class=\"container\">\r\n    <div class=\"row originalandauthor\">\r\n      <ul class=\"list-unstyled list-inline\">\r\n        <li>\r\n          <span class=\"text h5\" *ngIf=\"this.isOriginal\">原创：</span><span class=\"text-gray h6\">{{operatedDate | date:'yyyy-MM-dd'}}</span>\r\n        </li>\r\n        <li>\r\n          <span class=\"h6\" style=\"color:#607fa6\" [innerHTML]=\"author\"></span>\r\n        </li>\r\n      </ul>\r\n    </div>\r\n    <div *ngIf=\"this.showTitleThumbNail\" id=\"div_TitleThumbNail\" class=\"row center_infodetail\">\r\n      <img src=\"{{titleThumbNail}}\" class=\"img-responsive\" />\r\n    </div> \r\n    <div class=\"row\">\r\n      <p [innerHTML]=\"this.infoDescription\" class=\"text\">\r\n\r\n      </p>\r\n    </div>\r\n  </div>\r\n</div>\r\n  \r\n  <div class=\"container\" style=\"padding-left:5px;padding-right:5px;\">\r\n    <!--view portrait  infodetails.shopStaffId--> \r\n    <div class=\"panel panel-default\" *ngIf=\"shopstaff\">\r\n      <div class=\"panel-heading\">\r\n        <div class=\"panel-title no-margin no-padding\">\r\n          <i class=\"fa fa-user text-gray\"></i><span style=\"padding-left:5px;\">{{shopstaff.staffName}}</span>\r\n          <span class=\"h5\" style=\"padding-left:5px;\">{{shopstaff.contactTitle}}</span>\r\n        </div>\r\n      </div>\r\n      <div class=\"panel-body\">\r\n        <p align=\"center\"><img src=\"{{shopstaff.iconPortrait}}\" alt=\"\" width=\"120\" class=\"img-circle img-responsive\"></p>\r\n        <p align=\"center\" id=\"_ViewconPortrait_Introduction\" [innerHTML]=\"shopstaff.introduction\" class=\"no-margin\"></p>\r\n        <p align=\"center\" class=\"no-margin no-padding\">\r\n          <a href=\"{{shopstaff.otherQrcode}}\" class=\"center-block\">\r\n            <span class=\"h6\">{{shopstaff.otherChannelName}}</span>\r\n            <img src=\"{{shopstaff.otherQrcode}}\" class=\"img-responsive\" style=\"max-width:90px;\" />\r\n          </a>\r\n        </p>\r\n      </div>\r\n    </div>\r\n\r\n\r\n    <!--relate info-->\r\n    <div class=\"panel panel-default\" *ngIf=\"infoDetailRalateList\">\r\n      <div class=\"panel-heading\"  *ngIf=\"infoDetailRalateList\">\r\n        <span class=\"panel-title h4\">更多...</span>\r\n      </div>\r\n      <div class=\"panel-body\">\r\n        <ul class=\"list-unstyled no-margin\" style=\"padding-bottom:0;margin-bottom:0\" ng-init=\"{}\" *ngFor=\"let infodetail of infoDetailRalateList\">\r\n          <li style=\"line-height:25px;\">\r\n            <a [routerLink]='[\"/info/\"+ infodetail.userTraceId]' (click)=\"gotoTop()\">\r\n              <span><i class=\"fa fa-angle-double-right\"></i>{{infodetail.title}}</span>\r\n            </a>\r\n          </li>\r\n        </ul>\r\n\r\n        <ul class=\"list-unstyled no-margin\" *ngIf=\"userId=='620000'\" style=\"padding-top:0;margin-top:0;\">\r\n          <!--userid=620000-->\r\n          <li>\r\n            <i class=\"fa fa-angle-double-right\"></i> <a href=\"https://mp.weixin.qq.com/s/zbuPWhGFWqTj4FJ-w2OtdA\" class=\"h5 text-primary\">赌球热情与人间杯具，到底我们缺了什么？</a>\r\n          </li>\r\n          <li>\r\n            <i class=\"fa fa-angle-double-right\"></i> <a href=\"https://mp.weixin.qq.com/s/LtpkE5yWvIfLDRKOd8r8sA\" class=\"h5 text-primary\">香港社区与社交网络时代杂谈</a>\r\n          </li>\r\n          <li>\r\n            <i class=\"fa fa-angle-double-right\"></i> <a href=\"https://mp.weixin.qq.com/s/sdmXmFy1J-rYIj4gMAMtOA\" class=\"h5 text-primary\">父爱如山，女儿果然是爸爸上辈子的小情人</a>\r\n          </li>\r\n        </ul>\r\n      </div>\r\n    </div>\r\n\r\n  </div>\r\n"

/***/ }),

/***/ "./src/app/info/info.component.ts":
/*!****************************************!*\
  !*** ./src/app/info/info.component.ts ***!
  \****************************************/
/*! exports provided: InfoComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "InfoComponent", function() { return InfoComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _info_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./info.service */ "./src/app/info/info.service.ts");
/* harmony import */ var _ipcounter_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../ipcounter.service */ "./src/app/ipcounter.service.ts");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/models/model.url */ "./src/app/shared/models/model.url.ts");







var InfoComponent = /** @class */ (function () {
    function InfoComponent(http, baseUrl, routerInfo, router, infoService, ipCounterService) {
        var _this = this;
        this.routerInfo = routerInfo;
        this.router = router;
        this.infoService = infoService;
        this.ipCounterService = ipCounterService;
        this.routerInfo.params.subscribe(function (data) { _this.id = data.id; });
        this.getiInfoIDsExtend(this.id);
    }
    ;
    InfoComponent.prototype.getiInfoIDsExtend = function (Id) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var promise;
            var _this = this;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        promise = new Promise(function (resolve, reject) {
                            _this.infoService.getiInfoIDsExtend(Id)
                                .toPromise()
                                .then(function (dataiInfoIDs) {
                                _this.iiInfoIDs = dataiInfoIDs;
                                _this.title = _this.infoService.getObjectValue(dataiInfoIDs, "title");
                                //document.title = this.title;
                                _this.ShopId = _this.infoService.getObjectValue(dataiInfoIDs, "shopId");
                                _this.ShopStaffId = _this.infoService.getObjectValue(dataiInfoIDs, "shopStaffId");
                                _this.userId = _this.infoService.getObjectValue(dataiInfoIDs, "userId");
                                _this.SourceStatisticsId = _this.infoService.getObjectValue(dataiInfoIDs, "sourceStatisticsId");
                                _this.IpStatitics_StartDate_Token = _this.infoService.getObjectValue(dataiInfoIDs, "ipStatitics_StartDate_Token");
                                _this.showTitleThumbNail = _this.infoService.getObjectValue(dataiInfoIDs, "showTitleThumbNail");
                                _this.isOriginal = _this.infoService.getObjectValue(dataiInfoIDs, "isOriginal");
                                _this.operatedDate = _this.infoService.getObjectValue(dataiInfoIDs, "operatedDate");
                                _this.titleThumbNail = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_6__["apiHostName"].onlineImgHost + _this.infoService.getObjectValue(dataiInfoIDs, "titleThumbNail");
                                _this.author = _this.infoService.getObjectValue(dataiInfoIDs, "author");
                                _this.infoDescription = _this.infoService.getObjectValue(dataiInfoIDs, "infoDescription");
                                console.log("getStaffDetails");
                                _this.getStaffDetails(_this.ShopStaffId);
                                console.log("infodetaildalatedist");
                                _this.getInfodetaildalatedist(_this.id);
                                //console.log("getShopDetails");
                                //this.getShopDetails(this.ShopId);
                                //dataiInfoIDs
                                console.log("dataiInfoIDs");
                                console.log({ "dataiInfoIDs": dataiInfoIDs });
                                console.log({ "dataiInfoIDs": dataiInfoIDs });
                                //ip counter
                                _this.ipCounterService.IPstatitics(_this.SourceStatisticsId, _this.IpStatitics_StartDate_Token);
                                console.log("IPstatitics:::" + _this.SourceStatisticsId);
                                _this.ipCounterService.PageLoadingTimesCounter(_this.SourceStatisticsId, _this.IpStatitics_StartDate_Token);
                                console.log("PageLoadingTimesCounter:::" + _this.SourceStatisticsId);
                                resolve(dataiInfoIDs);
                            }, function (err) {
                                console.error(err);
                                reject(err);
                            });
                        });
                        return [4 /*yield*/, promise];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    InfoComponent.prototype.getStaffDetails = function (ShopStaffId) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var promise;
            var _this = this;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        promise = new Promise(function (resolve, reject) {
                            _this.infoService.getShopStaffDetails(ShopStaffId)
                                .toPromise()
                                .then(function (res) {
                                _this.shopstaff = res;
                                resolve(res); //加入參數才能用這個 日期  
                            }, function (err) {
                                console.error("getStaffDetails>error:::\n\r" + err);
                                reject(err);
                            });
                        });
                        return [4 /*yield*/, promise];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    InfoComponent.prototype.getInfodetaildalatedist = function (Id) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var promise;
            var _this = this;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        promise = new Promise(function (resolve, reject) {
                            _this.infoService.infoDetailRalateList(Id)
                                .toPromise()
                                .then(function (res) {
                                _this.infoDetailRalateList = res;
                                resolve(res); //需要傳入data 
                            }, function (err) {
                                console.error("error:::\n\r" + err);
                                reject(err);
                            });
                        });
                        return [4 /*yield*/, promise];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    //圖片loading
    InfoComponent.prototype.loadImageAsync = function (url) {
        return new Promise(function (resolve, reject) {
            var image = new Image();
            image.onload = function () {
                resolve(image);
            };
            image.onerror = function () {
                reject(new Error('Could not load image at ' + url));
            };
            image.src = url;
        });
    };
    ;
    InfoComponent.prototype.gotoTop = function () {
        document.querySelector("body").scrollTop = 0;
    };
    InfoComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.routerInfo.params.subscribe(function (data) {
            _this.id = data.id;
            _this.getiInfoIDsExtend(_this.id);
            console.log(data);
        });
    };
    ;
    InfoComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-info',
            template: __webpack_require__(/*! ./info.component.html */ "./src/app/info/info.component.html"),
            styles: [__webpack_require__(/*! ./info.component.css */ "./src/app/info/info.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String, _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            _info_service__WEBPACK_IMPORTED_MODULE_4__["InfoService"], _ipcounter_service__WEBPACK_IMPORTED_MODULE_5__["IpCounterService"]])
    ], InfoComponent);
    return InfoComponent;
}());



/***/ }),

/***/ "./src/app/info/info.service.ts":
/*!**************************************!*\
  !*** ./src/app/info/info.service.ts ***!
  \**************************************/
/*! exports provided: InfoService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "InfoService", function() { return InfoService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../shared/models/model.url */ "./src/app/shared/models/model.url.ts");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
// /app/ts.interface.lib/iMgInfoModelView.ts
//<reference path="/app/ts.interface.lib/iMgInfoModelView.ts" />





var InfoService = /** @class */ (function () {
    function InfoService(http, baseUrl) {
        this.http = http;
        this.s60x60 = "s60x60";
        this.s100X100 = "s100X100";
        this.s160X160 = "s160X160";
        this.s250X250 = "s250X250";
        this.s310X310 = "s310X310";
        this.s350X350 = "s350X350";
        this.s600X600 = "s600X600";
        this.BaseUrl = baseUrl;
        console.log("this.BaseUrl  :" + this.BaseUrl);
    }
    InfoService.prototype.getObjectValue = function (Object, PropertyValue) {
        if (Reflect.has(Object, PropertyValue)) {
            //console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
            return Reflect.get(Object, PropertyValue);
        }
        else {
            console.log("getObjectValue : no no no {0}:::::", PropertyValue);
            return null;
        }
    };
    //把本地圖片格式轉換為cloud對應格式
    InfoService.prototype.getImgOnlineApiUrl = function (Object, PropertyValue) {
        if (Reflect.has(Object, PropertyValue)) {
            debugger;
            var imgOnlineApiUrl = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiHostName"].onlineImgHost + Reflect.get(Object, PropertyValue);
            alert(imgOnlineApiUrl);
            console.log("getObjeimgOnlineApiUrl  :" + imgOnlineApiUrl);
            return imgOnlineApiUrl;
        }
        else {
            console.log("getObjectValue : no no no {0}:::::", PropertyValue);
            return null;
        }
    };
    InfoService.prototype.getiInfoIDsExtend = function (id) {
        var uri_getinfoids = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].getinfoids + id;
        return this.http.get(uri_getinfoids)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('fetched iInfoIDs'); }));
    };
    InfoService.prototype.getShopStaffDetails = function (ShopStaffId) {
        var StaffDetails_uri = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].shopstaffdetails + ShopStaffId;
        return this.http.get(StaffDetails_uri)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('fetched StaffDetails'); }));
    };
    InfoService.prototype.getShopDetails = function (ShopId) {
        var ShopDetails_uri = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].shopdetails + ShopId;
        //return this.http.get<iShop[]>(ShopDetails_uri);
        return this.http.get(ShopDetails_uri)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('fetched ShopDetails_uri'); }));
    };
    InfoService.prototype.infoDetailRalateList = function (id) {
        var InfoDetailRalateList_uri = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].InfoDetailRalateList + id;
        return this.http.get(InfoDetailRalateList_uri)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('fetched infoDetailRalateList'); }));
    };
    //home page list
    InfoService.prototype.GetInfolist = function (ShpId, RecommUserId, pageindex, pagesize) {
        var uri_getinfolist = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].getInfolist + ShpId + "/" + RecommUserId + "/" + pageindex + "/" + pagesize;
        console.log({ "uri_getinfolist": uri_getinfolist });
        return this.http.get(uri_getinfolist)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) {
            console.log("GetInfolist::" + Date());
        }));
    };
    //for test
    InfoService.prototype.GetInfolist2 = function (ShpId, RecommUserId, pageindex, pagesize) {
        var uri_getinfolist = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].getInfolist + ShpId + "/" + RecommUserId + "/" + pageindex + "/" + pagesize;
        return this.http.get(uri_getinfolist);
    };
    //remain to use
    //getInfoIDs(id: string) {
    //  const a = this.BaseUrl + apiUrls.getinfoids + id ;
    //  return this.http.get(a);
    //}
    InfoService.prototype.getInfoIDsResponse = function (id) {
        var b = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_3__["apiUrls"].getinfoids + id;
        return this.http.get(b, { observe: 'response' });
    };
    InfoService.prototype.getInfoPaneAdSetX = function (InfoPaneUrl) {
        return this.http.get(InfoPaneUrl)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('fetched getInfoPaneAdSet'); }));
    };
    InfoService.prototype.ReturnSizePicUrl = function (PicUrl, PictureSize) {
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
    };
    InfoService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String])
    ], InfoService);
    return InfoService;
}());



/***/ }),

/***/ "./src/app/infopane/infopane.component.css":
/*!*************************************************!*\
  !*** ./src/app/infopane/infopane.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "#info-pane-father {\r\n  /*position: relative;*/\r\n  margin-top: 0px;\r\n  margin-bottom: 15px;\r\n  border-radius: 0px;\r\n  max-height: 120px;\r\n}\r\n\r\n#info-pane-child {\r\n  padding-top: 15px;\r\n  background-color: #000;\r\n  opacity: 0.7;\r\n  filter: alpha(opacity=70);\r\n  color: #fff;\r\n  /*position: absolute;*/\r\n  bottom: 0px;\r\n  left: 0px;\r\n}\r\n\r\n#info-pane-child a {\r\n    color: #fff;\r\n  }\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaW5mb3BhbmUvaW5mb3BhbmUuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNFLHNCQUFzQjtFQUN0QixlQUFlO0VBQ2YsbUJBQW1CO0VBQ25CLGtCQUFrQjtFQUNsQixpQkFBaUI7QUFDbkI7O0FBRUE7RUFDRSxpQkFBaUI7RUFDakIsc0JBQXNCO0VBQ3RCLFlBQVk7RUFDWix5QkFBeUI7RUFDekIsV0FBVztFQUNYLHNCQUFzQjtFQUN0QixXQUFXO0VBQ1gsU0FBUztBQUNYOztBQUVFO0lBQ0UsV0FBVztFQUNiIiwiZmlsZSI6InNyYy9hcHAvaW5mb3BhbmUvaW5mb3BhbmUuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIiNpbmZvLXBhbmUtZmF0aGVyIHtcclxuICAvKnBvc2l0aW9uOiByZWxhdGl2ZTsqL1xyXG4gIG1hcmdpbi10b3A6IDBweDtcclxuICBtYXJnaW4tYm90dG9tOiAxNXB4O1xyXG4gIGJvcmRlci1yYWRpdXM6IDBweDtcclxuICBtYXgtaGVpZ2h0OiAxMjBweDtcclxufVxyXG5cclxuI2luZm8tcGFuZS1jaGlsZCB7XHJcbiAgcGFkZGluZy10b3A6IDE1cHg7XHJcbiAgYmFja2dyb3VuZC1jb2xvcjogIzAwMDtcclxuICBvcGFjaXR5OiAwLjc7XHJcbiAgZmlsdGVyOiBhbHBoYShvcGFjaXR5PTcwKTtcclxuICBjb2xvcjogI2ZmZjtcclxuICAvKnBvc2l0aW9uOiBhYnNvbHV0ZTsqL1xyXG4gIGJvdHRvbTogMHB4O1xyXG4gIGxlZnQ6IDBweDtcclxufVxyXG5cclxuICAjaW5mby1wYW5lLWNoaWxkIGEge1xyXG4gICAgY29sb3I6ICNmZmY7XHJcbiAgfVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/infopane/infopane.component.html":
/*!**************************************************!*\
  !*** ./src/app/infopane/infopane.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div id=\"info-pane-father\">\r\n  <a [routerLink]='[\"/info/\"+ data.userTraceId]' class=\"no-margin no-padding\">\r\n    <img [defaultImage]=\"this.defaultImage\" [lazyLoad]=\"data.titleThumbNail\" class=\"img-responsive\">\r\n  </a>\r\n  <div id=\"info-pane-child\" class=\"container\">\r\n    <h3>\r\n      <a [routerLink]='[\"/info/\"+ data.userTraceId]'>{{data.title}}</a>\r\n    </h3>\r\n    <div class=\"h6\">{{data.subTitle}}</div>\r\n  </div>\r\n\r\n</div>\r\n\r\n \r\n\r\n"

/***/ }),

/***/ "./src/app/infopane/infopane.component.ts":
/*!************************************************!*\
  !*** ./src/app/infopane/infopane.component.ts ***!
  \************************************************/
/*! exports provided: InfopaneComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "InfopaneComponent", function() { return InfopaneComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var InfopaneComponent = /** @class */ (function () {
    function InfopaneComponent() {
        this.defaultImage = "/assets/Rolling1s60pxblueblack.gif";
    }
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object)
    ], InfopaneComponent.prototype, "data", void 0);
    InfopaneComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-infopane',
            template: __webpack_require__(/*! ./infopane.component.html */ "./src/app/infopane/infopane.component.html"),
            styles: [__webpack_require__(/*! ./infopane.component.css */ "./src/app/infopane/infopane.component.css")]
        })
    ], InfopaneComponent);
    return InfopaneComponent;
}());



/***/ }),

/***/ "./src/app/infovideopane/infovideopane.component.css":
/*!***********************************************************!*\
  !*** ./src/app/infovideopane/infovideopane.component.css ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2luZm92aWRlb3BhbmUvaW5mb3ZpZGVvcGFuZS5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/infovideopane/infovideopane.component.html":
/*!************************************************************!*\
  !*** ./src/app/infovideopane/infovideopane.component.html ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"job-ad\">\r\n  <h4>{{data.title}} header001</h4>\r\n  Welcome 001\r\n  {{data.subTitle}}\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/infovideopane/infovideopane.component.ts":
/*!**********************************************************!*\
  !*** ./src/app/infovideopane/infovideopane.component.ts ***!
  \**********************************************************/
/*! exports provided: InfovideopaneComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "InfovideopaneComponent", function() { return InfovideopaneComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var InfovideopaneComponent = /** @class */ (function () {
    function InfovideopaneComponent() {
    }
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object)
    ], InfovideopaneComponent.prototype, "data", void 0);
    InfovideopaneComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-infovideopane',
            template: __webpack_require__(/*! ./infovideopane.component.html */ "./src/app/infovideopane/infovideopane.component.html"),
            styles: [__webpack_require__(/*! ./infovideopane.component.css */ "./src/app/infovideopane/infovideopane.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], InfovideopaneComponent);
    return InfovideopaneComponent;
}());



/***/ }),

/***/ "./src/app/ipcounter.service.ts":
/*!**************************************!*\
  !*** ./src/app/ipcounter.service.ts ***!
  \**************************************/
/*! exports provided: IpCounterService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IpCounterService", function() { return IpCounterService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _shared_models_model_url__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./shared/models/model.url */ "./src/app/shared/models/model.url.ts");
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ngx-cookie-service */ "./node_modules/ngx-cookie-service/index.js");






var IpCounterService = /** @class */ (function () {
    function IpCounterService(http, baseUrl, cookieService) {
        this.http = http;
        this.cookieService = cookieService;
        this.BaseUrl = baseUrl;
    }
    IpCounterService.prototype.getObjectValue = function (Object, PropertyValue) {
        if (Reflect.has(Object, PropertyValue)) {
            console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
            return Reflect.get(Object, PropertyValue);
        }
        else {
            console.log("no no no {0}:::::", PropertyValue);
            return null;
        }
    };
    IpCounterService.prototype.ngOnInit = function () {
        //加载页面耗时计算  loadTime
        var loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart;
        //浏览次数统计
        setTimeout("console.log(loadTime);", 3000);
        //initialize the IpIntervalId:
        clearInterval(this.IpIntervalId);
    };
    ;
    IpCounterService.prototype.getIpIntervalId = function (IpIntervalId) {
        var cookieIpIntervalIdExists = this.cookieService.check('IpIntervalId');
        if (cookieIpIntervalIdExists) {
            var ck = Number(this.cookieService.get('IpIntervalId'));
            if (IpIntervalId != null || ck != Number(IpIntervalId)) {
                console.log("getIpIntervalId:: IpIntervalId !=null::" + ck);
                this.cookieService.set('IpIntervalId', IpIntervalId);
            }
            return ck;
        }
        else {
            if (IpIntervalId != "undefined") {
                this.cookieService.set('IpIntervalId', IpIntervalId);
                return Number(IpIntervalId);
            }
            else {
                console.log("error :: IpIntervalId = undefined;return null (ipcounter.service)");
                return null;
            }
        }
    };
    ;
    IpCounterService.prototype.getPage = function () {
        var hidden, state, visibilityChange;
        if (typeof document["hidden"] !== "undefined") {
            hidden = "hidden";
            visibilityChange = "visibilitychange";
            state = "visibilityState";
        }
        else if (typeof document["mozHidden"] !== "undefined") {
            hidden = "mozHidden";
            visibilityChange = "mozvisibilitychange";
            state = "mozVisibilityState";
        }
        else if (typeof document["msHidden"] !== "undefined") {
            hidden = "msHidden";
            visibilityChange = "msvisibilitychange";
            state = "msVisibilityState";
        }
        else if (typeof document["webkitHidden"] !== "undefined") {
            hidden = "webkitHidden";
            visibilityChange = "webkitvisibilitychange";
            state = "webkitVisibilityState";
        }
        return { 'hidden': hidden, 'visibilityChange': visibilityChange, 'state': state };
    };
    //IP SourceStatistics 
    IpCounterService.prototype.SourceStatistics = function (SourceStatisticsID, IntervalMinutes, IpStatitics_StartDate_Token) {
        var SourceStatistics_Url = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_4__["apiUrls"].ipstatitic; //"IPstatitics/{IntervalMinutes}/{SourceStatisticsID}"
        SourceStatistics_Url = SourceStatistics_Url + IntervalMinutes + "/" + IpStatitics_StartDate_Token + "/" + SourceStatisticsID;
        console.log(SourceStatistics_Url);
        ///IP Statitics
        var Page = this.getPage();
        if (document[Page['state']] == 'hidden') {
            console.log("h5切换到后台");
        }
        else {
            this.http.get(SourceStatistics_Url).subscribe(function (dataIpCouter) {
                console.log(dataIpCouter);
                console.log("h5获得焦点\n\r" + SourceStatistics_Url);
            });
        }
        ;
    };
    IpCounterService.prototype.IPstatitics = function (SourceStatisticsID, IpStatitics_StartDate_Token) {
        var _this = this;
        this.IpIntervalId = setInterval(function () {
            _this.SourceStatistics(SourceStatisticsID, 0.5, IpStatitics_StartDate_Token); //if IntervalMinutes is equal to 1 minutes ,then variant of intervals set to 60000. 
        }, 30000);
        console.log("start::IpIntervalId::" + this.IpIntervalId); //window.clearInterval(t1); 
    };
    IpCounterService.prototype.PageLoadingTimesCounter = function (SourceStatisticsID, IpStatitics_StartDate_Token) {
        var _this = this;
        var loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart;
        var Osversion = this.getOSAndBrowser();
        var SourceUrl = encodeURIComponent(document.referrer); //encodeURIComponent(document.referrer).replace("/", "\/");
        if (SourceUrl.length < 1) {
            SourceUrl = "-";
        }
        console.log("SourceUrl ::\n\r" + SourceUrl);
        var PageLoading_Url = _shared_models_model_url__WEBPACK_IMPORTED_MODULE_4__["apiUrls"].pageLoadingTimesCounter;
        PageLoading_Url = PageLoading_Url + SourceStatisticsID + "/" + loadTime + "/" + Osversion + "/" + SourceUrl + "/" + IpStatitics_StartDate_Token;
        //loadTime
        console.log("loadTime::" + loadTime);
        setTimeout(function () {
            console.log('PageLoadingTimesCounter::\n\r' + PageLoading_Url);
            _this.http.get(PageLoading_Url)
                .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["tap"])(function (_) { return console.log('PageLoadingTimesCounter::\n\r' + PageLoading_Url); }));
            //this.http.get(PageLoading_Url).subscribe(dataPageLoading => {
            //  console.log(dataPageLoading);
            //  console.log("loadTime | Osversion | Token...\n\r" + PageLoading_Url);
            //}); //has essor  not be clone
        }, 10000);
    };
    //JS Get current operating system and browser name
    IpCounterService.prototype.getOSAndBrowser = function () {
        var os = navigator.platform;
        var userAgent = navigator.userAgent;
        var info_OS_Browser = "";
        if (/(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)) {
            info_OS_Browser = "iPhone";
        }
        else if (/(Android)/i.test(navigator.userAgent)) {
            info_OS_Browser = "Android";
        }
        else {
            info_OS_Browser = "Windows";
        }
        console.log("getOSAndBrowser:" + info_OS_Browser);
        return info_OS_Browser;
    };
    IpCounterService.prototype.ngOnDestroy = function () {
        clearInterval(this.IpIntervalId);
    };
    IpCounterService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String, ngx_cookie_service__WEBPACK_IMPORTED_MODULE_5__["CookieService"]])
    ], IpCounterService);
    return IpCounterService;
}());



/***/ }),

/***/ "./src/app/nav-menu/nav-manu-toggle.directive.ts":
/*!*******************************************************!*\
  !*** ./src/app/nav-menu/nav-manu-toggle.directive.ts ***!
  \*******************************************************/
/*! exports provided: NavManuToggleDirective */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavManuToggleDirective", function() { return NavManuToggleDirective; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var NavManuToggleDirective = /** @class */ (function () {
    function NavManuToggleDirective() {
    }
    NavManuToggleDirective.prototype.onMouseLeave = function () {
        console.log("mouseleave");
    };
    NavManuToggleDirective.prototype.onMouseEnter = function () {
        console.log("mouseenter");
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('mouseleave'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], NavManuToggleDirective.prototype, "onMouseLeave", null);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('mouseenter'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], NavManuToggleDirective.prototype, "onMouseEnter", null);
    NavManuToggleDirective = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Directive"])({
            selector: '[appNavManuToggle]'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], NavManuToggleDirective);
    return NavManuToggleDirective;
}());



/***/ }),

/***/ "./src/app/nav-menu/nav-menu.component.css":
/*!*************************************************!*\
  !*** ./src/app/nav-menu/nav-menu.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "li .glyphicon {\r\n    margin-right: 10px;\r\n}\r\n\r\n/* Highlighting rules for nav menu items */\r\n\r\nli.link-active a,\r\nli.link-active a:hover,\r\nli.link-active a:focus {\r\n    background-color: #4189C7;\r\n    color: white;\r\n}\r\n\r\n/* Keep the nav menu independent of scrolling and on top of other items */\r\n\r\n.main-nav {\r\n    position: fixed;\r\n    top: 0;\r\n    left: 0;\r\n    right: 0;\r\n    z-index: 1;\r\n}\r\n\r\n@media (min-width: 768px) {\r\n    /* On small screens, convert the nav menu to a vertical sidebar */\r\n    .main-nav {\r\n        height: 100%;\r\n        width: calc(25% - 20px);\r\n    }\r\n    .navbar {\r\n        border-radius: 0px;\r\n        border-width: 0px;\r\n        height: 100%;\r\n    }\r\n    .navbar-header {\r\n        float: none;\r\n    }\r\n    .navbar-collapse {\r\n        border-top: 1px solid #444;\r\n        padding: 0px;\r\n    }\r\n    .navbar ul {\r\n        float: none;\r\n    }\r\n    .navbar li {\r\n        float: none;\r\n        font-size: 15px;\r\n        margin: 6px;\r\n    }\r\n    .navbar li a {\r\n        padding: 10px 16px;\r\n        border-radius: 4px;\r\n    }\r\n    .navbar a {\r\n        /* If a menu item's text is too long, truncate it */\r\n        width: 100%;\r\n        white-space: nowrap;\r\n        overflow: hidden;\r\n        text-overflow: ellipsis;\r\n    }\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbmF2LW1lbnUvbmF2LW1lbnUuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtJQUNJLGtCQUFrQjtBQUN0Qjs7QUFFQSwwQ0FBMEM7O0FBQzFDOzs7SUFHSSx5QkFBeUI7SUFDekIsWUFBWTtBQUNoQjs7QUFFQSx5RUFBeUU7O0FBQ3pFO0lBQ0ksZUFBZTtJQUNmLE1BQU07SUFDTixPQUFPO0lBQ1AsUUFBUTtJQUNSLFVBQVU7QUFDZDs7QUFFQTtJQUNJLGlFQUFpRTtJQUNqRTtRQUNJLFlBQVk7UUFDWix1QkFBdUI7SUFDM0I7SUFDQTtRQUNJLGtCQUFrQjtRQUNsQixpQkFBaUI7UUFDakIsWUFBWTtJQUNoQjtJQUNBO1FBQ0ksV0FBVztJQUNmO0lBQ0E7UUFDSSwwQkFBMEI7UUFDMUIsWUFBWTtJQUNoQjtJQUNBO1FBQ0ksV0FBVztJQUNmO0lBQ0E7UUFDSSxXQUFXO1FBQ1gsZUFBZTtRQUNmLFdBQVc7SUFDZjtJQUNBO1FBQ0ksa0JBQWtCO1FBQ2xCLGtCQUFrQjtJQUN0QjtJQUNBO1FBQ0ksbURBQW1EO1FBQ25ELFdBQVc7UUFDWCxtQkFBbUI7UUFDbkIsZ0JBQWdCO1FBQ2hCLHVCQUF1QjtJQUMzQjtBQUNKIiwiZmlsZSI6InNyYy9hcHAvbmF2LW1lbnUvbmF2LW1lbnUuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbImxpIC5nbHlwaGljb24ge1xyXG4gICAgbWFyZ2luLXJpZ2h0OiAxMHB4O1xyXG59XHJcblxyXG4vKiBIaWdobGlnaHRpbmcgcnVsZXMgZm9yIG5hdiBtZW51IGl0ZW1zICovXHJcbmxpLmxpbmstYWN0aXZlIGEsXHJcbmxpLmxpbmstYWN0aXZlIGE6aG92ZXIsXHJcbmxpLmxpbmstYWN0aXZlIGE6Zm9jdXMge1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogIzQxODlDNztcclxuICAgIGNvbG9yOiB3aGl0ZTtcclxufVxyXG5cclxuLyogS2VlcCB0aGUgbmF2IG1lbnUgaW5kZXBlbmRlbnQgb2Ygc2Nyb2xsaW5nIGFuZCBvbiB0b3Agb2Ygb3RoZXIgaXRlbXMgKi9cclxuLm1haW4tbmF2IHtcclxuICAgIHBvc2l0aW9uOiBmaXhlZDtcclxuICAgIHRvcDogMDtcclxuICAgIGxlZnQ6IDA7XHJcbiAgICByaWdodDogMDtcclxuICAgIHotaW5kZXg6IDE7XHJcbn1cclxuXHJcbkBtZWRpYSAobWluLXdpZHRoOiA3NjhweCkge1xyXG4gICAgLyogT24gc21hbGwgc2NyZWVucywgY29udmVydCB0aGUgbmF2IG1lbnUgdG8gYSB2ZXJ0aWNhbCBzaWRlYmFyICovXHJcbiAgICAubWFpbi1uYXYge1xyXG4gICAgICAgIGhlaWdodDogMTAwJTtcclxuICAgICAgICB3aWR0aDogY2FsYygyNSUgLSAyMHB4KTtcclxuICAgIH1cclxuICAgIC5uYXZiYXIge1xyXG4gICAgICAgIGJvcmRlci1yYWRpdXM6IDBweDtcclxuICAgICAgICBib3JkZXItd2lkdGg6IDBweDtcclxuICAgICAgICBoZWlnaHQ6IDEwMCU7XHJcbiAgICB9XHJcbiAgICAubmF2YmFyLWhlYWRlciB7XHJcbiAgICAgICAgZmxvYXQ6IG5vbmU7XHJcbiAgICB9XHJcbiAgICAubmF2YmFyLWNvbGxhcHNlIHtcclxuICAgICAgICBib3JkZXItdG9wOiAxcHggc29saWQgIzQ0NDtcclxuICAgICAgICBwYWRkaW5nOiAwcHg7XHJcbiAgICB9XHJcbiAgICAubmF2YmFyIHVsIHtcclxuICAgICAgICBmbG9hdDogbm9uZTtcclxuICAgIH1cclxuICAgIC5uYXZiYXIgbGkge1xyXG4gICAgICAgIGZsb2F0OiBub25lO1xyXG4gICAgICAgIGZvbnQtc2l6ZTogMTVweDtcclxuICAgICAgICBtYXJnaW46IDZweDtcclxuICAgIH1cclxuICAgIC5uYXZiYXIgbGkgYSB7XHJcbiAgICAgICAgcGFkZGluZzogMTBweCAxNnB4O1xyXG4gICAgICAgIGJvcmRlci1yYWRpdXM6IDRweDtcclxuICAgIH1cclxuICAgIC5uYXZiYXIgYSB7XHJcbiAgICAgICAgLyogSWYgYSBtZW51IGl0ZW0ncyB0ZXh0IGlzIHRvbyBsb25nLCB0cnVuY2F0ZSBpdCAqL1xyXG4gICAgICAgIHdpZHRoOiAxMDAlO1xyXG4gICAgICAgIHdoaXRlLXNwYWNlOiBub3dyYXA7XHJcbiAgICAgICAgb3ZlcmZsb3c6IGhpZGRlbjtcclxuICAgICAgICB0ZXh0LW92ZXJmbG93OiBlbGxpcHNpcztcclxuICAgIH1cclxufVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/nav-menu/nav-menu.component.html":
/*!**************************************************!*\
  !*** ./src/app/nav-menu/nav-menu.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class='main-nav collapse' appNavManuToggle [ngClass]='{ \"in\": isExpanded2 }' >\r\n  <div class='navbar navbar-inverse'>\r\n    <div class='navbar-header'>\r\n      <button type='button' class='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse' [attr.aria-expanded]='isExpanded' (click)='toggle()'>\r\n        <span class='sr-only'>Toggle navigation</span>\r\n        <span class='icon-bar'></span>\r\n        <span class='icon-bar'></span>\r\n        <span class='icon-bar'></span>\r\n      </button>\r\n      <a class='navbar-brand' [routerLink]='[\"/\"]'><img src=\"{{shopLogo}}\" class=\"img-responsive\" alt=\"{{shopName}}\" /></a>\r\n    </div>\r\n    <div class='clearfix'></div>\r\n    <div class='navbar-collapse collapse' [ngClass]='{ \"in\": isExpanded }'>\r\n      <ul class='nav navbar-nav'>\r\n        <li [routerLinkActive]='[\"link-active\"]' [routerLinkActiveOptions]='{ exact: true }'>\r\n          <a [routerLink]='[\"/\"]' (click)='collapse()'>\r\n            <span class='glyphicon glyphicon-home'></span> Home\r\n          </a>\r\n        </li>\r\n        <li>\r\n          <a (click)='goToWebHome()'>\r\n            <span class='glyphicon glyphicon-blackboard'></span>电脑版\r\n          </a>\r\n        </li>\r\n        <li [routerLinkActive]='[\"link-active\"]' [routerLinkActiveOptions]='{ exact: true }'>\r\n          <a [routerLink]='[\"/homebak\"]' (click)='collapse()'>\r\n            <span class='glyphicon glyphicon-home'></span> Home2\r\n          </a>\r\n        </li>\r\n\r\n        <li [routerLinkActive]='[\"link-active\"]' [routerLinkActiveOptions]='{ exact: true }'>\r\n          <a [routerLink]='[\"/test\"]' (click)='collapse()'>\r\n            <span class='glyphicon glyphicon-home'></span> test\r\n          </a>\r\n        </li>\r\n\r\n      </ul>\r\n    </div>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/nav-menu/nav-menu.component.ts":
/*!************************************************!*\
  !*** ./src/app/nav-menu/nav-menu.component.ts ***!
  \************************************************/
/*! exports provided: NavMenuComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavMenuComponent", function() { return NavMenuComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _info_info_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../info/info.service */ "./src/app/info/info.service.ts");




var NavMenuComponent = /** @class */ (function () {
    function NavMenuComponent(http, baseUrl, shpId, infoService) {
        this.infoService = infoService;
        this.isExpanded = false;
        this.isExpanded2 = true;
        this.ShpId = shpId;
    }
    NavMenuComponent.prototype.collapse = function () {
        this.isExpanded = false;
        console.log("collapse = false; ");
    };
    NavMenuComponent.prototype.goToWebHome = function () {
        window.location.assign("/home/index");
    };
    NavMenuComponent.prototype.toggle = function () {
        this.isExpanded = !this.isExpanded;
    };
    NavMenuComponent.prototype.onMouseLeave = function () {
        console.log("mouseleave");
        this.isExpanded = false;
    };
    NavMenuComponent.prototype.onWindowScroll = function () {
        this.isExpanded = false;
        var number = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0; //  let scrollTop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop；
        if (number > 50) {
            this.isExpanded2 = false;
        }
        else if (number < 50) {
            this.isExpanded2 = true;
        }
        //console.log("manu nav" + number);
    };
    Object.defineProperty(NavMenuComponent.prototype, "myModelshopName", {
        set: function (value) {
            this.shopName = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NavMenuComponent.prototype, "myModelshopLogo", {
        set: function (value) {
            this.shopLogo = value;
        },
        enumerable: true,
        configurable: true
    });
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('mouseleave'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], NavMenuComponent.prototype, "onMouseLeave", null);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["HostListener"])('window:scroll', []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Function),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", []),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:returntype", void 0)
    ], NavMenuComponent.prototype, "onWindowScroll", null);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [Object])
    ], NavMenuComponent.prototype, "myModelshopName", null);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [Object])
    ], NavMenuComponent.prototype, "myModelshopLogo", null);
    NavMenuComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-nav-menu',
            template: __webpack_require__(/*! ./nav-menu.component.html */ "./src/app/nav-menu/nav-menu.component.html"),
            styles: [__webpack_require__(/*! ./nav-menu.component.css */ "./src/app/nav-menu/nav-menu.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](2, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String, String, _info_info_service__WEBPACK_IMPORTED_MODULE_3__["InfoService"]])
    ], NavMenuComponent);
    return NavMenuComponent;
}());



/***/ }),

/***/ "./src/app/public.service.ts":
/*!***********************************!*\
  !*** ./src/app/public.service.ts ***!
  \***********************************/
/*! exports provided: PublicService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PublicService", function() { return PublicService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var ngx_cookie_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-cookie-service */ "./node_modules/ngx-cookie-service/index.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");







var PublicService = /** @class */ (function () {
    function PublicService(http, baseUrl, shpId, route, titleService, cookieService, xlocation) {
        this.http = http;
        this.route = route;
        this.titleService = titleService;
        this.cookieService = cookieService;
        this.defaultLazyImage = "/assets/Rolling1s60pxblueblack.gif";
        this.RecommUserId = this.getRecommUserId();
        this.BaseUrl = baseUrl;
        this.ShpId = shpId;
        //_Location ============= 
        this.location = xlocation;
        var _platformStrategy = this.getObjectValue(this.location, "_platformStrategy");
        console.log(_platformStrategy);
        var _platformLocation = this.getObjectValue(_platformStrategy, "_platformLocation");
        console.log(_platformLocation);
        var _Location = this.getObjectValue(_platformLocation, "location");
        console.log("public service" + _Location);
        this.HostUrl = _Location;
        //=======================
    }
    PublicService.prototype.getObjectValue = function (Object, PropertyValue) {
        if (Reflect.has(Object, PropertyValue)) {
            //console.log("getObjectValue :" + Reflect.get(Object, PropertyValue));
            return Reflect.get(Object, PropertyValue);
        }
        else {
            console.log("getObjectValue : no no no {0}:::::", PropertyValue);
            return null;
        }
    };
    PublicService.prototype.getRecommUserId = function () {
        var cookieRecommUserIdExists = this.cookieService.check('RecommUserId');
        var cookieDefaultShopUserIdExists = this.cookieService.check('DefaultShopUserId');
        if (cookieRecommUserIdExists) {
            return this.cookieService.get('RecommUserId');
        }
        else if (cookieDefaultShopUserIdExists) {
            return this.cookieService.get('DefaultShopUserId');
        }
        else {
            return "620000";
        }
    };
    PublicService.prototype.setTitle = function (title) {
        // Get the config information from the app routing data
        this.config = this.route.snapshot.data;
        console.log("route.snapshop.data \n\r" + this.config);
        // Sets the page title
        this.titleService.setTitle(title);
    };
    PublicService.prototype.loadImageAsync = function (url) {
        return new Promise(function (resolve, reject) {
            var image = new Image();
            image.onload = function () {
                resolve(image);
            };
            image.onerror = function () {
                reject(new Error('Could not load image at ' + url));
            };
            image.src = url;
        });
    };
    PublicService.prototype.getScrollTop = function () {
        var scrollTop = 0, bodyScrollTop = 0, documentScrollTop = 0;
        if (document.body) {
            bodyScrollTop = document.body.scrollTop;
        }
        if (document.documentElement) {
            documentScrollTop = document.documentElement.scrollTop;
        }
        scrollTop = (bodyScrollTop - documentScrollTop > 0) ? bodyScrollTop : documentScrollTop;
        return scrollTop;
    };
    PublicService.prototype.getScrollHeight = function () {
        var scrollHeight = 0, bodyScrollHeight = 0, documentScrollHeight = 0;
        if (document.body) {
            bodyScrollHeight = document.body.scrollHeight;
        }
        if (document.documentElement) {
            documentScrollHeight = document.documentElement.scrollHeight;
        }
        scrollHeight = (bodyScrollHeight - documentScrollHeight > 0) ? bodyScrollHeight : documentScrollHeight;
        return scrollHeight;
    };
    PublicService.prototype.getWindowHeight = function () {
        var windowHeight = 0;
        if (document.compatMode == "CSS1Compat") {
            windowHeight = document.documentElement.clientHeight;
        }
        else {
            windowHeight = document.body.clientHeight;
        }
        return windowHeight;
    };
    PublicService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](2, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('ShpId')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClient"], String, String, _angular_router__WEBPACK_IMPORTED_MODULE_5__["ActivatedRoute"],
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_6__["Title"],
            ngx_cookie_service__WEBPACK_IMPORTED_MODULE_4__["CookieService"],
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["Location"]])
    ], PublicService);
    return PublicService;
}());



/***/ }),

/***/ "./src/app/shared/models/model.url.ts":
/*!********************************************!*\
  !*** ./src/app/shared/models/model.url.ts ***!
  \********************************************/
/*! exports provided: apiHostName, apiUrls */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "apiHostName", function() { return apiHostName; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "apiUrls", function() { return apiUrls; });
var apiHostName = {
    onlineHost: "http://www.tony123.top/ng/",
    offLineHost: "http://192.168.0.177:8082/",
    defaultHost: "http://localhost:8082/",
    onlineImgHost: "http://81.71.74.135:8081/"
};
var apiUrls = {
    weatherforecasts: apiHostName.defaultHost + 'SampleData/WeatherForecasts',
    ipstatitic: apiHostName.defaultHost + "IPcounter/IPstatitics/",
    getinfoids: apiHostName.defaultHost + "InfoData/getinfoids/",
    InfoDetailRalateList: apiHostName.defaultHost + "InfoData/InfoDetailRalateList/",
    shopstaffdetails: apiHostName.defaultHost + 'InfoData/ShopStaffDetails/',
    shopdetails: apiHostName.defaultHost + 'InfoData/ShopDetails/',
    pageLoadingTimesCounter: apiHostName.defaultHost + "IPcounter/PageLoadingTimesCounter/",
    getInfolist: apiHostName.defaultHost + "InfoData/GetInfolist/",
    getInfoPaneAdSet: apiHostName.defaultHost + "InfoData/getInfoPaneAdSet/"
};


/***/ }),

/***/ "./src/app/staff/staff.component.css":
/*!*******************************************!*\
  !*** ./src/app/staff/staff.component.css ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "body {\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvc3RhZmYvc3RhZmYuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtBQUNBIiwiZmlsZSI6InNyYy9hcHAvc3RhZmYvc3RhZmYuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbImJvZHkge1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/staff/staff.component.html":
/*!********************************************!*\
  !*** ./src/app/staff/staff.component.html ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<!--view portrait-->\r\n<div class=\"panel panel-default\" *ngIf=\"shopstaff\">\r\n  <div class=\"panel-heading\">\r\n    <div class=\"panel-title no-margin no-padding\">\r\n      <i class=\"fa fa-user text-gray\"></i><span style=\"padding-left:5px;\">{{shopstaff.staffName}}</span>\r\n      <span class=\"h5\">{{shopstaff.contactTitle}}</span>\r\n    </div>\r\n  </div>\r\n  <div class=\"panel-body\">\r\n    <p align=\"center\"><img src=\"{{shopstaff.iconPortrait}}\" alt=\"\" width=\"120\" ng-class=\"'img-circle img-responsive'\"></p>\r\n    <p align=\"center\" id=\"_ViewconPortrait_Introduction\" [innerHTML]=\"shopstaff.introduction\" class=\"no-margin\"></p>\r\n    <p align=\"center\" class=\"no-margin no-padding\">\r\n      <a href=\"{{shopstaff.otherQrcode}}\" class=\"center-block\" target=\"_blank\">\r\n        <span class=\"h6\">{{shopstaff.otherChannelName}}</span>\r\n        <img src=\"{{shopstaff.otherQrcode}}\" class=\"img-responsive\" style=\"max-width:90px;\" />\r\n      </a>\r\n    </p>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/staff/staff.component.ts":
/*!******************************************!*\
  !*** ./src/app/staff/staff.component.ts ***!
  \******************************************/
/*! exports provided: StaffComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StaffComponent", function() { return StaffComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
//<app-staff [ShopStaffId]="infodetails.shopStaffId" *ngIf="infodetails.shopStaffId"></app-staff>



var StaffComponent = /** @class */ (function () {
    function StaffComponent(http, baseUrl) {
        //// get shopstaff
        //console.log('this.ShopStaffId::::::' + this._ShopStaffId);
        console.log("Staff detail:::::::::::::::" + baseUrl + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId);
        //http.get<iShopStaff>(baseUrl + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId).subscribe(resultshopstaff => {
        //  console.log("形象 shopstaff :\n\r");
        //  console.log(resultshopstaff);
        //  this.shopstaff = resultshopstaff;
        //});
    }
    Object.defineProperty(StaffComponent.prototype, "ShopStaffId", {
        get: function () {
            return this._ShopStaffId;
        },
        set: function (ShopStaffId) {
            this._ShopStaffId = ShopStaffId;
            console.log('屬性::::::' + this._ShopStaffId);
            // dosomething
        },
        enumerable: true,
        configurable: true
    });
    ;
    ;
    StaffComponent.prototype.ngOnChanges = function (changes) {
        var _this = this;
        console.group('child ngOnChanges called.');
        console.log(changes);
        console.groupEnd();
        var changedProp = changes["ShopStaffId"];
        this._ShopStaffId = changedProp["currentValue"];
        console.log('ngOnChanges :this._ShopStaffId::::::' + this._ShopStaffId);
        //var baseUrl2 = "https://localhost:44363/";
        //console.log("Staff detail:::::::::::::::" + baseUrl2 + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId);
        this.http.get('/api/InfoData/ShopStaffDetails/' + this.ShopStaffId).subscribe(function (resultshopstaff) {
            console.log("形象 shopstaff :\n\r");
            console.log(resultshopstaff);
            _this.shopstaff = resultshopstaff;
        });
    };
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
    StaffComponent.prototype.ngOnInit = function () {
        // get shopstaff
        //console.log('this.ShopStaffId::::::' + this._ShopStaffId);
        //console.log("Staff detail:::::::::::::::" + baseUrl + 'api/InfoData/ShopStaffDetails/' + this._ShopStaffId);
        //http.get<iShopStaff[]>(baseUrl + 'api/InfoData/ShopStaffDetails/' + this.ShopStaffId).subscribe(resultshopstaff => {
        //  console.log("形象 shopstaff :\n\r");
        //  console.log(resultshopstaff);
        //  this.shopstaff = resultshopstaff;
        //});
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", String),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [String])
    ], StaffComponent.prototype, "ShopStaffId", null);
    StaffComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-staff',
            template: __webpack_require__(/*! ./staff.component.html */ "./src/app/staff/staff.component.html"),
            styles: [__webpack_require__(/*! ./staff.component.css */ "./src/app/staff/staff.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"])('BASE_URL')),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String])
    ], StaffComponent);
    return StaffComponent;
}());



/***/ }),

/***/ "./src/app/test/test.component.css":
/*!*****************************************!*\
  !*** ./src/app/test/test.component.css ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3Rlc3QvdGVzdC5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/test/test.component.html":
/*!******************************************!*\
  !*** ./src/app/test/test.component.html ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<abbr></abbr>\r\n<abbr></abbr>\r\n<div class=\"panel\">\r\n  <div class=\"panel-heading\">\r\n    <span class=\"box-title\"> \r\n      我是羅梓妍，一位小小小的程式員！！！\r\n    </span>\r\n  </div>\r\n  <div class=\"panel-body\">\r\n    <p class=\"h4\">\r\n      <span>我要計算一個球的體積：</span>\r\n      <br /> <br />\r\n      <span>知道半徑就可以知道球的體積</span>\r\n      <br /> <br />\r\n             <span class=\"h4 text-bold bg-red-active\">{{volume1}}</span> 立方厘米\r\n    </p>\r\n  </div>\r\n</div>\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/test/test.component.ts":
/*!****************************************!*\
  !*** ./src/app/test/test.component.ts ***!
  \****************************************/
/*! exports provided: TestComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TestComponent", function() { return TestComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var TestComponent = /** @class */ (function () {
    function TestComponent() {
        this.volume1 = 0;
        this.r = 10.2;
        this.volume1 = Math.PI * Math.pow(this.r, 2);
        this.volume1 = Math.ceil(this.volume1);
    }
    TestComponent.prototype.ngOnInit = function () {
    };
    TestComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-test',
            template: __webpack_require__(/*! ./test.component.html */ "./src/app/test/test.component.html"),
            styles: [__webpack_require__(/*! ./test.component.css */ "./src/app/test/test.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], TestComponent);
    return TestComponent;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! exports provided: getBaseUrl, getShpId */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getBaseUrl", function() { return getBaseUrl; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getShpId", function() { return getShpId; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
function getShpId() {
    var hostName = location.hostname.toLowerCase();
    //===================================================================
    if (hostName.includes('sh0001')) {
        console.log(hostName + " :1、shpId::getBaseUrl:::key:sh0001::" + "sh0001");
        return "sh0001";
    }
    if (hostName.includes('sunwaylink.com')) {
        console.log(hostName + " :2、shpId::getBaseUrl:::key:sunwaylink.com::" + "sh0001");
        return "sh0001";
    }
    //===================================================================
    if (hostName.includes('seo')) {
        console.log(hostName + " :4、shpId::getBaseUrl:::key:seo::" + "sh0006");
        return "sh0006";
    }
    if (hostName.includes('sh0006')) {
        console.log(hostName + " :6、shpId::getBaseUrl:::key:sh0006::" + "sh0006");
        return "sh0006";
    }
    if (hostName.includes('tony123.top')) {
        console.log(hostName + " :7、shpId::getBaseUrl:::key:tony123.top::" + "sh0001");
        return "sh0006";
    }
    //===================================================================
    if (hostName.includes('localhost')) {
        console.log(hostName + " :8、shpId::getBaseUrl:::key:sunwaylink.com::" + "sh0001");
        return "sh0006";
    }
    //default:
    console.log(hostName + " :9、default :: shpId::getBaseUrl::" + "sh0001");
    return "sh0006";
}
var providers = [
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
    { provide: 'ShpId', useFactory: getShpId, deps: [] }
];
if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])(providers).bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! D:\ClientIshop_Ishop_AD\IshopX_GitHub\ClientIshop\ClientIshop\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map
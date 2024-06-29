import { Component, Inject } from '@angular/core';
import { iShop, InfoService } from './info/info.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  DefaultShopUserId: string;
  title = 'ClientApp';
  ShpId: string;
  shopLogo: string;
  shopName: string;
  shopUserId: string;
  shop: iShop[];
  constructor(@Inject('BASE_URL') baseUrl: string, @Inject('ShpId') shpId: string, private infoService: InfoService, private cookieService: CookieService) { 
    this.ShpId = shpId;
    this.getShopDetails(this.ShpId);
  }
  async getShopDetails(ShopId: string) {
    const promise = new Promise((resolve, reject) => {
      this.infoService.getShopDetails(ShopId)
        .toPromise()
        .then(
          res => { // Success 
            this.shop = res;
            this.shopLogo = this.infoService.getObjectValue(res, "shopLogo");
            this.shopName = this.infoService.getObjectValue(res, "shopName");
            this.shopUserId = this.infoService.getObjectValue(res, "userId");
            this.defaultShopUserIdCookied(this.shopUserId);

            document.title = this.shopName;
            resolve();
          },
          err => {
            console.error("getShopDetails>error:::\n\r" + err);
            reject(err);
          }
        );
    });
    await promise;
  }
  defaultShopUserIdCookied(DefaultShopUserId:string):void { 
    const defaultShopUserIdCookieExists: boolean = this.cookieService.check('DefaultShopUserId');
    //if not then set a cookie
    if (!defaultShopUserIdCookieExists) {
      this.cookieService.set('DefaultShopUserId', DefaultShopUserId);
    }
    console.log("AppComponent >> DefaultShopUserId::" + this.cookieService.get("DefaultShopUserId"));
  }
}

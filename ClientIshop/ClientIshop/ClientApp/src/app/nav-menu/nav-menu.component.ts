import { Component, HostListener, EventEmitter,Inject,Input,Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { iShop, InfoService } from '../info/info.service';
import { apiUrls } from '../shared/models/model.url';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent{
  isExpanded = false;
  isExpanded2 = true;
  shopLogo: string;
  shopName: string;

  collapse() {
    this.isExpanded = false;
    console.log("collapse = false; ");
  }
  goToWebHome() {
    window.location.assign("/home/index")
  }
  toggle() {
    this.isExpanded = !this.isExpanded;  
  }

  @HostListener('mouseleave') onMouseLeave() {
    console.log("mouseleave");
    this.isExpanded = false;
  }
  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.isExpanded = false;
    const number = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;  //  let scrollTop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop；


    if (number > 50) {
      this.isExpanded2 = false; 
    } else if (number < 50) { 
      this.isExpanded2 = true;
    }
    //console.log("manu nav" + number);
  }

  ShpId: string;
  shop: iShop[];
   
  
  @Input()
  set myModelshopName(value) {
    this.shopName = value; 
  }
  @Input()
  set myModelshopLogo(value) {
    this.shopLogo = value;
  } 
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject('ShpId') shpId: string, private infoService: InfoService) {

    this.ShpId = shpId; 
   
  }

}

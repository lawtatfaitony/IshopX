import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import { HOST } from '@angular/core/src/render3/interfaces/view';
import { Location } from '@angular/common';
import { InfoService } from './app/info/info.service';

if (environment.production) {
  enableProdMode();
}

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getShpId() {

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
 
 
const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'ShpId', useFactory: getShpId, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core'; 

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module'; 
import { AppComponent } from './app.component';

import { LazyLoadImageModule, intersectionObserverPreset } from 'ng-lazyload-image';
import { CookieService } from 'ngx-cookie-service';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { InfoComponent } from './info/info.component';
import { FooterComponent } from './footer/footer.component';
import { StaffComponent } from './staff/staff.component';

import { InfoService } from './info/info.service';
import { IpCounterService } from './ipcounter.service';
import { HighlightDirective } from './highlight.directive';
import { NavManuToggleDirective } from './nav-menu/nav-manu-toggle.directive';
import { BootstraptestComponent } from './bootstraptest/bootstraptest.component';

import { ScrollingModule } from '@angular/cdk/scrolling';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { HomebakComponent } from './homebak/homebak.component';
import { TestComponent } from './test/test.component'; 
import { AdDirective } from './ad/ad.directive';
import { AdService } from './ad/ad.service';
import { AdBannerComponent } from './ad-banner/ad-banner.component';
import { InfopaneComponent } from './infopane/infopane.component';
import { InfovideopaneComponent } from './infovideopane/infovideopane.component'; 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    InfoComponent,
    FooterComponent,
    StaffComponent,
    HighlightDirective,
    NavManuToggleDirective,
    BootstraptestComponent,
    HomebakComponent,
    TestComponent, 
    AdBannerComponent,
    AdDirective,
    InfopaneComponent,
    InfovideopaneComponent
  ],
  imports: [
    HttpClientModule,
    LazyLoadImageModule.forRoot({
      preset: intersectionObserverPreset
    }),
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    ScrollingModule,
    DragDropModule
  ],
  entryComponents: [InfopaneComponent, InfovideopaneComponent],
  providers: [InfoService, IpCounterService, CookieService, AdService],
  bootstrap: [AppComponent]
})
export class AppModule { }

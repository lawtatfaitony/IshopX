import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { InfoComponent } from './info/info.component';
import { FooterComponent } from './footer/footer.component';
import { StaffComponent } from './staff/staff.component';
import { HomebakComponent } from './homebak/homebak.component';
import { BootstraptestComponent } from './bootstraptest/bootstraptest.component';
import { TestComponent } from './test/test.component';
const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home/index', component: HomeComponent, pathMatch: 'full' },  //2024-6-15
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'info/:id', component: InfoComponent },
  { path: 'Bootstraptest', component: BootstraptestComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'test', component: TestComponent },
  { path: 'homebak', component: HomebakComponent }];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

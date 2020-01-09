import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AppSettings } from './models/app.settings';
import { BeerDetailComponent } from './components/beer-detail/beer-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    BeerDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
    RouterModule.forRoot([
    ])
  ],
  providers: [AppSettings],
  bootstrap: [AppComponent]
})
export class AppModule { }

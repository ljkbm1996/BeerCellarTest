import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AppSettings } from './models/app.settings';
import { BeerDetailComponent } from './components/beer-detail/beer-detail.component';
import { AddBeerModalComponent } from './components/add-beer-modal/add-beer-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    BeerDetailComponent,
    AddBeerModalComponent
  ],
  entryComponents: [
    AddBeerModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
    NgbModalModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
    ])
  ],
  providers: [AppSettings],
  bootstrap: [AppComponent]
})
export class AppModule { }

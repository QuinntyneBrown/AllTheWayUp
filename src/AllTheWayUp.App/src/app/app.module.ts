import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { baseUrl } from '@core';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '@shared/shared.module';
import { SidenavModule } from '@shared/sidenav/sidenav.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SidenavModule,
    SharedModule
  ],
  providers: [{
    useValue:"https://localhost:5001/", provide: baseUrl
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }

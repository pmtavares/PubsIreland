import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PubsListCarouselComponent } from './components/pubs-list-carousel/pubs-list-carousel.component';
import { PubsService } from './services/pubs.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { PubListCardComponent } from './components/pub-list-card/pub-list-card.component';
import { PubListResumeComponent } from './components/pub-list-resume/pub-list-resume.component';

import {CarouselModule} from 'ngx-bootstrap/carousel';

import { PubFooterComponent } from './components/pub-footer/pub-footer.component';
import { PubListCityComponent } from './components/pub-list-city/pub-list-city.component';
import { PubListRecentComponent } from './components/pub-list-recent/pub-list-recent.component';
import { CitiesService } from './services/cities.service';
import { AngularMaterialModule } from './modules/angular-material/angular-material.module';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { PubDetailsComponent } from './components/pub-details/pub-details.component';
import { PubRegisterComponent } from './components/pub-register/pub-register.component';
import { NavbarComponent } from './components/navbar/navbar.component';






@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PubsListCarouselComponent,
    PubListCardComponent,
    PubListResumeComponent,
    PubFooterComponent,
    PubListCityComponent,
    PubListRecentComponent,
    AboutComponent,
    ContactComponent,
    PubDetailsComponent,
    PubRegisterComponent,
    NavbarComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CarouselModule,
    AngularMaterialModule,
    FormsModule

  ],
  exports: [

  ],
  providers: [PubsService, CitiesService],
  bootstrap: [AppComponent]
})
export class AppModule { }

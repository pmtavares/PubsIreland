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
import { PubsSearchCityComponent } from './components/pubs-search-city/pubs-search-city.component';
import { PubsComponent } from './components/pubs/pubs.component';
import { LoginComponent } from './components/login/login.component';
import { AuthService } from './services/auth.service';
import { ErrorInterceptorProvider } from './_config/errorInterceptor';
import {JwtModule} from '@auth0/angular-jwt';
import { PubEditComponent } from './components/pub-edit/pub-edit.component';
import { LoadingComponent } from './components/loading/loading.component';
import { PubMapComponent } from './components/pub-map/pub-map.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { TermsConditionsComponent } from './components/terms-conditions/terms-conditions.component'


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
    PubsSearchCityComponent,
    PubsComponent,
    LoginComponent,
    PubEditComponent,
    LoadingComponent,
    PubMapComponent,
    TermsConditionsComponent
  ],
  entryComponents: [TermsConditionsComponent],

  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CarouselModule,
    AngularMaterialModule,
    FormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter: () => { return localStorage.getItem('token') },
        whitelistedDomains: ["localhost:5000"],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    }),
    GoogleMapsModule

  ],
  exports: [

  ],
  providers: [
    ErrorInterceptorProvider, 
    PubsService, 
    CitiesService, 
    AuthService, ],
  bootstrap: [AppComponent]
})
export class AppModule { }

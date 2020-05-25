import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { PubDetailsComponent } from './components/pub-details/pub-details.component';
import { PubRegisterComponent } from './components/pub-register/pub-register.component';
import { PubsSearchCityComponent } from './components/pubs-search-city/pubs-search-city.component';
import { PubsComponent } from './components/pubs/pubs.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './_guard/auth.guard';
import { PubEditComponent } from './components/pub-edit/pub-edit.component';

const routes: Routes = [
  {path: "", component:HomeComponent},
  {path: "home", component:HomeComponent},
  {path: "about", component:AboutComponent},
  {path: "contact", component:ContactComponent},
  {path: "pubs/login", component: LoginComponent},
  {path: "pubs/search", component:PubsComponent},
  {path: "pubs/search/cities/:city", component:PubsSearchCityComponent},
  {path: "pubs/register", component: PubRegisterComponent},
  {path: "pubs/update", component: PubEditComponent, canActivate: [AuthGuard]},
  {path: "pubs/:code", component: PubDetailsComponent, canActivate: [AuthGuard]},
  
 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

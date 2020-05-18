import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { PubDetailsComponent } from './components/pub-details/pub-details.component';
import { PubRegisterComponent } from './components/pub-register/pub-register.component';

const routes: Routes = [
  {path: "", component:HomeComponent},
  {path: "home", component:HomeComponent},
  {path: "about", component:AboutComponent},
  {path: "contact", component:ContactComponent},
  {path: "pubs/register", component: PubRegisterComponent},

  {path: "pubs/:code", component: PubDetailsComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

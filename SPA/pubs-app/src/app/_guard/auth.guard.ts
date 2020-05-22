import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private auth: AuthService, private alertify: AlertifyService) {

  }
  canActivate(): boolean {
    if(this.auth.loggedIn())
    {
      return true;
    }
    this.alertify.error("Please login");
    this.router.navigate(['home']);
  }
  
 
  
}

import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  userName: string;
  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.setUsername();
  }

  loggedIn()
  {
    this.setUsername();
    return this.authService.loggedIn();
  }

  logout()
  {
    this.authService.logOut();
    this.alertify.warning("You have logged out");
    this.router.navigate(['home']);
  }

  setUsername()
  {    
    this.userName = this.authService.getLoggedUsername();    
  }

}

import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {}
  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login()
  {
    console.log(this.model);
    this.authService.login(this.model).subscribe(
      response => {
        this.alertify.success("Logged in success!");
        this.router.navigate(["home"]);

      },
      error => {
        this.alertify.error(error);
        console.log(error)
      }
    )
    
  }

}

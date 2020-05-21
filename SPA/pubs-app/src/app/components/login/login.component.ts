import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {}
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login()
  {
    console.log(this.model);
    this.authService.login(this.model).subscribe(
      response => {
        console.log("Success")
      },
      error => console.log(error)
    )
    
  }

}

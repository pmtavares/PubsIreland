import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit {

  baseUrl =  "http://localhost:5000/api/pubs/";
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  /*
  * In order to make something with the response, we need to make use of rxsj, therefore we have to 
    add "pipe" (transform the response in something else) operator at end of request as below
  */
  login(model: any)
  {
    return this.http.post(this.baseUrl + "login", model)
      .pipe(
        map((response: any) => {
          const user = response;
          if(user)
          {
            localStorage.setItem("token", user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            
            return user.token;
          }
        })
      )
  }

  loggedIn()
  {
    const token = localStorage.getItem('token');
    return this.jwtHelper.decodeToken(token);
  }

  logOut()
  {
    return localStorage.removeItem('token');
  }

  getLoggedUsername()
  {
    return this.jwtHelper.decodeToken(localStorage.getItem('token')).unique_name;
  }
}

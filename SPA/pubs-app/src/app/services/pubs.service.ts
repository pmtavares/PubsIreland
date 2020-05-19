import { Injectable, OnInit } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http'
import { IPub } from '../models/pub';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class PubsService implements OnInit{
  
  baseUrl = "http://localhost:5000/api/pubs";

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    console.log("On init")

  }

  getPubs():Observable<IPub[]>
  {
    return this.http.get<IPub[]>(this.baseUrl+ "/")
    
  }

  getPubsNumber(total: number): Observable<IPub[]>
  {
    return this.http.get<IPub[]>(this.baseUrl+"/top/"+total)
  }

  getOldestPubs(total: number): Observable<IPub[]>
  {
    return this.http.get<IPub[]>(this.baseUrl+"/oldest/"+total)
  }

  getRecenttPubs(total: number): Observable<IPub[]>
  {
    return this.http.get<IPub[]>(this.baseUrl+"/recent/"+total)
  }

  getPubDetail(id: string): Observable<IPub>
  {
    return this.http.get<IPub>(this.baseUrl+"/"+ id)
  }

  getPubsByCity(city: string): Observable<IPub[]>
  {
    return this.http.get<IPub[]>(this.baseUrl+"/search/cities/"+ city);
  }

  //Register pub
  registerPub(pub: IPub)
  {
    return this.http.post(this.baseUrl + "/register", pub)
  }

  private handleError(err: HttpErrorResponse)
  {
    let errorMessage;
    if(err.error instanceof ErrorEvent)
    {
      errorMessage = `An error ocurred: ${err.error.message}`
    }
    else{
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`
    }

    console.log(errorMessage);
    return throwError(errorMessage);
  }
}

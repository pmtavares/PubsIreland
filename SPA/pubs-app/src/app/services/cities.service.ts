import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICity } from '../models/city';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CitiesService implements OnInit {
  
  baseUrl = "http://localhost:5000/api/cities";

  constructor(private http: HttpClient) { }


  ngOnInit(): void {
    this.getCities();
  }

  getCities(): Observable<ICity[]>
  {
    return this.http.get<ICity[]>(this.baseUrl);
  }
}

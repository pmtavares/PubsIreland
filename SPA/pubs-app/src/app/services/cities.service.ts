import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICity } from '../models/city';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CitiesService implements OnInit {
  
  baseUrl = environment.apiCity

  constructor(private http: HttpClient) { }


  ngOnInit(): void {
    this.getCities();
  }

  getCities(): Observable<ICity[]>
  {
    return this.http.get<ICity[]>(this.baseUrl);
  }
}

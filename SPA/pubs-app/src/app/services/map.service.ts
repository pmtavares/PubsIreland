import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MapService implements OnInit{
  
  private baseMapUrl = environment.baseGoogleMapUrl;
  private mapKey = environment.mapKey;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  getLatLng(address: string)
  {
    return this.http.get(this.baseMapUrl + address + this.mapKey).
    pipe(
      map((response: any) => {
        return response.results[0].geometry.location;
        } 
      )
    );
    
  }
}

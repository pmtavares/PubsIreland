import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MapInfoWindow, MapMarker, GoogleMap} from '@angular/google-maps';
import { HttpClient } from '@angular/common/http';
import { MapService } from 'src/app/services/map.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-pub-map',
  templateUrl: './pub-map.component.html',
  styleUrls: ['./pub-map.component.css']
})
export class PubMapComponent implements OnInit {


  @ViewChild(GoogleMap) map: GoogleMap
  @ViewChild(MapInfoWindow) info: MapInfoWindow
  @Input() name: string;
  @Input() address: string = "Dublin, Ireland";

  zoom = 10
  center: google.maps.LatLngLiteral

  options: google.maps.MapOptions = {
    zoomControl: true,
    scrollwheel: false,
    disableDoubleClickZoom: false,
    maxZoom: 20,
    minZoom: 4,
  }
  lat: number = 53.35393066837019;
  long: number = -6.260025682128907;
  marker:any ={}
  infoContent = ''

  constructor(private mapService: MapService, private alertify: AlertifyService) { }

  ngOnInit() {

    //this.GetLatLong(this.address);    
    this.center = {
      lat: this.lat,
      lng: this.long
    };
    this.addMarker(this.lat, this.long);

    
  }
  

  GetLatLong(address: string)
  {
    this.mapService.getLatLng(address).subscribe(
      (data:any)=> {   
        this.lat = data.geometry.location.lat;
        this.long = data.geometry.location.lng;
        this.center = {
          lat: this.lat,
          lng: this.long
        };
        this.addMarker(this.lat, this.long);
        this.address = address
      },
      error => this.alertify.error(error)
    )

   
  }


  zoomIn() {
    if (this.zoom < this.options.maxZoom) this.zoom++
  }

  zoomOut() {
    if (this.zoom > this.options.minZoom) this.zoom--
  }

  click(event: google.maps.MouseEvent) {
    console.log(event)
   
  }

  mouseIn(event: google.maps.MouseEvent)
  {
    this.marker ={
      options: {
        animation: google.maps.Animation.BOUNCE
      },
    }
  }

  mouseOut(event: google.maps.MouseEvent)
  {
    this.marker ={
      options: {
        animation: null
      },
    }
  }

  logCenter() {
    console.log(JSON.stringify(this.map.getCenter()))
  }

  addMarker(latitude: number, longitude: number) {
    this.marker = {
      position: {
        lat: latitude,
        lng: longitude,
      },
      title: this.name,
      //info: 'Marker info ',
      options: {
        animation: google.maps.Animation.DROP,
      },
    }

  }

  openInfo(marker: MapMarker, content) {
    this.infoContent = content
    this.info.open(marker)
  }

}

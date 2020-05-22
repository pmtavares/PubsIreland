import { Component, OnInit } from '@angular/core';
import { CitiesService } from 'src/app/services/cities.service';
import { ICity } from 'src/app/models/city';

@Component({
  selector: 'app-pub-list-city',
  templateUrl: './pub-list-city.component.html',
  styleUrls: ['./pub-list-city.component.css']
})
export class PubListCityComponent implements OnInit {

  cities: ICity[] = [];
  categories: string[] = ["Disco", "Drinks", "Relax"]
  constructor(private services: CitiesService) { }

  ngOnInit() {
    this.getCities();
  }

  getCities()
  {
    return this.services.getCities().subscribe(
      response => {this.cities = response.sort((a,b)=> (a.name > b.name)?1:-1)}, //Sort fields
      error=> console.log(error)
    )
  }

}

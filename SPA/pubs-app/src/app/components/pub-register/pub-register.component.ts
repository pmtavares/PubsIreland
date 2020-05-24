import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { IPub } from 'src/app/models/pub';
import { PubsService } from 'src/app/services/pubs.service';
import { CitiesService } from 'src/app/services/cities.service';
import { ICity } from 'src/app/models/city';

@Component({
  selector: 'app-pub-register',
  templateUrl: './pub-register.component.html',
  styleUrls: ['./pub-register.component.css']
})
export class PubRegisterComponent implements OnInit {

  pub: IPub = {
    id: 0,
    name: "",
    address: "",
    imagePath: "",
    description: "",
    descriptionDetailed: "",
    phoneNumber: "",
    website: "",
    dateAdded: new Date(),
    dateFounded: null,
    cityId: null

  };

  cities: ICity[];

  constructor(private pubService: PubsService, private cityService: CitiesService ,private router: Router) { }

  ngOnInit() {
    this.getCities();
  }

  cancel()
  {
    this.router.navigate(['home'])
  }
  registerPub()
  {
    this.pubService.registerPub(this.pub).subscribe(()=> {
      console.log("Success");
      this.router.navigate(['home'])
    },
    error => {
      console.log(error)
    });
  }

  getCities()
  {
    this.cityService.getCities().subscribe(
      data=> this.cities = data.sort((a,b)=> (a.name > b.name)? 1: -1),
      error => console.log(error)
    )
  }

}

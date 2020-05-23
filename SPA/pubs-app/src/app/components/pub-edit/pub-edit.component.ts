import { Component, OnInit } from '@angular/core';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';
import { ICity } from 'src/app/models/city';
import { AuthService } from 'src/app/services/auth.service';
import { CitiesService } from 'src/app/services/cities.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pub-edit',
  templateUrl: './pub-edit.component.html',
  styleUrls: ['./pub-edit.component.css']
})
export class PubEditComponent implements OnInit {

  pub: IPub;
  cities: ICity[];

  constructor(private pubService: PubsService, private cityService: CitiesService, 
            private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.getCities();
    this.setPub();

  }

  editPub()
  {
    this.pubService.updatePub(this.pub).subscribe(
      () => {
        console.log("Success updated")
        this.router.navigate(['home'])
      },
      error => {
        console.log(error)
      }
    )
  }

  Cancel()
  {
    this.router.navigate(['home']);
  }
  setPub()
  {
    const pubId = this.authService.getLoggedUsernameId();
    this.pubService.getPubDetail(pubId).subscribe(
       data => {
         this.pub = data;
       },
       error => console.log(error)
     )
  }

  getCities()
  {
    this.cityService.getCities().subscribe(
      data=> this.cities = data.sort((a,b)=> (a.name > b.name)? 1: -1),
      error => console.log(error)
    )
  }

}

import { Component, OnInit } from '@angular/core';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';
import { ICity } from 'src/app/models/city';
import { AuthService } from 'src/app/services/auth.service';
import { AlertifyService } from 'src/app/services/alertify.service';
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
  loading: boolean = true;

  constructor(private pubService: PubsService, private cityService: CitiesService, 
            private authService: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.getCities();
    this.setPub();

  }

  editPub()
  {
    this.pubService.updatePub(this.pub).subscribe(
      () => {
        this.alertify.success("Success updated")
        this.router.navigate(['home'])
      },
      error => {
        this.alertify.error(error)
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
         this.loading = false
       },
       error => {
         console.log(error)
         this.loading = false
       }
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

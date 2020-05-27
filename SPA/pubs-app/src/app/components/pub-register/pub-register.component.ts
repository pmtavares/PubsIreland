import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { MatDialog } from '@angular/material';
import { IPub } from 'src/app/models/pub';
import { PubsService } from 'src/app/services/pubs.service';
import { CitiesService } from 'src/app/services/cities.service';
import { ICity } from 'src/app/models/city';
import { TermsConditionsComponent } from '../terms-conditions/terms-conditions.component';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-pub-register',
  templateUrl: './pub-register.component.html',
  styleUrls: ['./pub-register.component.css']
})
export class PubRegisterComponent implements OnInit {

  pub: any = {};
  terms: boolean = false;
  cities: ICity[];

  constructor(private pubService: PubsService, 
      private cityService: CitiesService ,private dialog: MatDialog,
      private router: Router, private alertify: AlertifyService) { }

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
      this.alertify.success("Success registered")
      this.router.navigate(['home'])
    },
    error => {
      this.alertify.error(error)
    });
  }

  getCities()
  {
    this.cityService.getCities().subscribe(
      data=> this.cities = data.sort((a,b)=> (a.name > b.name)? 1: -1),
      error => console.log(error)
    )
  }

  openDialog()
  {
    const dialogRef = this.dialog.open(TermsConditionsComponent);


    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}

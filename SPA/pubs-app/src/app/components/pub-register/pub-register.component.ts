import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { IPub } from 'src/app/models/pub';
import { PubsService } from 'src/app/services/pubs.service';

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
    dateFounded: new Date(),
    cityId: ""

  };

  constructor(private pubService: PubsService, private router: Router) { }

  ngOnInit() {
  }

  cancel()
  {
    this.router.navigate(['home'])
  }
  registerPub()
  {
    console.log(this.pub)
    this.pubService.registerPub(this.pub).subscribe(()=> {
      console.log("Success")
    },
    error => {
      console.log(error)
    });
  }

}

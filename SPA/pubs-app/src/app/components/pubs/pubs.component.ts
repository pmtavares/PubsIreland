import { Component, OnInit } from '@angular/core';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';

@Component({
  selector: 'app-pubs',
  templateUrl: './pubs.component.html',
  styleUrls: ['./pubs.component.css']
})
export class PubsComponent implements OnInit {

  pubs: IPub[] = [];
  loading: boolean = true;

  constructor(private pubService: PubsService) { }

  ngOnInit() {
    this.getPubs(12);
  }

  getPubs(pubs: number)
  {
    this.pubService.getPubsNumber(pubs).subscribe(
      data => {
        this.pubs = data;
        this.loading = false;
      },
      error => {
        console.log(error);
        this.loading = false;
      }
    )
  }

}

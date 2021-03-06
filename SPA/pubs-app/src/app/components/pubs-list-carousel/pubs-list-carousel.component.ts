import { Component, OnInit } from '@angular/core';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';

@Component({
  selector: 'app-pubs-carousel',
  templateUrl: './pubs-list-carousel.component.html',
  styleUrls: ['./pubs-list-carousel.component.css']
})
export class PubsListCarouselComponent implements OnInit {
  
  pubs: IPub[];
  loading: boolean = true;

  constructor(private pubService: PubsService) { }

  ngOnInit() {
    this.getPubs();
  }

  getPubs()
  {
    this.pubService.getOldestPubs(3).subscribe(
      data => {
        this.pubs = data,
        this.loading = false
      },
      error => {
        console.log(error),
        this.loading = false
      }
    )
  }

}

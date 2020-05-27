import { Component, OnInit } from '@angular/core';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';

@Component({
  selector: 'app-pub-list-card',
  templateUrl: './pub-list-card.component.html',
  styleUrls: ['./pub-list-card.component.css']
})
export class PubListCardComponent implements OnInit {

  pubs: IPub[];
  loading: boolean = true;

  constructor(private pubService: PubsService) { }

  ngOnInit() {
    this.getPubs(3);
  }

  getPubs(total: number)
  {
    this.pubService.getOldestPubs(total).subscribe(
      data => {
        this.pubs = data,
        this.loading = false
      },
      error => 
      { 
        console.log(error),
        this.loading = false
      }
    )
  }

}

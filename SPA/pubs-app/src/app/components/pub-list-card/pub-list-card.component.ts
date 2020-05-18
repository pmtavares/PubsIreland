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
  constructor(private pubService: PubsService) { }

  ngOnInit() {
    this.getPubs(3);
  }

  getPubs(total: number)
  {
    this.pubService.getPubsNumber(total).subscribe(
      data => this.pubs = data,
      error => console.log(error) 
    )
  }

}

import { Component, OnInit } from '@angular/core';
import { IPub } from 'src/app/models/pub';
import { PubsService } from 'src/app/services/pubs.service';

@Component({
  selector: 'app-pub-list-recent',
  templateUrl: './pub-list-recent.component.html',
  styleUrls: ['./pub-list-recent.component.css']
})
export class PubListRecentComponent implements OnInit {

  recentPubs: IPub[] = [];
  classical: string[] = ["The church", "Jonnhy Fox", "Oreilys"]
  constructor(private pubService: PubsService) { }  

  ngOnInit() {
    this.getRecentPubs(3)
  }

  getRecentPubs(total: number)
  {
    this.pubService.getRecenttPubs(total).subscribe(
      response => this.recentPubs = response,
      error => console.log(error)
    )
  }

}

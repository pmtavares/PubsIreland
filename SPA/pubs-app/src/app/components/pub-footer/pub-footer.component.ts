import { Component, OnInit } from '@angular/core';
import { IPub } from 'src/app/models/pub';
import { PubsService } from 'src/app/services/pubs.service';

@Component({
  selector: 'app-pub-footer',
  templateUrl: './pub-footer.component.html',
  styleUrls: ['./pub-footer.component.css']
})
export class PubFooterComponent implements OnInit {

  oldestPubs: IPub[] = []
  constructor(private pubService: PubsService) { }

  ngOnInit() {
   this.getOldestPubs(4);
  }

  getOldestPubs(total: number)
  {
    this.pubService.getOldestPubs(total).subscribe(
      response => this.oldestPubs = response,
      error => console.log(error)
    )
  }

}

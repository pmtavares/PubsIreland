import { Component, OnInit } from '@angular/core';
import { IPub } from 'src/app/models/pub';
import { PubsService } from 'src/app/services/pubs.service';

@Component({
  selector: 'app-pub-list-resume',
  templateUrl: './pub-list-resume.component.html',
  styleUrls: ['./pub-list-resume.component.css']
})
export class PubListResumeComponent implements OnInit {

  pubs: IPub[] = []

  constructor(private pubService: PubsService) { }

  ngOnInit() {
    this.getPubsByNumber(3);
  }

  getPubsByNumber(total: number)
  {
    this.pubService.getPubsNumber(total).subscribe(
      response => this.pubs = response,
      error => console.log(error)
    )
  }

 

}

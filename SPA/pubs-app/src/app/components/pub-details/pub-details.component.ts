import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';

@Component({
  selector: 'app-pub-details',
  templateUrl: './pub-details.component.html',
  styleUrls: ['./pub-details.component.css']
})
export class PubDetailsComponent implements OnInit {

  pubDetails: IPub | undefined;
  loading: boolean = true;

  constructor(private pubService: PubsService, private route: ActivatedRoute) { }

  ngOnInit() {
   this.getPubDetail();
  }

  getPubDetail()
  {
    let code: string = this.route.snapshot.paramMap.get('code');

    this.pubService.getPubDetail(code).subscribe(
      response=> {
        this.pubDetails = response,
        this.loading = false
      },
      error => {
        console.log(error),
        this.loading = false
      }
    )    
  }

}

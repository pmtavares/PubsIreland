import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';
import {MatPaginator} from '@angular/material/paginator';



@Component({
  selector: 'app-pubs-search',
  templateUrl: './pubs-search.component.html',
  styleUrls: ['./pubs-search.component.css']
})


export class PubsSearchComponent implements OnInit {

  displayedColumns: string[] = ['image', 'name', 'phone', 'city', 'dateFounded', 'website'];
  dataSource: MatTableDataSource<IPub>;
  pubs: IPub[];
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private pubService: PubsService) { }

  ngOnInit() {
    this.getPubsByCity("Dublin");
  }

  applyFilter(event: Event)
  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase(); 

    
  }
  
  getPubsByCity(city: string)
  {
    this.pubService.getPubsByCity(city).subscribe(
      response => 
          {
            this.pubs = response;
            this.initializeDataSource();
          },
          error => console.log(error)
    )
  }

  private initializeDataSource()
  {
    //Populate with callback from api
    this.dataSource= new MatTableDataSource(this.pubs);

    this.dataSource.paginator = this.paginator;

    //apply filter only to one column (name). If we remove it, filter will apply everywhere
    this.dataSource.filterPredicate = (data: IPub, filter: string) => {
      return data.name.trim().toLowerCase().indexOf(filter) !== -1;
    };

  }

  

}
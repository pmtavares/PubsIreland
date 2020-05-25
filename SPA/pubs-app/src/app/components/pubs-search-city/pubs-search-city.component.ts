import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import {MatSort} from '@angular/material/sort';
import { PubsService } from 'src/app/services/pubs.service';
import { IPub } from 'src/app/models/pub';
import {MatPaginator} from '@angular/material/paginator';
import {  ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-pubs-search',
  templateUrl: './pubs-search-city.component.html',
  styleUrls: ['./pubs-search-city.component.css']
})


export class PubsSearchCityComponent implements OnInit {

  displayedColumns: string[] = ['image', 'name', 'phone', 'city', 'dateFounded', 'website'];
  dataSource: MatTableDataSource<IPub>;

  pubs: IPub[];
  cityName: string;
  loading: boolean = true;


  @ViewChild(MatPaginator) paginator: MatPaginator;

  @ViewChild(MatSort) sort: MatSort;

  constructor(private pubService: PubsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.cityName = this.route.snapshot.paramMap.get('city');
    this.getPubsByCity(this.cityName);
  }

  applyFilter(event: Event)
  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase(); 

  }
  
  getPubsByCity(city: string )
  {
    this.pubService.getPubsByCity(city).subscribe(
      response => 
          {
            this.pubs = response;
            this.initializeDataSource();
            this.loading = false;
          },
          error => 
          {
            console.log(error);
            this.loading = false;
          }
    )
  }

  private initializeDataSource()
  {
    //Populate with callback from api
    this.dataSource= new MatTableDataSource(this.pubs);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    //apply filter only to one column (name). If we remove it, filter will apply everywhere
    this.dataSource.filterPredicate = (data: IPub, filter: string) => {
      return data.name.trim().toLowerCase().indexOf(filter) !== -1;
    };

  }

  

}
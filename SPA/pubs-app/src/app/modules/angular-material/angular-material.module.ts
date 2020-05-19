import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatToolbarModule, 
  MatDividerModule,
  MatIconModule, 
  MatCardModule,
  MatSidenavModule, 
  MatListModule, 
  MatGridListModule,
  MatButtonModule,
  MatInputModule,
  MatTooltipModule,
  MatTabsModule,
  MatChipsModule,
  MatMenuModule,
  MatSelectModule,
  MatTableModule,
  MatPaginatorModule,
  MatSortModule
   } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatIconModule, 
    MatSidenavModule, 
    MatListModule, 
    MatButtonModule,
    MatDividerModule,
    MatCardModule,
    MatGridListModule,
    MatInputModule,
    MatTooltipModule,
    MatTabsModule,
    MatChipsModule,
    MatMenuModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule
  ],
  exports:[
    MatToolbarModule,
    MatIconModule, 
    MatSidenavModule, 
    MatListModule, 
    MatButtonModule,
    MatDividerModule,
    MatCardModule,
    MatGridListModule,
    MatInputModule,
    MatTooltipModule,
    MatTabsModule,
    MatChipsModule,
    MatMenuModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule
  ]
})
export class AngularMaterialModule { }

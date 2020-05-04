import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  public rowData: ProductModel[] = [
    {
      Id: 1,
      Name: 'Test',
      Notes: 'Test Note',
      Price: 10,
      Quantity: 12,
      ImagePath: '',
      ResizedImagePath: '',
      Gender: 'Male',
    },
  ];

  columnDefs = [
    { headerName: 'Id', field: 'Id' },
    { headerName: 'Name', field: 'Name', sortable: true, filter: true },
    { headerName: 'Price', field: 'Price', sortable: true, filter: true },
    { headerName: 'Quantity', field: 'Quantity', sortable: true },
    { headerName: 'Notes', field: 'Notes' },
    { headerName: 'Gender', field: 'Gender', filter: true },
  ];

  constructor() {}

  ngOnInit(): void {
    this.populateTable();
  }

  populateTable() {}
}
interface ProductModel {
  Id: number;
  Name: string;
  Notes: string;
  Price: number;
  Quantity: number;
  ImagePath: string;
  ResizedImagePath: string;
  Gender: string;
}

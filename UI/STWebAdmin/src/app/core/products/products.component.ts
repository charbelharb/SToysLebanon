import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  displayedColumns: string[] = [
    'Id',
    'Name',
    'Price',
    'Price',
    'Quantity',
    'Notes',
    'Gender',
    'ImagePath',
    'ResizedImagePath',
  ];
  ProductsDataSource: MatTableDataSource<ProductModel>;

  public data: ProductModel[] = [
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
  constructor() {}

  ngOnInit(): void {
    this.populateTable();
  }

  populateTable() {
    this.ProductsDataSource = new MatTableDataSource<ProductModel>(this.data);
    this.ProductsDataSource.paginator = this.paginator;
    this.ProductsDataSource.sort = this.sort;
  }
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

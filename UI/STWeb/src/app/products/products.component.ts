import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
export interface ProductModel {
  id: number;
  name: string;
  description: string;
  price: number;
  quantity: number;
  imagePath: string;
  resizedImagePath: string;
  subtitle: string;
  brand: string;
}
export interface ProductsResponse {
  total: number;
  data: ProductModel[];
}

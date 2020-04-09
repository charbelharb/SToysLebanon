import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GlobalconfigService, SelectModel } from '../globalconfig.service';
import { MatPaginator } from '@angular/material/paginator';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { ProductsResponse } from '../products/products.component';

@Component({
  selector: 'app-search-products',
  templateUrl: './search-products.component.html',
  styleUrls: ['./search-products.component.css'],
})
export class SearchProductsComponent implements OnInit {
  @ViewChild('prSearchForm', { static: false }) signupForm: NgForm;
  @ViewChild('paginatorTop', { static: false }) paginatorTop: MatPaginator;
  @ViewChild('paginatorBottom', { static: false })
  paginatorBottom: MatPaginator;
  constructor(private config: GlobalconfigService, private http: HttpClient) {}
  error = new Subject<string>();
  total = 0;

  // Selects models
  genders: SelectModel[] = [
    { value: '0', viewValue: 'All' },
    { value: '1', viewValue: 'Boys' },
    { value: '2', viewValue: 'Girls' },
  ];

  ages: SelectModel[] = [
    { value: '0', viewValue: 'All' },
    { value: '1', viewValue: '0-1' },
    { value: '2', viewValue: '1-3' },
    { value: '3', viewValue: '3-7' },
    { value: '4', viewValue: '7-10' },
    { value: '5', viewValue: '10-13' },
    { value: '6', viewValue: '13+' },
  ];

  categories: SelectModel[] = [
    { value: '0', viewValue: 'All' },
    { value: '1', viewValue: 'Cars' },
    { value: '2', viewValue: 'Dolls' },
  ];

  sortBy: SelectModel[] = [
    { value: '1', viewValue: 'Price' },
    { value: '2', viewValue: 'Name' },
  ];

  direction: SelectModel[] = [
    { value: '1', viewValue: 'Ascending' },
    { value: '2', viewValue: 'Descending' },
  ];

  // Data Model
  selectedGender = '0';
  selectedAge = '0';
  selectedCategory = '0';
  textSearch = '';
  selectedSortBy = '1';
  selectedDirection = '1';

  ngOnInit(): void {
    this.search();
  }
  search() {
    const postData = {
      pageIndex:
        this.paginatorTop !== undefined ? this.paginatorTop.pageIndex : 0,
      pageSize: 15,
      Gender: +this.selectedGender,
      Age: +this.selectedAge,
      Category: +this.selectedCategory,
      SearchText: this.textSearch,
      SortBy: +this.selectedSortBy,
      Direction: +this.selectedDirection,
    };
    this.http
      .post<{ paginatorModel: ProductsResponse }>(
        this.config.getApiBase() + 'Products/GetProducts',
        postData,
        {
          observe: 'response',
        }
      )
      .subscribe(
        (responseData) => {
          this.total = responseData.body.paginatorModel.total;
        },
        (error) => {
          console.log(error.message);
          this.error.next(error.message);
        }
      );
  }
}

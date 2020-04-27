import { ProductModel } from './../products/products.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GlobalconfigService, SelectModel } from '../globalconfig.service';
import { MatPaginator } from '@angular/material/paginator';
import { HttpClient } from '@angular/common/http';
import { Subject, forkJoin } from 'rxjs';
import { ProductsResponse } from '../products/products.component';
import { NgBlockUI, BlockUI } from 'ng-block-ui';

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
  @BlockUI()
  blockUI: NgBlockUI;
  constructor(private config: GlobalconfigService, private http: HttpClient) {
    this.bui = this.blockUI;
  }
  error = new Subject<string>();
  total = 0;
  data: ProductModel[];
  bui: NgBlockUI;
  // Selects models
  genders: SelectModel[] = [
    { value: '0', viewValue: 'All' },
    { value: '1', viewValue: 'Boys' },
    { value: '2', viewValue: 'Girls' },
  ];
  categories: SelectModel[] = [{ value: '0', viewValue: 'All' }];
  brands: SelectModel[] = [{ value: '0', viewValue: 'All' }];
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
  selectedBrand = '0';
  selectedCategory = '0';
  textSearch = '';
  selectedSortBy = '1';
  selectedDirection = '1';

  ngOnInit(): void {
    this.initPage();
  }
  search(paging: boolean = false) {
    let pageIndex: number;
    if (!paging && this.paginatorTop !== undefined) {
      this.paginatorTop.firstPage();
      this.paginatorBottom.firstPage();
      pageIndex = 0;
    } else {
      pageIndex =
        this.paginatorTop !== undefined ? this.paginatorTop.pageIndex : 0;
    }
    this.bui.start('Loading...');
    const postData = {
      pageIndex,
      pageSize: 6,
      Gender: +this.selectedGender,
      Brand: +this.selectedBrand,
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
          this.data = responseData.body.paginatorModel.data;
          this.bui.stop();
        },
        (error) => {
          this.bui.stop();
          console.log(error.message);
          this.error.next(error.message);
        }
      );
  }

  initPage() {
    const brandsRequest = this.http.get<SelectModel[]>(
      this.config.getApiBase() + 'Products/GetBrands'
    );
    const categoriesRequest = this.http.get<SelectModel[]>(
      this.config.getApiBase() + 'Products/GetCategories'
    );
    forkJoin([brandsRequest, categoriesRequest]).subscribe((results) => {
      this.brands.push(...results[0]);
      this.categories.push(...results[1]);
      this.search();
    });
  }
}

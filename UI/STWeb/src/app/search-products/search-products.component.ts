import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SelectModel } from '../globalconfig.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-search-products',
  templateUrl: './search-products.component.html',
  styleUrls: ['./search-products.component.css'],
})
export class SearchProductsComponent implements OnInit {
  @ViewChild('prSearchForm', { static: false }) signupForm: NgForm;
  @ViewChild(MatPaginator) paginatorTop: MatPaginator;
  @ViewChild(MatPaginator) paginatorBottom: MatPaginator;
  constructor() {}
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

  total = 90;
  ngOnInit(): void {}
  onControlChange() {
    console.log(this.paginatorTop);
  }

  onpaginatorBottomChange(event: { pageIndex: number }) {
    console.log(event.pageIndex);
    this.paginatorTop.pageIndex = event.pageIndex;
  }

  onpaginatorTopChange(event: { pageIndex: number }) {
    this.paginatorBottom.pageIndex = event.pageIndex;
  }
  search() {
    console.log('ER');
  }
}

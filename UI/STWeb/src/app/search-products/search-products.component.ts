import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SelectModel } from '../globalconfig.service';

@Component({
  selector: 'app-search-products',
  templateUrl: './search-products.component.html',
  styleUrls: ['./search-products.component.css'],
})
export class SearchProductsComponent implements OnInit {
  @ViewChild('prSearchForm', { static: false }) signupForm: NgForm;
  constructor() {}
  // Selects models
  genders: SelectModel[] = [
    { value: '1', viewValue: 'Boys' },
    { value: '2', viewValue: 'Girls' },
    { value: '3', viewValue: 'Both' },
  ];

  ages: SelectModel[] = [
    { value: '1', viewValue: '0-1' },
    { value: '2', viewValue: '1-3' },
    { value: '3', viewValue: '3-7' },
    { value: '4', viewValue: '7-10' },
    { value: '5', viewValue: '10-13' },
    { value: '6', viewValue: '13+' },
  ];

  // Data Model
  selectedGender = '1';

  selectedAge = '4';

  ngOnInit(): void {}
  onSubmit() {}
}

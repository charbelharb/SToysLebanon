import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SharedModule } from './../shared/shared.module';
import { RouterModule } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { BrandsComponent } from './brands/brands.component';
import { CategoriesComponent } from './categories/categories.component';
import { AgGridModule } from 'ag-grid-angular';

@NgModule({
  declarations: [
    HomeComponent,
    ProductsComponent,
    BrandsComponent,
    CategoriesComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    AgGridModule.withComponents([]),
    RouterModule.forChild([
      {
        path: '',
        component: HomeComponent,
        children: [
          {
            path: 'products',
            component: ProductsComponent,
          },
          {
            path: 'brands',
            component: BrandsComponent,
          },
          {
            path: 'categories',
            component: CategoriesComponent,
          },
        ],
      },
    ]),
  ],
})
export class CoreModule {}

import { catchError, tap } from 'rxjs/operators';
import { Helper } from './../../shared/shared';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GlobalconfigService } from 'src/app/shared/globalconfig.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
})
export class CategoriesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    private config: GlobalconfigService,
    private helper: Helper,
    private http: HttpClient
  ) {}
  displayedColumns: string[] = ['Id', 'Name'];
  CategoriesDataSource: MatTableDataSource<CategoriesModel>;
  public data: CategoriesModel[] = [];
  ngOnInit(): void {
    this.doSearch();
  }
  doSearch() {
    this.http
      .get<CategoriesModel[]>(
        this.config.getApiBase() + 'ProductsAdmin/GetCategories'
      )
      .pipe(
        catchError(this.helper.handleError),
        tap((resData) => {
          this.data = resData;
          console.log(resData)
          this.CategoriesDataSource = new MatTableDataSource<CategoriesModel>(
            this.data
          );
          this.CategoriesDataSource.paginator = this.paginator;
          this.CategoriesDataSource.sort = this.sort;
          return;
        })
      );
  }
}

interface CategoriesModel {
  Id: number;
  Name: string;
}

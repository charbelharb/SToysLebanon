import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  exports: [MatCardModule, MatInputModule, MatPaginatorModule, MatSelectModule],
})
export class MaterialModule {}

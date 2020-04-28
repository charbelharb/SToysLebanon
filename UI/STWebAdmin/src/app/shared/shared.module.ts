import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalconfigService } from './globalconfig.service';
import { Helper, STErrorStateMatcher } from './shared';
import { MatNativeDateModule } from '@angular/material/core';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MaterialModule } from '../material-module';

@NgModule({
  exports: [MaterialModule],
  declarations: [],
  imports: [CommonModule, MaterialModule],
  providers: [
    GlobalconfigService,
    Helper,
    STErrorStateMatcher,
    MatNativeDateModule,
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'fill' },
    },
  ],
})
export class SharedModule {}

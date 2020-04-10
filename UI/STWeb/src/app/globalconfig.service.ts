import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GlobalconfigService {
  private apiBase = 'https://charbelharb.org/api/';
  constructor() {}
  public getApiBase = () => this.apiBase;
}

export interface SelectModel {
  value: string;
  viewValue: string;
}

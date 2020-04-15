import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GlobalconfigService {
  private apiBase = 'http://127.0.0.1:5000/api/';
  constructor() {}
  public getApiBase = () => this.apiBase;
}

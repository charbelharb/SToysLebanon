import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GlobalconfigService {
  private apiBase = 'https://localhost:44323/api/';
  constructor() {}
  public getApiBase = () => this.apiBase;
}

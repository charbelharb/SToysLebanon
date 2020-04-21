import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GlobalconfigService {
  private apiBase = 'http://127.0.0.1:5000/api/';
  private appName = 'ST Admin';
  private appTitle = 'ST Title';

  constructor() {}
  public getApiBase = () => this.apiBase;
  public getAppName = () => this.appName;
  public getAppTitle = () => this.appTitle;
}

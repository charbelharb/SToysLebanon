import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  contactUsMsg = 'For more info: 03 352 788';
  bannerMsg = 'Welcome to our site!';
  footerMessage = 'Copyright© ' + new Date().getFullYear();
}

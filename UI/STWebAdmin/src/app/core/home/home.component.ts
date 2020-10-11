import { Component, OnInit } from '@angular/core';
import { GlobalconfigService } from '../../shared/globalconfig.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private config: GlobalconfigService) {}
  AppName = this.config.getAppName();
  ngOnInit(): void {}
}

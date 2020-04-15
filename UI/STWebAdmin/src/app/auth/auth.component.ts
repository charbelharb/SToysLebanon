import { Component, OnInit } from '@angular/core';
import { STErrorStateMatcher } from './shared';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  passwordFormControl = new FormControl('', [Validators.required]);
  matcher = new STErrorStateMatcher();

  constructor() {}

  ngOnInit(): void {}
}

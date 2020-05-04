import { Component, OnInit } from '@angular/core';
import { STErrorStateMatcher, Helper } from '../shared/shared';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { AuthService, AuthResponseData } from './auth.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent implements OnInit {
  loginForm: FormGroup;
  showAuthError = false;
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  passwordFormControl = new FormControl('', [Validators.required]);
  matcher = new STErrorStateMatcher();

  @BlockUI()
  blockUI: NgBlockUI;
  constructor(
    private authService: AuthService,
    private router: Router,
    private helper: Helper
  ) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      emailFormControl: this.emailFormControl,
      passwordFormControl: this.passwordFormControl,
    });
  }

  reset() {
    this.loginForm.reset(this.loginForm.value);
  }

  login() {
    if (!this.loginForm.valid) {
      return;
    }
    this.blockUI.start();
    let authObs: Observable<any>;
    authObs = this.authService.login(
      this.emailFormControl.value,
      this.passwordFormControl.value
    );
    authObs.subscribe(
      () => {
        this.blockUI.stop();
        this.showAuthError = false;
        this.router.navigate(['/home']);
      },
      (errorMessage) => {
        this.blockUI.stop();
        if (errorMessage !== 'Not Authorized') {
          this.helper.openSnackBar(errorMessage, '');
        } else {
          this.showAuthError = true;
        }
      }
    );
  }
}

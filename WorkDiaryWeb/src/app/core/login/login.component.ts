import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/Shared/services/Storage.service';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  showPassword = false;
  loginError = false;

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
              private loginService: LoginService,
              private router: Router,
              private cacheStorage: CacheStorageService) {
    this.loginForm = this.fb.group({
      username: '',
      password: ''
    });
  }

  login() {
    const { username, password } = this.loginForm.value;
    this.loginService.login(username, password).subscribe(
      response => {
        if (response != null) {
          // Save the user details in localstorage
          this.cacheStorage.set("User", response);

          // Route to the comp accoding to user_type
          if (response.ROLE_ID == 2)
            this.router.navigate(['/providers']);
          else if (response.ROLE_ID == 3)
            this.router.navigate(['/buyers/home']);
          else
            console.log("Navigate to the NOT Found Component");
        }
        else {
          console.log("Incorrect Username & Password");
          this.loginError = true;
        }
      },
      error => {
        console.log(error);
      }
    );
    console.log(this.loginForm.value);
  }

}

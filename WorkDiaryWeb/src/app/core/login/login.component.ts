import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  showPassword = false;

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
              private loginService: LoginService,
              private router: Router) {
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
          this.localstorageObject("User", response);

          // Route to the comp accoding to user_type
          if (response.ROLE_ID == 2)
            this.router.navigate(['/providers']);
          else if (response.ROLE_ID == 3)
            this.router.navigate(['/buyers']);
          else
            console.log("Navigate to the NOT Found Component");
        }
        else {
          console.log("Incorrect Username & Password");
        }
      },
      error => {
        console.log(error);
      }
    );
    console.log(this.loginForm.value);
  }

  // Add Session Variables
  localstorageObject(key: string, object: Object) {
    localStorage.setItem(key, JSON.stringify(object));
  }
}

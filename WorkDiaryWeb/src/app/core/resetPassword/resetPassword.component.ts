import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/Shared/services/Storage.service';
import { LoginService } from '../services/login.service';
import { UserModel } from '../Models/user';

@Component({
  selector: 'app-resetPassword',
  templateUrl: './resetPassword.component.html',
  styleUrls: ['./resetPassword.component.css']
})
export class ResetPasswordComponent implements OnInit {

  Error: string = "";
  showPassword = false;
  showConfirmPassword = false;

  userData = {
    NewPassword: '',
    ConfirmPassword: ''
  };

  constructor(private storageService: StorageService,
    private router: Router,
    private loginService: LoginService) { }

  ngOnInit() {
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  toggleShowConfirmPassword() {
    this.showConfirmPassword = !this.showConfirmPassword;
  }

  resetPass(form: NgForm) {
    this.userData = form.value;
    const password = form.value.NewPassword;
    const confirmPassword = form.value.ConfirmPassword;

    if (password !== confirmPassword) {
      this.Error = "Password Not Matching";
    }
    else {
      this.loginService.resetPass(this.userData.NewPassword).subscribe(
        (response: any) => {
          // console.log(response);
          this.storageService.remove("forgotUser");
          this.router.navigate(['/login'])
        },
        (error: any) => {
          console.error(error);
        }
      )
    }
  }

}

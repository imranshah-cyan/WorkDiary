import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/Shared/services/Storage.service';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-forgotPassword',
  templateUrl: './forgotPassword.component.html',
  styleUrls: ['./forgotPassword.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  FogotError:string = "";
  userData = {
    username: '',
    securityQuestion: '',
    securityAnswer: ''
  };

  constructor(private router: Router,
              private loginService: LoginService,
              private storageService: StorageService) { }

  ngOnInit() {
    // this.ForgotPass("adil", "Adil");
  }

  ForgotPass(form: NgForm) {
    this.userData = form.value;

    this.loginService.ForgotPass(this.userData.username, this.userData.securityQuestion, this.userData.securityAnswer).subscribe(
      (response:any) => {
        console.log(response);
        if (response.message === "User Not Found")
          this.FogotError = response.message;
        else {
          this.storageService.set("forgotUser", response);
          this.router.navigate(['/reset']);
        }
      },
      (error:any) => {
        console.error(error);
      }
    )
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-UpdatePassword',
  templateUrl: './UpdatePassword.component.html',
  styleUrls: ['./UpdatePassword.component.css']
})
export class UpdatePasswordComponent implements OnInit {

  Newpassword: string = "";
  confirmPassword: string = "";

  PassNotSame: boolean = false;
  Updated: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  updatePass(passwordForm: NgForm) {
    console.log(passwordForm.form.value);

    this.Newpassword = passwordForm.form.value.newPass;
    this.confirmPassword = passwordForm.form.value.ConfirmNewPass;

    if (!(this.Newpassword === this.confirmPassword))
    {
      this.PassNotSame = true;
      this.Updated = false;
      return;
    }
    this.PassNotSame = false;
    this.Updated = true;
  }

}

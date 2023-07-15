import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CacheStorageService } from '../../services/CacheStorage.service';
import { UserService } from 'src/app/buyers/services/user.service';

@Component({
  selector: 'app-UpdatePassword',
  templateUrl: './UpdatePassword.component.html',
  styleUrls: ['./UpdatePassword.component.css']
})
export class UpdatePasswordComponent implements OnInit {

  CurrentUserId: number = 0;
  Updated: boolean = false;
  Alert: boolean = false;
  Result: string = '';

  constructor(private cacheStorage: CacheStorageService,
    private userService: UserService) {
    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
  }


  ngOnInit() {
  }

  updatePass(passwordForm: NgForm) {
    console.log(passwordForm.form.value);

    this.userService.updateExistingPass(this.CurrentUserId, passwordForm.form.value.currentPass, passwordForm.form.value.newPassword).subscribe(
      (response: any) => {
        console.log(response);
        if (response > 0) {
          this.Result = "Successfully updated the Password";
          this.Alert = false;
          this.Updated = true;
        }
        else {
          this.Result = "Kindly enter the correct password to update your password";
          this.Alert = true;
          this.Updated = true;
        }
      },
      (error: any) => {
        // console.log(error);
      }
    )
  }

}

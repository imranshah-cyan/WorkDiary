import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/buyers/services/user.service';
import { UserModel } from 'src/app/core/Models/user';
import { CacheStorageService } from '../../services/CacheStorage.service';

@Component({
  selector: 'app-profileComponent',
  templateUrl: './profileComponent.component.html',
  styleUrls: ['./profileComponent.component.css']
})
export class ProfileComponentComponent implements OnInit {

  CurrentUserId: number = 0;
  Updated: boolean = false;
  Alert: boolean = false;
  Result: string = '';

  User: any;

  constructor(private cacheStorage: CacheStorageService,
    private userService: UserService) {
    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;

    this.getUserbyId(this.CurrentUserId);
  }

  ngOnInit() {
  }

  getUserbyId(User_Id: number) {
    this.userService.getUserById(User_Id).subscribe(
      (response: any) => {
        // console.log(response);
        this.User = response;
      },
      (error: any) => {

      }
    )
  }

  update(form: NgForm) {

    var user = {
      USER_ID: this.CurrentUserId,
      FNAME: form.value.firstName,
      MNAME: form.value.MiddleName,
      LNAME: form.value.lastName,
      EMAIL: form.value.emailAddress,
      PRIMARYPHONE: form.value.PrimaryPhone,
      SECONDARYPHONE: form.value.SecondaryPhone,
      ADDRESS1: form.value.Address1,
      ADDRESS2: form.value.Address2
    };

    this.userService.updateUser(user).subscribe(
      (response: any) => {
        // console.log(response);
        if (response != null)
        {
          this.Result = "User Profile updated";
          this.Alert = false;
          this.Updated = true;
        }
        else {
          this.Result = "User Failed to Update Profile";
          this.Alert = true;
          this.Updated = true;
        }
      },
      (error: any) => {

      }
    )
  }

}

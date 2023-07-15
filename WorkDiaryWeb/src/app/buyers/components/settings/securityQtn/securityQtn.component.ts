import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { UserService } from 'src/app/buyers/services/user.service';

@Component({
  selector: 'app-securityQtn',
  templateUrl: './securityQtn.component.html',
  styleUrls: ['./securityQtn.component.css']
})
export class SecurityQtnComponent implements OnInit {

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

  updateSecurity(passwordForm: NgForm) {

    this.userService.updateSecurityQuestionAnswer(this.CurrentUserId, passwordForm.form.value.question, passwordForm.form.value.answer, passwordForm.form.value.password).subscribe(
      (response: any) => {
        console.log(response);
        if(response > 0) {
          this.Result = "Successfully updated the question and answer";
          this.Alert = false;
          this.Updated = true;
        }
        else
        {
          this.Result = "Kindly enter the correct password to update the security question and answer";
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

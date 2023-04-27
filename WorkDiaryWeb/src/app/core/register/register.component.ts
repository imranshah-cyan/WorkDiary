import { Component, ContentChild } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  showPassword = false;
  security_answer = true;

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  toggleSecurity_answer() {
    this.security_answer = !this.security_answer;
  }

  myForm: FormGroup;

  constructor(private fb: FormBuilder,
              private registerService: RegisterService,
              private router: Router) {
    this.myForm = this.fb.group({
      usertype: '',
      name: '',
      email: '',
      username: '',
      password: '',
      security_question: '',
      security_answer: ''
    });
  }

  register() {
    this.registerService.register(this.myForm.value)
      .subscribe(
        response => {
          // Save the user details in localstorage
          this.localstorageObject("User", response);

          // Route to the comp accoding to user_type
          if (response.ROLE_ID == 2)
            this.router.navigate(['/providerlogs']);
          else if (response.ROLE_ID == 3)
            this.router.navigate(['/buyers']);
          else
            console.log("Navigate to the NOT Found Component");

          // console.log('Response:', response);
        },
        error => {
          console.log('Error:', error);
          // handle the error here
        }
      );
  }

  // Add Session Variables
  localstorageObject(key: string, object: Object) {
    localStorage.setItem(key, JSON.stringify(object));
  }
}

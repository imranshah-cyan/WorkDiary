import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterModel } from '../Models/register';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private baseUrl = environment.API_URL;
  private apiUrl = this.baseUrl+'/user';

  constructor(private http: HttpClient) {
    console.log(this.apiUrl);
  }

  register(register: RegisterModel): Observable<any> {
    const url = this.apiUrl + '/insert';
    const payload = {
      ROLE_ID:                  register.usertype,
      FULL_NAME:                register.name,
      EMAIL:                    register.email,
      USER_NAME:                register.username,
      PASSWORD:                 register.password,
      SECURITY_QUESTION:        register.security_question,
      SECURITY_QUESTION_ANSWER: register.security_answer
    };
    return this.http.post(url, payload);
  }

}

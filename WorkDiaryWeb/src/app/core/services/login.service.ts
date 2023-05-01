import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserModel } from '../Models/user';
import { StorageService } from 'src/app/Shared/services/Storage.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private baseUrl = environment.API_URL;
  private apiUrl = this.baseUrl + '/user/validate';

  constructor(private http: HttpClient,
              private storageService: StorageService) { }

  login(username: string, password: string): Observable<any> {
    const url = `${this.apiUrl}?username=${username}&password=${password}`;
    return this.http.get(url);
  }

  ForgotPass(username:string, securityQuestion:string, securityAnswer:string): Observable<any> {
    const url = `${this.baseUrl}/user/forgotPassword?username=${username}&question=${securityQuestion}&answer=${securityAnswer}`;
    return this.http.get(url);
  }

  resetPass(password:string): Observable<any> {
    const user = this.storageService.get('forgotUser');
    const url = `${this.baseUrl}/user/updatePassword?userId=${user.USER_ID}&password=${password}`;
    console.log(url);
    return this.http.post(url, {});
  }
}

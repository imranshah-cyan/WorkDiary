import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from 'src/app/core/Models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  userId: number = 0;
  private baseUrl = environment.API_URL;

  constructor(private http:HttpClient) { }

  getUserById(provider_id:number) {
    const url =`${this.baseUrl}/user/${provider_id}`;
    return this.http.get(url);
  }

  updateUser(model: any) {
    const url = `${this.baseUrl}/User`;
    return this.http.put(url, model);
  }

  updateSecurityQuestionAnswer(userId: number, question: string, answer: string, password: string)
  {
    const url = `${this.baseUrl}/user/UpdateSecurity?userId=${userId}&question=${question}&answer=${answer}&password=${password}`;
    return this.http.post(url, 0);
  }

  updateExistingPass(userId: number, currentPass: string, newPass: string)
  {
    const url = `${this.baseUrl}/user/updateExistingPassword?userId=${userId}&currentPass=${currentPass}&newPass=${newPass}`;
    return this.http.post(url, 0);
  }
}

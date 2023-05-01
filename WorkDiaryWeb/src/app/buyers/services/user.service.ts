import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

}

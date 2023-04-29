import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProvidersService {

  private baseUrl = environment.API_URL;

  constructor(private http: HttpClient) { }

  getProviders(providerId: number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsbyBuyerId?Buyer_Id=${providerId}`;
    return this.http.get(url);
  }

  getTotalActiveProvidersByBuyer(Buyer_Id: number): Observable<any> {
    const url = `${this.baseUrl}/provider/?Buyer_Id=${Buyer_Id}`;
    return this.http.get(url);
  }

}

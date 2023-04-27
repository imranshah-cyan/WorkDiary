import { HttpClient } from '@angular/common/http';
import { Injectable, Provider } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  private baseUrl = environment.API_URL;

  constructor(private http: HttpClient) { }

  getJobs(providerId:number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsbyBuyerId?Buyer_Id=${providerId}`;
    return this.http.get(url);
  }

  getProvidersByJob(JobId:number, Buyer_Id:number): Observable<any> {
    const url = `${this.baseUrl}/job/GetProviders?JobId=${JobId}&Buyer_Id=${Buyer_Id}`;
    return this.http.get(url);
  }

}

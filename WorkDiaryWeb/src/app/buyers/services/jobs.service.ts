import { HttpClient } from '@angular/common/http';
import { Injectable, Provider } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  private baseUrl = environment.API_URL;
  JobId: number = 0;

  constructor(private http: HttpClient) { }

  getJobs(Buyer_Id:number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsbyBuyerId?Buyer_Id=${Buyer_Id}`;
    return this.http.get(url);
  }

  getJobById(Job_Id: number) {
    const url = `${this.baseUrl}/job/detail/${Job_Id}`;
    return this.http.get(url);
  }

  getTotalJobs(Buyer_Id:number): Observable<any> {
    const url = `${this.baseUrl}/buyer/totalJobs/${Buyer_Id}`;
    return this.http.get(url);
  }

  getTotalActiveJobsByBuyer(Buyer_Id:number): Observable<any> {
    const url = `${this.baseUrl}/job/?Buyer_Id=${Buyer_Id}`;
    return this.http.get(url);
  }

  getProvidersByJob(JobId:number, Buyer_Id:number): Observable<any> {
    const url = `${this.baseUrl}/job/GetProviders?JobId=${JobId}&Buyer_Id=${Buyer_Id}`;
    return this.http.get(url);
  }

}

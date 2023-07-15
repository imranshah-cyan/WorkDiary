import { HttpClient } from '@angular/common/http';
import { Injectable, Provider } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NewJob } from '../models/NewJob';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  private baseUrl = environment.API_URL;
  JobId: number = 0;

  constructor(private http: HttpClient) { }

  AddNewJob(NewJob: NewJob): Observable<any> {
    const url = `${this.baseUrl}/job/addJob`;
    return this.http.post(url, NewJob);
  }

  UpdateJob(Job: any) {
    const url = `${this.baseUrl}/job/UpdateJob`;
    return this.http.post(url, Job);
  }

  getJobStatus(): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobStatuses`;
    return this.http.get(url);
  }

  getJobClasses(): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobClasses`;
    return this.http.get(url);
  }

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

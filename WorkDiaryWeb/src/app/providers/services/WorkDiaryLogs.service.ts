import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WorkDiaryLogsService {

  private baseUrl = environment.API_URL;
  start_date: string = "";
  end_date: string = "";

  constructor(private http: HttpClient) {

  }

  getTotalTime(providerId: number, jobId: number, period: number): Observable<any> {
    const url = `${this.baseUrl}/workDiaryApp/TotalTimeinSec`;
    console.log(url);
    const data = {
      BUYER_ID: 0,
      PROVIDER_ID: providerId,
      JOB_ID: jobId,
      Period: period
    };

    return this.http.post(url, data);
  }

  getTotalLogs(providerId: number, jobId: number, period: number): Observable<any> {
    const url = `${this.baseUrl}/workDiaryApp/TotalLogs`;
    // console.log(url);
    const data = {
      BUYER_ID: 0,
      PROVIDER_ID: providerId,
      JOB_ID: jobId,
      Period: period
    };

    return this.http.post(url, data);
  }

  getScreenLogs(providerId:number, JobId:number, period:number): Observable<any> {

    var url = `${this.baseUrl}/workDiaryApp/webLogs`;
    const data = {
      BUYER_ID: 0,
      PROVIDER_ID: providerId,
      JOB_ID: JobId,
      Period: period
    }

    return this.http.post(url, data);
  }

  getTotalScreenLogs(providerId: number, JobId: number, period: number): Observable<any> {
    const url = `${this.baseUrl}/workDiaryApp/TotalScreenLogs`
    console.log(url);
    const data = {
      BUYER_ID: 0,
      PROVIDER_ID: providerId,
      JOB_ID: JobId,
      Period: period
    }

    return this.http.post(url, data);
  }

  formatDate(date:Date) {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    const Formateddate = `${year}-${month}-${day}`;
    return Formateddate;
  }

  getJobsByProvider(provider_id:number): Observable<any> {
    const url = `${this.baseUrl}/job/get/${provider_id}`;
    return this.http.get(url);
  }

  getJobsByBuyer(user_id: number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsbyBuyerId?Buyer_Id=${user_id}`;
    return this.http.get(url);
  }
}

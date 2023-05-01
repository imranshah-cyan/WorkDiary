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

  getScreenLogs(providerId:number, JobId:number, period:number): Observable<any> {

    var url = ``;
    const currentDate = new Date();
    const today = this.formatDate(currentDate);

    if(period == 1)
    {
      this.start_date = today;
      this.end_date = today;
      url = `${this.baseUrl}/workDiaryApp/webLogs?start_date=${today}&end_date=${today}&provider_id=${providerId}&job_id=${JobId}`;
    }
    else if(period == -1)
    {
      const yesterday = new Date(today);
      yesterday.setDate(yesterday.getDate() - 1);
      const start_date = this.formatDate(yesterday);

      this.start_date = start_date;
      this.end_date = today;

      url = `${this.baseUrl}/workDiaryApp/webLogs?start_date=${start_date}&end_date=${today}&provider_id=${providerId}&job_id=${JobId}`;
    }
    else if(period == -7){
      const lastWeekDate = new Date(today);
      lastWeekDate.setDate(lastWeekDate.getDate() - 7);
      const start_date = this.formatDate(lastWeekDate);

      this.start_date = start_date;
      this.end_date = today;

      url = `${this.baseUrl}/workDiaryApp/webLogs?start_date=${start_date}&end_date=${today}&provider_id=${providerId}&job_id=${JobId}`;
    }
    else if(period == -30){
      const lastMonthDate = new Date(today);
      lastMonthDate.setDate(lastMonthDate.getDate() - 30);
      const start_date = this.formatDate(lastMonthDate);

      this.start_date = start_date;
      this.end_date = today;

      url = `${this.baseUrl}/workDiaryApp/webLogs?start_date=${start_date}&end_date=${today}&provider_id=${providerId}&job_id=${JobId}`;
    }
    else
      url = `${this.baseUrl}/workDiaryApp/webLogs?start_date=${today}&end_date=${today}&provider_id=${providerId}&job_id=${JobId}`;

    return this.http.get(url);
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

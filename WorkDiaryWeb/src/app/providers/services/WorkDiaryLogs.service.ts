import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WorkDiaryLogsService {

  private baseUrl = environment.API_URL;

  constructor(private http: HttpClient) { }

  getScreenLogs(providerId:number, JobId:number, period:number): Observable<any> {
    const url = `${this.baseUrl}/workDiaryApp/webLogs?start_date=2023-04-17&end_date=2023-04-26&provider_id=${providerId}&job_id=${JobId}`;
    return this.http.get(url);
  }

  getJobsByProvider(provider_id:number): Observable<any> {
    const url = `${this.baseUrl}/job/get/${provider_id}`;
    return this.http.get(url);
  }
}

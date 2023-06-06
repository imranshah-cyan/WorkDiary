import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { Job } from 'src/app/buyers/models/Job';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  private baseUrl = environment.API_URL;

  CurrentUserId: number = 0;

  constructor(private http: HttpClient,
    private cacheStorage: CacheStorageService) {

    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
  }

  sendOffer(Job_Id: number, Buyer_Id: number): Observable<any> {
    const url = `${this.baseUrl}/offers/SendOffer`;
    const data = {
      Job_Id: Job_Id,
      Provider_Id: this.CurrentUserId,
      Buyer_Id: Buyer_Id,
      Currency_Id: 1
    };

    return this.http.post(url, data);
  }

  getOpenForOffers(Prov_Id: number): Observable<any> {
    const url = `${this.baseUrl}/job/JobsByStatusForProvider?Job_Status_Id=2&Prov_Id=${Prov_Id}`;
    return this.http.get(url);
  }

  getJobsForOffersSent(Prov_Id: number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsForOffersSentAwardedRejected?Prov_Id=${Prov_Id}&Is_Awarded=0&Is_Rejected=0`;
    return this.http.get(url);
  }

  getJobsForOffersAwarded(Prov_Id: number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsForOffersSentAwardedRejected?Prov_Id=${Prov_Id}&Is_Awarded=1&Is_Rejected=0`;
    return this.http.get(url);
  }

  getJobsForOffersRejected(Prov_Id: number): Observable<any> {
    const url = `${this.baseUrl}/job/GetJobsForOffersSentAwardedRejected?Prov_Id=${Prov_Id}&Is_Awarded=0&Is_Rejected=1`;
    return this.http.get(url);
  }
}

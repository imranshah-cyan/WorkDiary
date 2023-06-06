import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { environment } from 'src/environments/environment';
import { Offer } from '../../models/Offer';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobOffersService {

  private baseUrl = environment.API_URL;

  CurrentUserId: number = 0;

  constructor(private http: HttpClient,
    private cacheStorage: CacheStorageService) {

    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
  }

  acceptOffer(Job_Offer_Id:number, Job_Id:number, Provider_Id: number): Observable<any> {
    const url = `${this.baseUrl}/offers/AcceptRewardOffer`;
    const data = {
      Job_Offer_Id: Job_Offer_Id,
      Job_Id: Job_Id,
      Provider_Id: Provider_Id,
      Buyer_Id: this.CurrentUserId,
      Currency_Id: 1
    };

    return this.http.post(url, data);
  }

  rejectOffer(Job_Offer_Id: number): Observable<any> {
    const url = `${this.baseUrl}/offers/DeclineOffer?Job_Offer_Id=${Job_Offer_Id}&Buyer_Id=${this.CurrentUserId}`;
    return this.http.post(url, null);
  }

  getActiveOffers(): Observable<any> {
    const url = `${this.baseUrl}/offers/GetActiveOffersByBuyerId?buyer_Id=${this.CurrentUserId}`;
    return this.http.get(url);
  }

  getRejectedOffers(): Observable<any> {
    const url = `${this.baseUrl}/offers/GetRejectedOffersByBuyerId?buyer_Id=${this.CurrentUserId}`;
    return this.http.get(url);
  }

}

import { Component } from '@angular/core';
import { Offer } from '../../models/Offer';
import { JobOffersService } from './JobOffers.service';

@Component({
  selector: 'app-job-offers',
  templateUrl: './job-offers.component.html',
  styleUrls: ['./job-offers.component.scss']
})
export class JobOffersComponent {

  activeTab = 1;

  OfferRejected:boolean = false;
  OfferAccepted:boolean = false;

  OffersReceived: Offer[] = [];
  OffersRejected: Offer[] = [];

  changeTab(tabNumber: number) {
    this.activeTab = tabNumber;
  }

  constructor(private JobOffers: JobOffersService)
  {
    this.getActiveOffers();
    this.getRejectedOffers();
  }

  acceptOffer(Job_Offer_Id: number, Job_Id: number, Provider_Id: number) {
    this.JobOffers.acceptOffer(Job_Offer_Id, Job_Id, Provider_Id)
      .subscribe(
        (response: any) => {
          this.getActiveOffers();
          this.getRejectedOffers();
        },
        (error: any) => {

        }
      );
  }

  rejectOffer(Job_Offer_Id: number) {
    this.JobOffers.rejectOffer(Job_Offer_Id)
      .subscribe(
        (response: any) => {
          this.getActiveOffers();
          this.getRejectedOffers();
        },
        (error: any) => {

        }
      );
  }

  getActiveOffers() {
    this.JobOffers.getActiveOffers()
      .subscribe(
        (response: Offer[]) => {
          console.log(response);
          this.OffersReceived = response;
        },
        (error: any) => {

        }
      );
  }

  getRejectedOffers() {
    this.JobOffers.getRejectedOffers()
      .subscribe(
        (response: Offer[]) => {
          this.OffersRejected = response;
        },
        (error: any) => {

        }
      );
  }

}

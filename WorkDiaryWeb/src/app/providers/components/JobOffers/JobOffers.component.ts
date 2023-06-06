import { Component, OnInit } from '@angular/core';
import { Job } from 'src/app/buyers/models/Job';
import { JobService } from './Job.service';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';

@Component({
  selector: 'app-JobOffers',
  templateUrl: './JobOffers.component.html',
  styleUrls: ['./JobOffers.component.css']
})
export class JobOffersComponent implements OnInit {

  CurrentUserId: number = 0;
  activeTab = 1;

  OpenForOffers: Job[] = [];
  OffersSent: Job[] = [];
  OffersAwarded: Job[] = [];
  OffersRejected: Job[] = [];

  changeTab(tabNumber: number) {
    this.activeTab = tabNumber;
  }

  constructor(private JobService: JobService,
              private cacheStorage: CacheStorageService) {

    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;

    this.getOpenForOffers(this.CurrentUserId);
    this.getJobsForOffersSent(this.CurrentUserId);
    this.getJobsForOffersAwarded(this.CurrentUserId);
    this.getJobsForOffersRejected(this.CurrentUserId);
  }

  ngOnInit() {
  }

  OfferSent:boolean = false;
  sendOffer(Job_Id: number, Buyer_Id: number)
  {
    this.JobService.sendOffer(Job_Id, Buyer_Id)
      .subscribe(
        (response: any) => {
          // console.log(response);
          this.OfferSent = true;
          this.getOpenForOffers(this.CurrentUserId);
          this.getJobsForOffersSent(this.CurrentUserId);
          this.getJobsForOffersAwarded(this.CurrentUserId);
          this.getJobsForOffersRejected(this.CurrentUserId);
        },
        (error: any) => {
          console.log(error);
        }
      );
  }

  getOpenForOffers(Prov_Id: number) {
    this.JobService.getOpenForOffers(Prov_Id)
      .subscribe(
        (response: Job[]) => {
          this.OpenForOffers = response;
          // console.log(response);
        },
        (error: any) => {
          console.log(error);
        }
      );
  }

  getJobsForOffersSent(Prov_Id: number) {
    this.JobService.getJobsForOffersSent(Prov_Id)
      .subscribe(
        (response: Job[]) => {
          this.OffersSent = response;
        },
        (error: any) => {
          console.log(error);
        }
      );
  }

  getJobsForOffersAwarded(Prov_Id: number) {
    this.JobService.getJobsForOffersAwarded(Prov_Id)
      .subscribe(
        (response: Job[]) => {
          this.OffersAwarded = response;
        },
        (error: any) => {
          console.log(error);
        }
      );
  }

  getJobsForOffersRejected(Prov_Id: number) {
    this.JobService.getJobsForOffersRejected(Prov_Id)
      .subscribe(
        (response: Job[]) => {
          this.OffersRejected = response;
        },
        (error: any) => {
          console.log(error);
        }
      );
  }
}

import { Component, OnInit, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProvidersService } from '../../services/providers.service';
import { Provider } from '../../models/Provider';
import { JobsService } from '../../services/jobs.service';
import { Job } from '../../models/Job';
import { StorageService } from 'src/app/Shared/services/Storage.service';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent1 implements OnInit {

  TotalJobs:number = 0;
  TotalProviders:number = 0;
  jobs:Job[] = [];
  ServiceProviders: Provider[] = [];

  constructor(private providerService: ProvidersService,
              private jobService: JobsService,
              private cacheStorage: CacheStorageService,
              private router: Router,
              private userService: UserService) { }

  ngOnInit() {
    var currentUserId = this.cacheStorage.get("User").USER_ID;

    this.getTotalJobs(currentUserId);
    this.getTotalProviders(currentUserId);
    this.getJobsByBuyer(currentUserId);
    this.getServiceProvidersByBuyer(currentUserId);
  }

  viewProfile(provider:number) {
    this.userService.userId = provider;
    this.router.navigate(['/buyers/provProfile']);
  }

  JobDetails(Job_Id: number) {
    this.jobService.JobId = Job_Id;
    this.router.navigate(['/buyers/jobDetails']);
  }

  getTotalJobs(buyerId:number) {
    this.jobService.getTotalJobs(buyerId).subscribe(
      (response:any) => {
        this.TotalJobs = response;
      },
      (error:any) => {
        console.error(error);
      }
    )
  }

  getTotalProviders(buyerId:number) {
    this.providerService.getTotalActiveProvidersByBuyer(buyerId).subscribe(
      (response:any) => {
        this.TotalProviders = response;
        // console.log(response);
      },
      (error:any) => {
        console.log(error);
      }
    )
  }

  getJobsByBuyer(buyerId:number) {
    this.jobService.getJobs(buyerId).subscribe(
      (response:any[]) => {
        // console.log(response);
        this.jobs = response;
      },
      (error:any) => {
        console.error(error);
      }
    )
  }

  getServiceProvidersByBuyer(buyerId: number) {
    this.providerService.getProvidersByBuyer(buyerId).subscribe(
      (response:any[]) => {
        this.ServiceProviders = response;
      },
      (error:any) => {
        console.error(error);
      }
    )
  }

}

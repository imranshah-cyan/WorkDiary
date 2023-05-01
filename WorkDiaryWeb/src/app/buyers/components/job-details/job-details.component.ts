import { Component } from '@angular/core';
import { Provider } from '../../models/Provider';
import { UserService } from '../../services/user.service';
import { JobsService } from '../../services/jobs.service';
import { Job } from '../../models/Job';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.scss']
})
export class JobDetailsComponent {

  jobDetails!: Job;
  providers: { [key: number]: Provider[] } = {};

  constructor(private jobService: JobsService) { }

  ngOnInit() {
    // console.log(this.jobService.JobId);
    this.getJobDetails(this.jobService.JobId);
  }

  getJobDetails(Job_Id: number) {
    this.jobService.getJobById(Job_Id).subscribe(
      (response: any) => {
        this.jobDetails = response;
        this.getProvByJobId(this.jobDetails.JOB_ID, this.jobDetails.BUYER_USER_ID);
        // console.log(this.jobDetails);
      },
      (error: any) => {
        console.error(error);
      }
    )
  }

  getProvByJobId(jobId: number, buyerId: number) {
    this.jobService.getProvidersByJob(jobId, buyerId).subscribe(
      (response: any[]) => {
        if (response != null) {
          this.providers[jobId] = response;
        }
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}

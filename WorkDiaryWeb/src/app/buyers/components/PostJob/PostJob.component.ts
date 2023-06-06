import { Component, OnInit } from '@angular/core';
import { JobsService } from '../../services/jobs.service';
import { JobStatusType } from '../../models/JobStatusType';
import { NgForm } from '@angular/forms';
import { NewJob } from '../../models/NewJob';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';

@Component({
  selector: 'app-PostJob',
  templateUrl: './PostJob.component.html',
  styleUrls: ['./PostJob.component.css']
})
export class PostJobComponent implements OnInit {

  JobStatusTypes: JobStatusType[] = [];

  CurrentUserId: number = 0;
  showErrorMessage: boolean = false;
  isJobPosted: boolean = false;
  postJobMessage: string = '';

  AddNewJob: NewJob = {
    USER_ID: 0,
    JOB_TYPE_ID: 2,
    JOB_STATUS_ID: 0,
    JOB_TITLE: '',
    CLASS_ID: 0,
    DESCRIPTION: '',
    JOB_VIEW_IS_PUBLIC: true,
    CREATED_BY: 0,
    CURRENCY_ID: 1,
    RATE_TYPE_ID: 1,
    RATE: 1
  };

  constructor(private jobService: JobsService,
              private cacheStorage: CacheStorageService) {
    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
  }

  ngOnInit() {
    this.getJobStatuses();
  }

  AddJob(form: NgForm) {
    if (!this.areFieldsEmpty(form)) {
      // console.log('Form values:', form.value);

      this.AddNewJob.USER_ID = this.CurrentUserId;
      this.AddNewJob.JOB_TITLE = form.value.JobTitle;
      this.AddNewJob.DESCRIPTION = form.value.JobDescription;
      this.AddNewJob.JOB_STATUS_ID = form.value.JobStatusType;

      this.jobService.AddNewJob(this.AddNewJob)
        .subscribe(
          (response: any) => {
            this.isJobPosted = true;
            this.postJobMessage = 'New Job has been Posted';
            console.log(response);
          },
          (error: any) => {
            this.isJobPosted = false;
            this.postJobMessage = 'Failed to add a new Job';
            console.log(error);
          }
        );

      this.showErrorMessage = false;
    } else {
      this.showErrorMessage = true;
      console.log('At least one form value is empty');
    }
  }

  getJobStatuses() {
    this.jobService.getJobStatus()
      .subscribe(
        (response: any) => {
          this.JobStatusTypes = response;
        },
        (error: any) => {
          // console.log(error);
        }
      );
  }


  areFieldsEmpty(form: NgForm): boolean {
    for (const control in form.controls) {
      if (form.controls.hasOwnProperty(control)) {
        if (form.controls[control].value === null || form.controls[control].value === '') {
          return true; // At least one field is empty
        }
      }
    }
    return false; // All fields are not empty
  }

}

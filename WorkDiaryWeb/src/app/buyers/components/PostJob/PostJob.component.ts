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
  JobClasses: any[] = [];

  CurrentUserId: number = 0;
  showErrorMessage: boolean = false;
  isJobPosted: boolean = false;
  postJobMessage: string = '';

  AddNewJob: NewJob = {
    USER_ID: 0,
    JOB_STATUS_ID: 0,
    JOB_TITLE: '',
    CLASS_ID: 0,
    DESCRIPTION: '',
    CREATED_BY: 0
  };

  constructor(private jobService: JobsService,
              private cacheStorage: CacheStorageService) {
    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
  }

  ngOnInit() {
    this.getJobStatuses();
    this.getJobClasses();
  }

  AddJob(form: NgForm) {
    if (!this.areFieldsEmpty(form)) {

      this.AddNewJob.USER_ID = this.CurrentUserId;
      this.AddNewJob.JOB_STATUS_ID = form.value.jobStatus;
      this.AddNewJob.JOB_TITLE = form.value.JobTitle;
      this.AddNewJob.DESCRIPTION = form.value.JobDescription;
      this.AddNewJob.CLASS_ID = form.value.JobStatusClass;
      this.AddNewJob.CREATED_BY = this.CurrentUserId;

      console.log(form.value);
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
          // console.log(response);
        },
        (error: any) => {
          // console.log(error);
        }
      );
  }

  getJobClasses() {
    this.jobService.getJobClasses()
      .subscribe(
        (response: any) => {
          this.JobClasses = response;
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

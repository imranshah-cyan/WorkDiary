import { Component } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { WorkDiaryLogsService } from '../../services/WorkDiaryLogs.service';
import { Logs, WebLogs } from '../../models/WorkDiaryLogs';
import { DatePipe } from '@angular/common';
import { Jobs } from '../../models/Jobs';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';

@Component({
  selector: 'app-provider-logs',
  templateUrl: './provider-logs.component.html',
  styleUrls: ['./provider-logs.component.scss']
})
export class ProviderLogsComponent {

  defaultDuration = 1;

  CurrentUserId: number = 0;
  StartDate: string | undefined;
  EndDate: string | undefined;
  HourLogs: Logs[] = [];
  Jobs: Jobs[] = [];
  LogsFound: boolean = false;

  searchData = {
    jobId: 0,
    duration: 1,
  };

  constructor(private workDiaryLogsService: WorkDiaryLogsService,
    private datePipe: DatePipe,
    private cacheStorage: CacheStorageService) {
  }

  ngOnInit() {
    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;
    this.getJobsByProvider(userId);

  }

  search(form:NgForm) {
    this.getWorkDiaryLogs(this.CurrentUserId, form.value.jobId, form.value.duration);
  }

  getWorkDiaryLogs(providerId: number, job_id: number, period: number) {
    this.workDiaryLogsService.getScreenLogs(providerId, job_id, period).subscribe(
      (response: WebLogs) => {
        this.StartDate = this.workDiaryLogsService.start_date;
        this.EndDate = this.workDiaryLogsService.end_date;

        if (response != null) {
          // console.log(response);
          this.LogsFound = true;
          // Get Start Date
          const StartDate = this.datePipe.transform(response.StartDate, 'EEEE d MMMM yyyy hh:mm a');
          // this.StartDate = StartDate ? StartDate : undefined;

          // Get End Date
          const EndDate = this.datePipe.transform(response.EndDate, 'EEEE d MMMM yyyy hh:mm a');
          // this.EndDate = EndDate ? EndDate : undefined;

          // Get Hourly Logs
          this.HourLogs = response.Logs;
          // console.log(this.HourLogs);
        }
        else {
          this.LogsFound = false;
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getJobsByProvider(providerId: number) {
    this.workDiaryLogsService.getJobsByProvider(providerId).subscribe(
      (response: Jobs[]) => {

        // Get
        const jobs: Jobs[] = [];
        for (const res of response) {
          const job: Jobs = {
            JOB_ID: res.JOB_ID,
            JOB_TITLE: res.JOB_TITLE
          };
          jobs.push(job);
        }
        this.Jobs = jobs;
      },
      (error) => {
        console.error(error);
      }

    )
  }

}

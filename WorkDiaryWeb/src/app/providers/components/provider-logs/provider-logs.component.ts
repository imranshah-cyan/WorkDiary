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

  TotalTime: string = "0h 0m 00s";
  TotalLogs = {
    Total_Key_Strokes: 0,
    Total_Mouse_Clicks: 0,
    Total_Windows_Switched: 0,
    image_count: 0
  };

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
    this.getTotalLogs(this.CurrentUserId, form.value.jobId, form.value.duration);
    this.getTotalTimeinSecs(this.CurrentUserId, form.value.jobId, form.value.duration);
    this.getWorkDiaryLogs(this.CurrentUserId, form.value.jobId, form.value.duration);
    console.log(form.value);
  }

  getTotalTimeinSecs(providerId: number, jobId: number, period: number) {
    this.workDiaryLogsService.getTotalTime(providerId, jobId, period)
      .subscribe(
        (response: any) => {
          console.log(response);
          const formattedTime = this.convertSecondsToTime(response);
          // console.log(formattedTime); // Output: "1h 1m 5s"
          this.TotalTime = formattedTime;
        },
        (error: any) => {
          console.log(error);
        }
      );
  }

  getTotalLogs(providerId: number, jobId: number, period: number) {
    this.workDiaryLogsService.getTotalLogs(providerId, jobId, period)
      .subscribe(
        (response: any) => {
          this.TotalLogs = response;
          // console.log(this.TotalLogs);
        },
        (error: any) => {
          console.log(error);
        }
      );
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

  convertSecondsToTime(seconds: number): string {
    const hours = Math.floor(seconds / 3600);
    const minutes = Math.floor((seconds % 3600) / 60);
    const remainingSeconds = seconds % 60;

    const formattedTime = `${hours}h ${minutes}m ${remainingSeconds}s`;
    return formattedTime;
  }
}

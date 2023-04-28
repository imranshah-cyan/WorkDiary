import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { WorkDiaryLogsService } from '../../services/WorkDiaryLogs.service';
import { Logs, WebLogs } from '../../models/WorkDiaryLogs';
import { DatePipe } from '@angular/common';
import { Jobs } from '../../models/Jobs';

interface Food {
  value: string;
  viewValue: string;
}
interface time {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-provider-logs',
  templateUrl: './provider-logs.component.html',
  styleUrls: ['./provider-logs.component.scss']
})
export class ProviderLogsComponent {

  time: time[] = [
    { value: 'steak-0', viewValue: 'Today' },
    { value: 'pizza-1', viewValue: 'Yesterday' },
    { value: 'tacos-2', viewValue: 'Last Week' },
    { value: 'tacos-2', viewValue: 'Last Month' },
  ];

  foods: Food[] = [
    { value: 'steak-0', viewValue: 'Steak' },
    { value: 'pizza-1', viewValue: 'Pizza' },
    { value: 'tacos-2', viewValue: 'Tacos' },
  ];

  foodControl = new FormControl(this.foods[2].value);
  timeControl = new FormControl(this.time[0].value);
  form = new FormGroup({
    food: this.foodControl,
    time: this.timeControl,
  });

  StartDate: string | undefined;
  EndDate: string | undefined;
  HourLogs: Logs[] = [];
  Jobs: Jobs[] = [];

  constructor(private workDiaryLogsService: WorkDiaryLogsService,
              private datePipe: DatePipe) {

              this.getWorkDiaryLogs(35194, 7131, 1);

              const userId = sessionStorage.getItem('User');
              console.log(userId);
              this.getJobsByProvider(35194);
  }


  getWorkDiaryLogs(providerId:number, job_id:number, period:number) {
    this.workDiaryLogsService.getScreenLogs(providerId, job_id, period).subscribe(
      (response: WebLogs) => {
        if (response != null) {
          console.log(response);

          // Get Start Date
          const StartDate = this.datePipe.transform(response.StartDate, 'EEEE d MMMM yyyy hh:mm a');
          this.StartDate = StartDate ? StartDate : undefined;

          // Get End Date
          const EndDate = this.datePipe.transform(response.EndDate, 'EEEE d MMMM yyyy hh:mm a');
          this.EndDate = EndDate ? EndDate : undefined;

          // Get Hourly Logs
          this.HourLogs = response.Logs;
          // console.log(this.HourLogs);
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getJobsByProvider(providerId:number) {
    this.workDiaryLogsService.getJobsByProvider(providerId).subscribe(
      (response:Jobs[]) => {

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

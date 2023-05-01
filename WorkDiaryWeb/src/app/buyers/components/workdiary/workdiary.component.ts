import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { Jobs } from 'src/app/providers/models/Jobs';
import { Logs, WebLogs } from 'src/app/providers/models/WorkDiaryLogs';
import { WorkDiaryLogsService } from 'src/app/providers/services/WorkDiaryLogs.service';
import { JobsService } from '../../services/jobs.service';
import { Provider } from '../../models/Provider';

@Component({
  selector: 'app-workdiary',
  templateUrl: './workdiary.component.html',
  styleUrls: ['./workdiary.component.css']
})
export class WorkdiaryComponent implements OnInit {

  @Input() selectedJobId: number | null = null;
  @Output() selectedJobIdChange = new EventEmitter<number>();


  defaultDuration = 1;

  CurrentUserId: number = 0;
  StartDate: string | undefined;
  EndDate: string | undefined;
  HourLogs: Logs[] = [];
  Jobs: Jobs[] = [];
  Providers: Provider[] = [];
  LogsFound: boolean = false;

  searchData = {
    selectedJobId: 0,
    ProvId: 0,
    duration: 1,
  };

  constructor(private workDiaryLogsService: WorkDiaryLogsService,
    private datePipe: DatePipe,
    private cacheStorage: CacheStorageService,
    private jobService: JobsService) {
    const userId = this.cacheStorage.get('User').USER_ID;
    this.CurrentUserId = userId;

  }

  ngOnInit() {

    this.getJobsByProvider(this.CurrentUserId);
  }

  onJobChange(event: Event): void {
    this.selectedJobId = +event;
    this.selectedJobIdChange.emit(this.selectedJobId);

    this.getProvidersByJob(this.selectedJobId);
  }


  search(form: NgForm) {
    this.getWorkDiaryLogs(form.value.ProvId, form.value.jobId, form.value.duration);
    console.log(form.value);
  }

  getWorkDiaryLogs(providerId: number, job_id: number, period: number) {
    this.workDiaryLogsService.getScreenLogs(providerId, job_id, period).subscribe(
      (response: WebLogs) => {

        console.log(response);

        this.StartDate = this.workDiaryLogsService.start_date;
        this.EndDate = this.workDiaryLogsService.end_date;

        if (response != null) {
          // console.log(response);
          this.LogsFound = true;

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

  getProvidersByJob(JobId: number) {
    this.jobService.getProvidersByJob(JobId, this.CurrentUserId).subscribe(
      (response: any) => {
        this.Providers = response;
      },
      (error: any) => {
        console.error(error);
      }
    )
  }

  getJobsByProvider(buyerId: number) {
    this.workDiaryLogsService.getJobsByBuyer(buyerId).subscribe(
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

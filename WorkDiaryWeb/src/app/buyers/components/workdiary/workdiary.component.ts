import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CacheStorageService } from 'src/app/Shared/services/CacheStorage.service';
import { Jobs } from 'src/app/providers/models/Jobs';
import { Logs, WebLogs } from 'src/app/providers/models/WorkDiaryLogs';
import { WorkDiaryLogsService } from 'src/app/providers/services/WorkDiaryLogs.service';
import { JobsService } from '../../services/jobs.service';
import { Provider } from '../../models/Provider';
import { TotalScreenLogs } from 'src/app/providers/models/TotalScreenLogs';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-workdiary',
  templateUrl: './workdiary.component.html',
  styleUrls: ['./workdiary.component.css']
})
export class WorkdiaryComponent implements OnInit {

  @Input() selectedJobId: number | null = null;
  @Output() selectedJobIdChange = new EventEmitter<number>();


  defaultDuration = 1;

  UserSearched: string = "";
  CurrentUserId: number = 0;
  StartDate: string | undefined;
  EndDate: string | undefined;
  HourLogs: Logs[] = [];
  Jobs: Jobs[] = [];
  Providers: Provider[] = [];
  TotalScreenLogs: TotalScreenLogs[] = [];

  LogsFound: boolean = false;
  TotalScreenLogsFound: boolean = false;

  TotalTime: string = "0h 0m 00s";
  TotalTimeinSec: number = 0;
  TotalLogs = {
    Total_Key_Strokes: 0,
    Total_Mouse_Clicks: 0,
    Total_Windows_Switched: 0,
    image_count: 0
  };

  searchData = {
    selectedJobId: 0,
    ProvId: 0,
    duration: 1,
  };

  constructor(private workDiaryLogsService: WorkDiaryLogsService,
    private datePipe: DatePipe,
    private cacheStorage: CacheStorageService,
    private jobService: JobsService,
    private userService: UserService) {
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
    this.TotalScreenLogs = [];
    this.TotalTime = "0h 0m 00s";
    this.HourLogs = [];
    this.TotalLogs = {
      Total_Key_Strokes: 0,
      Total_Mouse_Clicks: 0,
      Total_Windows_Switched: 0,
      image_count: 0
    };
    this.LogsFound = false;

    this.getUserbyUserId(form.value.ProvId);
    this.getTotalLogs(form.value.ProvId, form.value.jobId, form.value.duration);
    this.getTotalTimeinSecs(form.value.ProvId, form.value.jobId, form.value.duration);
    this.getTotalScreenLogs(form.value.ProvId, form.value.jobId, form.value.duration);
    this.getWorkDiaryLogs(form.value.ProvId, form.value.jobId, form.value.duration);
    console.log(form.value);
  }

  getUserbyUserId(Id: number) {
    this.userService.getUserById(Id).subscribe(
      (response: any) => {
        console.log(response);
        this.UserSearched = response.FULL_NAME;
      },
      (error: any) => {

      }
    )
  }

  getTotalTimeinSecs(providerId: number, jobId: number, period: number) {
    this.workDiaryLogsService.getTotalTime(providerId, jobId, period)
      .subscribe(
        (response: any) => {

          const formattedTime = this.convertSecondsToTime(response);
          // console.log(formattedTime); // Output: "1h 1m 5s"
          this.TotalTime = formattedTime;

        },
        (error: any) => {
          // console.log(error);
        }
      );
  }

  async getTotalTimeinSecs1(providerId: number, jobId: number, period: number): Promise<any> {
    try {
      const response: any = await this.workDiaryLogsService.getTotalTime(providerId, jobId, period).toPromise();
      return response;
    } catch (error) {
      // Handle error here
      throw error;
    }
  }

  getTotalLogs(providerId: number, jobId: number, period: number) {
    this.workDiaryLogsService.getTotalLogs(providerId, jobId, period)
      .subscribe(
        (response: any) => {
          this.TotalLogs = response;
          // console.log(this.TotalLogs);
        },
        (error: any) => {
          // console.log(error);
        }
      );
  }

  getTotalScreenLogs(providerId: number, jobId: number, period: number) {
    this.workDiaryLogsService.getTotalScreenLogs(providerId, jobId, period)
      .subscribe(
        (response: any) => {
          this.TotalScreenLogsFound = true;

          // GetTotalTime
          this.getTotalTimeinSecs1(providerId, jobId, period).then((timeInSecs) => {
            var total = 0;
            const logs: TotalScreenLogs[] = [];
            for (const res of response) {
              const Time = this.convertSecondsToTime(res.TIME_SPENT);
              const log: TotalScreenLogs = {
                PROVIDER_ID: res.PROVIDER_ID,
                JOB_ID: res.JOB_ID,
                CLASS_DESCRIPTION: res.CLASS_DESCRIPTION,
                TIME_SPENT: Time,
                PercentSpent: Number((res.TIME_SPENT * 100 / timeInSecs).toFixed(2))
              };
              logs.push(log);
              total += log.PercentSpent;
            }
            this.TotalScreenLogs = logs;
            console.log(total);
          }).catch((error) => {
            // Handle error here
            console.error(error);
          });

        },
        (error: any) => {
          console.error(error);
        }
      )
  }


  getWorkDiaryLogs(providerId: number, job_id: number, period: number) {
    this.workDiaryLogsService.getScreenLogs(providerId, job_id, period).subscribe(
      (response: WebLogs) => {

        // console.log(response);

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
        // console.log(error);
      }
    );
  }

  getProvidersByJob(JobId: number) {
    this.jobService.getProvidersByJob(JobId, this.CurrentUserId).subscribe(
      (response: any) => {
        this.Providers = response;
      },
      (error: any) => {
        // console.error(error);
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
        // console.error(error);
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

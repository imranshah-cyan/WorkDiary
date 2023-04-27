import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

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

}

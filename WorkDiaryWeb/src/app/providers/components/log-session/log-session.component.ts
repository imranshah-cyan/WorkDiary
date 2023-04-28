import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-log-session',
  templateUrl: './log-session.component.html',
  styleUrls: ['./log-session.component.scss']
})
export class LogSessionComponent {
  @Input() ActiveWindowTitle: string | undefined;
  @Input() ActivityLevel: string | undefined;
  @Input() Start_Time: string | undefined;
  @Input() End_Time: string | undefined;
  @Input() Total_Minutes: string | undefined;
  @Input() Key_Stroke_Level: number | undefined;
  @Input() Mouse_Click: number | undefined;
  @Input() WindowsSwitched: number | undefined;
  @Input() Image_Name: string | undefined;

}

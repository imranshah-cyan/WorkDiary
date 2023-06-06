import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-app-log-session',
  templateUrl: './app-log-session.component.html',
  styleUrls: ['./app-log-session.component.scss']
})
export class AppLogSessionComponent {
  @Input() ActiveWindowTitle: string | undefined;
  @Input() ActivityLevel: string | undefined;
  @Input() Start_Time: string | undefined;
  @Input() End_Time: string | undefined;
  @Input() Total_Minutes: string | undefined;
  @Input() Key_Stroke_Level: number | undefined;
  @Input() Mouse_Click: number | undefined;
  @Input() ACTIVITY_LEVEL: number | undefined;
  @Input() WindowsSwitched: number | undefined;
  @Input() Image_Name: string | undefined;

  openLightbox(imageUrl: string) {
    window.open(imageUrl, '_blank');
  }
}

export interface WebLogs {
  StartDate: string;
  EndDate: string;
  Logs: Logs[];
}

export interface Logs {
  Hour: Date;
  Sessions: Session[];
}

export interface Session {
  IMAGE_ID: number;
  WORKING_ON: string;
  ACTIVE_WINDOW_TITLE: string;
  KEY_STROKE_LELVE: number;
  MOUSE_CLICK: number;
  WINDOWS_SWITCHED: number;
  activityLevel: number;
  IMAGE_NAME: string;
  START_TIME: string;
  END_TIME: string;
  totalMinutes: number;
  createdOn: Date;
}

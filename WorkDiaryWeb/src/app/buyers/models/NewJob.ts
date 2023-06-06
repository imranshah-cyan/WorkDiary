export interface NewJob {
  USER_ID: number,
  JOB_TYPE_ID: number,
  JOB_STATUS_ID: number,
  JOB_TITLE: string,
  CLASS_ID: number,
  DESCRIPTION: string,
  JOB_VIEW_IS_PUBLIC: boolean,
  CREATED_BY: number,
  CURRENCY_ID: number,
  RATE_TYPE_ID: number,
  RATE: number
}

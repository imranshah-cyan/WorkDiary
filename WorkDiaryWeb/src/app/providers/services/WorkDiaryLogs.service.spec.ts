/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { WorkDiaryLogsService } from './WorkDiaryLogs.service';

describe('Service: WorkDiaryLogs', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WorkDiaryLogsService]
    });
  });

  it('should ...', inject([WorkDiaryLogsService], (service: WorkDiaryLogsService) => {
    expect(service).toBeTruthy();
  }));
});

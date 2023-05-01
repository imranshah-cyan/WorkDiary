/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CacheStorageService } from './CacheStorage.service';

describe('Service: CacheStorage', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CacheStorageService]
    });
  });

  it('should ...', inject([CacheStorageService], (service: CacheStorageService) => {
    expect(service).toBeTruthy();
  }));
});

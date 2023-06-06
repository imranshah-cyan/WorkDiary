/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { JobOffersComponent } from './JobOffers.component';

describe('JobOffersComponent', () => {
  let component: JobOffersComponent;
  let fixture: ComponentFixture<JobOffersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobOffersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

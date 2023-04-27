import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppLogSessionComponent } from './app-log-session.component';

describe('AppLogSessionComponent', () => {
  let component: AppLogSessionComponent;
  let fixture: ComponentFixture<AppLogSessionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppLogSessionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppLogSessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

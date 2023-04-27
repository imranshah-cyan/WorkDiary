import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogSessionComponent } from './log-session.component';

describe('LogSessionComponent', () => {
  let component: LogSessionComponent;
  let fixture: ComponentFixture<LogSessionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LogSessionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LogSessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

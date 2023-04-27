import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderLogsComponent } from './provider-logs.component';

describe('ProviderLogsComponent', () => {
  let component: ProviderLogsComponent;
  let fixture: ComponentFixture<ProviderLogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProviderLogsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProviderLogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

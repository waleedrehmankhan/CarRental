import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceHistoryBarComponent } from './service-history-bar.component';

describe('ServiceHistoryBarComponent', () => {
  let component: ServiceHistoryBarComponent;
  let fixture: ComponentFixture<ServiceHistoryBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceHistoryBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceHistoryBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

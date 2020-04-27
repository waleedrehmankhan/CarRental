import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBookingComponent } from './view-booking.component';

describe('ViewBookingComponent', () => {
  let component: ViewBookingComponent;
  let fixture: ComponentFixture<ViewBookingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewBookingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

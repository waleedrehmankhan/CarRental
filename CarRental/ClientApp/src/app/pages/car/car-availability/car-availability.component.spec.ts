import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarAvailabilityComponent } from './car-availability.component';

describe('CarAvailabilityComponent', () => {
  let component: CarAvailabilityComponent;
  let fixture: ComponentFixture<CarAvailabilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarAvailabilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarAvailabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewHistoryComponent } from './view-history.component';

describe('ViewHistoryComponent', () => {
  let component: ViewHistoryComponent;
  let fixture: ComponentFixture<ViewHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewExtraComponent } from './view-extra.component';

describe('ViewExtraComponent', () => {
  let component: ViewExtraComponent;
  let fixture: ComponentFixture<ViewExtraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewExtraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewExtraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

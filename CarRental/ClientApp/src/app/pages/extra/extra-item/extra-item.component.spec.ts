import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtraItemComponent } from './extra-item.component';

describe('ExtraItemComponent', () => {
  let component: ExtraItemComponent;
  let fixture: ComponentFixture<ExtraItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExtraItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExtraItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

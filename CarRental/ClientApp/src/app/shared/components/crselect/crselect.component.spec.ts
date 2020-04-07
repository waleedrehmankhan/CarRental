import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrselectComponent } from './crselect.component';

describe('CrselectComponent', () => {
  let component: CrselectComponent;
  let fixture: ComponentFixture<CrselectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrselectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrselectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

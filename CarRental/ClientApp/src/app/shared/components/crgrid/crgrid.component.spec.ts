import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrgridComponent } from './crgrid.component';

describe('CrgridComponent', () => {
  let component: CrgridComponent;
  let fixture: ComponentFixture<CrgridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrgridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrfileComponent } from './crfile.component';

describe('CrfileComponent', () => {
  let component: CrfileComponent;
  let fixture: ComponentFixture<CrfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

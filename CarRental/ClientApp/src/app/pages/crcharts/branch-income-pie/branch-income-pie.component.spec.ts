import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchIncomePieComponent } from './branch-income-pie.component';

describe('BranchIncomePieComponent', () => {
  let component: BranchIncomePieComponent;
  let fixture: ComponentFixture<BranchIncomePieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchIncomePieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchIncomePieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { SidebarmenuService } from './sidebarmenu.service';

describe('SidebarmenuService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SidebarmenuService = TestBed.get(SidebarmenuService);
    expect(service).toBeTruthy();
  });
});

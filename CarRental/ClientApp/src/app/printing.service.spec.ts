import { TestBed } from '@angular/core/testing';

import { PrintingService } from './printing.service';

describe('PrintingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PrintingService = TestBed.get(PrintingService);
    expect(service).toBeTruthy();
  });
});

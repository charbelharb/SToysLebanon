import { TestBed } from '@angular/core/testing';

import { GlobalconfigService } from './globalconfig.service';

describe('GlobalconfigService', () => {
  let service: GlobalconfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GlobalconfigService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

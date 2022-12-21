import { TestBed } from '@angular/core/testing';

import { AlamedaWebAppService } from './alameda-web-app.service';

describe('AlamedaWebAppService', () => {
  let service: AlamedaWebAppService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlamedaWebAppService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

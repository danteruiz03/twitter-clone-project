import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { feedGuard } from './feed.guard';

describe('feedGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => feedGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});

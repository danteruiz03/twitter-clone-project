import { inject } from '@angular/core';
import { NavigationEnd, ResolveFn, Router } from '@angular/router';
import { ProfileService } from '../services/profile.service';
import { filter, map, mergeMap, of, tap } from 'rxjs';

export const profileResolver: ResolveFn<boolean> = () => {
  const profileService = inject(ProfileService);
  const router = inject(Router);

  if (profileService.getProfile().userName !== '') {
    return of(true)
  }

  // TODO: WRITE RESOLVER FOR GETTING PROFILE
  return of(true);
};

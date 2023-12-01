import { ResolveFn, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { inject } from '@angular/core';
import { catchError, map, mergeMap, of } from 'rxjs';

export const userResolver: ResolveFn<any> = () => {
  const userService = inject(UserService);

  return userService.fetchUser().pipe(
    mergeMap(result => {
      userService.setUser(result);
      return of(true);
    }));
};

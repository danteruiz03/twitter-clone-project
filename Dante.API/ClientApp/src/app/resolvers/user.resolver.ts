import { ResolveFn } from '@angular/router';
import { UserService } from '../services/user.service';
import { inject } from '@angular/core';
import { mergeMap, of } from 'rxjs';

export const userResolver: ResolveFn<any> = () => {
  const userService = inject(UserService);

  return userService.fetchUser().pipe(
    mergeMap(result => {
      userService.setUser(result);
      return of(true);
    }));
};

import { ResolveFn } from '@angular/router';
import { UserService } from '../services/user.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';

export const userResolver: ResolveFn<any> = () => {
  // return inject(UserService).validateToken().pipe(
  //   map(result => {
  //     return result;
  //   })
  // )
};

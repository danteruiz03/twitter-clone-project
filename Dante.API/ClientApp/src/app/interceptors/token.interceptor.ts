import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService, private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.authService.getToken();
    console.log(token)

    if (token) {
      const authReq = request.clone({
        headers: request.headers.set('Authorization', 'Bearer ' + token)
      })

      return next.handle(authReq)
        .pipe(
          catchError(x => this.handleAuthError(x)));
    }

    return next.handle(request)
      .pipe(
        catchError(x => this.handleAuthError(x)));
  }

  private handleAuthError(err: HttpErrorResponse): Observable<any> {
    if (err.status === 401 || err.status === 403) {
      this.authService.storeToken('');
      this.router.navigateByUrl('/auth/login')
    }
    return throwError(() => err);
  }
}

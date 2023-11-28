import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { lastValueFrom, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  login(user: User) {
    return this.http.post('/api/auth/login', user, { responseType: 'text' });
  }

  register(user: User) {
    return this.http.post('/api/auth/register', user);
  }
}

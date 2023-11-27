import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  login(user: User) {
    return this.http.post<User>('/api/auth/login', user);
  }

  register(user: User) {
    return this.http.post<User>('/api/auth/register', user);
  }
}

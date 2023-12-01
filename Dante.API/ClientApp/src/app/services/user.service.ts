import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private user: User = {name: '', role: ''};

  constructor(private http: HttpClient) { }

  login(user: Login) {
    return this.http.post('/api/auth/login', user, { responseType: 'text' });
  }

  register(user: Login) {
    return this.http.post('/api/auth/register', user);
  }

  fetchUser() {
    return this.http.get<User>('/api/auth');
  }

  getUser() {
    return this.user;
  }

  setUser(user: User){
    this.user = user;
  }
}

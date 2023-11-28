import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, tap } from 'rxjs';

const key = '513f1dd9-2c2b-4281-a522-41a3f4bedbdd';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  storeToken(token: string) {
    localStorage.setItem(key, token);
  }

  getToken() {
    return localStorage.getItem(key);
  }
}

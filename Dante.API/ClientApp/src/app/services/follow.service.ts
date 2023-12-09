import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FollowService {

  constructor(private http: HttpClient) { }

  followUser(userId: string) {
    return this.http.post('/api/follow', { userId: userId });
  }
}

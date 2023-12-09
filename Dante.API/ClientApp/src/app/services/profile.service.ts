import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Profile } from '../models/profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  currentProfile: Profile = {
    userName: '',
    userId: '',
    tweets: []
  }

  constructor(private http: HttpClient) { }

  fetchProfile(userName: string) {
    return this.http.get<Profile>('/api/profile/' + userName);
  }

  getProfile() {
    return this.currentProfile;
  }

  setProfile(profile: Profile) {
    this.currentProfile = profile;
  }
}

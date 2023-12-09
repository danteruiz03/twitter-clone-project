import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from 'src/app/models/profile.model';
import { AuthService } from 'src/app/services/auth.service';
import { FollowService } from 'src/app/services/follow.service';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  profile: Profile = {
    userName: '',
    userId: '',
    tweets: []
  }

  status = 'Follow';

  constructor(
    private profileService: ProfileService,
    private authService: AuthService,
    private followService: FollowService,
    private router: Router) { }

  ngOnInit(): void {
    this.profile = this.profileService.getProfile();
  }

  follow() {
    if(this.status == 'Follow') {
      this.followService.followUser(this.profile.userId).subscribe({
        next: () => {
          this.status = 'Followed';
        },
        error: () => {
          alert('Error occured');
        }
      })
    }
  }

  home() {
    this.router.navigateByUrl('')
  }

  logout() {
    this.authService.storeToken('');
    this.router.navigateByUrl('/auth/login');
  }
}


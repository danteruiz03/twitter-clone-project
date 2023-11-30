import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Tweet } from 'src/app/models/tweet.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent {
  tweets: Tweet[] = [
    { user: 'Dante', content: 'This is a tweet' },
    { user: 'Sasha', content: 'This is a tweet again' },
    { user: 'Reiner', content: 'This is a tweet again twice' }
  ]

  constructor(private authService: AuthService, private router: Router) { }

  logout() {
    this.authService.storeToken('');
    this.router.navigateByUrl('/auth/login');
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent {

  constructor(private authService: AuthService, private router: Router){}

  logout() {
    this.authService.storeToken('');
    this.router.navigateByUrl('/auth/login');
  }
}

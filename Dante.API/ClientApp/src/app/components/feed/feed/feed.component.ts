import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, map, switchMap, takeUntil } from 'rxjs';
import { Tweet } from 'src/app/models/tweet.model';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { TweetService } from 'src/app/services/tweet.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit, OnDestroy {
  private _destroying$ = new Subject<void>;

  form = new FormGroup({
    content: new FormControl('', {
      validators: [
        Validators.required,
        Validators.maxLength(255)]
    })
  })

  user: User = {
    name: '',
    role: ''
  }

  tweets: Tweet[] = []

  constructor(
    private authService: AuthService,
    private router: Router,
    private userService: UserService,
    private tweetService: TweetService
  ) { }

  ngOnInit(): void {
    this.user = this.userService.getUser();
    this.tweets = this.tweetService.getTweets();

    this.tweetService.tweetsChanged
      .pipe(
        switchMap(() =>
          this.tweetService.fetchTweets().pipe(
            map(tweets => {
              this.tweetService.setTweets(tweets);
              this.tweets = this.tweetService.getTweets();
            })
          )
        ),
        takeUntil(this._destroying$)
      )
      .subscribe()
  }

  logout() {
    this.authService.storeToken('');
    this.router.navigateByUrl('/auth/login');
  }

  submit() {
    const tweet: Tweet = {
      userName: this.userService.getUser().name,
      content: this.form.controls['content'].value ?? ''
    };

    this.tweetService.postTweet(tweet).subscribe(result => {
      this.form.reset();
      this.tweetService.tweetsChanged.next();
    });
  }

  ngOnDestroy(): void {
    this._destroying$.next(undefined);
    this._destroying$.complete();
  }
}

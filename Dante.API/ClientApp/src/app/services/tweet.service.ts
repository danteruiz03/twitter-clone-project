import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tweet } from '../models/tweet.model';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TweetService {
  private tweets: Tweet[] = [];
  tweetsChanged: Subject<void> = new Subject();

  constructor(private http: HttpClient) { }

  fetchTweets() {
    return this.http.get<Tweet[]>('/api/tweet');
  }

  getTweets() {
    return this.tweets;
  }

  setTweets(tweets: Tweet[]) {
    this.tweets = tweets;
  }

  postTweet(tweet: Tweet) {
    return this.http.post('/api/tweet', tweet);
  }
}

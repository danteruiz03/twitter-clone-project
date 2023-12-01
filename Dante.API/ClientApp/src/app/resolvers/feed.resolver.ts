import { ResolveFn } from '@angular/router';
import { TweetService } from '../services/tweet.service';
import { inject } from '@angular/core';
import { mergeMap, of } from 'rxjs';

export const feedResolver: ResolveFn<boolean> = () => {
  const tweetService = inject(TweetService);

  return tweetService.fetchTweets().pipe(
    mergeMap(result => {
      tweetService.setTweets(result);
      return of(true);
    }));
};

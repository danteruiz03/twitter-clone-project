import { Tweet } from "./tweet.model";

export interface Profile {
    userName: string;
    userId: string;
    tweets: Tweet[];
}
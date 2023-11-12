using Dante.Data.Entity;

namespace Dante.Data.Repository.Interface;

public interface ITweetRepository
{
    IQueryable<Tweet> GetTweets(List<Following> followingUsers);

    Task PostTweet(Tweet tweet);
}
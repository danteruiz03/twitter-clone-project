using Dante.Data.Entity;

namespace Dante.Data.Repository.Interface;

public interface ITweetRepository
{
    IQueryable<Tweet> GetTweets(IEnumerable<Following> followingUsers, Guid userId);

    IQueryable<Tweet> GetUserTweets(Guid userId);
    Task PostTweet(Tweet tweet);
}
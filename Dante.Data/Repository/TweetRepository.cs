using Dante.Data.Entity;
using Dante.Data.Entity.Context;
using Dante.Data.Repository.Interface;

namespace Dante.Data.Repository;

public class TweetRepository : ITweetRepository
{
    private readonly DanteDbContext _dbContext;

    public TweetRepository(DanteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Tweet> GetTweets(IEnumerable<Following> followingUsers, Guid userId)
    {
        var followingUserIds = followingUsers.Select(following => following.FollowingUserId);

        return _dbContext.Tweets
            .Where(t => (followingUserIds.Contains(t.UserId) || t.UserId == userId))
            .OrderByDescending(t => t.CreatedDate);
    }

    public async Task PostTweet(Tweet tweet)
    {
        await _dbContext.Tweets.AddAsync(tweet);
        await _dbContext.SaveChangesAsync();
    }
}
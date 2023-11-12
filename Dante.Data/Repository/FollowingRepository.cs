using Dante.Data.Entity;
using Dante.Data.Entity.Context;
using Dante.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dante.Data.Repository;

public class FollowingRepository : IFollowingRepository
{
    private readonly DanteDbContext _dbContext;

    public FollowingRepository(DanteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<Following> GetFollowingList(Guid id)
    {
        return _dbContext.Following.Where(f => f.FollowerUserId == id);
    }

    public async Task AddFollowing(Guid followerUserId, Guid followingUserId)
    {
        var following = new Following
        {
            FollowerUserId = followerUserId,
            FollowingUserId = followingUserId,
            FollowDate = DateTime.Now
        };

        await _dbContext.Following.AddAsync(following);
        await _dbContext.SaveChangesAsync();
    }
}
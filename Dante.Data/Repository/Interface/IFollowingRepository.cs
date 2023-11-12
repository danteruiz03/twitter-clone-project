using Dante.Data.Entity;

namespace Dante.Data.Repository.Interface;

public interface IFollowingRepository
{
    IQueryable<Following> GetFollowingList(Guid id);

    Task AddFollowing(Guid followerUserId, Guid followingUserId);
}
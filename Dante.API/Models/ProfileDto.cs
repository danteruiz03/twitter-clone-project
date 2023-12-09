using Dante.Data.Entity;

namespace Dante.API.Models;

public class ProfileDto
{
    public string UserName { get; set; }

    public Guid UserId { get; set; }

    public IEnumerable<Tweet> Tweets { get; set; }
}
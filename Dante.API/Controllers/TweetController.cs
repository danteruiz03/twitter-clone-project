using Dante.API.Utilities;
using Dante.Data.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly ITweetRepository _tweetRepository;

        public TweetController(IFollowingRepository followingRepository, ITweetRepository tweetRepository)
        {
            _followingRepository = followingRepository;
            _tweetRepository = tweetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTweets()
        {
            var userId = HttpContext.GetUserId();

            if (userId != null)
            {
                var followingList = await _followingRepository
                    .GetFollowingList(new Guid(userId))
                    .ToListAsync();

                var tweets = await _tweetRepository.GetTweets(followingList).ToListAsync();
                return Ok(tweets);
            }

            return BadRequest();
        }
    }
}
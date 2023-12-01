using AutoMapper;
using Dante.API.Models;
using Dante.API.Utilities;
using Dante.Data.Entity;
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
        private readonly IMapper _mapper;

        public TweetController(
            IFollowingRepository followingRepository,
            ITweetRepository tweetRepository,
            IMapper mapper)
        {
            _followingRepository = followingRepository;
            _tweetRepository = tweetRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTweets()
        {
            var userId = Guid.Parse(HttpContext.GetUserId()!);

            if (userId == null) return BadRequest();
            var followingList = await _followingRepository
                .GetFollowingList(userId)
                .ToListAsync();

            var tweets = await _tweetRepository.GetTweets(followingList, userId).ToListAsync();
            return Ok(tweets);
        }

        [HttpPost]
        public async Task<IActionResult> PostTweet([FromBody] TweetDto tweet)
        {
            var userId = HttpContext.GetUserId();

            if (userId == null) return BadRequest();

            var tweetDomainModel = new Tweet
            {
                Content = tweet.Content,
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse(userId)
            };

            await _tweetRepository.PostTweet(tweetDomainModel);

            return NoContent();
        }
    }
}
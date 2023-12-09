using Dante.API.Models;
using Dante.Data.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dante.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;

        public ProfileController(IUserRepository userRepository, ITweetRepository tweetRepository)
        {
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserProfile(string userName)
        {
            var user = await _userRepository.GetUserByUserName(userName);

            if (user == null)
            {
                return BadRequest();
            }

            var userTweets = await _tweetRepository.GetUserTweets(user.Id).ToListAsync();

            return Ok(new ProfileDto()
            {
                UserName = user.UserName,
                UserId = user.Id,
                Tweets = userTweets
            });
        }
    }
}
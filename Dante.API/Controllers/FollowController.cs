using Dante.API.Models;
using Dante.API.Utilities;
using Dante.Data.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dante.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly IUserRepository _userRepository;

        public FollowController(
            IFollowingRepository followingRepository,
            IUserRepository userRepository)
        {
            _followingRepository = followingRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] FollowDto followDto)
        {
            var followingUser = await _userRepository.GetUserById(followDto.UserId.ToString());
            var followerUser = Guid.Parse(HttpContext.GetUserId());
            await _followingRepository.AddFollowing(followerUser, followingUser.Id);
            
            return NoContent();
        }
    }
}
using AutoMapper;
using Dante.API.Models;
using Dante.API.Utilities;
using Dante.Data.Entity;
using Dante.Data.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthController(
            IUserRepository userRepository,
            IMapper mapper,
            ITokenRepository tokenRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
            _roleRepository = roleRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUserName(loginDto.UserName);

            if (user != null)
            {
                return BadRequest("Username is already taken");
            }

            var userDomainModel = _mapper.Map<User>(loginDto);

            var role = await _roleRepository.GetUserRole();
            await _userRepository.CreateUser(userDomainModel, role);

            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUserName(loginDto.UserName);

            if (user != null)
            {
                var checkPasswordResult = await _userRepository.CheckPasswordAsync(user, loginDto.Password);

                if (checkPasswordResult)
                {
                    var jwtToken = _tokenRepository.CreateJWTToken(user, user.Role.Name.ToString());

                    return Ok(jwtToken);
                }
            }

            return BadRequest("Username or password incorrect");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserDetails()
        {
            var user = await _userRepository.GetUserById(HttpContext.GetUserId());

            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }

            return BadRequest();
        }
    }
}
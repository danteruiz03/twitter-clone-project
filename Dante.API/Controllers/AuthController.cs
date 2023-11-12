using System;
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
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var user = await _userRepository.GetUserByUserName(userDto.UserName);

            if (user != null)
            {
                return BadRequest("Username is already taken");
            }

            var userDomainModel = _mapper.Map<User>(userDto);

            var role = await _roleRepository.GetUserRole();
            await _userRepository.CreateUser(userDomainModel, role);

            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var user = await _userRepository.GetUserByUserName(userDto.UserName);

            if (user != null)
            {
                var checkPasswordResult = await _userRepository.CheckPasswordAsync(user, userDto.Password);

                if (checkPasswordResult)
                {
                    var jwtToken = _tokenRepository.CreateJWTToken(user, user.Role.Name.ToString());

                    return Ok(jwtToken);
                }
            }

            return BadRequest("Username or password incorrect");
        }

        [HttpGet]
        [Route("test")]
        [Authorize]
        public IActionResult Test()
        {
            var userId = HttpContext.GetUserId();
            return Ok(userId);
        }
    }
}
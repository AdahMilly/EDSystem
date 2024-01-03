using AutoMapper;
using EDSystem.Models;
using EDSystem.Models.Dtos;
using EDSystem.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IUser _userService;
        public UserController(IMapper mapper, IUser user)
        {
            _mapper = mapper;
            _userService = user;
        }
        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterUser(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(addUserDto.Password, 6);
            var checkIfUserExists = await _userService.GetUserByEmail(addUserDto.Email);
            if (checkIfUserExists != null)
            {
                return BadRequest("Email Already exists");
            }
            var response = await _userService.RegisterUser(user);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(LoginUserDto user)
        {
            var checkIfUserExists = await _userService.GetUserByEmail(user.Email);
            if (checkIfUserExists == null)
            {
                return BadRequest("Invalid Credentials");
            }
            //verify correct password
            var isCorrectPassword = BCrypt.Net.BCrypt.Verify(user.Password, checkIfUserExists.Password);
            if(!isCorrectPassword)
            {
                return BadRequest("Invalid Credentials");
            }
            return Ok($"Welcome {checkIfUserExists.Name}");
        }
    }
}

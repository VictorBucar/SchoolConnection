using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolConnection.API.Dtos;
using SchoolConnection.API.Models;
using SchoolConnection.API.Repositories.Interfaces;

namespace SchoolConnection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private IConfiguration _config;

        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {   
            _authRepository = authRepository;
            _config = config;
            
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Name = userForRegisterDto.Name.ToLower();

            if(await _authRepository.UserExists(userForRegisterDto.Name))
                return BadRequest("Name Already exists");
            
            
            var userForRegister = new User 
            {
                Name = userForRegisterDto.Name,
                Email = userForRegisterDto.Email
            };

            var createdUser = await _authRepository.Register(userForRegister, userForRegisterDto.Password);

            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto UserForLoginDto)
        {
            var user = await _authRepository.Login(UserForLoginDto.Name.ToLower(), UserForLoginDto.Password);
            if(user == null)
                return Unauthorized();

            var tokenDescriptor = _authRepository.GenerateToken(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new 
            {
                token = tokenHandler.WriteToken(token)
            });

            
        }
    }
}
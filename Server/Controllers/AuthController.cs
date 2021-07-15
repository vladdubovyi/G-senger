using AutoMapper;
using G_senger.Configuration;
using G_senger.Data;
using G_senger.Dtos;
using G_senger.Dtos.Responses;
using G_senger.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace G_senger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public AuthController(IAuthRepository repository, IMapper mapper, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtConfig = optionsMonitor.CurrentValue ?? throw new ArgumentNullException(nameof(optionsMonitor));
        }

        // Register      POST     api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userRegisterDto)
        {
            var userModel = _mapper.Map<User>(userRegisterDto);
            if (_repository.RegisterUser(userModel))
            {
                await _repository.SaveChangesAsync();

                return Ok();
            }

            return StatusCode(403); // Forbidden

        }

        // Login     POST     api/Auth/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var userModel = _mapper.Map<User>(userLoginDto);
            var isSucced = _repository.Login(userModel);

            if (!isSucced)
            {
                return BadRequest(new AuthResponse()
                {
                    Errors = new List<string>() {
                                "Invalid login request"
                            },
                    Success = false
                });
            }

            var identityUser = new IdentityUser() { Email = userModel.Email };

            var jwtToken = GenerateJwtToken(identityUser);

            return Ok(new AuthResponse()
            {
                Success = true,
                Token = jwtToken
            });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        // Send email   GET api/Auth/SendEmail/{email}
        [HttpGet("SendEmail/{email}")]
        public async Task<IActionResult> SendMail(string email)
        {
            return Ok(await _repository.SendMail(email));
        }
    }
}

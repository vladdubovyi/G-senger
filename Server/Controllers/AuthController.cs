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
        private readonly IServerRepository _repository;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public AuthController(IServerRepository repository, IMapper mapper, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] UserCreateDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userRegisterDto);

                var isCreated = _repository.CreateUser(user);

                var identityUser = new IdentityUser() { Email = user.Email };

                if (isCreated)
                {
                    var jwtToken = GenerateJwtToken(identityUser);

                    return Ok(new AuthResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new AuthResponse()
                    {
                        Success = false
                    });
                }
            }

            return BadRequest(new AuthResponse
            {
                Errors = new List<string>()
                {
                    "Invalid payload!"
                },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userLoginDto);
                var isSucced = _repository.Login(user);

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

                var identityUser = new IdentityUser() { Email = user.Email };

                var jwtToken = GenerateJwtToken(identityUser);

                return Ok(new AuthResponse()
                {
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new AuthResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
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
    }
}

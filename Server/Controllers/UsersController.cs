﻿using AutoMapper;
using G_senger.Data;
using G_senger.Dtos;
using G_senger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace G_senger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IServerRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IServerRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get user by Id   GET api/Users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // User creation   POST api/Users
        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            _repository.CreateUser(userModel);

            await _repository.SaveChangesAsync();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(
                nameof(GetUserById),
                new { Id = userReadDto.Id },
                userModel);
        }

        // Login    Post api/User/Login
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var userModel = _mapper.Map<User>(userLoginDto);

            if(_repository.Login(userModel))
            {
                return Ok();
            }

            return Forbid();
        }
    }
}

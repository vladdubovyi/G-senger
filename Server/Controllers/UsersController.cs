﻿using AutoMapper;
using G_senger.Data;
using G_senger.Dtos;
using G_senger.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G_senger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpGet("test/{id:int}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            var userGetDto = _mapper.Map<UserGetDto>(user);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(userGetDto);
        }

        // User creation   POST api/Users
        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            if (_repository.CreateUser(userModel))
            {
                await _repository.SaveChangesAsync();

                var userReadDto = _mapper.Map<UserReadDto>(userModel);

                return CreatedAtRoute(
                    nameof(GetUserById),
                    new { Id = userReadDto.Id },
                    userModel);
            }
            return StatusCode(403); // Forbidden
        }

        // Getting user by Email    GET      api/Users/{email}
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _repository.GetUserByEmailAsync(email);

            var userGetDto = _mapper.Map<UserGetDto>(user);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(userGetDto);
        }

        // Getting list of contacts for centain user    GET     api/Users/GetContacts/{email}
        [HttpGet("GetContacts/{email}")]
        public async Task<IActionResult> GetContactsByEmail(string email)
        {
            var contacts = await _repository.GetContactsByEmailAsync(email);

            var contactsGetDto = new List<UserGetDto>();

            foreach(var user in contacts)
            {
                contactsGetDto.Add(_mapper.Map<UserGetDto>(user));
            }

            if(contactsGetDto.Count == 0)
            {
                return NotFound();
            }

            return Ok(contactsGetDto);
        }
    }
}

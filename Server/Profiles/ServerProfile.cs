using AutoMapper;
using G_senger.Dtos;
using G_senger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_senger.Profiles
{
    public class ServerProfile : Profile
    {
        public ServerProfile()
        {
            // source -> target
            CreateMap<User, UserCreateDto>();
        }
    }
}

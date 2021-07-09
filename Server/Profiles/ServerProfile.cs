using AutoMapper;
using G_senger.Dtos;
using G_senger.Models;

namespace G_senger.Profiles
{
    public class ServerProfile : Profile
    {
        public ServerProfile()
        {
            // source -> target
            CreateMap<User, UserCreateDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserReadDto, User>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginDto>();
        }
    }
}

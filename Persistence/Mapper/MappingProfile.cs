using Application.Authentication;
using AutoMapper;
using Infrastructure.Identity.Models;

namespace Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}

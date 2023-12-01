using AutoMapper;
using Dante.API.Models;
using Dante.Data.Entity;

namespace Dante.API.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<LoginDto, User>().ReverseMap();

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleId.ToString()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
    }
}
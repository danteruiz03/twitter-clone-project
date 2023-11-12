using AutoMapper;
using Dante.API.Models;
using Dante.Data.Entity;

namespace Dante.API.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}
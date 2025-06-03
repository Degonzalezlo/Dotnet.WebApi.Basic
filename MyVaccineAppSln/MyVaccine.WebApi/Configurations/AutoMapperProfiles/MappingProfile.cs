using AutoMapper;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Dependent, DependentRequestDto>().ReverseMap();
        CreateMap<Dependent, DependentResponseDto>()
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.DependentId)).ReverseMap();
    }
}

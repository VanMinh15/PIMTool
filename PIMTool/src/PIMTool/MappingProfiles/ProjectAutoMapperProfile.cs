using AutoMapper;
using PIMTool.Core.Domain.Entities;
using PIMTool.Dtos;

namespace PIMTool.MappingProfiles
{
    public class ProjectAutoMapperProfile : Profile
    {
        public ProjectAutoMapperProfile()
        {
            CreateMap<Project, ProjectDto>();

            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.ProjectNumber))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version));




        }
    }
}
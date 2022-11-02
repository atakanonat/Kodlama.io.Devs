using Application.Features.Technologies.Commands;
using Application.Features.Technologies.DTOs;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, TechnologyListDTO>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, GetByIdTechnologyDTO>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, CreatedTechnologyDTO>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, EditedTechnologyDTO>().ReverseMap();
            CreateMap<Technology, EditTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.DTOs;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDTO>().ReverseMap();
            CreateMap<ProgrammingLanguage, EditedProgrammingLanguageDTO>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDTO>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, EditProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDTO>().ReverseMap();
            CreateMap<ProgrammingLanguageListModel, IPaginate<ProgrammingLanguage>>().ReverseMap();
        }
    }
}
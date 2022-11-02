using Application.Features.ProgrammingLanguages.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.EditProgrammingLanguage
{
    public class EditProgrammingLanguageCommand : IRequest<EditedProgrammingLanguageDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class EditProgrammingLanguageHandler : IRequestHandler<EditProgrammingLanguageCommand, EditedProgrammingLanguageDTO>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

            public EditProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<EditedProgrammingLanguageDTO> Handle(EditProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage result = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                EditedProgrammingLanguageDTO editedProgrammingLanguageDTO = _mapper.Map<EditedProgrammingLanguageDTO>(result);
                return editedProgrammingLanguageDTO;
            }
        }
    }
}
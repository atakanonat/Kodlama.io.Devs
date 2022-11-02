using Application.Features.Technologies.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.EditTechnology
{
    public class EditTechnologyCommand : IRequest<EditedTechnologyDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class EditTechnologyCommandHandle : IRequestHandler<EditTechnologyCommand, EditedTechnologyDTO>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public EditTechnologyCommandHandle(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<EditedTechnologyDTO> Handle(EditTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = _mapper.Map<Technology>(request);
                Technology editedTechnology = await _technologyRepository.UpdateAsync(technology);
                EditedTechnologyDTO editedTechnologyDTO = _mapper.Map<EditedTechnologyDTO>(editedTechnology);
                return editedTechnologyDTO;
            }
        }
    }
}
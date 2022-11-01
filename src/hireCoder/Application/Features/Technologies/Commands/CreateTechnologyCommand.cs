using Application.Features.Technologies.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDTO>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDTO>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<CreatedTechnologyDTO> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = _mapper.Map<Technology>(request);
                Technology addedTechnology = await _technologyRepository.AddAsync(technology);
                CreatedTechnologyDTO createdTechnologyDTO = _mapper.Map<CreatedTechnologyDTO>(addedTechnology);
                return createdTechnologyDTO;
            }
        }
    }
}
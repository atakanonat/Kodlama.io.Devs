using Application.Features.Technologies.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDTO>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDTO>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public DeleteTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<DeletedTechnologyDTO> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = _mapper.Map<Technology>(request);
                Technology deletedTechnology = await _technologyRepository.DeleteAsync(technology);
                DeletedTechnologyDTO deletedTechnologyDTO = _mapper.Map<DeletedTechnologyDTO>(deletedTechnology);
                return deletedTechnologyDTO;
            }
        }
    }
}
using Application.Features.Technologies.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDTO>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDTO>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetByIdTechnologyHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<GetByIdTechnologyDTO> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology technology = await _technologyRepository.GetAsyncWithInclude(t => t.Id == request.Id, include: t => t.ProgrammingLanguage);
                GetByIdTechnologyDTO getByIdTechnologyDTO = _mapper.Map<GetByIdTechnologyDTO>(technology);
                return getByIdTechnologyDTO;
            }
        }
    }
}
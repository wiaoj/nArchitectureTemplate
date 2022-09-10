using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Queries.GetListProgrammingFramework;
public class GetListProgrammingFrameworkQuery : IRequest<ProgrammingFrameworkListModel> {
    public PageRequest PageRequest { get; set; }

    internal class GetListProgrammingFrameworkQueryHandler : IRequestHandler<GetListProgrammingFrameworkQuery, ProgrammingFrameworkListModel> {
        private readonly IProgrammingFrameworkReadRepository _programmingFrameworkReadRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingFrameworkQueryHandler(IProgrammingFrameworkReadRepository programmingFrameworkReadRepository, IMapper mapper) {
            _programmingFrameworkReadRepository = programmingFrameworkReadRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingFrameworkListModel> Handle(GetListProgrammingFrameworkQuery request, CancellationToken cancellationToken) {
            var entities = await _programmingFrameworkReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            include: x => x.Include(l => l.ProgrammingLanguage),
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            ProgrammingFrameworkListModel mappedEntitiesModel = _mapper.Map<ProgrammingFrameworkListModel>(entities);

            return mappedEntitiesModel;
        }
    }
}
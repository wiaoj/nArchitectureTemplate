using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
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
            IPaginate<ProgrammingFramework> programmingFrameworks = await _programmingFrameworkReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            include: x => x.Include(l => l.ProgrammingLanguage),
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            ProgrammingFrameworkListModel mappedProgrammingFrameworksModel = _mapper.Map<ProgrammingFrameworkListModel>(programmingFrameworks);

            return mappedProgrammingFrameworksModel;
        }
    }
}
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Queries.GetListProgrammingFrameworkByDynamic;
public class GetListProgrammingFrameworkByDynamicQuery : IRequest<ProgrammingFrameworkListModel> {
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }

    public class GetListProgrammingFrameworkByDynamicQueryHandler : IRequestHandler<GetListProgrammingFrameworkByDynamicQuery, ProgrammingFrameworkListModel> {
        private readonly IProgrammingFrameworkReadRepository _programmingFrameworkReadRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingFrameworkByDynamicQueryHandler(IProgrammingFrameworkReadRepository programmingFrameworkReadRepository, IMapper mapper) {
            _programmingFrameworkReadRepository = programmingFrameworkReadRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingFrameworkListModel> Handle(GetListProgrammingFrameworkByDynamicQuery request, CancellationToken cancellationToken) {
            IPaginate<ProgrammingFramework> programmingFrameworks = await _programmingFrameworkReadRepository.GetListByDynamicAsync(
                 dynamic: request.Dynamic,
                 include: x => x.Include(l => l.ProgrammingLanguage),
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
                 );

            ProgrammingFrameworkListModel mappedProgrammingFrameworks = _mapper.Map<ProgrammingFrameworkListModel>(programmingFrameworks);
            return mappedProgrammingFrameworks;
        }
    }
}

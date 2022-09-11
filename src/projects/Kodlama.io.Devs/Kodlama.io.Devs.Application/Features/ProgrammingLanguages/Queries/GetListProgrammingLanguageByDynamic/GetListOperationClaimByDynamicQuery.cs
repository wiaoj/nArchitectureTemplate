using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguageByDynamic;
public class GetListProgrammingLanguageByDynamicQuery : IRequest<ProgrammingLanguageListModel> {
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }

    public class GetListProgrammingLanguageByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageByDynamicQuery, ProgrammingLanguageListModel> {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageByDynamicQueryHandler(
            IProgrammingLanguageReadRepository programmingLanguageReadRepository,
            IMapper mapper
            ) {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageByDynamicQuery request, CancellationToken cancellationToken) {
            IPaginate<ProgrammingLanguage> programmingLanguage = await _programmingLanguageReadRepository.GetListByDynamicAsync(
                 dynamic: request.Dynamic,
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
                 );

            ProgrammingLanguageListModel mappedProgrammingLanguageModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);
            return mappedProgrammingLanguageModel;
        }
    }
}
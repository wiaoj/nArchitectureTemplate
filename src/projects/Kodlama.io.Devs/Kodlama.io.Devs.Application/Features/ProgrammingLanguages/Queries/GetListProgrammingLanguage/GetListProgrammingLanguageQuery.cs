using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel> {
    public PageRequest PageRequest { get; set; }

    internal class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel> {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(
            IProgrammingLanguageReadRepository programmingLanguageReadRepository, 
            IMapper mapper
            ) {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken) {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            ProgrammingLanguageListModel mappedProgrammingLanguageModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);

            return mappedProgrammingLanguageModel;
        }
    }
}
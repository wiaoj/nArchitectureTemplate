using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel> {
    public PageRequest PageRequest { get; set; }

    internal class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel> {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository, IMapper mapper) {
            this._programmingLanguageReadRepository = programmingLanguageReadRepository;
            this._mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken) {
            var entities = await _programmingLanguageReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            ProgrammingLanguageListModel mappedEntitiesModel = _mapper.Map<ProgrammingLanguageListModel>(entities);

            return mappedEntitiesModel;
        }
    }
}
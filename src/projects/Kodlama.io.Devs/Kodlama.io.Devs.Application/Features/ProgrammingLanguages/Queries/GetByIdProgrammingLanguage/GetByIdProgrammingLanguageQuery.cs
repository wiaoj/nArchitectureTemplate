using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto> {
    public Guid Id { get; set; }

    internal class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto> {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetByIdProgrammingLanguageQueryHandler(
            IProgrammingLanguageReadRepository programmingLanguageReadRepository,
            IMapper mapper,
            ProgrammingLanguageBusinessRules programmingLanguageBusinessRules
            ) {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken) {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageReadRepository.GetByIdAsync(request.Id, enableTracking: false);
            await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequest(programmingLanguage);
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
            return programmingLanguageGetByIdDto;
        }
    }
}
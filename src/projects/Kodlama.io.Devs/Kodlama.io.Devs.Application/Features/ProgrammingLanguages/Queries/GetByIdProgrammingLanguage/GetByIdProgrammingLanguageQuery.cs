using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.ReadRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto> {
    public Guid Id { get; set; }

    internal class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto> {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules) {
            this._programmingLanguageReadRepository = programmingLanguageReadRepository;
            this._mapper = mapper;
            this._programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken) {
            var programmingLanguage = await _programmingLanguageReadRepository.GetByIdAsync(request.Id, enableTracking: false);
            await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequest(programmingLanguage);
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
            return programmingLanguageGetByIdDto;
        }
    }
}
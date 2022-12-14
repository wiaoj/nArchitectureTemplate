using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>, ISecuredRequest {
    public String Name { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto> {
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageCommandHandler(
            IProgrammingLanguageWriteRepository programmingLanguageWriteRepository,
            IMapper mapper,
            ProgrammingLanguageBusinessRules programmingLanguageBusinessRules
            ) {
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken) {
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageWriteRepository.AddAsync(mappedProgrammingLanguage);
            CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);
            return createdProgrammingLanguageDto;
        }
    }
}
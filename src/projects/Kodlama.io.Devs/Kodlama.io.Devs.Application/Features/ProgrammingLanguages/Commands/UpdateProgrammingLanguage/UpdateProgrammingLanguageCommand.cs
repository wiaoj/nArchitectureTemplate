using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto> {
    public Guid Id { get; set; }
    public String Name { get; set; }

    internal class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto> {
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageWriteRepository programmingLanguageWriteRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules) {
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken) {
            await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequestId(request.Id);
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageWriteRepository.UpdateAsync(mappedProgrammingLanguage);
            UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);

            return updatedProgrammingLanguageDto;
        }
    }
}
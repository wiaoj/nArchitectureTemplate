using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>, ISecuredRequest {
    public Guid Id { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto> {
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public DeleteProgrammingLanguageCommandHandler(
            IProgrammingLanguageWriteRepository programmingLanguageWriteRepository, 
            IMapper mapper, 
            ProgrammingLanguageBusinessRules programmingLanguageBusinessRules
            ) {
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken) {
            await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequestId(request.Id);

            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageWriteRepository.DeleteAsync(mappedProgrammingLanguage);
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
            return deletedProgrammingLanguageDto;
        }
    }
}
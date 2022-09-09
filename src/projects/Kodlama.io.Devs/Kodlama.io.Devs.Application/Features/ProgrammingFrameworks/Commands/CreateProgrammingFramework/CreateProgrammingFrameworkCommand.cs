using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.CreateProgrammingFramework;
public class CreateProgrammingFrameworkCommand : IRequest<CreatedProgrammingFrameworkDto> {
    public String Name { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }
    public Guid ProgrammingLanguageId { get; set; }

    internal class CreateProgrammingFrameworkCommandHandler : IRequestHandler<CreateProgrammingFrameworkCommand, CreatedProgrammingFrameworkDto> {
        private readonly IProgrammingFrameworkWriteRepository _programmingFrameworkWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingFrameworkBusinessRules _programmingFrameworkBusinessRules;

        public CreateProgrammingFrameworkCommandHandler(IProgrammingFrameworkWriteRepository programmingFrameworkWriteRepository, IMapper mapper, ProgrammingFrameworkBusinessRules programmingFrameworkBusinessRules) {
            this._programmingFrameworkWriteRepository = programmingFrameworkWriteRepository;
            this._mapper = mapper;
            this._programmingFrameworkBusinessRules = programmingFrameworkBusinessRules;
        }

        public async Task<CreatedProgrammingFrameworkDto> Handle(CreateProgrammingFrameworkCommand request, CancellationToken cancellationToken) {
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkShouldExistWhenRequestProgrammingLanguageId(request.ProgrammingLanguageId);
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkVersionTagCanNotBeDuplicatedWhenInserted(request.Name, request.Version, request.Tag);

            ProgrammingFramework mappedProgrammingFramework = _mapper.Map<ProgrammingFramework>(request);
            ProgrammingFramework createdProgrammingFramework = await _programmingFrameworkWriteRepository.AddAsync(mappedProgrammingFramework);
            CreatedProgrammingFrameworkDto createdProgrammingFrameworkDto = _mapper.Map<CreatedProgrammingFrameworkDto>(createdProgrammingFramework);
            return createdProgrammingFrameworkDto;
        }
    }
}
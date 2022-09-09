﻿using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.DeleteProgrammingFramework;
public class DeleteProgrammingFrameworkCommand : IRequest<DeletedProgrammingFrameworkDto> {
    public Guid Id { get; set; }

    internal class DeleteProgrammingFrameworkCommandHandler : IRequestHandler<DeleteProgrammingFrameworkCommand, DeletedProgrammingFrameworkDto> {
        private readonly IProgrammingFrameworkWriteRepository _programmingFrameworkWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingFrameworkBusinessRules _programmingFrameworkBusinessRules;

        public DeleteProgrammingFrameworkCommandHandler(IProgrammingFrameworkWriteRepository programmingFrameworkWriteRepository, IMapper mapper, ProgrammingFrameworkBusinessRules programmingFrameworkBusinessRules) {
            this._programmingFrameworkWriteRepository = programmingFrameworkWriteRepository;
            this._mapper = mapper;
            this._programmingFrameworkBusinessRules = programmingFrameworkBusinessRules;
        }

        public async Task<DeletedProgrammingFrameworkDto> Handle(DeleteProgrammingFrameworkCommand request, CancellationToken cancellationToken) {
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkShouldExistWhenRequestId(request.Id);

            ProgrammingFramework mappedProgrammingFramework = _mapper.Map<ProgrammingFramework>(request);
            ProgrammingFramework deletedProgrammingFramework = await _programmingFrameworkWriteRepository.DeleteAsync(mappedProgrammingFramework);
            DeletedProgrammingFrameworkDto deletedProgrammingFrameworkDto = _mapper.Map<DeletedProgrammingFrameworkDto>(deletedProgrammingFramework);
            return deletedProgrammingFrameworkDto;
            ;
        }
    }

}
﻿using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Common.ValidationRulesExtension;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Rules;
using Kodlama.io.Devs.Application.Services.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.UpdateProgrammingFrameworks;
public class UpdateProgrammingFrameworkCommand : IRequest<UpdatedProgrammingFrameworkDto> {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }
    public Guid ProgrammingLanguageId { get; set; }

    internal class UpdateProgrammingFrameworkCommandHandler : IRequestHandler<UpdateProgrammingFrameworkCommand, UpdatedProgrammingFrameworkDto> {
        private readonly IProgrammingFrameworkWriteRepository _programmingFrameworkWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingFrameworkBusinessRules _programmingFrameworkBusinessRules;

        public UpdateProgrammingFrameworkCommandHandler(IProgrammingFrameworkWriteRepository programmingFrameworkWriteRepository, IMapper mapper, ProgrammingFrameworkBusinessRules programmingFrameworkBusinessRules) {
            this._programmingFrameworkWriteRepository = programmingFrameworkWriteRepository;
            this._mapper = mapper;
            this._programmingFrameworkBusinessRules = programmingFrameworkBusinessRules;
        }

        public async Task<UpdatedProgrammingFrameworkDto> Handle(UpdateProgrammingFrameworkCommand request, CancellationToken cancellationToken) {
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkShouldExistWhenRequestId(request.Id);
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkShouldExistWhenRequestProgrammingLanguageId(request.ProgrammingLanguageId);
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkVersionTagCanNotBeDuplicatedWhenInserted(request.Name, request.Version, request.Tag);

            ProgrammingFramework mappedProgrammingFramework = _mapper.Map<ProgrammingFramework>(request);
            ProgrammingFramework updatedProgrammingFramework = await _programmingFrameworkWriteRepository.UpdateAsync(mappedProgrammingFramework);
            UpdatedProgrammingFrameworkDto updatedProgrammingFrameworkDto = _mapper.Map<UpdatedProgrammingFrameworkDto>(updatedProgrammingFramework);
            return updatedProgrammingFrameworkDto;
        }
    }
}
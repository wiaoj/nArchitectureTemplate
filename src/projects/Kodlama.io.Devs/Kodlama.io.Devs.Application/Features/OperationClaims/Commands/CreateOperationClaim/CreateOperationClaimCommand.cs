using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest {
    public String Name { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto> {
        private readonly IOperationClaimWriteRepository _operationClaimWriteRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public CreateOperationClaimCommandHandler(
            IOperationClaimWriteRepository operationClaimWriteRepository,
            IMapper mapper,
            OperationClaimBusinessRules operationClaimBusinessRules
            ) {
            _operationClaimWriteRepository = operationClaimWriteRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken) {
            await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);
            OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim createdOperationClaim = await _operationClaimWriteRepository.AddAsync(mappedOperationClaim);
            CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
            return createdOperationClaimDto;
        }
    }
}
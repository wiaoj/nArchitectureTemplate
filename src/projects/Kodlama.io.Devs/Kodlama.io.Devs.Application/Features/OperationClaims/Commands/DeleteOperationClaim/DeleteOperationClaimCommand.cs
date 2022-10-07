using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest {
    public Guid Id { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto> {
        private readonly IOperationClaimWriteRepository _operationClaimWriteRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public DeleteOperationClaimCommandHandler(
            IOperationClaimWriteRepository operationClaimWriteRepository,
            IMapper mapper,
            OperationClaimBusinessRules operationClaimBusinessRules
            ) {
            _operationClaimWriteRepository = operationClaimWriteRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken) {
            await _operationClaimBusinessRules.OperationClaimShouldExistWhenRequestId(request.Id);
            OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim deletedOperationClaim = await _operationClaimWriteRepository.DeleteAsync(mappedOperationClaim);
            DeletedOperationClaimDto deletedOperationClaimDto = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
            return deletedOperationClaimDto;
        }
    }
}
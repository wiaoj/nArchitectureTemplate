using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto> {
    public Guid Id { get; set; }
    public String Name { get; set; }

    internal class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto> {
        private readonly IOperationClaimWriteRepository _operationClaimWriteRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimWriteRepository operationClaimWriteRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules) {
            _operationClaimWriteRepository = operationClaimWriteRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken) {
            await _operationClaimBusinessRules.OperationClaimShouldExistWhenRequestId(request.Id);
            await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);
            OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim updatedOperationClaim = await _operationClaimWriteRepository.UpdateAsync(mappedOperationClaim);
            UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
            return updatedOperationClaimDto;
        }
    }
}
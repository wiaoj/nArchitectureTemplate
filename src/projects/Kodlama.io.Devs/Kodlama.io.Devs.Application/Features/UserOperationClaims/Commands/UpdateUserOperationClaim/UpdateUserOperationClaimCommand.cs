using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>, ISecuredRequest {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto> {
        private readonly IUserOperationClaimWriteRepository _userOperationClaimWriteRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(
            IUserOperationClaimWriteRepository userOperationClaimWriteRepository,
            UserOperationClaimBusinessRules userOperationClaimBusinessRules,
            IMapper mapper
            ) {
            _userOperationClaimWriteRepository = userOperationClaimWriteRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken) {
            await _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequestId(request.Id);
            await _userOperationClaimBusinessRules.UserOperationClaimUserIdShouldExistWhenRequest(request.UserId);
            await _userOperationClaimBusinessRules.UserOperationClaimClaimIdShouldExistWhenRequest(request.OperationClaimId);

            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim updatedUserOperationClaim = await _userOperationClaimWriteRepository.UpdateAsync(mappedUserOperationClaim);
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
            return updatedUserOperationClaimDto;
        }
    }
}
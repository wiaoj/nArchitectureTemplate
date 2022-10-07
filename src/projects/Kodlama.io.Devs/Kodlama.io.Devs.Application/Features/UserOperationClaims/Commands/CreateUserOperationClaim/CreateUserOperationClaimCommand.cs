using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest {
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto> {
        private readonly IUserOperationClaimWriteRepository _userOperationClaimWriteRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(
            IUserOperationClaimWriteRepository userOperationClaimWriteRepository,
            IMapper mapper,
            UserOperationClaimBusinessRules userOperationClaimBusinessRules
            ) {
            _userOperationClaimWriteRepository = userOperationClaimWriteRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken) {
            await _userOperationClaimBusinessRules.UserOperationClaimUserIdShouldExistWhenRequest(request.UserId);
            await _userOperationClaimBusinessRules.UserOperationClaimClaimIdShouldExistWhenRequest(request.OperationClaimId);
            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim createdUserOperationClaim = await _userOperationClaimWriteRepository.AddAsync(mappedUserOperationClaim);
            CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return createdUserOperationClaimDto;
        }
    }
}
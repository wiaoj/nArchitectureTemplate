using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest {
    public Guid Id { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto> {
        private readonly IUserOperationClaimWriteRepository _userOperationClaimWriteRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public DeleteUserOperationClaimCommandHandler(
            IUserOperationClaimWriteRepository userOperationClaimWriteRepository, 
            UserOperationClaimBusinessRules userOperationClaimBusinessRules,
            IMapper mapper
            ) {
            _userOperationClaimWriteRepository = userOperationClaimWriteRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken) {
            await _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequestId(request.Id);

            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim deletedUserOperationClaim = await _userOperationClaimWriteRepository.AddAsync(mappedUserOperationClaim);
            DeletedUserOperationClaimDto deletedUserOperationClaimDto = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
            return deletedUserOperationClaimDto;
        }
    }
}
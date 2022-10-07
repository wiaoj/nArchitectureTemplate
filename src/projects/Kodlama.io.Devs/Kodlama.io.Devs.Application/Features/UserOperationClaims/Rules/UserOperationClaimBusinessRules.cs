using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
internal class UserOperationClaimBusinessRules {
    private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimReadRepository userOperationClaimReadRepository) {
        _userOperationClaimReadRepository = userOperationClaimReadRepository;
    }
    public async Task UserOperationClaimShouldExistWhenRequestId(Guid id) {
        _ = await _userOperationClaimReadRepository.GetByIdAsync(id, enableTracking: false)
           ?? throw new BusinessException("User operation claim not found");
    }

    public async Task UserOperationClaimUserIdShouldExistWhenRequest(Guid userId) {
        _ = await _userOperationClaimReadRepository.GetAsync(x => x.UserId.Equals(userId))
            ?? throw new BusinessException("User not found");
    }

    public async Task UserOperationClaimClaimIdShouldExistWhenRequest(Guid operationId) {
        _ = await _userOperationClaimReadRepository.GetAsync(x => x.OperationClaimId.Equals(operationId))
            ?? throw new BusinessException("User claim not found");
    }
}
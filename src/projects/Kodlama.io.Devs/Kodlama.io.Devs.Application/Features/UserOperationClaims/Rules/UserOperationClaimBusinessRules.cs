using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
internal class UserOperationClaimBusinessRules {
    private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimReadRepository userOperationClaimReadRepository) {
        _userOperationClaimReadRepository = userOperationClaimReadRepository;
    }

    public async Task UserOperationUserIdShouldExistWhenRequest(Guid userId) {
        var result = await _userOperationClaimReadRepository.GetAsync(x => x.UserId.Equals(userId));
        if(result is null) {
            throw new BusinessException("Kullanıcı id yanlış");
        }
    }

    public async Task UserOperationClaimIdShouldExistWhenRequest(Guid operationId) {
        var result = await _userOperationClaimReadRepository.GetAsync(x => x.OperationClaimId.Equals(operationId));
        if(result is null) {
            throw new BusinessException("Kullanıcı operasyon id yanlış");
        }
    }
}
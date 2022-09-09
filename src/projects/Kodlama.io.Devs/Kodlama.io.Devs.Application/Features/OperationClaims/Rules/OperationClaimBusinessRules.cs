using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
internal class OperationClaimBusinessRules {
    private readonly IOperationClaimReadRepository _operationClaimReadRepository;

    public OperationClaimBusinessRules(IOperationClaimReadRepository operationClaimReadRepository) {
        _operationClaimReadRepository = operationClaimReadRepository;
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(String name) {
        IPaginate<OperationClaim> result = await _operationClaimReadRepository.GetListAsync(x => x.Name.Equals(name), enableTracking: false);
        if(result.Items.Any())
            throw new BusinessException("Operation claim name exists.");
    }

    public async Task OperationClaimShouldExistWhenRequestId(Guid id) {
        OperationClaim? programmingLanguage = await _operationClaimReadRepository.GetByIdAsync(id, enableTracking: false);
        if(programmingLanguage is null)
            throw new BusinessException("Operation claim does not exists.");
    }
}
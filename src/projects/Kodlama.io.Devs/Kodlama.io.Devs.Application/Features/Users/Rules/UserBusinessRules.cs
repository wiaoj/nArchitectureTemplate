using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

namespace Kodlama.io.Devs.Application.Features.Users.Rules;
internal class UserBusinessRules {
    private readonly IUserReadRepository _userReadRepository;

    public UserBusinessRules(IUserReadRepository userReadRepository) {
        _userReadRepository = userReadRepository;
    }
    public async Task UserShouldExistWhenRequestId(Guid id) {
        _ = await _userReadRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new BusinessException("User not found");
    }
}
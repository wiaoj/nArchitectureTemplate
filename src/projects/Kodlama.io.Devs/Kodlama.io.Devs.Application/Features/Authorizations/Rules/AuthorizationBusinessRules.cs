using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Rules;
internal class AuthorizationBusinessRules {

    private readonly IUserReadRepository _userReadRepository;

    public AuthorizationBusinessRules(IUserReadRepository userReadRepository) {
        _userReadRepository = userReadRepository;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegistered(String email) {
        ApplicationUser? user = await _userReadRepository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        if(user is not null)
            throw new BusinessException("Mail already exists");
    }

    public Task UserShouldBeExists(ApplicationUser? user) {
        _ = user ?? throw new BusinessException("User not found");
        return Task.CompletedTask;
    }

    public Task UserPasswordShouldBeMatch(ApplicationUser user, String password) {
        if(HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) is false)
            throw new BusinessException("Password is wrong");
        return Task.CompletedTask;
    }
}
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Rules;
internal class AuthorizationBusinessRules {

    private readonly IUserReadRepository _userReadRepository;

    public AuthorizationBusinessRules(IUserReadRepository userReadRepository) {
        this._userReadRepository = userReadRepository;
    }

    public async Task UserEmailShouldBeNotExists(String email) {
        User? user = await _userReadRepository.GetAsync(u => u.Email.Equals(email));
        if(user is not null)
            throw new BusinessException("User mail already exists");
    }

    public async Task UserShouldBeExists(User? user) {
        if(user is null)
            throw new BusinessException("User not found");
    }

    public async Task UserPasswordShouldBeMatch(Guid id, String password) {
        User? user = await _userReadRepository.GetAsync(u => u.Id == id);
        if(HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) is false)
            throw new BusinessException("Password is wrong");

    }
}
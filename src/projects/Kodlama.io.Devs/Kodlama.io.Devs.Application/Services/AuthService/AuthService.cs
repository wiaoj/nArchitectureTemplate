using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Services.AuthService;

public class AuthService : IAuthService {
    private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
    private readonly IUserOperationClaimWriteRepository _userOperationClaimWriteRepository;
    private readonly IOperationClaimReadRepository _operationClaimReadRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;

    public AuthService(
        IUserOperationClaimReadRepository userOperationClaimReadRepository,
        IUserOperationClaimWriteRepository userOperationClaimWriteRepository,
        IOperationClaimReadRepository operationClaimReadRepository,
        ITokenHelper tokenHelper,
        IRefreshTokenWriteRepository refreshTokenWriteRepository
        ) {
        _userOperationClaimReadRepository = userOperationClaimReadRepository;
        _userOperationClaimWriteRepository = userOperationClaimWriteRepository;
        _operationClaimReadRepository = operationClaimReadRepository;
        _tokenHelper = tokenHelper;
        _refreshTokenWriteRepository = refreshTokenWriteRepository;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken) => await _refreshTokenWriteRepository.AddAsync(refreshToken);

    public async Task<AccessToken> CreateAccessToken(User user) {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimReadRepository.GetListAsync(
                userOperationClaim => userOperationClaim.UserId.Equals(user.Id),
                include: userOperationClaim => userOperationClaim.Include(x => x.OperationClaim));

        IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(
            userOperationClaim => new OperationClaim {
                Id = userOperationClaim.OperationClaim.Id,
                Name = userOperationClaim.OperationClaim.Name
            }).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public async Task<RefreshToken> CreateRefreshToken(User user, String ipAddress) {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return await Task.FromResult(refreshToken);
    }

    public async Task CreateUserClaim(User user) {
        OperationClaim? operationClaim = await _operationClaimReadRepository.GetAsync(x => x.Name.Equals("User"));

        await _userOperationClaimWriteRepository.AddAsync(new() {
            UserId = user.Id,
            OperationClaimId = operationClaim.Id
        });
    }
}
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Kodlama.io.Devs.Application.Features.Authorizations.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Queries.Login;
public class LoginQuery : IRequest<LoginedDto> {
    public UserForLoginDto Login { get; set; }
    public String IpAddress { get; set; }

    internal class LoginQueryHandler : IRequestHandler<LoginQuery, LoginedDto> {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        private readonly AuthorizationBusinessRules _authorizationBusinessRules;
        private readonly IAuthService _authService;

        public LoginQueryHandler(
            IUserReadRepository userReadRepository,
            IMapper mapper,
            AuthorizationBusinessRules authorizationBusinessRules,
            IAuthService authService
            ) {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
            _authorizationBusinessRules = authorizationBusinessRules;
            _authService = authService;
        }

        public async Task<LoginedDto> Handle(LoginQuery request, CancellationToken cancellationToken) {
            ApplicationUser? user = await _userReadRepository.GetAsync(
                user => user.Email.ToLower().Equals(request.Login.Email.ToLower())
                );
            await _authorizationBusinessRules.UserShouldBeExists(user);
            await _authorizationBusinessRules.UserPasswordShouldBeMatch(user, request.Login.Password);

            AccessToken accessToken = await _authService.CreateAccessToken(user);
            //AccessTokenDto mappedAccessToken = _mapper.Map<AccessTokenDto>(accessToken);

            RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);
            //RefreshTokenDto mappedRefreshToken = _mapper.Map<RefreshTokenDto>(addedRefreshToken);
            return new() {
                AccessToken = accessToken,
                RefreshToken = addedRefreshToken
            };
        }
    }
}
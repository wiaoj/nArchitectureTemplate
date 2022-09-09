using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.Authorizations.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register;
public class RegisterCommand : IRequest<RegisteredDto> {
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public String IpAddress { get; set; }

    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto> {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;
        private readonly AuthorizationBusinessRules _authorizationBusinessRules;
        private readonly IAuthService _authService;

        public RegisterCommandHandler(
            IUserWriteRepository userWriteRepository,
            IMapper mapper,
            AuthorizationBusinessRules authorizationBusinessRules,
            IAuthService authService
            ) {
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
            _authorizationBusinessRules = authorizationBusinessRules;
            _authService = authService;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken) {

            await _authorizationBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out Byte[] passwordHash, out Byte[] passwordSalt);

            User user = new() {
                Email = request.UserForRegisterDto.Email,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AuthenticatorType = Core.Security.Enums.AuthenticatorType.None
            };

            User addedUser = await _userWriteRepository.AddAsync(user);

            AccessToken accessToken = await _authService.CreateAccessToken(addedUser);
            AccessTokenDto mappedAccessToken = _mapper.Map<AccessTokenDto>(accessToken);

            RefreshToken refreshToken = await _authService.CreateRefreshToken(addedUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);
            RefreshTokenDto mappedRefreshToken = _mapper.Map<RefreshTokenDto>(addedRefreshToken);
            return new() {
                AccessToken = mappedAccessToken,
                RefreshToken = mappedRefreshToken
            };
        }
    }
}
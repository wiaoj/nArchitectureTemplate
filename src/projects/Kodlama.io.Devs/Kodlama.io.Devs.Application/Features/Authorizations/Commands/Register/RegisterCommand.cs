using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Kodlama.io.Devs.Application.Features.Authorizations.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register;
public class RegisterCommand : IRequest<RegisteredDto> {
    public UserForRegisterDto Register { get; set; }
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

            await _authorizationBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.Register.Email);

            HashingHelper.CreatePasswordHash(request.Register.Password, out Byte[] passwordHash, out Byte[] passwordSalt);

            ApplicationUser user = new() {
                Email = request.Register.Email,
                FirstName = request.Register.FirstName,
                LastName = request.Register.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AuthenticatorType = Core.Security.Enums.AuthenticatorType.None
            };

            ApplicationUser createdUser = await _userWriteRepository.AddAsync(user);

            await _authService.CreateUserClaim(user);
            //kullanıcı yetkisi eklenecek
            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            return new() {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };
        }
    }
}
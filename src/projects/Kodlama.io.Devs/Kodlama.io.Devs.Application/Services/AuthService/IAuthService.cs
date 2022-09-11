﻿using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Services.AuthService;
public interface IAuthService {
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user, String ipAddress);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    public Task CreateUserClaim(User user);
}
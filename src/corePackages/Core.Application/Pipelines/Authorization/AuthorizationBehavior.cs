using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>, ISecuredRequest {
	private readonly IHttpContextAccessor _httpContextAccessor;

	public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor) {
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
										RequestHandlerDelegate<TResponse> next) {
		List<String>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

		if(roleClaims is null)
			throw new AuthorizationException("Claims not found.");

		Boolean isNotMatchedARoleClaimWithRequestRoles =
			roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role.Equals(roleClaim))).IsNullOrEmpty();
		if(isNotMatchedARoleClaimWithRequestRoles)
			throw new AuthorizationException("You are not authorized.");

		TResponse response = await next();
		return response;
	}
}
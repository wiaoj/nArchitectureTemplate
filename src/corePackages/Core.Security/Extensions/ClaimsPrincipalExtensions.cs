using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimsPrincipalExtensions {
    public static List<String>? Claims(this ClaimsPrincipal claimsPrincipal, String claimType) {
        List<String>? result = claimsPrincipal?.FindAll(claimType)?.Select(claim => claim.Value).ToList();
        return result;
    }

    public static List<String>? ClaimRoles(this ClaimsPrincipal claimsPrincipal) {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }

    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal) {
        return Guid.Parse(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
    }
}
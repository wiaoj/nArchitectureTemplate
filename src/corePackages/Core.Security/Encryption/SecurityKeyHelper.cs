using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption;

public class SecurityKeyHelper {
	public static SecurityKey CreateSecurityKey(String securityKey) {
		return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
	}
}
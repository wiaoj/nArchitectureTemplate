using System.Security.Cryptography;

namespace Core.Security.EmailAuthenticator;

public class EmailAuthenticatorHelper : IEmailAuthenticatorHelper {
	public Task<String> CreateEmailActivationKey() {
		String key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
		return Task.FromResult(key);
	}

	public Task<String> CreateEmailActivationCode() {
		String code = RandomNumberGenerator.GetInt32(Convert.ToInt32(Math.Pow(10, 6))).ToString().PadLeft(6, '0');
		return Task.FromResult(code);
	}
}
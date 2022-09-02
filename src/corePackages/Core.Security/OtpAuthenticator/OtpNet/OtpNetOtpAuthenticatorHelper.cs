using OtpNet;

namespace Core.Security.OtpAuthenticator.OtpNet;

public class OtpNetOtpAuthenticatorHelper : IOtpAuthenticatorHelper {
	public Task<Byte[]> GenerateSecretKey() {
		Byte[] key = KeyGeneration.GenerateRandomKey(20);

		String base32String = Base32Encoding.ToString(key);
		Byte[] base32Bytes = Base32Encoding.ToBytes(base32String);

		return Task.FromResult(base32Bytes);
	}

	public Task<String> ConvertSecretKeyToString(Byte[] secretKey) {
		string base32String = Base32Encoding.ToString(secretKey);
		return Task.FromResult(base32String);
	}

	public Task<Boolean> VerifyCode(Byte[] secretKey, String code) {
		Totp totp = new(secretKey);

		String totpCode = totp.ComputeTotp(DateTime.UtcNow);

		Boolean result = totpCode.Equals(code);

		return Task.FromResult(result);
	}
}
namespace Core.Security.OtpAuthenticator;

public interface IOtpAuthenticatorHelper {
	public Task<Byte[]> GenerateSecretKey();
	public Task<String> ConvertSecretKeyToString(Byte[] secretKey);
	public Task<Boolean> VerifyCode(Byte[] secretKey, String code);
}
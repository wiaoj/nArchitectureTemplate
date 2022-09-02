namespace Core.Security.EmailAuthenticator;

public interface IEmailAuthenticatorHelper {
	public Task<String> CreateEmailActivationKey();
	public Task<String> CreateEmailActivationCode();
}
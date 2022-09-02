namespace Core.CrossCuttingConcerns.Exceptions;

public class AuthorizationException : Exception {
	public AuthorizationException(String message) : base(message) { }
}
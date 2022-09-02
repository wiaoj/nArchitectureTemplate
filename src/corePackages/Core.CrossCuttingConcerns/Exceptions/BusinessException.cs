namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessException : Exception {
	public BusinessException(String message) : base(message) { }
}
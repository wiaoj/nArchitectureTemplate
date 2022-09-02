using FluentValidation;
using FluentValidation.Results;

namespace Core.Application.Pipelines.Validation;

public class ValidationTool {
	public static void Validate(IValidator validator, Object entity) {
		ValidationContext<Object> context = new(entity);
		ValidationResult result = validator.Validate(context);
		if(result.IsValid is false) //TODO: !result.IsValid
			throw new ValidationException(result.Errors);
	}
}
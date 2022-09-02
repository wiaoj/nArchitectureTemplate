using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ValidationProblemDetails : ProblemDetails {
	public Object Errors { get; set; }

	public override String ToString() {
		return JsonConvert.SerializeObject(this);
	}
}
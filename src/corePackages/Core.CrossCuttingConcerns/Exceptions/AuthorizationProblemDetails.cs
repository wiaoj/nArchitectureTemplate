using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class AuthorizationProblemDetails : ProblemDetails {
	public override String ToString() {
		return JsonConvert.SerializeObject(this);
	}
}
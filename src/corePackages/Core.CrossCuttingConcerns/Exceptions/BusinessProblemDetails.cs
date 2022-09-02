using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessProblemDetails : ProblemDetails {
	public override String ToString() {
		return JsonConvert.SerializeObject(this);
	}
}
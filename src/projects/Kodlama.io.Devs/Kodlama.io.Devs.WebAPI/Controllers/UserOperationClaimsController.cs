using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatedUserOperationClaimDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand) {
        var result = await Mediator.Send(createUserOperationClaimCommand);
        return Created("", result);
    }
}
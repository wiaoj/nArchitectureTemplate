using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatedOperationClaimDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand) {
        var result = await Mediator.Send(createOperationClaimCommand);
        return Created("", result);
    }
}
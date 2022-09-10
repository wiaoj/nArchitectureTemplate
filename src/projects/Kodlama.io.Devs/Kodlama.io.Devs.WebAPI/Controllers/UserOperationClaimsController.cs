using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaimByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserUserOperationClaimsController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatedUserOperationClaimDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserUserOperationClaimCommand) {
        var result = await Mediator.Send(createUserUserOperationClaimCommand);
        return Created("", result);
    }


    [HttpDelete("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DeletedUserOperationClaimDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand) {
        var result = await Mediator.Send(deleteUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdatedUserOperationClaimDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand) {
        var result = await Mediator.Send(updateUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserOperationClaimListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic) {
        GetListUserOperationClaimByDynamicQuery getListUserOperationClaimByDynamicQuery = new() {
            PageRequest = pageRequest,
            Dynamic = dynamic
        };
        UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimByDynamicQuery);
        return Ok(result);
    }
}
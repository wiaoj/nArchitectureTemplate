using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaimByDynamic;
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


    [HttpDelete("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DeletedOperationClaimDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand) {
        var result = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdatedOperationClaimDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand) {
        var result = await Mediator.Send(updateOperationClaimCommand);
        return Ok(result);
    }

    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(OperationClaimListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic) {
        GetListOperationClaimByDynamicQuery getListOperationClaimByDynamicQuery = new() {
            PageRequest = pageRequest,
            Dynamic = dynamic
        };
        OperationClaimListModel result = await Mediator.Send(getListOperationClaimByDynamicQuery);
        return Ok(result);
    }

    [HttpGet("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(OperationClaimListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest) {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }
}
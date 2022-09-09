using Microsoft.AspNetCore.Mvc;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Queries.GetByIdProgrammingFramework;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Queries.GetListProgrammingFrameworkByDynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.CreateProgrammingFramework;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.UpdateProgrammingFramework;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.DeleteProgrammingFramework;
using Core.Persistence.Dynamic;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingFrameworksController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatedProgrammingFrameworkDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingFrameworkCommand createProgrammingFrameworkCommand) {
        var result = await Mediator.Send(createProgrammingFrameworkCommand);
        return Created("", result);
    }

    [HttpDelete("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DeletedProgrammingFrameworkDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingFrameworkCommand deleteProgrammingFrameworkCommand) {
        var result = await Mediator.Send(deleteProgrammingFrameworkCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdatedProgrammingFrameworkDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingFrameworkCommand updateProgrammingFrameworkCommand) {
        var result = await Mediator.Send(updateProgrammingFrameworkCommand);
        return Ok(result);
    }


    /*
    {
        "sort": [
            {
                "field": "tag",
                "dir": "asc"
            }
        ],
        "filter": {
            "field": "tag",
            "operator": "eq",
            "value": "latest",
            "logic": "or",
            "filters": [
                {
                    "field": "version",
                    "operator": "gte",
                    "value": "13"
                }
            ]
        }
    }
    */


    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProgrammingFrameworkListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic) {
        GetListProgrammingFrameworkByDynamicQuery getListProgrammingFrameworkByDynamicQuery = new() { 
            PageRequest = pageRequest,
            Dynamic = dynamic
        };
        ProgrammingFrameworkListModel result = await Mediator.Send(getListProgrammingFrameworkByDynamicQuery);
        return Ok(result);
    }

    [HttpGet("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProgrammingFrameworkGetByIdDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingFrameworkQuery getByIdProgrammingFrameworkQuery) {
        return Ok(await Mediator.Send(getByIdProgrammingFrameworkQuery));
    }
}
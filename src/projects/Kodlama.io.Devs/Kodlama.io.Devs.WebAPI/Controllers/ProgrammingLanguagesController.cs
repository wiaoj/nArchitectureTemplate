using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatedProgrammingLanguageDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand) {
        var result = await Mediator.Send(createProgrammingLanguageCommand);
        return Created("", result);
    }

    [HttpDelete("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DeletedProgrammingLanguageDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand) {
        var result = await Mediator.Send(deleteProgrammingLanguageCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdatedProgrammingLanguageDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand) {
        var result = await Mediator.Send(updateProgrammingLanguageCommand);
        return Ok(result);
    }

    [HttpGet("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProgrammingLanguageListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest) {
        GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
        ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
        return Ok(result);
    }

    [HttpGet("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProgrammingLanguageGetByIdDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery) {
        return Ok(await Mediator.Send(getByIdProgrammingLanguageQuery));
    }
}
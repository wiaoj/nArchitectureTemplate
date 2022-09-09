using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.SocialLinks.Commands.CreateSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Commands.DeleteSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Commands.UpdateSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.SocialLinks.Models;
using Kodlama.io.Devs.Application.Features.SocialLinks.Queries.GetListSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Queries.GetListSocialLinkByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialLinksController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatedSocialLinkDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] CreateSocialLinkCommand createSocialLinkCommand) {
        var result = await Mediator.Send(createSocialLinkCommand);
        return Created("", result);
    }


    [HttpDelete("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DeletedSocialLinkDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] DeleteSocialLinkCommand deleteSocialLinkCommand) {
        var result = await Mediator.Send(deleteSocialLinkCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdatedSocialLinkDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateSocialLinkCommand updateSocialLinkCommand) {
        var result = await Mediator.Send(updateSocialLinkCommand);
        return Ok(result);
    }


    [HttpGet("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SocialLinkListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest) {
        GetListSocialLinkQuery getListSocialLinkQuery = new() { PageRequest = pageRequest };
        SocialLinkListModel result = await Mediator.Send(getListSocialLinkQuery);
        return Ok(result);
    }


    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SocialLinkListModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic) {
        GetListSocialLinkByDynamicQuery getListSocialLinkByDynamicQuery = new() {
            PageRequest = pageRequest,
            Dynamic = dynamic
        };
        SocialLinkListModel result = await Mediator.Send(getListSocialLinkByDynamicQuery);
        return Ok(result);
    }
}
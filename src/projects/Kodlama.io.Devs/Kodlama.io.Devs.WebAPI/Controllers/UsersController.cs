using Kodlama.io.Devs.Application.Features.Users.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.Users.Queries.GetByIdUser;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController {
    [HttpGet("[action]/{Id:Guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserGetByIdDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery) {
        return Ok(await Mediator.Send(getByIdUserQuery));
    }
}
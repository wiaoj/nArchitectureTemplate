using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.Authorizations.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthsController : BaseController {
    protected String? getIpAddress() {
        if(Request.Headers.ContainsKey("X-Forwarded-For")) {
            return Request.Headers["X-Forwarded-For"];
        }
        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RegisteredDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto) {
        RegisteredDto registeredDto = await Mediator.Send(
            new RegisterCommand {
                Register = userForRegisterDto,
                IpAddress = getIpAddress()
            });
        return Created("", registeredDto);
    }

    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RegisteredDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto) {
        LoginedDto loginedDto = await Mediator.Send(
            new LoginQuery {
                Login = userForLoginDto,
                IpAddress = getIpAddress()
            });
        return Ok(loginedDto);
    }
}
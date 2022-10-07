using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Kodlama.io.Devs.Application.Features.Authorizations.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : BaseController {
    

    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(AccessToken), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto) {
        RegisteredDto result = await Mediator.Send(
            new RegisterCommand {
                Register = userForRegisterDto,
                IpAddress = GetIpAddress()
            });
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }

    [HttpPost("[action]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(AccessToken), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto) {
        LoginedDto result = await Mediator.Send(
            new LoginQuery {
                Login = userForLoginDto,
                IpAddress = GetIpAddress()
            });

        SetRefreshTokenToCookie(result.RefreshToken);
        return Ok(result.AccessToken);
    }

    private void SetRefreshTokenToCookie(RefreshToken refreshToken) {
        CookieOptions cookieOptions = new() {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}
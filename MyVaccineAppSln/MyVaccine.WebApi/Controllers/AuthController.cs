using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyVaccine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(UserManager<IdentityUser> userManager, IUserService userService)
    {
        _userService = userService;


    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterRequetDto model)
    {

        var reponse = await _userService.AddUserAsync(model);
        if (reponse.IsSucess)
        {
            return Ok(reponse);
        }
        else
        {
            return BadRequest(reponse);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        var reponse = await _userService.Login(model);
        if (reponse.IsSucess)
        {
            return Ok(reponse);
        }
        else
        {
            return Unauthorized(reponse);
        }
    }

    [Authorize]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] LoginRequestDto model)
    {
    var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        var reponse = await _userService.RefreshToken(claimsIdentity.Name);
        if (reponse.IsSucess)
        {
            return Ok(reponse);
        }
        else
        {
            return Unauthorized(reponse);
        }
    }

    [Authorize]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        var reponse = await _userService.GetUserInfo(claimsIdentity.Name);
       
            return Ok(reponse);
       
    }

}
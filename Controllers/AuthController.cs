using dotnetapi.Interfaces;
using dotnetapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin)
    {
        var response = await _authService.Login(userLogin);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserResponseViewModel userRegister)
    {
        var response = await _authService.Register(userRegister);
        return Ok(response);
    }

}

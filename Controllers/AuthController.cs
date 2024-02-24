using dotnetapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(UserResponseViewModel userRegister)
    {
        return Ok();
    }

}

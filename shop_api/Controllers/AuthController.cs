using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    public readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = await _service.RegisterAsync(request);
        if(user == null)
        {
            throw new Exception("An error has occured");
        }

        return CreatedAtAction(nameof(Me), new {id = user.Id}, user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _service.LoginAsync(request);
        return CreatedAtAction(user.Username, user);
    }

    [HttpGet]  
    [Authorize]
    public async Task<IActionResult> Me()
    {
        var id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var user = await _service.UserAsync(id);
        return Ok(user);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        await _service.ChangePasswordAsync(id, request);
        return NoContent();
    }

}
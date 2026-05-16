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
        return CreatedAtAction(string.Empty, new {id = user.Id}, user); // replace with Me method once implemented
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _service.LoginAsync(request);
        return CreatedAtAction(user.Username, user);
    }

}


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        
    }

}


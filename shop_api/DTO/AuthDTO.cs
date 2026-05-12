public class RegisterRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Password { get; set; }
    public string Email { get; set; }
}

public class RegisterResponse
{
    public Guid Id {get; set;}
    public string Email {get; set;}
    public string Username {get; set;}
}

public class LoginResponse
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public UserRole Role { get; set; }
    public DateTime ExpiresAt { get; set; }
}
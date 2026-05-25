public class RegisterRequest
{
    public string Email { get; set; }  = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginRequest
{
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class RegisterResponse
{
    public Guid Id {get; set;}
    public string Email {get; set;} = string.Empty;
    public string Username {get; set;} = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public DateTime ExpiresAt { get; set; }
}

public class UserResponse
{
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class ChangePasswordRequest
{
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
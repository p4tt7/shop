public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Password {get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public UserRole Role { get; set; } = UserRole.Costumer;
}

public enum UserRole
{
    Costumer,
    Admin
}
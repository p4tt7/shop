using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    public readonly IAuthRepository _repo;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository repo, IConfiguration configuration)
    {
        _repo = repo;
        _configuration = configuration;
    }

    public async Task<RegisterResponse?> RegisterAsync (RegisterRequest request)
    {
        string password = request.Password;
        var hashed_pw = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            Email = request.Email,
            Username = request.Username,
            Password = hashed_pw
        };

        var saved_user = await _repo.RegisterAsync(user);
    
        return new RegisterResponse
        {
            Id = saved_user.Id,
            Email = saved_user.Email,
            Username = saved_user.Username,
        };
    }

    public async Task<LoginResponse> LoginAsync (LoginRequest request)
    {
        var user = await _repo.GetByEmailAsync(request.Email);
        
        bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if(!isValid) throw new Exception("Wrong password");

        var token = GenerateToken(user);

        return new LoginResponse
        {
            Token = token,
            Email = user.Email,
            Username = user.Username,
            ExpiresAt = DateTime.UtcNow.AddHours(24)
        };
    }

    public async Task<UserResponse> UserAsync(Guid id)
    {
        var user = await _repo.GetByIdAsync(id);

        var user_response = new UserResponse
        {
            Username = user.Username,
            CreatedAt = user.CreatedAt,
            Email = user.Email 
        };

        return user_response;
    }

    public async Task ChangePasswordAsync(Guid id, ChangePasswordRequest request)
    {
        var user = await _repo.GetByIdAsync(id);

        bool valid = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Password);
        if(!valid) throw new Exception("Incorrect password");

        user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        await _repo.UpdateUser(user);
    }

    private string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt__Secret"]!));

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            claims : claims,
            expires : DateTime.UtcNow.AddHours(24),
            signingCredentials : new SigningCredentials(key, SecurityAlgorithms.HmacSha256) 
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}

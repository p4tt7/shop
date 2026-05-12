using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

public interface IAuthService
{
    Task<RegisterResponse?> RegisterAsync (RegisterRequest request);
    Task<LoginResponse> LoginAsync (LoginRequest request);
}
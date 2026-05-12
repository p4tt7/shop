using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

public interface IAuthRepository
{
    Task<User> RegisterAsync (RegisterRequest request);
    Task<User> LoginAsync (LoginRequest request);
}
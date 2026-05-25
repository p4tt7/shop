using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

public interface IAuthRepository
{
    Task<User> RegisterAsync (User user);
    Task<User> GetByEmailAsync (String email);
    Task<User> GetByIdAsync (Guid id);
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

public interface IAuthRepository
{
    Task<User> RegisterAsync (User user);
    Task<User> GetByEmailAsync (string email);
    Task<User> GetByIdAsync (Guid id);
    Task UpdateUser(User mod_user);
}
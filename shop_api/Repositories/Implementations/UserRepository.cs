using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IAuthRepository
{
    private readonly ShopDbContext _db;

    public UserRepository(ShopDbContext db)
    {
        _db = db;
    }

    public async Task<User> RegisterAsync(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetByEmailAsync(String email)
    {
        var user = await _db.Users.FirstOrDefaultAsync(p => p.Email == email);
        if(user == null) throw new Exception("Email is not registered");
        return user;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);
        if(user == null) throw new Exception("User does not exist");
        return user;
    }

}
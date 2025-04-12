using Lans.Core.Services.Interfaces;
using Lans.DataLayer.Context;
using Lans.DataLayer.Entities.User;

namespace Lans.Core.Services;

public class UserService : IUserService
{
    private readonly LansDbContext _context;

    public UserService(LansDbContext context)
    {
        _context = context;
    }

    public int InsertUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.UserId;
    }

    public bool IsEmailExist(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public bool IsUserNameExist(string username)
    {
        return _context.Users.Any(u => u.UserName == username);
    }
}

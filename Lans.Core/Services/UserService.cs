using Lans.Core.Convertors;
using Lans.Core.DTOs;
using Lans.Core.Generators;
using Lans.Core.Security;
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

    public bool ActiveAccount(string activationCode)
    {
        var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activationCode);
        if (user is null || user.IsActive)
            return false;

        user.IsActive = true;
        user.ActiveCode = Generator.GenerateActivationCode();
        _context.SaveChanges();
        return true;
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

    public User LoginUser(LoginViewModel login)
    {
        string pass = PasswordHelpers.EncodePasswordMD5(login.Password);
        string email = FixedString.FixEmailString(login.Email);

        return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == pass)!;
    }
}

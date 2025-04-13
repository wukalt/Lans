using Lans.Core.DTOs;
using Lans.DataLayer.Entities.User;

namespace Lans.Core.Services.Interfaces;

public interface IUserService
{
    bool IsUserNameExist(string username);
    bool IsEmailExist(string email);
    int InsertUser(User user);
    User LoginUser(LoginViewModel login);
    bool ActiveAccount(string activationCode);
}

using Lans.Core.Convertors;
using Lans.Core.DTOs;
using Lans.Core.Generators;
using Lans.Core.Security;
using Lans.Core.Services.Interfaces;
using Lans.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace Lans.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("UserName", "اطلاعات وارد شده صحیح نمیباشد");
                return View(register);
            }

            if (_userService.IsUserNameExist(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام وارد شده تکراری میباشد. نام دیگری انتخاب کنید");
                return View(register);
            }

            if (_userService.IsEmailExist(FixedString.FixEmailString(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده تکراری میباشد");
                return View(register);
            }

            User user = new()
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = PasswordHelpers.EncodePasswordMD5(register.Password),
                RegisterDate = DateTime.Now,
                ActiveCode = Generator.GenerateActivationCode(),
                IsActive = false,
                UserAvatar = "DefaultAvatar"
            };

            _userService.InsertUser(user);


            return View("SuccessfulRegister", user);
        }

        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        #endregion
    }
}

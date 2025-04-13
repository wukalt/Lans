using System.Security.Claims;
using Lans.Core.Convertors;
using Lans.Core.DTOs;
using Lans.Core.Generators;
using Lans.Core.Security;
using Lans.Core.Services.Interfaces;
using Lans.DataLayer.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.LoginUser(login);
            if (user is not null)
            {
                if (user.IsActive)
                {
                    var claimes = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    var identity = new ClaimsIdentity(claimes, CookieAuthenticationDefaults.AuthenticationScheme);
                    var pricipal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = login.RemmemberMe
                    };

                    HttpContext.SignInAsync(pricipal, properties);
                    ViewBag.IsSuccess = true;

                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمیباشد.");
                }
            }

            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده پیدا نشد");
            return View(login);
        }

        #endregion

        #region ActiveAccount 

        public IActionResult ActivateAccount(string id)
        {
            ViewBag.isActive = _userService.ActiveAccount(id);
            return View();
        }

        #endregion

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Register");
        }
    }
}

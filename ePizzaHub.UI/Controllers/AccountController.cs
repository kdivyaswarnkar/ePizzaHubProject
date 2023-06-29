
using ePizzaHub.Models;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace ePizzaHub.UI.Controllers
{
    public class AccountController : Controller
    {
        IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService =authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        async void GenerateTicket(UserModel user)
        {
            string strData = JsonSerializer.Serialize(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(",",user.Roles)),
                new Claim(ClaimTypes.UserData, strData)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model,string returnUrl)
        {
            UserModel user = _authService.ValidateUser(model.Email, model.Password);
            if(user!=null)
            {
                GenerateTicket(user);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new {area="Admin"});
                }
                else if (user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "User" });
                }
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult UnAuthorize()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
   
}

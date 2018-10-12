using System.Collections.Generic;
using System.Security.Claims;
using Latihan.Data;
using Latihan.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Latihan.Web.Controllers
{
    public class AccountController : Controller
    {

        private DataAccess da;

        public AccountController(DataAccess dataAccess)
        {
            this.da = dataAccess;
        }

        #region login

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginViewModel, string returnurl)
        {
            if (ModelState.IsValid)
            {
                var user = da.ValidateLogin(loginViewModel.UserName, loginViewModel.Password);
                if (user != null)
                {
                    List<Claim> id = new List<Claim>();
                    id.Add(new Claim(ClaimTypes.Name, loginViewModel.UserName));
                    id.Add(new Claim(ClaimTypes.NameIdentifier, user.email));
                    id.Add(new Claim(ClaimTypes.Email, user.email));
                    id.Add(new Claim(ClaimTypes.IsPersistent, loginViewModel.RememberMe.ToString()));
                    id.Add(new Claim(ClaimTypes.Actor, loginViewModel.UserName));

                    // cuman demo, default role adalah user dan reguler.
                    var roles = new string[] { "user", "reguler" };
                    foreach (var r in roles)
                    {
                        id.Add(new Claim(ClaimTypes.Role, r));
                    }
                    ClaimsIdentity ids = new ClaimsIdentity(id, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.NameIdentifier, ClaimTypes.Role);
                    ids.AddClaim(new Claim(ClaimTypes.Actor, loginViewModel.UserName));


                    var principal = new ClaimsPrincipal(ids);

                    var props = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                    {
                        IsPersistent = loginViewModel.RememberMe
                    };
                    if (returnurl != null || !string.IsNullOrEmpty(returnurl))
                    {
                        props.RedirectUri = returnurl;
                    }
                    var s = SignIn(principal, CookieAuthenticationDefaults.AuthenticationScheme);
                    s.Properties = props;
                    return s;
                }
            }

            return View(loginViewModel);
        }

        #endregion


        [HttpPost]
        public IActionResult Logout(LoginViewModel loginViewModel)
        {
            var sr = SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
            sr.Properties = new AuthenticationProperties{ RedirectUri="/" };
            return sr;
        }

        public IActionResult Denied()
        {
            return View();
        }

    }

}
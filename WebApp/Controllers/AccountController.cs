using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;

namespace WebApp
{
    public class AccountController : Controller
    {
        private readonly AccountManager accountManager;

        public AccountController(IRepository repository)
        {
            accountManager = new AccountManager(repository);
        }
       
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("signup")]
        //dsf
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginRequest loginRequest)
        {
           var loginResponse= accountManager.LogIn(loginRequest);
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(AppClaimTypes.UserId, loginResponse.Id.ToString()));
            identity.AddClaim(new Claim(AppClaimTypes.UserName, loginResponse.UserName));
            identity.AddClaim(new Claim(AppClaimTypes.UserEmail, loginResponse.Email));
            identity.AddClaim(new Claim(AppClaimTypes.PhoneNo, loginResponse.PhoneNo));
            identity.AddClaim(new Claim(AppClaimTypes.UserRole, loginResponse.UserRole.ToString()));

            ClaimsPrincipal principal= new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = loginRequest.RememberMe,
                ExpiresUtc = DateTime.Now.AddMinutes(60),
            }) ;


            return View();
        }
    }
}

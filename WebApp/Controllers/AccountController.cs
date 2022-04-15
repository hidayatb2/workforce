using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;
using System.Security.Claims;

namespace WebApp
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IRepository repository;
        private readonly AccountManager accountManager;
        private readonly IEmailService emailService;

        public AccountController(IRepository repository,IEmailService emailService)
        {
            accountManager = new AccountManager(repository,emailService);
            this.emailService = emailService;
            this.repository = repository;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("signup")]
        public IActionResult SignUp(SignupRequest signupRequest)
        {
            if (ModelState.IsValid)
            {
                var returnValue = accountManager.Add(signupRequest);
                if (returnValue > 0)
                    ViewBag.Message = 1;
                else
                    ViewBag.Message = 0;
            }
                return View();
            
        }

        [HttpGet("login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginRequest loginRequest)
        {

            if (ModelState.IsValid)
            {
                var loginResponse = accountManager.LogIn(loginRequest);

            if (loginResponse.UserStatus != UserStatus.Inactive && loginResponse.UserStatus != null)
            {


                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(AppClaimTypes.UserId, loginResponse.Id.ToString()));
                identity.AddClaim(new Claim(AppClaimTypes.UserName, loginResponse.UserName));
                identity.AddClaim(new Claim(AppClaimTypes.Email, loginResponse.Email));
                //identity.AddClaim(new Claim(AppClaimTypes.PhoneNo, loginResponse.PhoneNo));
                identity.AddClaim(new Claim(AppClaimTypes.Role, loginResponse.UserRole.ToString()));

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = loginRequest.RememberMe,
                    ExpiresUtc = DateTime.Now.AddMinutes(60),
                });

                if (loginResponse.UserRole == UserRole.Admin)
                {
                    return RedirectToAction("DashBoard", "Admin");
                }
                else if (loginResponse.UserRole == UserRole.Customer)
                {
                    return RedirectToAction("index", "Customer");
                }
                else if (loginResponse.UserRole == UserRole.Contractor)
                {
                    return RedirectToAction("index", "Contractor");
                }
                else if (loginResponse.UserRole == UserRole.Manager)
                {
                    return RedirectToAction("index", "Manager");
                }
                else if (loginResponse.UserRole == UserRole.Labour)
                {
                    return RedirectToAction("index", "Labour");
                }

            }


            }
            else
            {
                ViewBag.Message = "User not found";
            }
            return View();
        }

        [HttpGet("profile")]
        public IActionResult Profile()
        {
            Guid id = User.GetUserId();

            var user =  accountManager.GetUserById(id);

            return View(user);
        }
    }
}



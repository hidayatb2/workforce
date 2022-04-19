using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;
using System.Security.Claims;

namespace WebApp
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly AccountRepository repository;
        private readonly AccountManager accountManager;
        private readonly IEmailService emailService;
        private readonly IWebHostEnvironment environment;

        public AccountController(AccountRepository repository, IEmailService emailService, IWebHostEnvironment environment)
        {
            accountManager = new AccountManager(repository, emailService);
            this.emailService = emailService;
            this.environment = environment;
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

                if (loginResponse.UserStatus != UserStatus.Inactive && loginResponse?.UserStatus != null)
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
                        return RedirectToAction(nameof(Index), nameof(CustomerController));
                    }
                    else if (loginResponse.UserRole == UserRole.Contractor)
                    {
                        return RedirectToAction("Profile", "Account");
                    }
                    else if (loginResponse.UserRole == UserRole.Manager)
                    {
                        return RedirectToAction("Profile", "Account");
                    }
                    else if (loginResponse.UserRole == UserRole.Labour)
                    {
                        return RedirectToAction("Profile", "Account");
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
        [AllowAnonymous]
        public IActionResult Profile()
        {
            Guid id = User.GetUserId();
            var userRole = User.GetRole();
            var user = accountManager.GetUserById(id, userRole);
            return View(user);
        }



        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [Route("forgotpassword")]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("forgotpassword")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordRequest forgotemail, [FromServices] SharedLibrary.IEmailService emailService)
        {
            string link = Request.GetEncodedUrl().Replace(Request.Path.ToUriComponent(), "/Account/ResetPassword?guid=");
            string msg = accountManager.ForgetPassword(forgotemail, link, emailService);
            if (msg == "success")
                ViewBag.Message = "Check your Registered Email to Reset your Password";
            else
                ViewBag.Message = "Invalid Email";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("resetpassword")]
        public ActionResult ResetPassword()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("resetpassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest resetPassword)
        {
            var user = accountManager.ResetPassword(resetPassword);
            if (user == null)
            {
                ViewBag.Message = "Error";
                return View();
            }
            else
            {
                if (resetPassword.IsChecked)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(AppClaimTypes.UserId, user.Id.ToString()));
                    identity.AddClaim(new Claim(AppClaimTypes.UserName, user.UserName));
                    identity.AddClaim(new Claim(AppClaimTypes.Email, user.Email));
                    identity.AddClaim(new Claim(AppClaimTypes.Role, user.UserRole.ToString()));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        IssuedUtc = DateTime.UtcNow,
                        ExpiresUtc = DateTime.UtcNow.AddHours(10)
                    });
                    if (user.UserRole == UserRole.Admin)
                    {
                        return RedirectToAction("DashBoard", "Admin");
                    }
                    else if (user.UserRole == UserRole.Customer)
                    {
                        return RedirectToAction("index", "Customer");
                    }
                    else if (user.UserRole == UserRole.Contractor)
                    {
                        return RedirectToAction("index", "Contractor");
                    }
                    else if (user.UserRole == UserRole.Manager)
                    {
                        return RedirectToAction("index", "Manager");
                    }
                    else if (user.UserRole == UserRole.Labour)
                    {
                        return RedirectToAction("index", "Labour");
                    }
                }
                ViewBag.Message = "Success";
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet("changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Route("changepassword")]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordRequest changePassword)
        {
            changePassword.Id = User.GetUserId();
            ViewBag.Message = accountManager.ChangePassword(changePassword);
            return View();
        }


    }
}



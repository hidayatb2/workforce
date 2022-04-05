using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp
{
    [Route("account")]
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

        [HttpGet("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("signup")]
        public IActionResult SignUp(UserRequest userRequest)
        {
            int returnValue = accountManager.Add(userRequest);
            if (returnValue > 0)
                ViewBag.Success = true;
            else
                ModelState.AddModelError("","Try again after sometime");
            
            return View();
        }


    }
}

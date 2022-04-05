using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

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
    }
}

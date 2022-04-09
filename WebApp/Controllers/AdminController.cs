using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;

namespace WebApp
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IRepository repository;
        private readonly AdminManager adminManager;
        private readonly IEmailService emailService;

        public AdminController(IRepository repository,IEmailService emailService)
        {
            adminManager = new AdminManager(repository,emailService);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("dashboard")]
        public IActionResult DashBoard(string searchString)
        {
            var users = accountManager.SearchUserBy(searchString);
            return View(users);
        }
        

        [HttpGet("getuserby/{searchString?}")]
        public PartialViewResult getuserby(string searchString)
        {
            DashBoard(searchString);
            var users = accountManager.SearchUserBy(searchString);  
            
            return PartialView("_searchPartial", users);

        }

        [HttpGet("create")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateUser(SignupRequest signupRequest)
        {
            var result = adminManager.CreateUser(signupRequest);
            if(result > 0)
                ViewBag.Message = "1";
            else
                ViewBag.Message = "0";
            return View();
        }
    }
}

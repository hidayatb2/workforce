using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;

namespace WebApp
{
    [Authorize(Roles = "Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        //private readonly IRepository repository;
        //private readonly IEmailService emailService;
        private readonly AdminManager adminManager;
        private readonly AccountManager accountManager;

        public AdminController(IRepository repository,IEmailService emailService)
        {
            adminManager = new AdminManager(repository,emailService);
            accountManager = new AccountManager(repository,emailService);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("dashboard")]
        public IActionResult DashBoard()
        {
            //var users = accountManager.SearchUserBy(searchString);
            //return View(users);
            return View();
        }
        

        //[HttpGet("getuserby/{searchString?}")]
        //public PartialViewResult getuserby(string searchString)
        //{
        //    DashBoard(searchString);
        //    var users = accountManager.SearchUserBy(searchString);  
            
        //    return PartialView("_searchPartial", users);

        //}


        [HttpGet("Search")]
        public IActionResult SearchBox(string searchString)
        {
            var users = accountManager.SearchUserBy(searchString);
            return View(users);
        }


        [HttpGet("users")]
        public IActionResult AllUsers()
        {
            var allUsers = accountManager.GetAllUsers();
            return View(allUsers);    
        }


        [HttpGet("details/{Id}")]
        public IActionResult GetDetailsById(Guid Id)
        {
           var user= accountManager.GetAllUsers().FirstOrDefault(x => x.Id == Id);
            return View(user);
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
            if (result == -2)
                ViewBag.Message = -2;
            else
                if (result == -1)
                ViewBag.Message = -1;
            else
                if (result > 0)
                ViewBag.Message = 1;
            return View();
        }
        

        [HttpGet("getuserby/{searchString?}/{roleValue?}")]
        public PartialViewResult getuserby(string searchString,UserRole roleValue)
        {


            SearchBox(searchString);
            if (roleValue == 0)
            {
                var users = accountManager.SearchUserBy(searchString);

                return PartialView("_searchPartial", users);
            }
            else
            {
                var users = accountManager.SearchUserBy(searchString);
                var filteredOnRoleUsers=users.Where(x => x.UserRole == roleValue);

                return PartialView("_searchPartial", filteredOnRoleUsers);
            }
            

        }

        [HttpGet("getallusersbyrole/{roleVal?}")]
        public PartialViewResult GetAllUsersByRole(UserRole roleVal)
        {
            var users = accountManager.GetAllUsers().Where(x => x.UserRole == roleVal);
            return PartialView("_searchPartial", users);

        }


    }
}

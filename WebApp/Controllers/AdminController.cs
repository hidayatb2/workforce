using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp
{
    //[Authorize(Roles = "Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {

        private readonly AccountManager accountManager;
        public AdminController(IRepository repository)
        {
           accountManager = new AccountManager(repository);
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

        [HttpGet("getallusersbyrole/{roleVal?}")]
        public PartialViewResult GetAllUsersByRole(UserRole roleVal)
        {
            var users = accountManager.GetAllUsers().Where(x => x.UserRole == roleVal);
            return PartialView("_searchPartial", users);

        }


    }
}

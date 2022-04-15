using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace WebApp
{
    public class LabourController : Controller
    {
        private readonly AccountRepository repository;

        public LabourController(AccountRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
           
            return View();
        }

    }
}

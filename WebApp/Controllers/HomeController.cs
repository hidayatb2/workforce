using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp;

namespace WebApp
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
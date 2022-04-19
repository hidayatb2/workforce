using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

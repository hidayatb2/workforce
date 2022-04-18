using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class ContractorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

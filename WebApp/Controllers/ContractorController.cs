using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{


    [Route("Contractor")]
    public class ContractorController : Controller
    {
        readonly ContractorManager contractorManager;

        public ContractorController(ContractorManager contractorManager)
        {
            this.contractorManager = contractorManager;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Managers")]
        public IActionResult AllManagers()
        {
            contractorManager.GetManagers().ToList();
            return View();
        }
    }

    
}

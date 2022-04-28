using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp
{


    [Route("Contractor")]
    public class ContractorController : Controller
    {
        readonly ContractorManager contractorManager;

        public ContractorController(ContractorRepository contractorRepository)
        {
            contractorManager = new ContractorManager(contractorRepository);
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("managers")]
        public IActionResult Managers()
        {
            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                generalResponses = contractorManager.GetManagers(),


            };
            return View(generalRequestModel);
        }


        [HttpPost]
        public IActionResult SendRequest(RequestDb requestDb)
        {

            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                returnValue = contractorManager.SendRequest(requestDb),

            };
            return RedirectToAction("Managers", generalRequestModel);
        }



        [HttpGet("requests")]
        public IActionResult Requests()
        {
            Guid id = User.GetUserId();
            return View(contractorManager.GetRequests(id));

        }

    }


}

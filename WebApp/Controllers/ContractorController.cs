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

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Managers")]
        public IActionResult AllManagers()
        {
            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                generalResponses = contractorManager.GetManagers(),
                
                
            };

          
            return View(generalRequestModel);
        }



        [HttpPost("Request")]
        public IActionResult Requests(RequestDb requestDb)
        {
            
            var returnValue=  contractorManager.PostRequest(requestDb);


            return RedirectToAction(nameof(AllManagers),new GeneralRequestModel
            {
                returnValue=returnValue,
            });
        }
    }

    
}

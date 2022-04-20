using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp
{
    [Route("Manager")]
    public class ManagerController : Controller
    {
        readonly ManagerRoleManager roleManager;

        public ManagerController(ManagerRepository managerRepository)
        {
           roleManager = new ManagerRoleManager(managerRepository);
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Contractors")]
        public IActionResult GetContractors()
        {
            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                generalResponses = roleManager.GetContractors(),

            };

            return View(generalRequestModel);
        }

        [HttpPost("RequestsM")]
        public IActionResult RequestsM(RequestDb requestDb)
        {

            var returnValue = roleManager.PostRequest(requestDb);


            return RedirectToAction(nameof(GetContractors), new GeneralRequestModel
            {
                returnValue = returnValue,
            });
        }


        [HttpGet("GetRequests")]
        public IActionResult RequestMessages()
        {
            Guid id = User.GetUserId();
            return View(roleManager.GetRequestMessages(id));

        }

    }
}

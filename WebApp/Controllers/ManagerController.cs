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
        public IActionResult Contractors()
        {
            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                generalResponses = roleManager.GetContractors()
            };

            return View(generalRequestModel);
        }


        [HttpPost]
        public IActionResult SendRequest(RequestDb requestDb)
        {

            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                returnValue = roleManager.SendRequest(requestDb),

            };
            return RedirectToAction("Contractors", generalRequestModel);
        }

        [HttpGet]
        public IActionResult Requests()
        {
            Guid id = User.GetUserId();
            return View(roleManager.GetRequests(id));
        }

        [HttpGet("ulabours")]
        public IActionResult UnassignedLabours()
        {
            var res = roleManager.UnassignedLabours();
            return View(res);
        }

    }


}


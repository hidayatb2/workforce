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
            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                userResponses = roleManager.UnassignedLabours().ToList()
            };
            
            return View(generalRequestModel);
        }

        [HttpPost("sendrequest")]
        public IActionResult SendLabourRequest(RequestDb requestDb)
        {
                GeneralRequestModel generalRequestModel = new GeneralRequestModel()
                {
                    returnValue = roleManager.SendLabourRequest(requestDb),

                };
                return RedirectToAction("",generalRequestModel);
        }

        [HttpGet("getrequest")]
        public IActionResult GetLabourRequestt(Guid id)
        {
            var lbr = roleManager.GetLabourRequests(id);
            return View();
        }


    }


}


using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp
{

    [Route("labour")]
    public class LabourController : Controller
    {
        
        private readonly LabourManager labourManager;

        public LabourController(LabourRepository labourRepository)
        {
            labourManager = new LabourManager(labourRepository);
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




        [HttpGet("managers")]
        public IActionResult Managers()
        {
            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                generalResponses = labourManager.GetManagers(),


            };
            return View(generalRequestModel);
        }




        [HttpPost]
        public IActionResult SendRequest(RequestDb requestDb)
        {

            GeneralRequestModel generalRequestModel = new GeneralRequestModel()
            {
                returnValue = labourManager.SendRequest(requestDb),

            };
            return RedirectToAction("Managers", generalRequestModel);
        }



        [HttpGet("requests")]
        public IActionResult Requests()
        {
            Guid id = User.GetUserId();
            return View(labourManager.GetRequests(id));
        }


        public IActionResult DeleteRequest(Guid id)
        {

            return RedirectToAction("Requests", labourManager.DeletebyId(id));

        }


    }
}

using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;

namespace WebApp
{
    [Route("bid")]
    public class BidController : Controller
    {
        private readonly BidManager bidManager;
        private readonly AccountManager accountManager;

        public BidController(BidRepository repository, IEmailService emailService)
        {
            bidManager = new BidManager(repository, emailService);
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost("bids")]
        public PartialViewResult CreateBid(BidRequest bidRequest)
        {
            var res = bidManager.CreateBid(bidRequest);
          //  var questions = bidManager.GetQuestionsBySubId(questionrequest.SubjectId);
            return PartialView("_BidListPartial", res);
        }
    }
}

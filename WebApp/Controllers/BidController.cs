using AutoMapper;
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
        private readonly IMapper mapper;

        public BidController(BidRepository repository, IMapper mapper, IEmailService emailService)
        {
            bidManager = new BidManager(repository, mapper, emailService);
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var bids = bidManager.GetBidsByCustomerId(User.GetUserId());
            return View(bids);
        }



        [HttpPost("createbid")]
        public IActionResult CreateBid(BidRequest bidRequest)
        {
            var userId = User.GetUserId();
            var returnVal = bidManager.GetBidsByCustomerId(userId);
            if (ModelState.IsValid)
            {
               // var userId = User.GetUserId();
                var res = bidManager.CreateBid(bidRequest, userId);
                var bids = bidManager.GetBidsByCustomerId(userId);
                return PartialView("_BidListPartial", bids);

            }
            else
            return PartialView("_BidListPartial", returnVal);


        }

        [HttpGet("deletebid")]
        public IActionResult Deletebid(Guid id)
        {
            var returnval = bidManager.DeleteBid(id);
            return RedirectToAction(nameof(Index), returnval);
        }
    }
}

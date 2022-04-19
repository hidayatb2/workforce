using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;

namespace WebApp
{
    public class TestimonialController : Controller
    {
        private readonly TestimonialManager testimonialManager;

        public TestimonialController(IRepository repository)
        {
            testimonialManager = new TestimonialManager(repository);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public PartialViewResult Testimonial()
        //{
        //    return PartialView("_TestimonialPartial");
        //}


        [HttpPost]
        public IActionResult Testimonial(TestimonialRequest feedbackRequest)
        {

            var returnValue = testimonialManager.Testimonial(feedbackRequest);
        

            if (User.GetRole() == nameof(UserRole.Customer))
            {
                return RedirectToAction("Index", "Customer");
            }


            else if (User.GetRole() == UserRole.Labour.ToString())
            {
                return RedirectToAction("Index", "Labour");
            }


            else if (User.GetRole() == UserRole.Manager.ToString())
            {
                return RedirectToAction("Index", "Manager");
            }


            else if (User.GetRole() == UserRole.Contractor.ToString())
            {
                return RedirectToAction("Index", "Contractor");
            }

            else
            {
                return View();
            }

        }



        public IActionResult Delete(Guid id)
        {    
            return RedirectToAction("Testimonial", "Admin", testimonialManager.Delete(id)) ;
        }
    }
}

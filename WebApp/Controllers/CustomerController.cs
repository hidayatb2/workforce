using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp
{
    public class CustomerController : Controller
    {
        private readonly CustomerManager customerManager;


        public CustomerController(IRepository repository)
        {
            customerManager = new CustomerManager(repository);
        }

        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Testimonial(TestimonialRequest testimonialRequest)
        {
            var returnValue = customerManager.Testimonial(testimonialRequest);
            ViewBag.returnValue = returnValue;
            return View();
        }

        //public IActionResult Delete(Guid id)
        //{
        //    var x = customerManager.Delete(id);
        //    return RedirectToAction("Feedbacks", "Admin", x);
        //}


    }
}

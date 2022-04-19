
using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

using Models;
using System.Net;

namespace WebApp.Controllers
{
    public class SliderController : Controller
    {

        private readonly SliderManager sliderManager;
        private readonly IWebHostEnvironment Environment;
        public SliderController(IRepository repository, IWebHostEnvironment environment)
        {
            sliderManager = new SliderManager(repository);
            Environment = environment;
        }

        
        public IActionResult Index()
        {
            var sliders = sliderManager.GetSliders();
            return View(sliders);
        }

        
        
        [HttpPost]
        public IActionResult AddSlider(SliderRequest sliderRequest)
        {
            if (ModelState.IsValid)
            {
                var message = sliderManager.AddSlider(sliderRequest, Environment.WebRootPath);
                if (message != "Success")
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(message);
                }

                return PartialView("_SliderPartial", sliderManager.GetSliders());
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return RedirectToAction(nameof(Index));
        }


        public IActionResult deleteslider(Guid id)
        {
            if (true)
            {

            }
            var response = sliderManager.DeleteSlider(id, Environment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }





        //public iactionresult update()
        //{
        //    return view();
        //}

    }
}   

using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
﻿using BusinessAccess;
using System.Diagnostics;
using WebApp;
using WebApp.Models;

namespace WebApp
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly HomeManager homeManager;
        public HomeController(ILogger<HomeController> logger,IRepository repository)
        {
            _logger = logger;
            this.homeManager=new HomeManager(repository);

        }

        public IActionResult Index()
        {
            HomeModel homeModel = new HomeModel()
            {
                skillResponses = homeManager.GetUserSkills().DistinctBy(x => x.JobProfile)
            };
            return View(homeModel);
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ContactUs(ContactUsRequest contactUsRequest)
        {
           var returnValue=homeManager.AddContactUsMessage(contactUsRequest);
            ViewBag.returnValue = returnValue;
            return View();
        }



        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("skills")]
        public IActionResult SkillName(string jobprofile)
        {

            return View(homeManager.FindBy(jobprofile));
        }

    }
}
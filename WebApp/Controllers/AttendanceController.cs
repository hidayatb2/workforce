using BusinessAccess;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    [Route("attendance")]
    public class AttendanceController : Controller
    {
        private readonly AttendanceRepository repository;
        private readonly AttendanceManager attendanceManager;

        public AttendanceController(AttendanceRepository repository)
        {
            this.repository = repository;
            attendanceManager = new AttendanceManager(repository);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

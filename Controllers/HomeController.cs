using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ticketing_System_Interview_Exam.Data;
using Ticketing_System_Interview_Exam.Models;

namespace Ticketing_System_Interview_Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Ticketing_System_Interview_ExamContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public Task<IActionResult> QA_Index()
        {
            BugsController bugsController = new BugsController(_context);
            return bugsController.Index();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

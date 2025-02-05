using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Models;
using System.Diagnostics;

namespace ProjectManagementSystem.Controllers
{

    // Denna kontroller genererades med hjälp av AI-assistans som grund,
    // men har anpassats och kompletterats manuellt efteråt.

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
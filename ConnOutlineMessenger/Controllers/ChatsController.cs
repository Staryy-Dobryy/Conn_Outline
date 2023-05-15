using ConnOutlineMessenger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConnOutlineMessenger.Controllers
{
    public class ChatsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ChatsController (ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Chat()
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

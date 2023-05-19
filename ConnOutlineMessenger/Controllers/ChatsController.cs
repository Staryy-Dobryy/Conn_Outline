using ConnOutlineMessenger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConnOutlineMessenger.Controllers
{
    //[Authorize]
    public class ChatsController : Controller
    {
        private readonly ILogger<ChatsController> _logger;

        public ChatsController (ILogger<ChatsController> logger)
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

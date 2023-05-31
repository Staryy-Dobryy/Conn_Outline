using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConnOutlineMessenger.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<ChatsController> _logger;
        private readonly IChatService _chatService;

        public MenuController(ILogger<ChatsController> logger, IChatService chatService)
        {
            _logger = logger;
            _chatService = chatService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreateChat()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChat1()
        {
            await _chatService.CreateChat();
            return RedirectToAction("Index", "Chats");
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult AddFriend()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddFriend(AddFriendViewModel model)
        {

            return RedirectToAction("Index", "Chats");
        }
    }
}

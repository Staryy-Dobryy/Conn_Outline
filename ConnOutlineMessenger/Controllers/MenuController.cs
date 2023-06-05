using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DTO;
using ConnOutlineMessenger.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConnOutlineMessenger.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<ChatsController> _logger;
        private readonly IChatService _chatService;
        private readonly IFriendsService _friendsService;
        private readonly IJwtTokenService _jwtTokenService;

        public MenuController(ILogger<ChatsController> logger, IChatService chatService, IFriendsService friendsService, IJwtTokenService jwtTokenService)
        {
            _logger = logger;
            _chatService = chatService;
            _friendsService = friendsService;
            _jwtTokenService = jwtTokenService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateChat()
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);
            CreateChatModel model = new()
            {
                Friends = await _friendsService.GetFriendsByUserIdAsync(userId)
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChat(CreateChatModel model)
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);

            if (model.Members == null || model.Members.Count == 0)
                model.Members = new() { userId };

            else
                model.Members.Add(userId);

            await _chatService.CreateChat(model);
            return RedirectToAction("Index", "Chats");
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddFriend()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Friends()
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);
            GetFriendsModel model = new(await _friendsService.GetFriendsByUserIdAsync(userId));
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddFriend(AddFriendViewModel model)
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);
            await _friendsService.AddFriend(userId, model.UserId);
            return RedirectToAction("Index", "Chats");
        }
    }
}

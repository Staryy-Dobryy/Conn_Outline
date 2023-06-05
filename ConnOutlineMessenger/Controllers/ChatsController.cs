using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Services.Realization;
using ConnOutlineMessenger.BuisnessLogic.SignalR;
using ConnOutlineMessenger.DTO;
using ConnOutlineMessenger.Entities;
using ConnOutlineMessenger.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace ConnOutlineMessenger.Controllers
{
    public class ChatsController : Controller
    {
        private readonly ILogger<ChatsController> _logger;
        private readonly IChatService _chatService;
        private readonly IJwtTokenService _jwtTokenService;

        public ChatsController (ILogger<ChatsController> logger, IChatService chatService, IJwtTokenService jwtTokenService, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _chatService = chatService;
            _jwtTokenService = jwtTokenService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Chat(string stringChatId)
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);
            var chatId = uint.Parse(stringChatId);
            var currentChat = await _chatService.GetChat(userId, chatId);

            return View(currentChat);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Leave(string stringChatId)
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);
            var chatId = uint.Parse(stringChatId);
            await _chatService.RemoveUserFromChat(userId, chatId);
            return RedirectToAction("Index", "Chats");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtTokenService.GetUserIdByToken(tokenString);
            var chats = await _chatService.GetAllChatsByUserId(userId);
            var viewModel = new ChatsViewModel()
            {
                Chats = chats
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

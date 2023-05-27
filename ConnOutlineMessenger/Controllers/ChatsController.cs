using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DTO;
using ConnOutlineMessenger.Entities;
using ConnOutlineMessenger.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace ConnOutlineMessenger.Controllers
{
    public class ChatsController : Controller
    {
        private readonly ILogger<ChatsController> _logger;
        private readonly IChatService _chatService;

        public ChatsController (ILogger<ChatsController> logger, IChatService chatService)
        {
            _logger = logger;
            _chatService = chatService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Chat()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Leave(string stringChatId)
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = new JwtSecurityToken(tokenString);
            var userId = uint.Parse(token.Payload["Id"].ToString());
            var chatId = uint.Parse(stringChatId);
            await _chatService.RemoveUserFromChat(userId, chatId);
            return RedirectToAction("Index", "Chats");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = new JwtSecurityToken(tokenString);
            var userId = uint.Parse(token.Payload["Id"].ToString());
            var chats = await _chatService.GetChatsByUserId(userId);
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

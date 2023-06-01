using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DataAccess.Repositories;
using ConnOutlineMessenger.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMessageRepository _messageRepository;
        public readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        public ChatHub (IMessageRepository messageRepository, IJwtTokenService jwtTokenService, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }   
        public async Task Send(string message, string chatId, string token)
        {
            var messageObj = new Message
            {
                MessageText = message,
                SendTime = DateTime.Now,
                CurrentChatId = uint.Parse(chatId),
                SenderId = _jwtTokenService.GetUserIdByToken(token),
            };
            await _messageRepository.CreateAsync(messageObj);

            string output = "<div id=\"message\">" +
                   "<div id=\"message-sender\">";
            if (sender.UserIcon != null)
            {
                output += "<img src=\"@message.Sender.UserIcon.Link\">";
            }
            else
            {
                output += "<img src=\"/images/user-icon.png\">";
            }
            output += $"<h5>{sender.UserName}</h5>" +
                $"<sub>{DateTime.Now}</sub>" +
                "<button id=\"@message.Id\" class=\"delete-button\">delete</button></div>" +
                "<div id=\"message-content\">" +
                $"<p>{message}</p>";

            /*if (message.MessageImg != null)
            {
                output += <img src="@message.MessageImg">
            }*/
            output += "</div></div>";
            await Clients.All.SendAsync("Receive", output);
        }
    }
}

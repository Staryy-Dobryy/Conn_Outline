using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DataAccess.Repositories;
using ConnOutlineMessenger.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task Send(GetMessageModel model)
        {
            var userId = _jwtTokenService.GetUserIdByToken(model.Token);
            var messageObj = new Message
            {
                MessageText = model.MessageText,
                SendTime = DateTime.Now,
                CurrentChatId = uint.Parse(model.ChatId),
                SenderId = userId,
                Sender = await _userRepository.GetByIdWithIconAsync(userId)
            };
            var receive = await _messageRepository.CreateAndReturnAsync(messageObj);
            receive.SendTime = receive.SendTime.ToLocalTime();

            await Clients.All.SendAsync("Receive", receive);
        }
    }
}

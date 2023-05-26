using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Realization
{
    public class ChatService : IChatService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;
        public ChatService(IUserRepository userRepository, IChatRepository chatRepository)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }
        public async Task<ICollection<Chat>?> GetChatsByUserId(uint id)
        {
            var user = await _chatRepository.GetChatsByUserId(id);
            return user;
        }
        public async Task CreateChat()
        {
            var user1 = await _userRepository.GetByIdAsync(3);
            var user2 = await _userRepository.GetByIdAsync(4);
            var list = new List<User>() { user1, user2 };
            await _chatRepository.CreateChatWithUsersAsync(list);
        }
    }
}

using AutoMapper;
using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.Entities;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Realization
{
    public class ChatService : IChatService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        public ChatService(IUserRepository userRepository, IChatRepository chatRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<Chat>?> GetAllChatsByUserId(uint id)
        {
            var chats = await _chatRepository.GetChatsByUserIdAsync(id);
            return chats;
        }

        public async Task<CurrentChatModel?> GetChat(uint userId, uint chatId)
        {
            var chats = await _chatRepository.GetChatsByUserIdAsync(userId);

            if (chats.Any(x => x.Id == chatId))
            {
                var chat = await _chatRepository.GetChatWithDetails(chatId);
                return _mapper.Map<CurrentChatModel>(chat);
            }

            return null;
        }

        public async Task CreateChat(CreateChatModel model)
        {
            var list = new List<User>();
            foreach (var id in model.Members)
                list.Add(await _userRepository.GetByIdAsync(id));

            await _chatRepository.CreateChatWithUsersAsync(model.ChatName, list);
        }

        public async Task RemoveUserFromChat(uint userId, uint chatId)
        {
            var user = await _userRepository.GetByIdWithDetailsAsync(userId);
            if (user == null)
                return;

            if (user.Chats.Any(x => x.Id == chatId))
            {
                var chat = user.Chats.First(x => x.Id == chatId);
                if (chat.Members.Count == 1)
                    await _chatRepository.DeleteAsync(chatId);
                
                else
                {
                    user.Chats.Remove(user.Chats.First(x => x.Id == chatId));
                    await _userRepository.UpdateAsync(user);
                }
            }
        }
    }
}

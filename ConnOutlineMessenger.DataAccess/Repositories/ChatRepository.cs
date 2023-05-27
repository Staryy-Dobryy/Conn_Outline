using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DBstur;
using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ConnOutlineMessenger.DataAccess.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        private readonly IUserRepository _userRepository;
        public ChatRepository(DataBaseContext db, IUserRepository userRepository) : base(db)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserToChatAsync(uint id, User user)
        {
            var chat = await GetByIdAsync(id);
            if (chat != null)
            {
                chat.Members.Add(user);
                await UpdateAsync(chat);
            }
        }

        public async Task AddUsersToChatAsync(uint id, IEnumerable<User> users)
        {
            var chat = await GetByIdAsync(id);
            if (chat != null)
            {
                chat.Members.Concat(users);
                await UpdateAsync(chat);
            }
        }

        public async Task CreateChatWithUsersAsync(ICollection<User> users)
        {
            var chat = new Chat()
            {
                CreationTime = DateTime.Now,
                Members = users
            };
            await CreateAsync(chat);
        }

        public async Task AddMessageToChatAsync(uint id, Message message)
        {
            var chat = await GetByIdAsync(id);
            if (chat != null && chat.Messages != null)
            {
                chat.Messages.Add(message);
                await UpdateAsync(chat);
            }
        }

        public async Task DeleteMessageFromChatAsync(uint chatId, uint messageId)
        {

        }
        public async Task<ICollection<Chat>?> GetChatsByUserId(uint id)
        {
            //Eager loading
            var result = await _db.Set<User>()
                .Include(x => x.Chats)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result.Chats;
        }
    }
}

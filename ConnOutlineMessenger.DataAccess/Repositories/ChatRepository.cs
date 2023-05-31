using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DBstur;
using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ConnOutlineMessenger.DataAccess.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(DataBaseContext db) : base(db) { }

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
                ChatName = "SomeName",
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

        public async Task<ICollection<Chat>?> GetChatsByUserIdAsync(uint id)
        {
            //Eager loading
            var result = await _db.Set<User>()
                .Include(x => x.Chats)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result.Chats;
        }

        public async Task<Chat?> GetChatWithMessages(uint chatId)
        {
            return await _db.Set<Chat>()
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == chatId);
        }

        public async Task<Chat?> GetChatWithDetails(uint chatId)
        {
            return await _db.Set<Chat>()
                .Include(x => x.Members)
                .Include(x => x.Messages)
                .ThenInclude(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == chatId);
        }
    }
}

using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Interfaces
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task AddUserToChatAsync(uint id, User user);
        Task AddUsersToChatAsync(uint id, IEnumerable<User> users);
        Task CreateChatWithUsersAsync(string chatName, ICollection<User> users);
        Task AddMessageToChatAsync(uint id, Message message);
        Task<ICollection<Chat>?> GetChatsByUserIdAsync(uint id);
        Task<Chat?> GetChatWithDetails(uint chatId);
        Task<Chat?> GetChatWithMessages(uint chatId);
    }
}

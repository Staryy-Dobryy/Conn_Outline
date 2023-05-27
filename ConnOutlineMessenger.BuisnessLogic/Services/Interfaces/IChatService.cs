using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Interfaces
{
    public interface IChatService
    {
        Task<ICollection<Chat>> GetChatsByUserId(uint id);
        Task RemoveUserFromChat(uint userId, uint chatId);
        Task CreateChat();
    }
}

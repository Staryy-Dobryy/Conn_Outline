using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Interfaces
{
    public interface IFriendsService
    {
        Task AddFriend(uint userId, uint friendId);
        Task DeleteFriend(uint userId, uint friendId);
        Task<ICollection<User>> GetFriendsByUserIdAsync(uint userId);
    }
}

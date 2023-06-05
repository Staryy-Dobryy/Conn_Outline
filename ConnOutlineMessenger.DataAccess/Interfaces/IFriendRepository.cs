using ConnOutlineMessenger.DataAccess.Entities;
using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Interfaces
{
    public interface IFriendRepository : IRepository<Friend>
    {
        Task AddFriendByIdAsync(uint userId, uint friendId);
        Task<ICollection<User>> GetFriendsCollectionById(uint userId);
    }
}

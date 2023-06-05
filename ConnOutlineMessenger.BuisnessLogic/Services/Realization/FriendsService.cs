using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Realization
{
    public class FriendsService : IFriendsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendRepository _friendRepository;
        public FriendsService (IUserRepository userRepository, IFriendRepository friendRepository)
        {
            _userRepository = userRepository;
            _friendRepository = friendRepository;
        }

        public async Task AddFriend(uint userId, uint friendId)
        {
            await _friendRepository.AddFriendByIdAsync(userId, friendId);
        }

        public async Task DeleteFriend(uint userId, uint friendId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<User>> GetFriendsByUserIdAsync(uint userId)
        {
            return await _friendRepository.GetFriendsCollectionById(userId);
        }
    }
}

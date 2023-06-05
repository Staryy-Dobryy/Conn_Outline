using ConnOutlineMessenger.DataAccess.Entities;
using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DBstur;
using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(DataBaseContext db) : base(db) { }

        public async Task AddFriendByIdAsync(uint userId, uint friendId)
        {
            if (userId == friendId)
                return;

            if (_db.Set<Friend>().Any(x => x.UserId == userId && x.FriendUserId == friendId))
                return;

            var newFriend = new Friend
            {
                UserId = userId,
                FriendUserId = friendId
            };

            await _db.Set<Friend>().AddAsync(newFriend);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetFriendsCollectionById(uint userId)
        {
            var friendsIds = _db.Set<Friend>().Where(x => x.UserId == userId);
            List<User> result = _db.Set<User>().Where(x => friendsIds.Any(y => y.FriendUserId == x.Id)).ToList();
            return result;
        }
    }
}

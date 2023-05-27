using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DBstur;
using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext db) : base(db) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _db.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetByIdWithDetailsAsync(uint id)
        {
            return await _db.Set<User>()
                .Include(x => x.Chats)
                .ThenInclude(x => x.Members)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _db.Set<User>().FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}

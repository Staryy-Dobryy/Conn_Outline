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
    public class UserRepository : IUserRepository
    {
        private bool _disposedValue;
        private readonly DataBaseContext _db;
        public UserRepository(DataBaseContext db) => _db = db;

        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(uint id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null) _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetById(uint id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User?> GetByUserName(string userName)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task Update(User entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

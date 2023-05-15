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
    public class ChatRepository : IRepository<Chat>
    {
        private bool _disposedValue;
        private readonly DataBaseContext _db;
        public ChatRepository(DataBaseContext db) => _db = db;

        public async Task Create(Chat entity)
        {
            await _db.Chats.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(uint id)
        {
            var chat = await _db.Chats.FindAsync(id);
            if (chat != null) _db.Chats.Remove(chat);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Chat> GetAll()
        {
            return _db.Chats;
        }

        public async Task<Chat?> GetById(uint id)
        {
            return await _db.Chats.FindAsync(id);
        }

        public async Task Update(Chat entity)
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
